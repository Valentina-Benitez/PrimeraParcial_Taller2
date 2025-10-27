using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PrimeraEntrega
{
    public partial class ReporteProductos : Form
    {
        private string connectionString = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";

        public ReporteProductos()
        {
            InitializeComponent();
            ConfigurarGrafico();
        }

        private void ConfigurarGrafico()
        {
            chart1.Series.Clear();
            chart1.Series.Add("Ventas");
            chart1.Series["Ventas"].ChartType = SeriesChartType.Column;
            chart1.Series["Ventas"].IsValueShownAsLabel = true;

            chart1.ChartAreas.Clear();
            ChartArea area = new ChartArea();
            area.AxisX.Title = "Producto";
            area.AxisY.Title = "Cantidad Vendida";
            area.AxisX.Interval = 1;
            chart1.ChartAreas.Add(area);
        }

        private void btnFiltrar_Click(object sender, EventArgs e) => CargarDatos("TODOS");
        private void btnMasVendido_Click(object sender, EventArgs e) => CargarDatos("MAS_VENDIDO");
        private void btnMenosVendido_Click(object sender, EventArgs e) => CargarDatos("MENOS_VENDIDO");
        private void btnAltas_Click(object sender, EventArgs e) => CargarDatos("ALTAS");
        private void btnBajas_Click(object sender, EventArgs e) => CargarDatos("BAJAS");

        private void CargarDatos(string filtro)
        {
            DateTime fechaDesde = dateTimePickerDesde.Value.Date;
            DateTime fechaHasta = dateTimePickerHasta.Value.Date.AddDays(1).AddSeconds(-1);

            string query = @"
                SELECT 
                    P.id_producto AS IdProducto,
                    P.Nombre,
                    SUM(DP.cantidad) AS nro_ventas
                FROM Detalle_Pedido DP
                INNER JOIN Pedido PE ON DP.id_pedido = PE.id_pedido
                INNER JOIN Producto P ON DP.id_producto = P.id_producto
                WHERE PE.fecha BETWEEN @desde AND @hasta";

            // Agregar filtros específicos
            if (filtro == "ALTAS")
                query += " AND P.Estado = 'Alta'";
            else if (filtro == "BAJAS")
                query += " AND P.Estado = 'Baja'";

            query += " GROUP BY P.id_producto, P.Nombre";

            // Ordenar según el filtro
            switch (filtro)
            {
                case "MAS_VENDIDO":
                case "ALTAS":
                case "BAJAS":
                    query += " ORDER BY SUM(DP.cantidad) DESC";
                    break;
                case "MENOS_VENDIDO":
                    query += " ORDER BY SUM(DP.cantidad) ASC";
                    break;
                default:
                    query += " ORDER BY P.Nombre ASC";
                    break;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@desde", fechaDesde);
                    cmd.Parameters.AddWithValue("@hasta", fechaHasta);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvProductos.DataSource = dt;

                    if (dgvProductos.Columns.Contains("IdProducto"))
                        dgvProductos.Columns["IdProducto"].HeaderText = "ID Producto";
                    if (dgvProductos.Columns.Contains("Nombre"))
                        dgvProductos.Columns["Nombre"].HeaderText = "Nombre del Producto";
                    if (dgvProductos.Columns.Contains("nro_ventas"))
                        dgvProductos.Columns["nro_ventas"].HeaderText = "Cantidad Vendida";

                    ActualizarGrafico(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarGrafico(DataTable dt)
        {
            chart1.Series["Ventas"].Points.Clear();

            if (dt.Rows.Count == 0) return;

            foreach (DataRow row in dt.Rows)
            {
                string nombre = row["Nombre"].ToString();
                int cantidad = Convert.ToInt32(row["nro_ventas"]);
                chart1.Series["Ventas"].Points.AddXY(nombre, cantidad);
            }
        }
    }
}
