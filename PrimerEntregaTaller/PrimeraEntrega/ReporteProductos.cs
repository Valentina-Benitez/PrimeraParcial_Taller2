using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PrimeraEntrega
{
    public partial class ReporteProductos : Form
    {
        private string connectionString = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";

        public ReporteProductos()
        {
            InitializeComponent();
            this.Load += ReporteProductos_Load;
            // Asegurar que el botón Filtrar invoque al método correcto
            this.button1.Click += btnFiltrar_Click;
        }

        private void ReporteProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos(string filtro = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            p.id_producto,
                            p.nombre AS nombre,
                            COUNT(*) AS nro_ventas
                        FROM ventas v
                        INNER JOIN producto p ON v.id_producto = p.id_producto
                        WHERE (@desde IS NULL OR v.fecha >= @desde)
                          AND (@hasta IS NULL OR v.fecha <= @hasta)
                        GROUP BY p.id_producto, p.nombre_producto " + filtro;

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Si quieres posibilidad de "sin filtro" cambia la lógica de estos parámetros.
                        object desde = dateTimePicker1 != null ? (object)dateTimePicker1.Value.Date : DBNull.Value;
                        object hasta = dateTimePicker2 != null ? (object)dateTimePicker2.Value.Date : DBNull.Value;

                        cmd.Parameters.AddWithValue("@desde", desde ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@hasta", hasta ?? DBNull.Value);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reporte: " + ex.Message);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Filtra por fechas
            CargarProductos();
        }

        private void masVendido_Click(object sender, EventArgs e)
        {
            // Ordena descendente por ventas
            CargarProductos("ORDER BY nro_ventas DESC");
        }

        private void menosVendido_Click(object sender, EventArgs e)
        {
            // Ordena ascendente por ventas
            CargarProductos("ORDER BY nro_ventas ASC");
        }

        private void altaProductos_Click(object sender, EventArgs e)
        {
            // Ejemplo: productos con más de 100 ventas
            CargarProductos("HAVING COUNT(*) >= 100 ORDER BY nro_ventas DESC");
        }

        private void bajaProductos_Click(object sender, EventArgs e)
        {
            // Ejemplo: productos con menos de 50 ventas
            CargarProductos("HAVING COUNT(*) < 50 ORDER BY nro_ventas ASC");
        }

        // Método de Paint ya existente en el diseñador
        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
        }
    }
}
