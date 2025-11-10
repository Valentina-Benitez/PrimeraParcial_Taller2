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
        
        // Propósito: Inicializar componentes y asociar el evento de pintado personalizado para la grilla.
        public FormVentasAdmin()
        {
            InitializeComponent();
            dgvVentas.CellPainting += dgvVentas_CellPainting;
        }

        // Método: ObtenerConexion
        // Propósito: Crear y devolver una nueva SqlConnection conectada a la BD del restaurante.
        private SqlConnection ObtenerConexion()
        {
            return new SqlConnection(@"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True");
        }

        // Evento Load del formulario
        // Propósito: Configurar la grilla (no autogenerar columnas), cargar ventas y ajustar formato/columnas.
        private void FormVentasAdmin_Load(object sender, EventArgs e)
        {
            dgvVentas.AutoGenerateColumns = false;
            CargarVentas();
            dgvVentas.Columns["Total"].DefaultCellStyle.Format = "C2";

            // --- Agregar columna de botón "VerFactura" (siempre se añade desde aquí)
            DataGridViewButtonColumn btnVerFactura = new DataGridViewButtonColumn();
            btnVerFactura.Name = "VerFactura";
            btnVerFactura.HeaderText = "Factura";
            btnVerFactura.Text = "Ver";
            btnVerFactura.UseColumnTextForButtonValue = true;
            dgvVentas.Columns.Add(btnVerFactura);
        }

        // Método: CargarVentas
        // Propósito: Consultar la tabla Ventas (unida a Pedido, Cliente y Usuario) y poblar el DataGridView con los resultados.
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

        // Handler vacío para eventos de texto (pueden usarse para búsquedas)
        private void txtPedido_TextChanged(object sender, EventArgs e) { }
        private void txtMesa_TextChanged(object sender, EventArgs e) { }

        // Evento CellContentClick de dgvVentas
        // Propósito: Detectar clics sobre la columna de botón "VerFactura" y abrir el formulario con el detalle de pedido.
        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            string estadoActual = dgvVentas.Rows[e.RowIndex].Cells["TipoPago"].Value.ToString().ToLower();
            int pedidoId = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["nroPedido"].Value);

            if (dgvVentas.Columns[e.ColumnIndex].Name == "VerFactura")
            {
                object cellValue = dgvVentas.Rows[e.RowIndex].Cells["nroPedido"].Value;

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

        // Métodos auxiliares de validación de teclas (sin lógica adicional)
        private void txtVenta_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; }
        private void txtMesa_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; }
        private void txtPedido_KeyDown(object sender, KeyEventArgs e) { }
        private void txtPedido_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; }
        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; }
        private void txtEmpleado_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)) e.Handled = true; }
        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)) e.Handled = true; }
        private void txtPago_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)) e.Handled = true; }

        // Evento CellPainting personalizado
        // Propósito: Dibujar un estilo de botón personalizado para la columna "VerFactura".
        private void dgvVentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Verifica que sea la columna del botón y que no sea el encabezado
            if (e.ColumnIndex >= 0 && dgvVentas.Columns[e.ColumnIndex].Name == "VerFactura" && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);
                e.PaintContent(e.CellBounds);

                // Área del "botón" dentro de la celda (con margen)
                Rectangle rect = e.CellBounds;
                rect.Inflate(-4, -4);

                // Color celeste claro para el botón
                Color colorCeleste = Color.FromArgb(173, 216, 230); // LightBlue

                using (SolidBrush brush = new SolidBrush(colorCeleste))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }

                // Texto centrado "Ver"
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
