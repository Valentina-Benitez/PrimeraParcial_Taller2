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
    public partial class FormEmpleadosVistas : Form
    {
        public FormEmpleadosVistas()
        {
            InitializeComponent();

            CargarEmpleados();

            textNombre.KeyPress += SoloLetras;
            textApellido.KeyPress += SoloLetras;
            textDNI.KeyPress += SoloNumeros;

        }
        private SqlConnection ObtenerConexion()
        {
            string cadena = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";
            return new SqlConnection(cadena);
        }
        private void CargarEmpleados()
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
                   dgvEmpleados.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
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

        private void bBuscar_Click(object sender, EventArgs e)
        {
            // Validar que al menos un campo tenga valor
            if (string.IsNullOrWhiteSpace(textNombre.Text) &&
        string.IsNullOrWhiteSpace(textApellido.Text) &&
        string.IsNullOrWhiteSpace(textDNI.Text) )
            {
                MessageBox.Show("Por favor, complete al menos un campo para realizar la búsqueda.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Construir la consulta SQL dinámica
            string query = "SELECT * FROM Empleados WHERE 1=1 ";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(textNombre.Text))
            {
                query += " AND Nombre LIKE @nombre";
                parameters.Add(new SqlParameter("@nombre", "%" + textNombre.Text + "%"));
            }
            if (!string.IsNullOrWhiteSpace(textApellido.Text))
            {
                query += " AND ApellidoLIKE @apellido";
                parameters.Add(new SqlParameter("@apeliido", "%" + textApellido.Text + "%"));
            }

           

            if (!string.IsNullOrWhiteSpace(textDNI.Text))
            {
                query += " AND Dni LIKE @dni";
                parameters.Add(new SqlParameter("@dni", "%" + textDNI.Text + "%"));
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
                    dgvEmpleados.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar al empleado: " + ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
