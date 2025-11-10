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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeraEntrega
{
    public partial class Form1 : Form
    {
        // Constructor
        // Propósito: Inicializar componentes y asociar manejadores para el textbox DNI.
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Aseguro que el TextBox del DNI tenga los manejadores necesarios incluso si no están ligados desde el diseñador
            this.textDni.KeyPress += textDni_KeyPress;
            this.textDni.TextChanged += textDni_TextChanged;
        }

        // Evento Load del formulario
        // Propósito: Ajustar el tamaño máximo de la ventana al tamaño del monitor.
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            this.MaximumSize = SystemInformation.PrimaryMonitorSize;
        }

        private void label1_Click(object sender, EventArgs e){}
        private void panel1_Paint(object sender, PaintEventArgs e)      {        }
        private void bInicio_Click(object sender, EventArgs e ){}
        private void pictureBox1_Click(object sender, EventArgs e)       {       }

        private void pictureBox1_Click_1(object sender, EventArgs e){}

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)   {}

        // Evento TextChanged del textbox DNI
        // Propósito: Normalizar el valor dejando solo dígitos y mantener posición del caret.
        private void textDni_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null) return;

            string original = tb.Text;
            string digits = Regex.Replace(original, @"\D+", ""); // elimina todo lo que no sea dígito

            if (digits != original)
            {
                int originalSelectionStart = tb.SelectionStart;
                int removed = original.Length - digits.Length;

                tb.Text = digits;

                // Ajusto la posición del caret intentando mantener la posición esperada
                int newSelection = Math.Max(0, originalSelectionStart - Math.Max(0, removed));
                tb.SelectionStart = Math.Min(tb.Text.Length, newSelection);
            }
        }

        // Evento KeyPress del textbox DNI
        // Propósito: Evitar la entrada de caracteres no numéricos desde el teclado.
        private void textDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir controles (Backspace, etc.) y dígitos únicamente
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        // Evento click del botón de inicio de sesión
        // Propósito: Validar credenciales, establecer sesión y abrir el formulario según rol.
        private void bInicio_Click_1(object sender, EventArgs e)
        {
            string dni = textDni.Text.Trim(); // obtengo el dni que escribe el usuario
            string pass = textBox4.Text.Trim(); // obtengo la contraseña 

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

                    // Traemos todos los datos del usuario
                    string query = "SELECT id_usuario, nombre, apellido, rol FROM Usuario WHERE dni = @dni AND contraseña = @pass";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // encontró usuario
                    {
                        // Guardamos sesión global
                        SesionActual.IdUsuario = Convert.ToInt32(reader["id_usuario"]);
                        SesionActual.NombreUsuario = reader["nombre"].ToString() + " " + reader["apellido"].ToString();
                        SesionActual.Rol = reader["rol"].ToString();

                        string rol = SesionActual.Rol;
                        Form siguienteForm = null;

                        // Abrir formulario según rol
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

                        // Al cerrar el form de rol, volver al login
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

        // Evento CheckedChanged del CheckBox
        // Propósito: Mostrar/ocultar caracteres de la contraseña.
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}