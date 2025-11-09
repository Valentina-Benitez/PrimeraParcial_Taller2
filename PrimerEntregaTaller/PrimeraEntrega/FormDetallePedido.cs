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
        // ===========================================================
        // CONSTRUCTOR DEL FORMULARIO
        // Configura la posición, eventos y comportamiento inicial
        // ===========================================================
        public FormDetallePedido()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent; // Centrar ventana al abrir
            this.Load += FormDetallePedido_Load; // Evento de carga del formulario
        }

        // Propiedad pública que recibe el ID del pedido a mostrar
        public int PedidoId { get; set; }

        // ===========================================================
        // CLASE INTERNA: ProductoDetalle
        // Representa una fila del detalle del pedido (nombre, cantidad, precio, total)
        // ===========================================================
        public class ProductoDetalle
        {
            public string Nombre { get; set; }   // Nombre del producto
            public int Cantidad { get; set; }    // Cantidad solicitada
            public decimal Precio { get; set; }  // Precio unitario
            public decimal Total { get; set; }   // Subtotal = Cantidad * Precio
        }

        // ===========================================================
        // EVENTO LOAD: se ejecuta al cargar el formulario
        // ===========================================================
        private void FormDetallePedido_Load(object sender, EventArgs e)
        {
            // Validar que se haya establecido un ID de pedido válido
            if (PedidoId <= 0)
            {
                MessageBox.Show("Error: El ID del pedido no es válido.");
                this.Close();
                return;
            }

            // Cargar los datos generales del pedido (estado, cliente, tipo de pago)
            CargarDatosPedido();

            // Obtener los productos correspondientes al pedido
            var listaDeProductos = ObtenerProductosDelPedido(PedidoId);

            // Calcular el total general del pedido sumando los subtotales
            decimal totalGeneral = listaDeProductos.Sum(x => x.Total);
            lblTotalValor.Text = totalGeneral.ToString("C2"); // Mostrar total en formato moneda

            // Configuración del DataGridView
            dataGridView1.AutoGenerateColumns = false;

            try
            {
                // Asignar los DataPropertyName según las propiedades de la clase ProductoDetalle
                dataGridView1.Columns["Nombre"].DataPropertyName = "Nombre";
                dataGridView1.Columns["Cantidad"].DataPropertyName = "Cantidad";
                dataGridView1.Columns["PrecioUnitario"].DataPropertyName = "Precio";
                dataGridView1.Columns["TotalLinea"].DataPropertyName = "Total";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR DE MAPEO DE COLUMNAS. Verifique el nombre de las columnas en el diseñador: " + ex.Message);
                return;
            }

            // Cargar los productos en la grilla
            dataGridView1.DataSource = listaDeProductos;
        }

        // ===========================================================
        // MÉTODO: ObtenerProductosDelPedido()
        // Consulta SQL que trae los productos asociados a un pedido
        // ===========================================================
        public List<ProductoDetalle> ObtenerProductosDelPedido(int pedidoId)
        {
            var lista = new List<ProductoDetalle>();

            using (SqlConnection con = new SqlConnection(
                @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True"))
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

                        // Cargar cada producto del pedido en la lista
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
                    MessageBox.Show("Error de Base de Datos o conversión: " + ex.Message);
                }
            }

            // Agrupa los productos repetidos sumando cantidades y totales
            var listaAgrupada = lista
                .GroupBy(x => x.Nombre)
                .Select(g => new ProductoDetalle
                {
                    Nombre = g.Key,
                    Cantidad = g.Sum(x => x.Cantidad),
                    Precio = g.First().Precio, // Se mantiene el mismo precio unitario
                    Total = g.Sum(x => x.Total)
                })
                .ToList();

            return listaAgrupada;
        }

        // ===========================================================
        // MÉTODO: CargarDatosPedido()
        // Obtiene y muestra la información general del pedido
        // ===========================================================
        private void CargarDatosPedido()
        {
            using (SqlConnection con = new SqlConnection(
                @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True"))
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
                        // Mostrar los datos en los labels del formulario
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

        // ===========================================================
        // EVENTOS DE INTERFAZ (sin lógica funcional específica)
        // ===========================================================
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblTipoPago_Click(object sender, EventArgs e) { }
        private void lblEstadoPedido_Click(object sender, EventArgs e) { }
        private void lblClientePedido_Click(object sender, EventArgs e) { }

        // ===========================================================
        // BOTÓN CERRAR: cierra el formulario de detalle
        // ===========================================================
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
