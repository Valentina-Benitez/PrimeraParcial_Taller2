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
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        private SqlConnection ObtenerConexion()
        {
            return new SqlConnection(@"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True");

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            // Evitar que se autogenere si ya tenés columnas diseñadas en el diseñador
            dgvVentas.AutoGenerateColumns = false;

            CargarVentas();

            // Aplicar estilo al botón existente "VerFactura" (columna definida en el diseñador)
            if (dgvVentas.Columns.Contains("VerFactura"))
            {
                var btnCol = dgvVentas.Columns["VerFactura"] as DataGridViewButtonColumn;
                if (btnCol != null)
                {
                    btnCol.UseColumnTextForButtonValue = true;
                    btnCol.Text = "Ver";
                    btnCol.DefaultCellStyle.BackColor = Color.PowderBlue;
                    btnCol.DefaultCellStyle.ForeColor = Color.Black;
                    btnCol.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 255);
                    btnCol.FlatStyle = FlatStyle.Flat;
                }
            }
        }

        private void CargarVentas()
        {
            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();

                    string query = @"
                    SELECT 
                        v.id_venta AS [NroVenta],
                        v.id_pedido AS [NroPedido],
                        u.nombre + ' ' + u.apellido AS [Empleado],
                        c.nombre + ' ' + u.apellido AS [Cliente],
                        v.fecha AS [Fecha],
                        v.total AS [total],
                        v.tipo_pago AS [TipoPago]

                    FROM Ventas v
                    INNER JOIN Pedido p ON v.id_pedido = p.id_pedido
                    INNER JOIN Cliente c ON p.id_cliente = c.id_cliente
                    LEFT JOIN Usuario u ON v.id_usuario = u.id_usuario;
                    ";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvVentas.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas: " + ex.Message);
            }
        }

        private void CargarGraficoVentas()
        {
            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();

                    string query = @"
            SELECT 
                DATENAME(MONTH, v.fecha) AS Mes,
                SUM(v.total) AS Total
            FROM Ventas v
            WHERE v.fecha BETWEEN @desde AND @hasta
            GROUP BY DATENAME(MONTH, v.fecha), MONTH(v.fecha)
            ORDER BY MONTH(v.fecha);";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@desde", dtpDesde.Value.Date);
                    cmd.Parameters.AddWithValue("@hasta", dtpHasta.Value.Date);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay ventas registradas en el rango de fechas seleccionado.");
                        chartVentas.Series.Clear();
                        return;
                    }

                    // 🔹 Limpiar títulos y leyendas y crear la leyenda nueva primero
                    chartVentas.Titles.Clear();
                    chartVentas.Legends.Clear();
                    var legend = new Legend("Leyenda");
                    legend.Docking = Docking.Bottom;
                    legend.Alignment = StringAlignment.Center;
                    legend.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                    chartVentas.Legends.Add(legend);

                    // 🔹 Limpiar series y agregar serie asignándole explícitamente la leyenda existente
                    chartVentas.Series.Clear();
                    var series = new Series("Ventas por Mes");
                    series.Legend = legend.Name; // <--- asignación explícita de la leyenda
                    chartVentas.Series.Add(series);

                    // 🔹 Configurar tipo de gráfico: TORTA
                    series.ChartType = SeriesChartType.Pie;
                    series["PieLabelStyle"] = "Outside"; // Etiquetas fuera de la torta
                    series["PieDrawingStyle"] = "SoftEdge"; // Bordes suaves
                    series.IsValueShownAsLabel = true;
                    series.LabelForeColor = Color.Black;

                    // 🔹 Mostrar porcentaje
                    series.Label = "#VALX (#PERCENT{P0})";

                    // 🔹 Paleta de colores llamativa
                    chartVentas.Palette = ChartColorPalette.BrightPastel;

                    // 🔹 Cargar datos
                    foreach (DataRow row in dt.Rows)
                    {
                        string mes = row["Mes"].ToString();
                        decimal total = Convert.ToDecimal(row["Total"]);
                        series.Points.AddXY(mes, total);
                    }

                    // 🔹 Configuración visual
                    chartVentas.ChartAreas[0].BackColor = Color.White;
                    chartVentas.BackColor = Color.White;


                    // 🔹 Título principal
                    chartVentas.Titles.Clear();
                    chartVentas.Titles.Add("Distribución de Ventas por Mes");
                    chartVentas.Titles[0].Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    chartVentas.Titles[0].ForeColor = Color.FromArgb(52, 73, 94);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el gráfico de torta: " + ex.Message);
            }
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string estadoActual = dgvVentas.Rows[e.RowIndex].Cells["TipoPago"].Value.ToString().ToLower();
            int pedidoId = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["nroPedido"].Value);

            if (dgvVentas.Columns[e.ColumnIndex].Name == "VerFactura")
            {
                object cellValue = dgvVentas.Rows[e.RowIndex].Cells["nroPedido"].Value;

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
        private void FiltrarPorVendedor()
        {
            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();

                    string query = @"
                SELECT 
                    u.nombre + ' ' + u.apellido AS Vendedor,
                    COUNT(v.id_venta) AS CantidadVentas
                FROM Ventas v
                LEFT JOIN Usuario u ON v.id_usuario = u.id_usuario
                WHERE v.fecha BETWEEN @desde AND @hasta
                GROUP BY u.nombre, u.apellido
                ORDER BY CantidadVentas DESC;";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@desde", dtpDesde.Value.Date);
                    cmd.Parameters.AddWithValue("@hasta", dtpHasta.Value.Date.AddDays(1));

                    SqlDataReader rd = cmd.ExecuteReader();

                    // 🔹 Limpiar gráfico antes de cargar
                    chartVentas.Series.Clear();
                    Series serie = new Series("Ventas por Vendedor");
                    serie.ChartType = SeriesChartType.Column;
                    serie.IsValueShownAsLabel = true;

                    Random rand = new Random();

                    while (rd.Read())
                    {
                        string vendedor = rd["Vendedor"].ToString();
                        int cantidad = Convert.ToInt32(rd["CantidadVentas"]);

                        int r = rand.Next(50, 255);
                        int g = rand.Next(50, 255);
                        int b = rand.Next(50, 255);

                        int pointIndex = serie.Points.AddXY(vendedor, cantidad);
                        serie.Points[pointIndex].Color = Color.FromArgb(r, g, b);
                    }

                    // Asegurarse de que exista una leyenda y, si existe, asignarla
                    if (chartVentas.Legends.Count == 0)
                    {
                        var l = new Legend("Leyenda");
                        l.Docking = Docking.Bottom;
                        l.Alignment = StringAlignment.Center;
                        chartVentas.Legends.Add(l);
                    }
                    serie.Legend = chartVentas.Legends[0].Name;

                    chartVentas.Series.Add(serie);
                    chartVentas.ChartAreas[0].AxisX.Interval = 1;
                    chartVentas.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                    chartVentas.ChartAreas[0].BackColor = Color.White;
                    chartVentas.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar por vendedor: " + ex.Message);
            }
        }

        private void FiltrarPorCliente()
        {
            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();

                    string query = @"
                SELECT 
                    c.nombre + ' ' + c.apellido AS Cliente,
                    COUNT(v.id_venta) AS CantidadVentas
                FROM Ventas v
                INNER JOIN Pedido p ON v.id_pedido = p.id_pedido
                INNER JOIN Cliente c ON p.id_cliente = c.id_cliente
                WHERE v.fecha BETWEEN @desde AND @hasta
                GROUP BY c.nombre, c.apellido
                ORDER BY CantidadVentas DESC;";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@desde", dtpDesde.Value.Date);
                    cmd.Parameters.AddWithValue("@hasta", dtpHasta.Value.Date.AddDays(1));

                    SqlDataReader rd = cmd.ExecuteReader();

                    // 🔹 Limpiar gráfico y configurar serie
                    chartVentas.Series.Clear();
                    Series serie = new Series("Ventas por Cliente");
                    serie.ChartType = SeriesChartType.Column;
                    serie.IsValueShownAsLabel = true;

                    Random rand = new Random();

                    while (rd.Read())
                    {
                        string cliente = rd["Cliente"].ToString();
                        int cantidad = Convert.ToInt32(rd["CantidadVentas"]);

                        int r = rand.Next(80, 220);
                        int g = rand.Next(80, 220);
                        int b = rand.Next(80, 220);

                        int index = serie.Points.AddXY(cliente, cantidad);
                        serie.Points[index].Color = Color.FromArgb(r, g, b);
                    }

                    if (chartVentas.Legends.Count == 0)
                    {
                        var l = new Legend("Leyenda");
                        l.Docking = Docking.Bottom;
                        l.Alignment = StringAlignment.Center;
                        chartVentas.Legends.Add(l);
                    }
                    serie.Legend = chartVentas.Legends[0].Name;

                    chartVentas.Series.Add(serie);
                    chartVentas.ChartAreas[0].AxisX.Interval = 1;
                    chartVentas.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                    chartVentas.ChartAreas[0].BackColor = Color.White;
                    chartVentas.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar por cliente: " + ex.Message);
            }
        }

        private void CargarGraficoPorMetodoPago()
        {
            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();

                    string query = @"
                SELECT 
                    v.tipo_pago AS MetodoPago,
                    SUM(v.total) AS Total
                FROM Ventas v
                WHERE v.fecha BETWEEN @desde AND @hasta
                GROUP BY v.tipo_pago
                ORDER BY Total DESC;";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@desde", dtpDesde.Value.Date);
                    cmd.Parameters.AddWithValue("@hasta", dtpHasta.Value.Date);

                    SqlDataReader rd = cmd.ExecuteReader();

                    chartVentas.Series.Clear();
                    chartVentas.Series.Add("Método de Pago");

                    var series = chartVentas.Series["Método de Pago"];
                    series.ChartType = SeriesChartType.Column;
                    series.IsValueShownAsLabel = true;

                    // 🎨 Paleta de colores para cada método de pago
                    Dictionary<string, Color> colores = new Dictionary<string, Color>()
            {
                { "Efectivo", Color.FromArgb(46, 204, 113) },      // Verde
                { "Tarjeta", Color.FromArgb(52, 152, 219) },       // Azul
                { "MercadoPago", Color.FromArgb(241, 196, 15) },   // Amarillo
                { "Transferencia", Color.FromArgb(155, 89, 182) }, // Violeta
                { "Otro", Color.FromArgb(230, 126, 34) }           // Naranja
            };

                    while (rd.Read())
                    {
                        string metodo = rd["MetodoPago"].ToString();
                        decimal total = Convert.ToDecimal(rd["Total"]);

                        int pointIndex = series.Points.AddXY(metodo, total);

                        // Asigna color si está definido
                        if (colores.ContainsKey(metodo))
                            series.Points[pointIndex].Color = colores[metodo];
                        else
                            series.Points[pointIndex].Color = Color.FromArgb(149, 165, 166); // Gris por defecto
                    }
                }

                if (chartVentas.Legends.Count == 0)
                {
                    var l = new Legend("Leyenda");
                    l.Docking = Docking.Bottom;
                    l.Alignment = StringAlignment.Center;
                    chartVentas.Legends.Add(l);
                }
                chartVentas.Series["Método de Pago"].Legend = chartVentas.Legends[0].Name;

                chartVentas.ChartAreas[0].AxisX.Interval = 1;
                chartVentas.ChartAreas[0].AxisX.Title = "Método de Pago";
                chartVentas.ChartAreas[0].AxisY.Title = "Total Vendido ($)";
                chartVentas.ChartAreas[0].BackColor = Color.White;
                chartVentas.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar gráfico por método de pago: " + ex.Message);
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            CargarGraficoPorMetodoPago();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarVentas();
            CargarGraficoVentas();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FiltrarPorVendedor();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FiltrarPorCliente();
        }
    }
}
