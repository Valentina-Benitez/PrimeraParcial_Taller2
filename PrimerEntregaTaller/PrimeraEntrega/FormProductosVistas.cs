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
    public partial class FormProductosVistas : Form
    {

        public FormProductosVistas()
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
        private SqlConnection ObtenerConexion()
        {
            string cadena = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";
            return new SqlConnection(cadena);
        }

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

        private void CargarProductos()
        {
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT * FROM Producto";
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
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            // Validar que al menos un campo tenga valor
            if (string.IsNullOrWhiteSpace(textNombreP.Text) &&
        string.IsNullOrWhiteSpace(textCategoriaP.Text) &&
        string.IsNullOrWhiteSpace(textDescuentoP.Text) &&
        string.IsNullOrWhiteSpace(textProvinciaP.Text) &&
        string.IsNullOrWhiteSpace(textEstadoP.Text) &&
        string.IsNullOrWhiteSpace(textPrecioP.Text))
            {
                MessageBox.Show("Por favor, complete al menos un campo para realizar la búsqueda.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Construir la consulta SQL dinámica
            string query = "SELECT * FROM Producto WHERE 1=1 ";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(textNombreP.Text))
            {
                query += " AND Nombre LIKE @nombre";
                parameters.Add(new SqlParameter("@nombre", "%" + textNombreP.Text + "%"));
            }if (!string.IsNullOrWhiteSpace(textCategoriaP.Text))
            {
                query += " AND Categoria LIKE @categoria";
                parameters.Add(new SqlParameter("@categoria", "%" + textCategoriaP.Text + "%"));
            }

            if (!string.IsNullOrWhiteSpace(textProvinciaP.Text))
            {
                query += " AND Provincia LIKE @provincia";
                parameters.Add(new SqlParameter("@provincia", "%" + textProvinciaP.Text + "%"));
            }

            if (!string.IsNullOrWhiteSpace(textEstadoP.Text))
            {
                query += " AND Estado LIKE @estado";
                parameters.Add(new SqlParameter("@estado", "%" + textEstadoP.Text + "%"));
            }

            if (!string.IsNullOrWhiteSpace(textDescuentoP.Text))
            {
                query += " AND Descuento LIKE @descuento";
                parameters.Add(new SqlParameter("@descuento", "%" + textDescuentoP.Text + "%"));
            }

            if (!string.IsNullOrWhiteSpace(textPrecioP.Text))
            {
                query += " AND Precio LIKE @precio";
                parameters.Add(new SqlParameter("@precio", "%" + textPrecioP.Text + "%"));
            }

            // Cargar los resultados de la búsqueda
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddRange(parameters.ToArray());
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProductos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar productos: " + ex.Message);
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormProductosVistas_Load(object sender, EventArgs e)
        {

        }

        private void textNombreP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}