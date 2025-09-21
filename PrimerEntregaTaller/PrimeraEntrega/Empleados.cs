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
    public partial class Empleados : Form
    {
        private string connectionString = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";

        public Empleados()
        {
            InitializeComponent();
            CargarEmpleados();

            // Eventos de validación
            textNombre.KeyPress += SoloLetras;
            textApellido.KeyPress += SoloLetras;
            textDni.KeyPress += SoloNumeros;
            textTelefono.KeyPress += SoloNumeros;
            textGmail.KeyPress += SinEspacios;
            textContraseña.KeyPress += SinEspacios;
            textReContraseña.KeyPress += SinEspacios;
        }

        private SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }

        // =========================
        // VALIDACIONES
        // =========================
        private void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void SinEspacios(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private bool ValidarCorreo(string correo)
        {
            string patron = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            return Regex.IsMatch(correo, patron);
        }

        private bool ValidarContraseñasIguales()
        {
            return textContraseña.Text == textReContraseña.Text;
        }

        // =========================
        // CARGAR EMPLEADOS
        // =========================
        private void CargarEmpleados()
        {
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT * FROM Empleados";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvEmpleados.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados " + ex.Message);
            }
        }

        // =========================
        // BOTÓN AGREGAR
        // =========================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!CamposCompletos())
            {
                MessageBox.Show("Debe completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidarCorreo(textGmail.Text))
            {
                MessageBox.Show("El correo debe ser válido y terminar en @gmail.com.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidarContraseñasIguales())
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Empleados (Nombre, Apellido, DNI, FechaNacimiento, Domicilio, Telefono, Gmail, TipoUsuario, Contraseña) " +
                    "VALUES (@Nombre, @Apellido, @DNI, @FechaNacimiento, @Domicilio, @Telefono, @Gmail, @TipoUsuario, @Contraseña)", con);

                cmd.Parameters.AddWithValue("@Nombre", textNombre.Text);
                cmd.Parameters.AddWithValue("@Apellido", textApellido.Text);
                cmd.Parameters.AddWithValue("@DNI", textDni.Text);
                cmd.Parameters.AddWithValue("@FechaNacimiento", dtpFechaNac.Value.Date);
                cmd.Parameters.AddWithValue("@Domicilio", textDomicilio.Text);
                cmd.Parameters.AddWithValue("@Telefono", textTelefono.Text);
                cmd.Parameters.AddWithValue("@Gmail", textGmail.Text);
                cmd.Parameters.AddWithValue("@TipoUsuario", cbTipoUsuario.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Contraseña", textContraseña.Text); // ⚠️ mejor encriptar

                cmd.ExecuteNonQuery();
                MessageBox.Show("Empleado agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarEmpleados();
        }

        // =========================
        // BOTÓN MODIFICAR
        // =========================
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un empleado para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CamposCompletos())
            {
                MessageBox.Show("Debe completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidarCorreo(textGmail.Text))
            {
                MessageBox.Show("El correo debe ser válido y terminar en @gmail.com.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidarContraseñasIguales())
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["Id"].Value);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Empleados SET Nombre=@Nombre, Apellido=@Apellido, DNI=@DNI, FechaNacimiento=@FechaNacimiento, " +
                    "Domicilio=@Domicilio, Telefono=@Telefono, Gmail=@Gmail, TipoUsuario=@TipoUsuario, Contraseña=@Contraseña " +
                    "WHERE Id=@Id", con);

                cmd.Parameters.AddWithValue("@Nombre", textNombre.Text);
                cmd.Parameters.AddWithValue("@Apellido", textApellido.Text);
                cmd.Parameters.AddWithValue("@DNI", textDni.Text);
                cmd.Parameters.AddWithValue("@FechaNacimiento", dtpFechaNac.Value.Date);
                cmd.Parameters.AddWithValue("@Domicilio", textDomicilio.Text);
                cmd.Parameters.AddWithValue("@Telefono", textTelefono.Text);
                cmd.Parameters.AddWithValue("@Gmail", textGmail.Text);
                cmd.Parameters.AddWithValue("@TipoUsuario", cbTipoUsuario.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Contraseña", textContraseña.Text);
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Empleado modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarEmpleados();
        }

        // =========================
        // BOTÓN ELIMINAR
        // =========================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un empleado para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["Id"].Value);

            DialogResult dr = MessageBox.Show("¿Está seguro de eliminar este empleado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Empleados WHERE Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }

                CargarEmpleados();
                MessageBox.Show("Empleado eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // =========================
        // AUXILIAR: VALIDAR CAMPOS
        // =========================
        private bool CamposCompletos()
        {
            return !string.IsNullOrWhiteSpace(textNombre.Text) &&
                   !string.IsNullOrWhiteSpace(textApellido.Text) &&
                   !string.IsNullOrWhiteSpace(textDni.Text) &&
                   !string.IsNullOrWhiteSpace(textDomicilio.Text) &&
                   !string.IsNullOrWhiteSpace(textTelefono.Text) &&
                   !string.IsNullOrWhiteSpace(textGmail.Text) &&
                   cbTipoUsuario.SelectedIndex != -1 &&
                   !string.IsNullOrWhiteSpace(textContraseña.Text) &&
                   !string.IsNullOrWhiteSpace(textReContraseña.Text);
        }

        // =========================
        // SELECCIONAR FILA
        // =========================
        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvEmpleados.Rows[e.RowIndex];
                textNombre.Text = fila.Cells["Nombre"].Value.ToString();
                textApellido.Text = fila.Cells["Apellido"].Value.ToString();
                textDni.Text = fila.Cells["DNI"].Value.ToString();
                dtpFechaNac.Value = Convert.ToDateTime(fila.Cells["FechaNacimiento"].Value);
                textDomicilio.Text = fila.Cells["Domicilio"].Value.ToString();
                textTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                textGmail.Text = fila.Cells["Gmail"].Value.ToString();
                cbTipoUsuario.Text = fila.Cells["TipoUsuario"].Value.ToString();
                textContraseña.Text = fila.Cells["Contraseña"].Value.ToString();
                textReContraseña.Text = fila.Cells["Contraseña"].Value.ToString();
            }
        }
    }
}
