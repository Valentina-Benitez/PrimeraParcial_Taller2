using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace PrimeraEntrega
{
    public partial class FormDetallePedido : Form
    {
        public FormDetallePedido()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            // Suscribir el evento Load para que se ejecute la lógica de carga
            this.Load += FormDetallePedido_Load;
        }

        public int PedidoId { get; set; }

        public class ProductoDetalle
        {
            // Propiedades que se usarán como DataPropertyName
            public string Nombre { get; set; } 
            public int Cantidad { get; set; } 
            public decimal Precio { get; set; }  // Precio Unitario (Calculado)
            public decimal Total { get; set; }   // Total/Subtotal de la línea
        }

        private void FormDetallePedido_Load(object sender, EventArgs e)
        {
            if (PedidoId <= 0)
            {
                MessageBox.Show("Error: El ID del pedido no es válido.");
                this.Close();
                return;
            }

            CargarDatosPedido();

            var listaDeProductos = ObtenerProductosDelPedido(PedidoId);
            // ✅ Calcular el total sumando todos los subtotales
            decimal totalGeneral = listaDeProductos.Sum(x => x.Total);

            // ✅ Mostrar el total abajo
            lblTotalValor.Text = totalGeneral.ToString("C2");

            // Desactivar Autogenerar columnas 
            dataGridView1.AutoGenerateColumns = false;

            try
            {
                // Mapear los nombres de columna del DGV (propiedad 'Name' en el diseñador)
                dataGridView1.Columns["Nombre"].DataPropertyName = "Nombre";
                dataGridView1.Columns["Cantidad"].DataPropertyName = "Cantidad";
                dataGridView1.Columns["PrecioUnitario"].DataPropertyName = "Precio";
                dataGridView1.Columns["TotalLinea"].DataPropertyName = "Total";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR DE MAPEO DE COLUMNAS. Verifique el nombre (Propiedad 'Name') de las columnas en el diseñador: " + ex.Message);
                return;
            }

            // Asignar la lista al DataGridView
            dataGridView1.DataSource = listaDeProductos;
        }

        public List<ProductoDetalle> ObtenerProductosDelPedido(int pedidoId)
        {
            var lista = new List<ProductoDetalle>();

            using (SqlConnection con = new SqlConnection(@"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True"))
            {
                try
                {
                    con.Open();
                    string query = @"
                SELECT 
                    p.nombre, 
                    dp.cantidad, 
                    (dp.subtotal / NULLIF(dp.cantidad, 0)) AS PrecioUnitario, 
                    dp.subtotal AS TotalLinea
                FROM Detalle_Pedido dp
                INNER JOIN Producto p ON dp.id_producto = p.id_producto
                WHERE dp.id_pedido = @pedidoId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@pedidoId", pedidoId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            lista.Add(new ProductoDetalle
                            {
                                Nombre = reader["nombre"].ToString(),
                                Cantidad = Convert.ToInt32(reader["cantidad"]),
                                Precio = Convert.ToDecimal(reader["PrecioUnitario"], CultureInfo.InvariantCulture),
                                Total = Convert.ToDecimal(reader["TotalLinea"], CultureInfo.InvariantCulture)
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de Base de Datos/Conversión: " + ex.Message);
                }
            }

            // ✅ AGRUPAMOS POR PRODUCTO
            var listaAgrupada = lista
                .GroupBy(x => x.Nombre)
                .Select(g => new ProductoDetalle
                {
                    Nombre = g.Key,
                    Cantidad = g.Sum(x => x.Cantidad),
                    Precio = g.First().Precio, // Mismo precio para todos
                    Total = g.Sum(x => x.Total)
                })
                .ToList();

            return listaAgrupada;
        }

        private void CargarDatosPedido()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True"))
            {
                try
                {
                    con.Open();

                    string query = @"
                SELECT 
                    p.estado, 
                    c.dni,
                    ISNULL(v.tipo_pago, ' --- ') AS tipo_pago
                FROM Pedido p
                JOIN Cliente c ON p.id_cliente = c.id_cliente
                LEFT JOIN Ventas v ON p.id_pedido = v.id_pedido
                WHERE p.id_pedido = @id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", PedidoId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblEstadoPedido.Text = "Estado: " + reader["estado"].ToString();
                        lblClientePedido.Text = "Cliente DNI: " + reader["dni"].ToString();
                        lblTipoPago.Text = "Tipo Pago: " + reader["tipo_pago"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos del pedido: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTipoPago_Click(object sender, EventArgs e)
        {

        }

        private void lblEstadoPedido_Click(object sender, EventArgs e)
        {

        }

        private void lblClientePedido_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}