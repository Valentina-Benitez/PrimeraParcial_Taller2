using gerente;
using RestauranteApp;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            this.MaximumSize = SystemInformation.PrimaryMonitorSize;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bInicio_Click(object sender, EventArgs e)
        {
            string dni = textDni.Text.Trim();
            string pass = textBox4.Text.Trim();

            if (dni == "" || pass == "")
            {
                MessageBox.Show("Por favor complete todos los campos.");
                return;
            }

            try
            {
                using (SqlConnection conexion = ConexionDB.ObtenerConexion())
                {
                    conexion.Open();

                    string query = "SELECT rol FROM Usuario WHERE dni = @dni AND contraseña = @pass";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    object result = cmd.ExecuteScalar();

                    if (result != null) // Significa que encontró usuario
                    {
                        string rol = result.ToString();

                        MessageBox.Show("Bienvenido, " + rol);

                        Form siguienteForm = null;

                        switch (rol.ToLower())
                        {
                            case "recepcionista":
                                siguienteForm = new Form3();
                                break;
                            case "administrador":
                                siguienteForm = new FormPrincipalAdmi();
                                break;
                            case "gerente":
                                siguienteForm = new Form2();
                                break;
                            default:
                                MessageBox.Show("Rol no reconocido.");
                                return;
                        }

                        siguienteForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("DNI o contraseña incorrectos.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textDni_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
