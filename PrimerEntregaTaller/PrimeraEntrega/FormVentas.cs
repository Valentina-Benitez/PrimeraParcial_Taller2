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
            return new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True");
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
           // dgvVentas.Columns["Total"].DefaultCellStyle.Format = "C2";
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
                FORMAT(v.fecha, 'yyyy-MM') AS Periodo,
                DATENAME(MONTH, v.fecha) AS Mes,
                SUM(v.total) AS Total
            FROM Ventas v
            WHERE v.fecha BETWEEN @desde AND @hasta
            GROUP BY FORMAT(v.fecha, 'yyyy-MM'), DATENAME(MONTH, v.fecha), MONTH(v.fecha)
            ORDER BY FORMAT(v.fecha, 'yyyy-MM');";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@desde", dtpDesde.Value.Date);
                    cmd.Parameters.AddWithValue("@hasta", dtpHasta.Value.Date);

                    SqlDataReader rd = cmd.ExecuteReader();

                    chartVentas.Series.Clear();
                    chartVentas.Series.Add("Total Ventas");

                    while (rd.Read())
                    {
                        chartVentas.Series["Total Ventas"].Points
                            .AddXY(rd["Mes"].ToString(), Convert.ToDecimal(rd["Total"]));
                    }
                }

                // Estilo visual
                var series = chartVentas.Series["Total Ventas"];
                series.ChartType = SeriesChartType.Column;
                series.Color = Color.FromArgb(0, 122, 204);
                series.IsValueShownAsLabel = true;

                chartVentas.ChartAreas[0].AxisX.Interval = 1;
                chartVentas.ChartAreas[0].BackColor = Color.White;
                chartVentas.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar gráfico: " + ex.Message);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarVentas();
            CargarGraficoVentas();

        }
    }
}
