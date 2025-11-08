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
        public FormPedidos()
        {
            InitializeComponent();
            // Desactivar generación automática de columnas
            dataGridView1.AutoGenerateColumns = false;

            CargarPedidos();
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

        }

        private SqlConnection ObtenerConexion()
        {
            string cadena = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";
            return new SqlConnection(cadena);
        }

        private void CargarPedidos()
        {
            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();
                    // Consulta que une la tabla Pedido con la tabla Cliente
                    string consulta = @"
                    SELECT
                        p.id_pedido,
                        ISNULL(c.dni, 'Desconocido') AS [Cliente],
                        p.fecha AS [Fecha],
                        p.estado AS [Estado]
                    FROM
                        Pedido p
                    LEFT JOIN
                        Cliente c ON p.id_cliente = c.id_cliente;";

                    SqlDataAdapter da = new SqlDataAdapter(consulta, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pedidos: " + ex.Message);
            }

        }



        private List<ProductoSeleccionado> productosEnPedido = new List<ProductoSeleccionado>();

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


        public List<ProductoSeleccionado> productosSeleccionados { get; private set; } = new List<ProductoSeleccionado>();

        private void ActualizarTotal()
        {
            decimal total = productosSeleccionados.Sum(p => p.Cantidad * p.Precio);
            txtTotal.Text = total.ToString("0.00");
        }

        private void FormPedidos_Load(object sender, EventArgs e)
        {
            CargarPedidos();

            if (!dataGridView1.Columns.Contains("btnEntregar"))
            {
                DataGridViewButtonColumn btnEntregar = new DataGridViewButtonColumn();
                btnEntregar.Name = "btnEntregar";
                btnEntregar.HeaderText = "Entregar";
                btnEntregar.Text = "✔";
                btnEntregar.UseColumnTextForButtonValue = true;
                btnEntregar.DefaultCellStyle.BackColor = Color.LightGreen;
                btnEntregar.Width = 80;
                dataGridView1.Columns.Add(btnEntregar);
            }

            txtTotal.ReadOnly = true;
           // comboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboEstado.Items.Clear();
            //comboEstado.Items.Add("pendiente");
           // comboEstado.Items.Add("en preparación");
           // comboEstado.Items.Add("Entregado");
           // comboEstado.Items.Add("Cancelado");
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBusqueda.Text.Trim();

            // La consulta base siempre se ejecuta, y la cláusula WHERE
            // se ajusta dinámicamente.
            string consulta = "SELECT id_pedido, ISNULL(dni,'X') AS [Cliente], fecha AS [Fecha], estado AS [Estado] FROM Pedido";

            using (SqlConnection conexion = ObtenerConexion())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(consulta, conexion))
                {
                    // Crea un DataTable para almacenar los resultados.
                    DataTable dt = new DataTable();

                    if (!string.IsNullOrEmpty(filtro))
                    {
                        // Si hay un filtro, añade la cláusula WHERE
                        // y los parámetros.
                        consulta += " WHERE CAST(id_pedido AS VARCHAR) LIKE @filtro OR dni LIKE @filtro";

                        // Vuelve a crear el SqlDataAdapter con la consulta completa
                        da.SelectCommand.CommandText = consulta;
                        da.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    }

                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // cancela la tecla
            }
        }


        private void textBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // cancela la tecla
            }
        }

        private void MostrarProductosEnPedido()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            foreach (var p in productosEnPedido)
            {
                dataGridView1.Rows.Add(p.IdProducto, p.Nombre, p.Precio);
            }

            decimal total = productosEnPedido.Sum(x => x.Precio);
            txtTotal.Text = total.ToString("C");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string estadoActual = dataGridView1.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn4"].Value.ToString().ToLower();
            int pedidoId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["nroPedido"].Value);

            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnDetalle")
            {
                object cellValue = dataGridView1.Rows[e.RowIndex].Cells["nroPedido"].Value;

                //MessageBox.Show($"Valor en celda: {(cellValue ?? "null")}");

                int PedidoId = 0;
                if (cellValue != null && cellValue != DBNull.Value)
                {
                    PedidoId = Convert.ToInt32(cellValue);
                }

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
                    {
                        RegistrarVenta(pedidoId, pagoForm.TipoDePagoSeleccionado);
                    }
                }
            }

        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        // Método: devuelve id_cliente (o lanza excepción si no existe y no querés crearlo)
        private int ObtenerIdClientePorDni(string dni, SqlConnection con, SqlTransaction tran)
        {
            // ✅ Validación básica
            if (string.IsNullOrWhiteSpace(dni))
                throw new Exception("Debe ingresar un DNI válido antes de crear el pedido.");

            // ✅ Buscar cliente existente
            string sqlSelect = "SELECT id_cliente FROM Cliente WHERE dni = @dni";
            using (SqlCommand cmdSelect = new SqlCommand(sqlSelect, con, tran))
            {
                cmdSelect.Parameters.AddWithValue("@dni", dni);

                object result = cmdSelect.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    // 🔹 Ya existe → devolver su ID
                    return Convert.ToInt32(result);
                }
            }

            // ✅ Si no existe, crear nuevo
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
                    MessageBox.Show($"DNI capturado: '{dni}'", "Debug DNI"); // 👈 Agregado

                    int idCliente = ObtenerIdClientePorDni(dni, con, tran);


                    // ✅ Insertar el pedido
                    string insertPedido = @"
                INSERT INTO Pedido (id_cliente, id_usuario, fecha, estado)
                VALUES (@id_cliente, @id_usuario, @fecha, 'en preparación');
                SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdPedido = new SqlCommand(insertPedido, con, tran);
                    cmdPedido.Parameters.AddWithValue("@id_cliente", idCliente);
                    cmdPedido.Parameters.AddWithValue("@id_usuario", SesionActual.IdUsuario);
                    cmdPedido.Parameters.AddWithValue("@fecha", DateTime.Now);

                    int idPedido = Convert.ToInt32(cmdPedido.ExecuteScalar());

                    // ✅ Insertar detalles
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






        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Limpiar las listas de productos.
            // Tienes dos listas que parecen referirse al mismo propósito, limpiamos ambas por seguridad.
            productosEnPedido.Clear();      // Lista que usas en MostrarProductosEnPedido()
            productosSeleccionados.Clear(); // Lista que usas en bPedido_Click y ActualizarTotal()

            // 2. Limpiar campos de entrada de datos.

            // DNI Cliente (asumiendo que es el control 'textBox4')
            if (textBox4 != null)
            {
                textBox4.Clear();
            }

            // Estado (control 'comboEstado')
            //if (comboEstado != null)
           // {
                // Esto deselecciona cualquier opción.
                //comboEstado.SelectedIndex = -1;
           // }

            if (txtTotal != null)
            {
                txtTotal.Text = "0.00";
            }

           
            MostrarProductosEnPedido();

         
            if (textBox4 != null)
            {
                textBox4.Focus();
            }
        }

        private void RegistrarVenta(int pedidoId, string tipoPago)
        {
            using (SqlConnection con = ObtenerConexion())
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    // ✅ Obtener id_cliente relacionado
                    string queryCliente = "SELECT id_cliente FROM Pedido WHERE id_pedido = @id_pedido";
                    SqlCommand cmdCliente = new SqlCommand(queryCliente, con, tran);
                    cmdCliente.Parameters.AddWithValue("@id_pedido", pedidoId);
                    int idCliente = Convert.ToInt32(cmdCliente.ExecuteScalar());

                    // ✅ Calcular total real desde DB
                    string queryTotal = @"
                SELECT SUM(subtotal) 
                FROM Detalle_Pedido 
                WHERE id_pedido = @id_pedido";

                    SqlCommand cmdTotal = new SqlCommand(queryTotal, con, tran);
                    cmdTotal.Parameters.AddWithValue("@id_pedido", pedidoId);
                    decimal total = Convert.ToDecimal(cmdTotal.ExecuteScalar());

                    // ✅ Insertar en Ventas incluyendo id_cliente
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


                    // ✅ Cambiar estado del pedido
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

            // ✅ Refrescar grilla
            CargarPedidos();
        }


    }
}

