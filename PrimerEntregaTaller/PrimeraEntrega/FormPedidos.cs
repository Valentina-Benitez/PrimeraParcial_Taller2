using PrimeraEntrega;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Taller_AppRestaurante
{
    public partial class FormPedidos : Form
    {
        // ==============================================================
        // CONSTRUCTOR: inicializa el formulario, configura el DataGridView
        // y carga los pedidos desde la base de datos.
        // ==============================================================
        public FormPedidos()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false; // evita duplicar columnas

            CargarPedidos(); // carga los pedidos existentes al iniciar

            txtBusqueda.TextChanged += txtBusqueda_TextChanged; // filtra en tiempo real
            dataGridView1.CellContentClick += dataGridView1_CellContentClick; // maneja clicks
        }

        // ==============================================================
        // MÉTODO: ObtenerConexion()
        // Devuelve una conexión abierta con la base de datos SQL Server.
        // ==============================================================
        private SqlConnection ObtenerConexion()
        {
            string cadena = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";
            return new SqlConnection(cadena);
        }

        // ==============================================================
        // MÉTODO: CargarPedidos()
        // Obtiene los pedidos desde la BD y los muestra en el DataGridView.
        // ==============================================================
        private void CargarPedidos()
        {
            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();

                    // Une Pedido con Cliente para mostrar el DNI
                    string consulta = @"
                    SELECT
                        p.id_pedido,
                        ISNULL(c.dni, 'Desconocido') AS [Cliente],
                        p.fecha AS [Fecha],
                        p.estado AS [Estado]
                    FROM Pedido p
                    LEFT JOIN Cliente c ON p.id_cliente = c.id_cliente;";

                    SqlDataAdapter da = new SqlDataAdapter(consulta, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt; // muestra los datos
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pedidos: " + ex.Message);
            }
        }

        // Lista auxiliar para manejar los productos agregados temporalmente
        private List<ProductoSeleccionado> productosEnPedido = new List<ProductoSeleccionado>();

        // ==============================================================
        // EVENTO: botón "Agregar productos" (bPedido_Click)
        // Abre el formulario de productos, permite seleccionar y devuelve la lista.
        // ==============================================================
        private void bPedido_Click(object sender, EventArgs e)
        {
            using (FormAgregarProductos form = new FormAgregarProductos())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    productosSeleccionados.AddRange(form.ProductosSeleccionados);
                    MostrarProductosEnPedido();
                    ActualizarTotal();
                }
            }
        }

        // Lista pública con los productos seleccionados en el pedido actual
        public List<ProductoSeleccionado> productosSeleccionados { get; private set; } = new List<ProductoSeleccionado>();

        // ==============================================================
        // MÉTODO: ActualizarTotal()
        // Calcula y muestra el total del pedido actual.
        // ==============================================================
        private void ActualizarTotal()
        {
            decimal total = productosSeleccionados.Sum(p => p.Cantidad * p.Precio);
            txtTotal.Text = total.ToString("0.00");
        }

        // ==============================================================
        // EVENTO LOAD: agrega el botón “Entregar” y configura estilos.
        // ==============================================================
        private void FormPedidos_Load(object sender, EventArgs e)
        {
            // Evitar duplicados
            dataGridView1.AutoGenerateColumns = false;

            // cargamos los datos
            CargarPedidos();

            // Boton personalizado "Entregar"

            if (!dataGridView1.Columns.Contains("btnEntregar"))
            {
                DataGridViewButtonColumn btnEntregar = new DataGridViewButtonColumn();
                btnEntregar.Name = "btnEntregar";
                btnEntregar.HeaderText = "Entregar";
                btnEntregar.Text = "✔";
                btnEntregar.UseColumnTextForButtonValue = true;
                btnEntregar.DefaultCellStyle.BackColor = Color.CadetBlue;
                btnEntregar.DefaultCellStyle.ForeColor = Color.White;
                btnEntregar.FlatStyle = FlatStyle.Popup;
                btnEntregar.Width = 80;
                dataGridView1.Columns.Add(btnEntregar);
            }

            // Ajustes
            txtTotal.ReadOnly = true;
            dataGridView1.CellPainting += dataGridView1_CellPainting;
        }


        // ==============================================================
        // EVENTO: txtBusqueda_TextChanged()
        // Filtra los pedidos por ID o DNI a medida que se escribe.
        // ==============================================================
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBusqueda.Text.Trim();
            string consulta = "SELECT id_pedido, ISNULL(dni,'X') AS [Cliente], fecha AS [Fecha], estado AS [Estado] FROM Pedido";

            using (SqlConnection conexion = ObtenerConexion())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(consulta, conexion))
                {
                    DataTable dt = new DataTable();

                    if (!string.IsNullOrEmpty(filtro))
                    {
                        consulta += " WHERE CAST(id_pedido AS VARCHAR) LIKE @filtro OR dni LIKE @filtro";
                        da.SelectCommand.CommandText = consulta;
                        da.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    }

                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }

        // ==============================================================
        // Validación: permite solo números en campos tipo DNI o ID
        // ==============================================================
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        // ==============================================================
        // MÉTODO: MostrarProductosEnPedido()
        // Refresca la tabla con los productos agregados y calcula total.
        // ==============================================================
        private void MostrarProductosEnPedido()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            foreach (var p in productosEnPedido)
                dataGridView1.Rows.Add(p.IdProducto, p.Nombre, p.Precio);

            decimal total = productosEnPedido.Sum(x => x.Precio);
            txtTotal.Text = total.ToString("C");
        }

        // ==============================================================
        // EVENTO: dataGridView1_CellContentClick_1()
        // Maneja botones Detalle y Entregar dentro del DataGridView.
        // ==============================================================
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string estadoActual = dataGridView1.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn4"].Value.ToString().ToLower();
            int pedidoId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["nroPedido"].Value);

            // Botón Detalle → abre el FormDetallePedido
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnDetalle")
            {
                object cellValue = dataGridView1.Rows[e.RowIndex].Cells["nroPedido"].Value;
                int PedidoId = cellValue != null && cellValue != DBNull.Value ? Convert.ToInt32(cellValue) : 0;
                
                if (PedidoId > 0)
                {
                    FormDetallePedido formDetalle = new FormDetallePedido();
                    formDetalle.PedidoId = PedidoId;
                    formDetalle.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el ID del pedido.");
                }
            }

            // Botón Entregar → cambia estado y registra la venta
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnEntregar")
            {
                if (estadoActual.Contains("entregado"))
                {
                    MessageBox.Show("Este pedido ya está entregado ✅");
                    return;
                }

                using (var pagoForm = new FormSeleccionarPago())
                {
                    if (pagoForm.ShowDialog() == DialogResult.OK)
                        RegistrarVenta(pedidoId, pagoForm.TipoDePagoSeleccionado);
                }
            }
        }

        // ==============================================================
        // MÉTODO: ObtenerIdClientePorDni()
        // Devuelve el ID del cliente, o lo crea si no existe.
        // ==============================================================
        private int ObtenerIdClientePorDni(string dni, SqlConnection con, SqlTransaction tran)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new Exception("Debe ingresar un DNI válido antes de crear el pedido.");

            string sqlSelect = "SELECT id_cliente FROM Cliente WHERE dni = @dni";
            using (SqlCommand cmdSelect = new SqlCommand(sqlSelect, con, tran))
            {
                cmdSelect.Parameters.AddWithValue("@dni", dni);
                object result = cmdSelect.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    return Convert.ToInt32(result);
            }

            // Si no existe → crear un cliente “DESCONOCIDO”
            string sqlInsert = @"
                INSERT INTO Cliente (dni, nombre, apellido)
                VALUES (@dni, @nombre, @apellido);
                SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmdInsert = new SqlCommand(sqlInsert, con, tran))
            {
                cmdInsert.Parameters.AddWithValue("@dni", dni);
                cmdInsert.Parameters.AddWithValue("@nombre", "DESCONOCIDO");
                cmdInsert.Parameters.AddWithValue("@apellido", "DESCONOCIDO");
                object newId = cmdInsert.ExecuteScalar();
                return Convert.ToInt32(newId);
            }
        }

        // ==============================================================
        // BOTÓN: Guardar pedido (button2_Click)
        // Inserta Pedido y Detalle_Pedido con transacción.
        // ==============================================================
        private void button2_Click(object sender, EventArgs e)
        {
            if (productosSeleccionados.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto antes de guardar el pedido.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Debe ingresar el DNI del cliente antes de crear el pedido.");
                return;
            }

            using (SqlConnection con = ObtenerConexion())
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    string dni = textBox4.Text.Trim();
                    int idCliente = ObtenerIdClientePorDni(dni, con, tran);

                    // Insertar el pedido
                    string insertPedido = @"
                        INSERT INTO Pedido (id_cliente, id_usuario, fecha, estado)
                        VALUES (@id_cliente, @id_usuario, @fecha, 'en preparación');
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdPedido = new SqlCommand(insertPedido, con, tran);
                    cmdPedido.Parameters.AddWithValue("@id_cliente", idCliente);
                    cmdPedido.Parameters.AddWithValue("@id_usuario", SesionActual.IdUsuario);
                    cmdPedido.Parameters.AddWithValue("@fecha", DateTime.Now);

                    int idPedido = Convert.ToInt32(cmdPedido.ExecuteScalar());

                    // Insertar detalles del pedido
                    foreach (var prod in productosSeleccionados)
                    {
                        string insertDetalle = @"
                            INSERT INTO Detalle_Pedido (id_pedido, id_producto, cantidad, subtotal)
                            VALUES (@id_pedido, @id_producto, @cantidad, @subtotal);";

                        SqlCommand cmdDetalle = new SqlCommand(insertDetalle, con, tran);
                        cmdDetalle.Parameters.AddWithValue("@id_pedido", idPedido);
                        cmdDetalle.Parameters.AddWithValue("@id_producto", prod.IdProducto);
                        cmdDetalle.Parameters.AddWithValue("@cantidad", prod.Cantidad);
                        cmdDetalle.Parameters.AddWithValue("@subtotal", prod.Cantidad * prod.Precio);
                        cmdDetalle.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("✅ Pedido guardado correctamente.");

                    // Limpieza post-guardado
                    productosSeleccionados.Clear();
                    MostrarProductosEnPedido();
                    ActualizarTotal();
                    textBox4.Clear();
                    txtTotal.Text = "0.00";
                    CargarPedidos();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("❌ Error al guardar pedido: " + ex.Message);
                }
            }
        }

        // ==============================================================
        // BOTÓN: Limpiar campos (button1_Click)
        // Restablece los datos del formulario a su estado inicial.
        // ==============================================================
        private void button1_Click(object sender, EventArgs e)
        {
            productosEnPedido.Clear();
            productosSeleccionados.Clear();

            textBox4?.Clear();
            txtTotal.Text = "0.00";
            MostrarProductosEnPedido();
            textBox4?.Focus();
        }

        // ==============================================================
        // MÉTODO: RegistrarVenta()
        // Crea una venta, actualiza el estado del pedido a “entregado”
        // y confirma la transacción.
        // ==============================================================
        private void RegistrarVenta(int pedidoId, string tipoPago)
        {
            using (SqlConnection con = ObtenerConexion())
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    string queryCliente = "SELECT id_cliente FROM Pedido WHERE id_pedido = @id_pedido";
                    SqlCommand cmdCliente = new SqlCommand(queryCliente, con, tran);
                    cmdCliente.Parameters.AddWithValue("@id_pedido", pedidoId);
                    int idCliente = Convert.ToInt32(cmdCliente.ExecuteScalar());

                    // Total del pedido desde Detalle_Pedido
                    string queryTotal = "SELECT SUM(subtotal) FROM Detalle_Pedido WHERE id_pedido = @id_pedido";
                    SqlCommand cmdTotal = new SqlCommand(queryTotal, con, tran);
                    cmdTotal.Parameters.AddWithValue("@id_pedido", pedidoId);
                    decimal total = Convert.ToDecimal(cmdTotal.ExecuteScalar());

                    // Insertar registro en Ventas
                    string insertVenta = @"
                        INSERT INTO Ventas (id_pedido, fecha, hora, total, tipo_pago, id_usuario, id_cliente)
                        VALUES (@id_pedido, GETDATE(), CONVERT(time, GETDATE()), @total, @pago, @usuario, @id_cliente);";

                    SqlCommand cmdVenta = new SqlCommand(insertVenta, con, tran);
                    cmdVenta.Parameters.AddWithValue("@id_pedido", pedidoId);
                    cmdVenta.Parameters.AddWithValue("@total", total);
                    cmdVenta.Parameters.AddWithValue("@pago", tipoPago);
                    cmdVenta.Parameters.AddWithValue("@usuario", SesionActual.IdUsuario);
                    cmdVenta.Parameters.AddWithValue("@id_cliente", idCliente);
                    cmdVenta.ExecuteNonQuery();

                    // Actualizar estado del pedido
                    string updatePedido = "UPDATE Pedido SET estado = 'entregado' WHERE id_pedido = @id";
                    SqlCommand cmdPedido = new SqlCommand(updatePedido, con, tran);
                    cmdPedido.Parameters.AddWithValue("@id", pedidoId);
                    cmdPedido.ExecuteNonQuery();

                    tran.Commit();
                    MessageBox.Show("✅ Pedido entregado y venta registrada correctamente.");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("❌ Error en la venta: " + ex.Message);
                }
            }

            CargarPedidos(); // refresca la grilla
        }

        // ==============================================================
        // EVENTO: dataGridView1_CellPainting()
        // Pinta los botones según el estado del pedido (colores visuales).
        // ==============================================================
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var col = dataGridView1.Columns[e.ColumnIndex];
            if (col.Name != "btnEntregar") return;

            var estadoCol = dataGridView1.Columns
                .Cast<DataGridViewColumn>()
                .FirstOrDefault(c =>
                    string.Equals(c.Name, "Estado", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(c.DataPropertyName, "estado", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(c.HeaderText, "Estado", StringComparison.OrdinalIgnoreCase));

            if (estadoCol == null)
            {
                estadoCol = dataGridView1.Columns
                    .Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => !string.IsNullOrEmpty(c.HeaderText) &&
                                         c.HeaderText.IndexOf("estado", StringComparison.OrdinalIgnoreCase) >= 0);
            }

            string estado = null;
            if (estadoCol != null)
            {
                object val = dataGridView1.Rows[e.RowIndex].Cells[estadoCol.Index].Value;
                estado = val?.ToString()?.ToLowerInvariant();
            }

            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);

            // Colorea según estado
            Color colorBoton = Color.LightGray;
            if (!string.IsNullOrEmpty(estado))
            {
                if (estado.Contains("en preparación") || estado.Contains("en preparacion"))
                    colorBoton = Color.LightPink;
                else if (estado.Contains("entregado"))
                    colorBoton = Color.LightGreen;
            }

            using (SolidBrush brush = new SolidBrush(colorBoton))
                e.Graphics.FillRectangle(brush, e.CellBounds);

            TextRenderer.DrawText(
                e.Graphics,
                "✔",
                e.CellStyle.Font,
                e.CellBounds,
                Color.Black,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );

            e.Paint(e.CellBounds, DataGridViewPaintParts.Border);
        }
    }
}
