using PrimeraEntrega;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

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
                    c.dni AS [Cliente],
                    p.fecha AS [Fecha],
                    p.estado AS [Estado]
                FROM
                    Pedido p
                JOIN
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
            decimal total = productosSeleccionados.Sum(p => p.Precio);
            txtTotal.Text = total.ToString("0.00");
        }

        private void FormPedidos_Load(object sender, EventArgs e)
        {
            CargarPedidos();

            comboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboEstado.Items.Clear();
            comboEstado.Items.Add("pendiente");
            comboEstado.Items.Add("en preparación");
            comboEstado.Items.Add("entregado");
            comboEstado.Items.Add("cancelado");
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
        }

   
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        // Método: devuelve id_cliente (o lanza excepción si no existe y no querés crearlo)
        private int ObtenerIdClientePorDni(string dni, SqlConnection con, SqlTransaction tran)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("Debe ingresar el DNI del cliente.");

            string sql = "SELECT id_cliente FROM Cliente WHERE dni = @dni";
            using (SqlCommand cmd = new SqlCommand(sql, con, tran))
            {
                cmd.Parameters.AddWithValue("@dni", dni);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    return Convert.ToInt32(result);

                // Si no existe, podés:
                // - lanzar error
                // - o crear el cliente automáticamente (aquí dejo el ejemplo que crea con nombre 'DESCONOCIDO')
                string insert = "INSERT INTO Cliente (dni, nombre, apellido) VALUES (@dni, @nombre, @apellido); SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmdIns = new SqlCommand(insert, con, tran))
                {
                    cmdIns.Parameters.AddWithValue("@dni", dni);
                    cmdIns.Parameters.AddWithValue("@nombre", "DESCONOCIDO");
                    cmdIns.Parameters.AddWithValue("@apellido", "DESCONOCIDO");
                    object idNew = cmdIns.ExecuteScalar();
                    return Convert.ToInt32(idNew);
                }

                // Si preferís no crear, en vez de insertar podés:
                // throw new Exception("No se encontró el cliente con ese DNI.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (productosSeleccionados.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto.");
                return;
            }

            using (SqlConnection con = ObtenerConexion())
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    // Insertar pedido
                    string insertPedido = @"
                INSERT INTO Pedido (id_cliente, fecha, estado, total)
                VALUES (@id_cliente, @fecha, @estado, @total);
                SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdPedido = new SqlCommand(insertPedido, con, tran);
                    cmdPedido.Parameters.AddWithValue("@id_cliente", ObtenerIdClientePorDni(textBox4.Text, con, tran));
                    cmdPedido.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmdPedido.Parameters.AddWithValue("@estado", comboEstado.SelectedItem.ToString());
                    cmdPedido.Parameters.AddWithValue("@total", decimal.Parse(txtTotal.Text));

                    int idPedido = Convert.ToInt32(cmdPedido.ExecuteScalar());

                    // Insertar detalles
                    foreach (var prod in productosSeleccionados)
                    {
                        string insertDetalle = @"
                    INSERT INTO Detalle_Pedido (id_pedido, id_producto, cantidad, subtotal)
                    VALUES (@id_pedido, @id_producto, 1, @precio);";

                        SqlCommand cmdDetalle = new SqlCommand(insertDetalle, con, tran);
                        cmdDetalle.Parameters.AddWithValue("@id_pedido", idPedido);
                        cmdDetalle.Parameters.AddWithValue("@id_producto", prod.IdProducto);
                        cmdDetalle.Parameters.AddWithValue("@precio", prod.Precio);
                        cmdDetalle.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("Pedido guardado correctamente.");
                    productosSeleccionados.Clear();
                    MostrarProductosEnPedido();
                    ActualizarTotal();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Error al guardar pedido: " + ex.Message);
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
            if (comboEstado != null)
            {
                // Esto deselecciona cualquier opción.
                comboEstado.SelectedIndex = -1;
            }

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

    }
}

