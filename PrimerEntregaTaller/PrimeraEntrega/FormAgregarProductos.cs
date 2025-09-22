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

                    // ¡MEJORA! Reemplazamos los Labels por Botones
                    foreach (DataRow fila in tabla.Rows)
                    {
                        string nombre = fila["nombre"].ToString();
                        decimal precio = Convert.ToDecimal(fila["precio"]);
                        int idProducto = Convert.ToInt32(fila["id_producto"]);

                        // Panel contenedor tipo fila
                        TableLayoutPanel filaProducto = new TableLayoutPanel();
                        filaProducto.ColumnCount = 3;
                        filaProducto.RowCount = 1;
                        filaProducto.Width = flowLayoutPanel1.Width - 25;
                        filaProducto.Height = 35;
                        filaProducto.Margin = new Padding(2);
                        filaProducto.BackColor = Color.WhiteSmoke;

                        // Configurar columnas (70% nombre, 20% precio, 10% botón)
                        filaProducto.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
                        filaProducto.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                        filaProducto.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));

                        // Nombre
                        Label lblNombre = new Label();
                        lblNombre.Text = nombre;
                        lblNombre.Dock = DockStyle.Fill;
                        lblNombre.TextAlign = ContentAlignment.MiddleLeft;
                        lblNombre.Font = new Font("Segoe UI", 10, FontStyle.Regular);

                        // Precio
                        Label lblPrecio = new Label();
                        lblPrecio.Text = $"${precio}";
                        lblPrecio.Dock = DockStyle.Fill;
                        lblPrecio.TextAlign = ContentAlignment.MiddleCenter;
                        lblPrecio.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                        // Botón agregar
                        Button btnAgregar = new Button();
                        btnAgregar.Text = "+";
                        btnAgregar.Tag = idProducto;
                        btnAgregar.Dock = DockStyle.Fill;
                        btnAgregar.Click += BtnProducto_Click;

                        // Agregar controles al panel fila
                        filaProducto.Controls.Add(lblNombre, 0, 0);
                        filaProducto.Controls.Add(lblPrecio, 1, 0);
                        filaProducto.Controls.Add(btnAgregar, 2, 0);

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

        private void BtnProducto_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            
        }

        // Aquí van los manejadores de eventos existentes para los controles
        private void txtBuscaP_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Puedes dejarlo vacío o borrarlo si no hace nada
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscaP_TextChanged_1(object sender, EventArgs e)
        {
            CargarProductos(txtBuscaP.Text.Trim());
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
