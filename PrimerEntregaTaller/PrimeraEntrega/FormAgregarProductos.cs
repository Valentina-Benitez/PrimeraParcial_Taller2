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

namespace PrimeraEntrega
{
    public partial class FormAgregarProductos : Form
    {
        // Lista de productos seleccionados (se llena cuando el usuario agrega productos)
        public List<ProductoSeleccionado> ProductosSeleccionados { get; private set; } = new List<ProductoSeleccionado>();

        public FormAgregarProductos()
        {
            InitializeComponent(); // Inicializa los componentes visuales (manejado por el diseñador)
            this.Load += FormAgregarProductos_Load; // Asocia el evento Load al método que carga los productos
        }

        // ===========================================================
        // EVENTO LOAD: se ejecuta al abrir el formulario
        // Carga los productos desde la base de datos y prepara el panel
        // ===========================================================
        private void FormAgregarProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();  // Carga los productos desde la base de datos
            ActualizarTotal();  // Calcula el total inicial (0)

            // Configura el contenedor de los productos
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown; // Acomoda las filas de arriba hacia abajo
        }

        // ===========================================================
        // MÉTODO: CargarProductos()
        // Obtiene los productos desde la base de datos y los muestra
        // dinámicamente en el FlowLayoutPanel como filas con botones
        // ===========================================================
        private void CargarProductos(string filtro = "")
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(@"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True"))
                {
                    conexion.Open();

                    // Consulta SQL (con opción de filtro por nombre)
                    string consulta = "SELECT id_producto, nombre, precio FROM producto";
                    if (!string.IsNullOrEmpty(filtro))
                    {
                        consulta += " WHERE nombre LIKE @filtro";
                    }

                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
                    if (!string.IsNullOrEmpty(filtro))
                    {
                        adaptador.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    }

                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    // Limpia el contenedor antes de volver a cargar
                    flowLayoutPanel1.Controls.Clear();

                    // Recorre todos los productos de la tabla y los muestra en forma de fila
                    foreach (DataRow fila in tabla.Rows)
                    {
                        string nombre = fila["nombre"].ToString();
                        decimal precio = Convert.ToDecimal(fila["precio"]);
                        int idProducto = Convert.ToInt32(fila["id_producto"]);

                        // --- Crea una fila visual para el producto ---
                        TableLayoutPanel filaProducto = new TableLayoutPanel();
                        filaProducto.ColumnCount = 4;
                        filaProducto.RowCount = 1;
                        filaProducto.Width = flowLayoutPanel1.Width - 25;
                        filaProducto.Height = 40;
                        filaProducto.Margin = new Padding(3);
                        filaProducto.BackColor = Color.White;
                        filaProducto.BorderStyle = BorderStyle.FixedSingle;

                        // Configura proporción de columnas (nombre, precio, cantidad, botón)
                        filaProducto.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
                        filaProducto.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                        filaProducto.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
                        filaProducto.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));

                        // --- Nombre del producto ---
                        Label lblNombre = new Label();
                        lblNombre.Text = nombre;
                        lblNombre.Dock = DockStyle.Fill;
                        lblNombre.TextAlign = ContentAlignment.MiddleLeft;
                        lblNombre.Font = new Font("Segoe UI", 10);

                        // --- Precio ---
                        Label lblPrecio = new Label();
                        lblPrecio.Text = precio.ToString("C0");
                        lblPrecio.Dock = DockStyle.Fill;
                        lblPrecio.TextAlign = ContentAlignment.MiddleCenter;
                        lblPrecio.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                        // --- Selector de cantidad ---
                        NumericUpDown nudCantidad = new NumericUpDown();
                        nudCantidad.Minimum = 1;
                        nudCantidad.Maximum = 50;
                        nudCantidad.Value = 1;
                        nudCantidad.Dock = DockStyle.Fill;
                        nudCantidad.Tag = idProducto;

                        // --- Botón para agregar el producto ---
                        Button btnAgregar = new Button();
                        btnAgregar.Text = "+";
                        btnAgregar.Dock = DockStyle.Fill;
                        btnAgregar.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                        btnAgregar.ForeColor = Color.White;
                        btnAgregar.BackColor = Color.LightGreen;
                        btnAgregar.FlatStyle = FlatStyle.Flat;
                        btnAgregar.FlatAppearance.BorderSize = 0;
                        btnAgregar.Cursor = Cursors.Hand;

                        // Efectos visuales al pasar el mouse
                        btnAgregar.MouseEnter += (s, ev) => btnAgregar.BackColor = Color.FromArgb(100, 200, 100);
                        btnAgregar.MouseLeave += (s, ev) => btnAgregar.BackColor = Color.FromArgb(144, 238, 144);

                        // Guarda información útil dentro del botón
                        btnAgregar.Tag = new Tuple<int, Label, NumericUpDown>(idProducto, lblPrecio, nudCantidad);
                        btnAgregar.Click += BtnProducto_Click;

                        // Agrega los controles a la fila
                        filaProducto.Controls.Add(lblNombre, 0, 0);
                        filaProducto.Controls.Add(lblPrecio, 1, 0);
                        filaProducto.Controls.Add(nudCantidad, 2, 0);
                        filaProducto.Controls.Add(btnAgregar, 3, 0);

                        // Finalmente agrega la fila al contenedor principal
                        flowLayoutPanel1.Controls.Add(filaProducto);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        // ===========================================================
        // EVENTO: Al hacer clic en el botón "+"
        // Agrega el producto seleccionado a la lista de compra
        // ===========================================================
        private void BtnProducto_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var data = (Tuple<int, Label, NumericUpDown>)btn.Tag;

            int idProducto = data.Item1;
            decimal precio = decimal.Parse(data.Item2.Text.Replace("$", ""));
            int cantidad = (int)data.Item3.Value;

            string nombre = ((Label)((TableLayoutPanel)btn.Parent).Controls[0]).Text;

            // Si el producto ya estaba agregado, solo actualiza la cantidad
            var existente = ProductosSeleccionados.FirstOrDefault(p => p.IdProducto == idProducto);
            if (existente != null)
            {
                existente.Cantidad += cantidad;
            }
            else
            {
                // Si es un producto nuevo, lo agrega a la lista
                ProductosSeleccionados.Add(new ProductoSeleccionado
                {
                    IdProducto = idProducto,
                    Nombre = nombre,
                    Precio = precio,
                    Cantidad = cantidad
                });
            }

            MessageBox.Show($"{nombre} x{cantidad} agregado ✅");
            ActualizarTotal(); // Actualiza el total mostrado
        }

        // ===========================================================
        // EVENTOS VARIOS (de diseño o sin lógica importante)
        // ===========================================================
        private void txtBuscaP_TextChanged(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { this.Close(); }
        private void label1_Click(object sender, EventArgs e) { }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        // Al escribir en el cuadro de búsqueda, recarga los productos filtrados
        private void txtBuscaP_TextChanged_1(object sender, EventArgs e)
        {
            CargarProductos(txtBuscaP.Text.Trim());
        }

        // ===========================================================
        // MÉTODO: ActualizarTotal()
        // Recalcula el importe total de los productos seleccionados
        // ===========================================================
        private void ActualizarTotal()
        {
            decimal total = ProductosSeleccionados.Sum(p => p.Cantidad * p.Precio);
            txtTotal.Text = total.ToString("C2", new System.Globalization.CultureInfo("es-AR"));
        }
    }
}
