using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gerente
{
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();

            // Validaciones
            textNombreP.KeyPress += SoloLetras;
            textCategoriaP.KeyPress += SoloLetras;
            textDescuentoP.KeyPress += SoloNumeros;
            textProvinciaP.KeyPress += SoloLetras;
            textEstadoP.KeyPress += SoloLetras;
            textPrecioP.KeyPress += SoloNumeros;

           CargarProductos();
        }

        // =========================
        // CONEXIÓN A BD
        // =========================
        private SqlConnection ObtenerConexion()
        {
          string cadena = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";
        return new SqlConnection(cadena);
        }

        // =========================
        // VALIDACIONES
        // =========================
        private void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }


        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

            // =========================
            // CARGAR PRODUCTOS EN GRID
            // =========================
             private void CargarProductos()
            {
              try
               {
                   using (SqlConnection conn = ObtenerConexion())
                   {
                       conn.Open();
                       string query = "SELECT * FROM Productos";
                       SqlDataAdapter da = new SqlDataAdapter(query, conn);
                       DataTable dt = new DataTable();
                       da.Fill(dt);
                       dgvProductos.DataSource = dt;
                   }
               }
               catch (Exception ex)
               {
                   MessageBox.Show("Error al cargar productos: " + ex.Message);
               }
           }

           // =========================
           // BOTÓN AGREGAR
           // =========================
           private void bAgregar_Click(object sender, EventArgs e)
           {
               if (string.IsNullOrWhiteSpace(textNombreP.Text) ||
                   string.IsNullOrWhiteSpace(textCategoriaP.Text) ||
                   string.IsNullOrWhiteSpace(textDescuentoP.Text) ||
                   string.IsNullOrWhiteSpace(textProvinciaP.Text) ||
                   string.IsNullOrWhiteSpace(textEstadoP.Text) ||
                   string.IsNullOrWhiteSpace(textPrecioP.Text))
               {
                   MessageBox.Show("Debe completar todos los campos antes de guardar.",
                                   "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return;
               }

               using (SqlConnection conn = ObtenerConexion())
               {
                   conn.Open();
                   string query = @"INSERT INTO Productos 
                                   (Nombre, Categoria, Descuento, Provincia, Estado, Precio) 
                                   VALUES (@Nombre, @Categoria, @Descuento, @Provincia, @Estado, @Precio)";
                   SqlCommand cmd = new SqlCommand(query, conn);
                   cmd.Parameters.AddWithValue("@Nombre", textNombreP.Text);
                   cmd.Parameters.AddWithValue("@Categoria", textCategoriaP.Text);
                   cmd.Parameters.AddWithValue("@Descuento", decimal.Parse(textDescuentoP.Text));
                   cmd.Parameters.AddWithValue("@Provincia", textProvinciaP.Text);
                   cmd.Parameters.AddWithValue("@Estado", textEstadoP.Text);
                   cmd.Parameters.AddWithValue("@Precio", decimal.Parse(textPrecioP.Text));
                   cmd.ExecuteNonQuery();
               }

               MessageBox.Show("Producto guardado con éxito.", "Éxito",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

               LimpiarFormulario();
               CargarProductos();
           }

           // =========================
           // BOTÓN MODIFICAR
           // =========================
           private void bModificar_Click(object sender, EventArgs e)
           {
               if (dgvProductos.CurrentRow == null) return;

               int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["Id"].Value);

               using (SqlConnection conn = ObtenerConexion())
               {
                   conn.Open();
                   string query = @"UPDATE Productos SET 
                                   Nombre=@Nombre, Categoria=@Categoria, Descuento=@Descuento,
                                   Provincia=@Provincia, Estado=@Estado, Precio=@Precio
                                   WHERE Id=@Id";
                   SqlCommand cmd = new SqlCommand(query, conn);
                   cmd.Parameters.AddWithValue("@Id", id);
                   cmd.Parameters.AddWithValue("@Nombre", textNombreP.Text);
                   cmd.Parameters.AddWithValue("@Categoria", textCategoriaP.Text);
                   cmd.Parameters.AddWithValue("@Descuento", decimal.Parse(textDescuentoP.Text));
                   cmd.Parameters.AddWithValue("@Provincia", textProvinciaP.Text);
                   cmd.Parameters.AddWithValue("@Estado", textEstadoP.Text);
                   cmd.Parameters.AddWithValue("@Precio", decimal.Parse(textPrecioP.Text));
                   cmd.ExecuteNonQuery();
               }

               MessageBox.Show("Producto modificado con éxito.", "Éxito",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

               CargarProductos();
           }

           // =========================
           // BOTÓN ELIMINAR
           // =========================
           private void bEliminar_Click(object sender, EventArgs e)
           {
               if (dgvProductos.CurrentRow == null) return;

               int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["Id"].Value);

               using (SqlConnection conn = ObtenerConexion())
               {
                   conn.Open();
                   string query = "DELETE FROM Productos WHERE Id=@Id";
                   SqlCommand cmd = new SqlCommand(query, conn);
                   cmd.Parameters.AddWithValue("@Id", id);
                   cmd.ExecuteNonQuery();
               }

               MessageBox.Show("Producto eliminado con éxito.", "Éxito",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

               CargarProductos();
           }

           // =========================
           // LIMPIAR FORMULARIO
           // =========================
           private void LimpiarFormulario()
           {
               textNombreP.Clear();
               textCategoriaP.Clear();
               textDescuentoP.Clear();
               textProvinciaP.Clear();
               textEstadoP.Clear();
               textPrecioP.Clear();
           }

           // =========================
           // AL SELECCIONAR FILA EN GRID
           // =========================
           private void dgvProductos_SelectionChanged(object sender, EventArgs e)
           {
               if (dgvProductos.CurrentRow != null)
               {
                   textNombreP.Text = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
                   textCategoriaP.Text = dgvProductos.CurrentRow.Cells["Categoria"].Value.ToString();
                   textDescuentoP.Text = dgvProductos.CurrentRow.Cells["Descuento"].Value.ToString();
                   textProvinciaP.Text = dgvProductos.CurrentRow.Cells["Provincia"].Value.ToString();
                   textEstadoP.Text = dgvProductos.CurrentRow.Cells["Estado"].Value.ToString();
                   textPrecioP.Text = dgvProductos.CurrentRow.Cells["Precio"].Value.ToString();
               }
           }

        }
    }


