using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PrimeraEntrega
{
    public partial class FormEmpleadosVistas : Form
    {
        // ===========================================================
        // CONSTRUCTOR
        // Configura la vista inicial y carga la lista de empleados
        // ===========================================================
        public FormEmpleadosVistas()
        {
            InitializeComponent();

            // Evita que el DataGridView genere columnas automáticamente
            dgvEmpleados.AutoGenerateColumns = false;

            // Carga los empleados desde la base de datos
            CargarEmpleados();
        }

        // ===========================================================
        // MÉTODO: ObtenerConexion()
        // Retorna una conexión a la base de datos
        // ===========================================================
        private SqlConnection ObtenerConexion()
        {
            string cadena = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";
            return new SqlConnection(cadena);
        }

        // ===========================================================
        // MÉTODO: CargarEmpleados()
        // Carga todos los usuarios registrados en la tabla Usuario
        // ===========================================================
        private void CargarEmpleados()
        {
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT * FROM Usuario";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvEmpleados.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        // ===========================================================
        // VALIDACIONES DE ENTRADA
        // Solo permite letras o números en los campos correspondientes
        // ===========================================================
        private void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // ===========================================================
        // MÉTODO: ConfigurarGrafico()
        // Prepara el gráfico antes de dibujar los datos (colores, títulos, ejes, etc.)
        // ===========================================================
        private void ConfigurarGrafico(string titulo)
        {
            chartEmpleados.Series.Clear();
            chartEmpleados.Titles.Clear();
            chartEmpleados.ChartAreas.Clear(); // Limpia áreas previas

            chartEmpleados.Titles.Add(titulo);

            // Crear y configurar el área principal
            var area = new ChartArea("MainArea");
            chartEmpleados.ChartAreas.Add(area);

            area.BackColor = Color.White;
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;

            chartEmpleados.BackColor = Color.White;
            chartEmpleados.Palette = ChartColorPalette.Bright;

            // Configuración de leyenda
            chartEmpleados.Legends.Clear();
            var legend = new Legend("Leyenda");
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
            chartEmpleados.Legends.Add(legend);
        }

        // ===========================================================
        // EVENTOS DE INTERFAZ (vacíos)
        // ===========================================================
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void btnFiltrarMes_Click(object sender, EventArgs e) { }

        // ===========================================================
        // BOTÓN: ReservasRegistradas_Click
        // Muestra en gráfico la cantidad de reservas realizadas por cada empleado
        // ===========================================================
        private void ReservasRegistradas_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            u.nombre + ' ' + u.apellido AS Empleado,
                            COUNT(r.id_reserva) AS Reservas
                        FROM Reserva r
                        INNER JOIN Usuario u ON r.id_usuario = u.id_usuario
                        WHERE r.fecha_reserva BETWEEN @desde AND @hasta
                        GROUP BY u.nombre, u.apellido
                        ORDER BY Reservas DESC";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@desde", dtpDesde.Value.Date);
                    cmd.Parameters.AddWithValue("@hasta", dtnHasta.Value.Date);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ConfigurarGrafico("Reservas por Empleado");

                    var series = chartEmpleados.Series.Add("Reservas");
                    series.ChartType = SeriesChartType.Column;
                    series.Color = Color.FromArgb(46, 204, 113);
                    series.IsValueShownAsLabel = true;

                    // Asigna valores y colores dinámicos
                    foreach (DataRow row in dt.Rows)
                    {
                        series.Points.AddXY(row["Empleado"], row["Reservas"]);
                        int index = series.Points.Count - 1;
                        series.Points[index].Color = Color.FromArgb(
                            100 + (index * 30) % 155,
                            50 + (index * 50) % 205,
                            150 + (index * 70) % 105
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reservas: " + ex.Message);
            }
        }

        // ===========================================================
        // BOTÓN: VentasRealizadas_Click
        // Muestra las ventas totales realizadas por cada empleado
        // ===========================================================
        private void VentasRealizadas_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            u.nombre + ' ' + u.apellido AS Empleado,
                            COUNT(v.id_venta) AS Ventas
                        FROM Ventas v
                        INNER JOIN Usuario u ON v.id_usuario = u.id_usuario
                        WHERE v.fecha BETWEEN @desde AND @hasta
                        GROUP BY u.nombre, u.apellido
                        ORDER BY Ventas DESC";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@desde", dtpDesde.Value.Date);
                    cmd.Parameters.AddWithValue("@hasta", dtnHasta.Value.Date);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay datos en el rango de fechas seleccionado.");
                        chartEmpleados.Series.Clear();
                        return;
                    }

                    ConfigurarGrafico("Ventas por Empleado");

                    var series = chartEmpleados.Series.Add("Ventas");
                    series.ChartType = SeriesChartType.Column;
                    series.IsValueShownAsLabel = true;
                    series.Palette = ChartColorPalette.Bright;

                    // Etiquetas y colores dinámicos
                    foreach (DataRow row in dt.Rows)
                    {
                        series.Points.AddXY(row["Empleado"], row["Ventas"]);
                        int index = series.Points.Count - 1;
                        series.Points[index].Color = Color.FromArgb(
                            100 + (index * 30) % 155,
                            50 + (index * 50) % 205,
                            150 + (index * 70) % 105
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas: " + ex.Message);
            }
        }

        // ===========================================================
        // BOTÓN: PedidosTomados_Click
        // Genera un gráfico con los pedidos realizados por cada empleado
        // ===========================================================
        private void PedidosTomados_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            u.nombre + ' ' + u.apellido AS Empleado,
                            COUNT(p.id_pedido) AS Pedidos
                        FROM Pedido p
                        INNER JOIN Usuario u ON p.id_usuario = u.id_usuario
                        WHERE p.fecha BETWEEN @desde AND @hasta
                        GROUP BY u.nombre, u.apellido
                        ORDER BY Pedidos DESC";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@desde", dtpDesde.Value.Date);
                    cmd.Parameters.AddWithValue("@hasta", dtnHasta.Value.Date);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ConfigurarGrafico("Pedidos por Empleado");

                    var series = chartEmpleados.Series.Add("Pedidos");
                    series.ChartType = SeriesChartType.Column;
                    series.Color = Color.FromArgb(255, 153, 51);
                    series.IsValueShownAsLabel = true;

                    // Colores dinámicos según posición
                    foreach (DataRow row in dt.Rows)
                    {
                        series.Points.AddXY(row["Empleado"], row["Pedidos"]);
                        int index = series.Points.Count - 1;
                        series.Points[index].Color = Color.FromArgb(
                            100 + (index * 30) % 155,
                            50 + (index * 50) % 205,
                            150 + (index * 70) % 105
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pedidos: " + ex.Message);
            }
        }

        // ===========================================================
        // BOTÓN: btnFiltrarMes_Click_1
        // Muestra la cantidad de ventas mensuales en un gráfico
        // ===========================================================
        private void btnFiltrarMes_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            DATENAME(MONTH, v.fecha) AS Mes,
                            COUNT(v.id_venta) AS CantidadVentas
                        FROM Ventas v
                        WHERE YEAR(v.fecha) = @anio
                        GROUP BY DATENAME(MONTH, v.fecha), MONTH(v.fecha)
                        ORDER BY MONTH(v.fecha)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@anio", dtpDesde.Value.Year);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay datos para el año seleccionado.");
                        chartEmpleados.Series.Clear();
                        return;
                    }

                    ConfigurarGrafico("Ventas por Mes");

                    var series = chartEmpleados.Series.Add("VentasMensuales");
                    series.ChartType = SeriesChartType.Column;
                    series.IsValueShownAsLabel = true;

                    foreach (DataRow row in dt.Rows)
                    {
                        series.Points.AddXY(row["Mes"], row["CantidadVentas"]);
                        int index = series.Points.Count - 1;
                        series.Points[index].Color = Color.FromArgb(
                            80 + (index * 25) % 175,
                            100 + (index * 40) % 155,
                            150 + (index * 60) % 105
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar gráfico mensual: " + ex.Message);
            }
        }
    }
}
