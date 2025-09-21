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

                    // ¡MEJORA! Agregamos 'id_producto' a la consulta
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

                        Button btnProducto = new Button();
                        btnProducto.Text = $"{nombre}\n${precio}";
                        btnProducto.Tag = idProducto;
                        btnProducto.Size = new System.Drawing.Size(150, 60);
                        btnProducto.BackColor = System.Drawing.Color.LightGreen;
                        btnProducto.Margin = new Padding(5);
                        btnProducto.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
                        btnProducto.FlatStyle = FlatStyle.Flat;
                        btnProducto.FlatAppearance.BorderSize = 0;
                        btnProducto.Cursor = Cursors.Hand;

                        btnProducto.Click += BtnProducto_Click;

                        flowLayoutPanel1.Controls.Add(btnProducto);
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
            if (btn != null)
            {
                int idProducto = (int)btn.Tag;
                string[] infoProducto = btn.Text.Split('\n');
                string nombre = infoProducto[0];
                string precio = infoProducto[1];

                MessageBox.Show($"Producto seleccionado:\nID: {idProducto}\nNombre: {nombre}\nPrecio: {precio}");
            }
        }

        // Aquí van los manejadores de eventos existentes para los controles
        private void txtBuscaP_TextChanged(object sender, EventArgs e)
        {
            CargarProductos(txtBuscaP.Text.Trim());
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
    }
}
