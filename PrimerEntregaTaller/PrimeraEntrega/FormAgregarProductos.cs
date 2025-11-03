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

        public FormAgregarProductos()
        {
            InitializeComponent(); // Esto lo maneja el Designer.cs
            this.Load += FormAgregarProductos_Load;
        }

        private void FormAgregarProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
            ActualizarTotal();


            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;

        }

        private void CargarProductos(string filtro = "")
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(@"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True"))
                {
                    conexion.Open();

                    
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

                    flowLayoutPanel1.Controls.Clear();

                   
                    foreach (DataRow fila in tabla.Rows)
                    {
                        string nombre = fila["nombre"].ToString();
                        decimal precio = Convert.ToDecimal(fila["precio"]);
                        int idProducto = Convert.ToInt32(fila["id_producto"]);

                        // Panel contenedor tipo fila
                        TableLayoutPanel filaProducto = new TableLayoutPanel();
                        filaProducto.ColumnCount = 4;
                        filaProducto.RowCount = 1;
                        filaProducto.Width = flowLayoutPanel1.Width - 25;
                        filaProducto.Height = 40;
                        filaProducto.Margin = new Padding(3);
                        filaProducto.BackColor = Color.White;
                        filaProducto.BorderStyle = BorderStyle.FixedSingle;

                        // Configurar columnas (55% nombre, 20% precio, 15% cantidad, 10% botón)
                        filaProducto.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
                        filaProducto.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                        filaProducto.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
                        filaProducto.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));

                        // Nombre
                        Label lblNombre = new Label();
                        lblNombre.Text = nombre;
                        lblNombre.Dock = DockStyle.Fill;
                        lblNombre.TextAlign = ContentAlignment.MiddleLeft;
                        lblNombre.Font = new Font("Segoe UI", 10);

                        // Precio
                        Label lblPrecio = new Label();
                        lblPrecio.Text = precio.ToString("C0");
                        lblPrecio.Dock = DockStyle.Fill;
                        lblPrecio.TextAlign = ContentAlignment.MiddleCenter;
                        lblPrecio.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                        // Cantidad NumericUpDown
                        NumericUpDown nudCantidad = new NumericUpDown();
                        nudCantidad.Minimum = 1;
                        nudCantidad.Maximum = 50;
                        nudCantidad.Value = 1;
                        nudCantidad.Dock = DockStyle.Fill;
                        nudCantidad.Tag = idProducto;

                        // Botón agregar
                        Button btnAgregar = new Button();
                        btnAgregar.Text = "+";
                        btnAgregar.Dock = DockStyle.Fill;
                        btnAgregar.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                        btnAgregar.ForeColor = Color.White;
                        btnAgregar.BackColor = Color.LightGreen;  
                        btnAgregar.FlatStyle = FlatStyle.Flat;
                        btnAgregar.FlatAppearance.BorderSize = 0;
                        btnAgregar.Cursor = Cursors.Hand;

                        // Sombra o efecto hover opcional
                        btnAgregar.MouseEnter += (s, ev) => btnAgregar.BackColor = Color.FromArgb(100, 200, 100);
                        btnAgregar.MouseLeave += (s, ev) => btnAgregar.BackColor = Color.FromArgb(144, 238, 144);

                        btnAgregar.Tag = new Tuple<int, Label, NumericUpDown>(idProducto, lblPrecio, nudCantidad);
                        btnAgregar.Click += BtnProducto_Click;


                        // Agregar controles al panel fila
                        filaProducto.Controls.Add(lblNombre, 0, 0);
                        filaProducto.Controls.Add(lblPrecio, 1, 0);
                        filaProducto.Controls.Add(nudCantidad, 2, 0);
                        filaProducto.Controls.Add(btnAgregar, 3, 0);

                        // Agregar fila al FlowLayoutPanel
                        flowLayoutPanel1.Controls.Add(filaProducto);

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        public List<ProductoSeleccionado> ProductosSeleccionados { get; private set; } = new List<ProductoSeleccionado>();

        private void BtnProducto_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var data = (Tuple<int, Label, NumericUpDown>)btn.Tag;

            int idProducto = data.Item1;
            decimal precio = decimal.Parse(data.Item2.Text.Replace("$", ""));
            int cantidad = (int)data.Item3.Value;

            string nombre = ((Label)((TableLayoutPanel)btn.Parent).Controls[0]).Text;

            // ✅ Si ya existe el producto en la lista, solo actualizamos cantidad
            var existente = ProductosSeleccionados.FirstOrDefault(p => p.IdProducto == idProducto);
            if (existente != null)
            {
                existente.Cantidad += cantidad;
            }
            else
            {
                ProductosSeleccionados.Add(new ProductoSeleccionado
                {
                    IdProducto = idProducto,
                    Nombre = nombre,
                    Precio = precio, // Precio unitario
                    Cantidad = cantidad
                });
            }

            MessageBox.Show($"{nombre} x{cantidad} agregado ✅");
            ActualizarTotal();

        }




        // Aquí van los manejadores de eventos existentes para los controles
        private void txtBuscaP_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void label1_Click(object sender, EventArgs e)
        {
            // Puedes dejarlo vacío o borrarlo si no hace nada
        }

        private void txtBuscaP_TextChanged_1(object sender, EventArgs e)
        {
            CargarProductos(txtBuscaP.Text.Trim());
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ActualizarTotal()
        {
            decimal total = ProductosSeleccionados.Sum(p => p.Cantidad * p.Precio);
            txtTotal.Text = total.ToString("C2", new System.Globalization.CultureInfo("es-AR"));
        }

        // public List<ProductoSeleccionado> ProductosSeleccionados { get; private set; } = new List<ProductoSeleccionado>();

    }
}
