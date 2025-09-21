using PrimeraEntrega;
using System;
using System.Data;
using System.Data.SqlClient;
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
                    p.id_pedido AS [Nro Pedido],
                    c.nombre AS [Cliente],
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

        

        private void bPedido_Click(object sender, EventArgs e)
        {
            FormAgregarProductos formAgregarProductos = new FormAgregarProductos();
            formAgregarProductos.ShowDialog();
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
            string consulta = "SELECT id_pedido AS [Nro Pedido], ISNULL(nombre,'X') AS [Cliente], fecha AS [Fecha], estado AS [Estado] FROM Pedido";

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
                        consulta += " WHERE CAST(id_pedido AS VARCHAR) LIKE @filtro OR nombre LIKE @filtro";

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
            // Verifica si la columna del clic es la del botón "Detalle"
            // y si no es la cabecera del DataGridView.
            if (e.ColumnIndex == dataGridView1.Columns["btnDetalle"].Index && e.RowIndex >= 0)
            {
                // Obtiene el ID del pedido de la fila en la que se hizo clic.
               // int pedidoId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Nro Pedido"].Value);

                // Crea la nueva ventana y le pasa el ID del pedido.
                FormDetallePedido formDetalle = new FormDetallePedido();
               //ormDetalle.PedidoId = pedidoId; // Asigna el ID del pedido a la propiedad PedidoId.

                formDetalle.ShowDialog();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
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
    }
}
