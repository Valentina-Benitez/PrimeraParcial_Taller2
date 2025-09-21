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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int pedidoId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Nro Pedido"].Value);

                FormDetallePedido formDetalle = new FormDetallePedido();
                formDetalle.PedidoId = pedidoId;
                formDetalle.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un pedido de la lista.");
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
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBusqueda.Text.Trim();

            if (string.IsNullOrEmpty(filtro))
            {
                CargarPedidos();
            }
            else
            {
                if (int.TryParse(filtro, out int id_pedido))
                {
                    string consulta = "SELECT id_pedido AS [Nro Pedido], ISNULL(nombre,'X') AS [Cliente], fecha AS [Fecha], estado AS [Estado] FROM Pedido WHERE id_pedido = @id_pedido";
                    using (SqlConnection conexion = ObtenerConexion())
                    {
                        SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
                        da.SelectCommand.Parameters.AddWithValue("@id_pedido", id_pedido);

                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                else
                {
                    string consulta = "SELECT id_pedido AS [Nro Pedido], ISNULL(nombre,'X') AS [Cliente], fecha AS [Fecha], estado AS [Estado] FROM Pedido WHERE nombre LIKE @nombre";
                    using (SqlConnection conexion = ObtenerConexion())
                    {
                        SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
                        da.SelectCommand.Parameters.AddWithValue("@nombre", "%" + filtro + "%");

                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }
    }
}
