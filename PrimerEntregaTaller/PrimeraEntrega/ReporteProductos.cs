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
        // ==============================================================
        // VARIABLE DE FILTRO ACTUAL
        // Indica qué tipo de filtro está aplicado al reporte.
        // Ej: "MAS_VENDIDOS", "MENOS_VENDIDOS", "ALTAS", "BAJAS", "MES"
        // ==============================================================
        private string filtroActual = "TODOS";

        // ==============================================================
        // CONSTRUCTOR PRINCIPAL
        // Configura el DataGridView, el gráfico y los eventos de los botones.
        // ==============================================================
        public ReporteProductos()
        {
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;
            ConfigurarGrid();
            ConfigurarGrafico("Ventas por Producto");

            // ---------------- SUSCRIPCIÓN DE EVENTOS ----------------
            btnMasVendidos.Click += (s, e) => CambiarFiltro("MAS_VENDIDOS", btnMasVendidos);
            btnMenosVendidos.Click += (s, e) => CambiarFiltro("MENOS_VENDIDOS", btnMenosVendidos);
            btnAltas.Click += (s, e) => CambiarFiltro("ALTAS", btnAltas);
            btnBajas.Click += (s, e) => CambiarFiltro("BAJAS", btnBajas);
            btnMes.Click += (s, e) => CambiarFiltro("MES", btnMes);

            // Actualizar automáticamente al cambiar las fechas
            dateTimePickerDesde.ValueChanged += (s, e) => CargarDatos();
            dateTimePickerHasta.ValueChanged += (s, e) => CargarDatos();

            // Cargar datos al iniciar el formulario
            CargarDatos();
        }

        // ==============================================================
        // MÉTODO: ObtenerConexion()
        // Devuelve una conexión SQL lista para usar.
        // ==============================================================
        private SqlConnection ObtenerConexion()
        {
            string cadena = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";
            return new SqlConnection(cadena);
        }

        // ==============================================================
        // MÉTODO: ConfigurarGrid()
        // Define las columnas del DataGridView con sus nombres y propiedades.
        // ==============================================================
        private void ConfigurarGrid()
        {
            dgvProductos.Columns.Clear();
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nombres", HeaderText = "Nombre", DataPropertyName = "nombre" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "categorias", HeaderText = "Categoría", DataPropertyName = "categoria" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "ventas", HeaderText = "Nro de Ventas", DataPropertyName = "nro_ventas" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "estado", HeaderText = "Estado", DataPropertyName = "estado" });
        }

        // ==============================================================
        // MÉTODO: ConfigurarGrafico()
        // Inicializa el gráfico con título, área, leyenda y estilo.
        // ==============================================================
        private void ConfigurarGrafico(string titulo)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add(titulo);

            ChartArea area = new ChartArea("MainArea");
            area.Position = new ElementPosition(8, 8, 70, 84);
            area.BackColor = Color.White;
            area.Area3DStyle.Enable3D = true;
            area.Area3DStyle.Inclination = 40;
            chart1.ChartAreas.Add(area);

            chart1.BackColor = Color.White;
            chart1.Legends.Clear();

            Legend legend = new Legend("Leyenda")
            {
                Docking = Docking.Right,
                Alignment = StringAlignment.Center,
                LegendStyle = LegendStyle.Table
            };
            legend.Font = new Font("Segoe UI", 9);
            chart1.Legends.Add(legend);

            chart1.Palette = ChartColorPalette.Pastel;
            chart1.AntiAliasing = AntiAliasingStyles.Graphics;
        }

        // ==============================================================
        // MÉTODO: CambiarFiltro()
        // Cambia el filtro activo y actualiza la vista visual de los botones.
        // ==============================================================
        private void CambiarFiltro(string filtro, Button boton)
        {
            filtroActual = filtro;

            // Restaura colores de todos los botones
            foreach (Control c in GetAllControls(this))
            {
                if (c is Button btn && btn != boton)
                {
                    btn.BackColor = SystemColors.Control;
                    btn.ForeColor = Color.Black;
                }
            }

            // Destaca el botón del filtro actual
            boton.BackColor = Color.SteelBlue;
            boton.ForeColor = Color.White;

            // Actualiza los datos según el filtro
            CargarDatos();
        }

        // ==============================================================
        // MÉTODO: GetAllControls()
        // Devuelve todos los controles del formulario (útil para recorrer botones).
        // ==============================================================
        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                yield return c;
                foreach (var child in GetAllControls(c))
                    yield return child;
            }
        }

        // ==============================================================
        // MÉTODO: CargarDatos()
        // Consulta SQL que une Producto, Pedido, Detalle_Pedido y Ventas.
        // Calcula el total de ventas por producto y aplica el filtro activo.
        // ==============================================================
        private void CargarDatos()
        {
            DateTime desde = dateTimePickerDesde.Value.Date;
            DateTime hasta = dateTimePickerHasta.Value.Date.AddDays(1).AddSeconds(-1);

            string query = @"
                SELECT 
                    p.nombre,
                    p.categoria,
                    ISNULL(SUM(CASE WHEN v.fecha BETWEEN @desde AND @hasta THEN dp.cantidad ELSE 0 END), 0) AS nro_ventas,
                    p.estado,
                    MAX(v.fecha) AS fechaventa
                FROM Producto p
                LEFT JOIN Detalle_Pedido dp ON dp.id_producto = p.id_producto
                LEFT JOIN Pedido pe ON pe.id_pedido = dp.id_pedido
                LEFT JOIN Ventas v ON v.id_pedido = pe.id_pedido
                GROUP BY p.id_producto, p.nombre, p.categoria, p.estado
                ORDER BY nro_ventas DESC";

            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@desde", desde);
                        cmd.Parameters.AddWithValue("@hasta", hasta);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }

                // Aplica el filtro activo
                DataTable dtFiltrado = AplicarFiltro(dt);

                // Actualiza el grid y el gráfico
                dgvProductos.DataSource = dtFiltrado;
                ActualizarGrafico(dtFiltrado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        // ==============================================================
        // MÉTODO: AplicarFiltro()
        // Filtra la tabla según el tipo de filtro seleccionado.
        // ==============================================================
        private DataTable AplicarFiltro(DataTable dt)
        {
            DataTable filtrado = dt.Clone();

            foreach (DataRow row in dt.Rows)
            {
                bool incluir = false;

                switch (filtroActual)
                {
                    case "MAS_VENDIDOS":
                        incluir = Convert.ToInt32(row["nro_ventas"]) >= 6;
                        break;

                    case "MENOS_VENDIDOS":
                        incluir = Convert.ToInt32(row["nro_ventas"]) <= 5;
                        break;

                    case "ALTAS":
                        {
                            string estado = row["estado"].ToString().Trim().ToLower();
                            incluir = estado.Contains("disponible") || estado.Contains("alta") ||
                                      estado.Contains("activo") || estado == "1" || estado == "true";
                            break;
                        }

                    case "BAJAS":
                        {
                            string estado = row["estado"].ToString().Trim().ToLower();
                            incluir = estado.Contains("no disponible") || estado.Contains("baja") ||
                                      estado.Contains("inactivo") || estado == "0" || estado == "false";
                            break;
                        }

                    case "MES":
                        if (row["fechaventa"] != DBNull.Value)
                        {
                            DateTime fecha = Convert.ToDateTime(row["fechaventa"]);
                            incluir = fecha.Month == DateTime.Now.Month && fecha.Year == DateTime.Now.Year;
                        }
                        break;

                    default:
                        incluir = true;
                        break;
                }

                if (incluir)
                    filtrado.ImportRow(row);
            }

            return filtrado;
        }

        // ==============================================================
        // MÉTODO: ActualizarGrafico()
        // Crea un gráfico circular con las ventas por producto.
        // ==============================================================
        private void ActualizarGrafico(DataTable dt)
        {
            chart1.Series.Clear();
            ConfigurarGrafico("Ventas por Producto");

            Series series = new Series("Ventas")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                ["PieLabelStyle"] = "Outside",
                ["PieDrawingStyle"] = "SoftEdge",
                ["PieStartAngle"] = "270"
            };

            chart1.Series.Add(series);

            // Solo incluir productos con ventas
            var filas = new List<DataRow>();
            foreach (DataRow row in dt.Rows)
            {
                int cantidad = row["nro_ventas"] == DBNull.Value ? 0 : Convert.ToInt32(row["nro_ventas"]);
                if (cantidad > 0) filas.Add(row);
            }

            // Si no hay ventas, mostrar un gráfico vacío
            if (filas.Count == 0)
            {
                int idx = series.Points.AddY(1);
                DataPoint p = series.Points[idx];
                p.AxisLabel = "Sin ventas";
                p.Label = "Sin ventas";
                p.Color = Color.LightGray;
                return;
            }

            // Calcular el total general
            int total = 0;
            foreach (var r in filas) total += Convert.ToInt32(r["nro_ventas"]);

            // Añadir puntos al gráfico con porcentajes
            foreach (var row in filas)
            {
                string nombre = row["nombre"].ToString();
                int cantidad = Convert.ToInt32(row["nro_ventas"]);
                int idx = series.Points.AddY(cantidad);

                DataPoint point = series.Points[idx];
                point.LegendText = nombre;
                point.Label = $"{nombre}\n{(cantidad * 100.0 / total):F1}%";
                point.ToolTip = $"{nombre}: {cantidad} ventas";
            }
        }
    }
}
