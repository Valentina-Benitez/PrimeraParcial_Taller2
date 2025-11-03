using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PrimeraEntrega
{
    public partial class ReporteProductos : Form
    {

        public ReporteProductos()
        {
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;
            ConfigurarGrid();
            ConfigurarGrafico("Ventas por Producto");

            // Suscribir manejadores de Click para los botones (si el diseñador no lo hizo)
            btnMasVendidos.Click += btnMasVendidos_Click;
            btnMenosVendidos.Click += btnMenosVendidos_Click;
            btnAltas.Click += btnAltas_Click;
            btnBajas.Click += btnBajas_Click;

            // Cargar datos iniciales (sin filtro aplicado)
            CargarDatos();

            // Detectar cambios de fecha
            dateTimePickerDesde.ValueChanged += (s, e) => CargarDatos();
            dateTimePickerHasta.ValueChanged += (s, e) => CargarDatos();
        }

        private SqlConnection ObtenerConexion()
        {
            string cadena = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";
            return new SqlConnection(cadena);
        }

        // ---------------- Configuración ----------------

        private void ConfigurarGrid()
        {
            dgvProductos.Columns.Clear();
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "id_producto", HeaderText = "ID Producto", DataPropertyName = "id_producto" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nombre", HeaderText = "Nombre", DataPropertyName = "nombre" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "categoria", HeaderText = "Categoría", DataPropertyName = "categoria" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nro_ventas", HeaderText = "Nro de Ventas", DataPropertyName = "nro_ventas" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "estado", HeaderText = "Estado", DataPropertyName = "estado" });
        }

        private void ConfigurarGrafico(string titulo)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add(titulo);

            ChartArea area = new ChartArea("MainArea");
            // dejar espacio para leyenda y activar 3D suave
            area.Position = new ElementPosition(8, 8, 70, 84);
            area.BackColor = Color.White;
            area.Area3DStyle.Enable3D = true;
            area.Area3DStyle.Inclination = 40;
            area.Area3DStyle.IsClustered = false;
            area.Area3DStyle.Rotation = 0;
            chart1.ChartAreas.Add(area);

            chart1.BackColor = Color.White;
            chart1.Legends.Clear();
            Legend legend = new Legend("Leyenda")
            {
                Docking = Docking.Right,
                Alignment = StringAlignment.Center,
                LegendStyle = LegendStyle.Table,
                TableStyle = LegendTableStyle.Auto
            };
            legend.Font = new Font("Segoe UI", 9);
            chart1.Legends.Add(legend);

            chart1.Palette = ChartColorPalette.Pastel;
            chart1.AntiAliasing = AntiAliasingStyles.Graphics;
            chart1.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
        }

        // ---------------- Filtro ----------------
        private string filtroActual = "TODOS";

        private void btnMasVendidos_Click(object sender, EventArgs e) => CambiarFiltro("MAS_VENDIDOS", btnMasVendidos);
        private void btnMenosVendidos_Click(object sender, EventArgs e) => CambiarFiltro("MENOS_VENDIDOS", btnMenosVendidos);
        private void btnAltas_Click(object sender, EventArgs e) => CambiarFiltro("ALTAS", btnAltas);
        private void btnBajas_Click(object sender, EventArgs e) => CambiarFiltro("BAJAS", btnBajas);

        private void CambiarFiltro(string filtro, Button boton)
        {
            filtroActual = filtro;

            // Reset de colores (recorrer controles anidados)
            foreach (Control c in GetAllControls(this))
            {
                if (c is Button btn && btn != btnFiltrar)
                {
                    btn.BackColor = SystemColors.Control;
                    btn.ForeColor = Color.Black;
                }
            }

            boton.BackColor = Color.SteelBlue;
            boton.ForeColor = Color.White;

            // NO llamar a CargarDatos() aquí: el usuario quiere que el filtrado
            // se aplique solo cuando presione el botón "Filtrar".
        }

        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                yield return c;
                foreach (var child in GetAllControls(c))
                    yield return child;
            }
        }

        // ---------------- Cargar Datos ----------------
        private void CargarDatos()
        {
            DateTime desde = dateTimePickerDesde.Value.Date;
            DateTime hasta = dateTimePickerHasta.Value.Date.AddDays(1).AddSeconds(-1);

            string query = @"
                    SELECT 
                        p.id_producto,
                        p.nombre,
                        p.categoria,
                        ISNULL(SUM(CASE WHEN v.fecha BETWEEN @desde AND @hasta THEN dp.cantidad ELSE 0 END), 0) AS nro_ventas,
                        p.estado
                    FROM Producto p
                    LEFT JOIN Detalle_Pedido dp ON dp.id_producto = p.id_producto
                    LEFT JOIN Pedido pe ON pe.id_pedido = dp.id_pedido
                    LEFT JOIN Ventas v ON v.id_pedido = pe.id_pedido
                    GROUP BY p.id_producto, p.nombre, p.categoria, p.estado
                ";

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@desde", desde);
                        cmd.Parameters.AddWithValue("@hasta", hasta);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                DataRow[] filasFiltradas = string.IsNullOrEmpty(GetFiltroExpresion(filtroActual)) ? dt.Select() : dt.Select(GetFiltroExpresion(filtroActual));
                DataTable dtFiltrado = dt.Clone();
                foreach (DataRow fila in filasFiltradas)
                    dtFiltrado.ImportRow(fila);

                dgvProductos.DataSource = dtFiltrado;
                ActualizarGrafico(dtFiltrado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private string GetFiltroExpresion(string filtro)
        {
            switch (filtro)
            {
                case "MAS_VENDIDOS": return "nro_ventas >= 6";
                case "MENOS_VENDIDOS": return "nro_ventas <= 5";
                case "ALTAS": return "estado = 'Disponible'";
                case "BAJAS": return "estado = 'No disponible'";
                default: return ""; // TODOS
            }
        }

        private void ActualizarGrafico(DataTable dt)
        {
            chart1.Series.Clear();

            var series = new Series("Ventas")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                // etiquetas fuera de la torta con estilo suave
                ["PieLabelStyle"] = "Outside",
                ["PieDrawingStyle"] = "SoftEdge",
                ["PieStartAngle"] = "270"
            };
            series.Label = "#VALX\n#PERCENT{P1}";
            series.LegendText = "#VALX (#VALY)";
            series["PieLabelStyle"] = "Outside";
            series.IsVisibleInLegend = true;

            chart1.Series.Add(series);

            // Recoger filas con ventas > 0 y ordenar descendente
            var filas = new List<DataRow>();
            foreach (DataRow row in dt.Rows)
            {
                int cantidad = row["nro_ventas"] == DBNull.Value ? 0 : Convert.ToInt32(row["nro_ventas"]);
                if (cantidad > 0) filas.Add(row);
            }

            filas.Sort((a, b) => Convert.ToInt32(b["nro_ventas"]).CompareTo(Convert.ToInt32(a["nro_ventas"])));

            if (filas.Count == 0)
            {
                // mostrar estado "sin datos" para que la torta no quede vacía
                int idx = series.Points.AddY(1);
                DataPoint p = series.Points[idx];
                p.AxisLabel = "Sin ventas";
                p.Label = "Sin ventas";
                p.Color = Color.LightGray;
                return;
            }

            int total = 0;
            foreach (var r in filas) total += Convert.ToInt32(r["nro_ventas"]);

            // Añadir puntos con etiquetas y tooltips
            foreach (var row in filas)
            {
                string nombre = row["nombre"].ToString();
                int cantidad = Convert.ToInt32(row["nro_ventas"]);
                int idx = series.Points.AddY(cantidad);
                DataPoint point = series.Points[idx];
                point.LegendText = nombre;
                point.Label = $"{nombre}: {cantidad} ({(cantidad * 100.0 / total):F1}%)";
                point.ToolTip = $"{nombre}: {cantidad} ventas";
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Aplicar el filtro seleccionado (ahora solo se carga al presionar Filtrar)
            CargarDatos();
        }
    }
}