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
            this.StartPosition = FormStartPosition.CenterScreen;
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bInicio_Click_1(object sender, EventArgs e)
        {
            string dni = textDni.Text.Trim(); //obtengo el dni q escribe el usuario
            string pass = textBox4.Text.Trim(); //obtengo la contraseña 

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

                    // 🔹 Traemos todos los datos del usuario
                    string query = "SELECT id_usuario, nombre, apellido, rol FROM Usuario WHERE dni = @dni AND contraseña = @pass";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // encontró usuario
                    {
                        // ✅ Guardamos sesión global
                        SesionActual.IdUsuario = Convert.ToInt32(reader["id_usuario"]);
                        SesionActual.NombreUsuario = reader["nombre"].ToString() + " " + reader["apellido"].ToString();
                        SesionActual.Rol = reader["rol"].ToString();

                        string rol = SesionActual.Rol;
                        Form siguienteForm = null;

                        switch (rol.ToLower())
                        {
                            case "empleado":
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

                        // 👇 Cuando se cierre el form de rol, volver al login
                        siguienteForm.FormClosed += (s, args) => this.Show();

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

        private void textDni_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.UseSystemPasswordChar = false;

            }
            else
            {
                textBox4.UseSystemPasswordChar = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
