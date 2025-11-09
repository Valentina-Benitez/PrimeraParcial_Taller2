using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeraEntrega
{
    public partial class FormVentasAdmin : Form
    {
        public FormVentasAdmin()
        {
            InitializeComponent();
            dgvVentas.CellPainting += dgvVentas_CellPainting;

        }

        private SqlConnection ObtenerConexion()
        {
            return new SqlConnection(@"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True");
        }

        private void FormVentasAdmin_Load(object sender, EventArgs e)
        {
            dgvVentas.AutoGenerateColumns = false;
            CargarVentas();
            dgvVentas.Columns["Total"].DefaultCellStyle.Format = "C2";

            // --- Agregar columna de botón ---
            DataGridViewButtonColumn btnVerFactura = new DataGridViewButtonColumn();
            btnVerFactura.Name = "VerFactura";
            btnVerFactura.HeaderText = "Factura";
            btnVerFactura.Text = "Ver";
            btnVerFactura.UseColumnTextForButtonValue = true;
            dgvVentas.Columns.Add(btnVerFactura);


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
                        c.dni AS [Cliente],
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

        
        private void txtPedido_TextChanged(object sender, EventArgs e) { }
        private void txtMesa_TextChanged(object sender, EventArgs e) { }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e) {
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
        private void txtVenta_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; }
        private void txtMesa_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; }
        private void txtPedido_KeyDown(object sender, KeyEventArgs e) { }
        private void txtPedido_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; }
        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; }
        private void txtEmpleado_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)) e.Handled = true; }
        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)) e.Handled = true; }
        private void txtPago_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)) e.Handled = true; }

        private void dgvVentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Verifica que sea la columna del botón y que no sea el encabezado
            if (e.ColumnIndex >= 0 && dgvVentas.Columns[e.ColumnIndex].Name == "VerFactura" && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);
                e.PaintContent(e.CellBounds);

                // Área del botón dentro de la celda
                Rectangle rect = e.CellBounds;
                rect.Inflate(-4, -4);

                // Color celeste claro
                Color colorCeleste = Color.FromArgb(173, 216, 230); // LightBlue

                using (SolidBrush brush = new SolidBrush(colorCeleste))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }

                // Texto centrado
                TextRenderer.DrawText(
                    e.Graphics,
                    "Ver",
                    e.CellStyle.Font,
                    rect,
                    Color.Black,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                e.Handled = true;
            }
        }

    }

}
