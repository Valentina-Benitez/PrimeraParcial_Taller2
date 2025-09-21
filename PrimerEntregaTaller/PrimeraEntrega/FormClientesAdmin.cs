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
    public partial class FormClientesAdmin : Form
    {
        private string connectionString = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";

        public FormClientesAdmin()
        {
            InitializeComponent();

            // Cargar clientes al iniciar
            CargarClientes();

            // Restricciones en campos
            txtNombre.KeyPress += SoloLetras;
            txtApellido.KeyPress += SoloLetras;
            txtTipo.KeyPress += SoloLetras;
            txtDNI.KeyPress += SoloNumeros;
            txtTelefono.KeyPress += SoloNumeros;

            dvgClientes.CellClick += dvgClientes_CellClick;
        }

        private SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }

        private void CargarClientes()
        {
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT * FROM Clientes";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dvgClientes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes " + ex.Message);
            }
        }

        // -------- Restricciones --------
        private void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private bool CorreoValido(string correo)
        {
            return Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        // -------- Buscar --------
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) &&
                string.IsNullOrWhiteSpace(txtApellido.Text) &&
                string.IsNullOrWhiteSpace(txtDNI.Text) &&
                string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                string.IsNullOrWhiteSpace(txtCorreo.Text) &&
                string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                MessageBox.Show("Debe rellenar uno o más campos para buscar.");
                return;
            }

            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT * FROM Clientes WHERE " +
                                   "(Nombre LIKE @Nombre OR @Nombre = '') AND " +
                                   "(Apellido LIKE @Apellido OR @Apellido = '') AND " +
                                   "(DNI LIKE @DNI OR @DNI = '') AND " +
                                   "(Telefono LIKE @Telefono OR @Telefono = '') AND " +
                                   "(Correo LIKE @Correo OR @Correo = '') AND " +
                                   "(Tipo LIKE @Tipo OR @Tipo = '')";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", "%" + txtNombre.Text + "%");
                    da.SelectCommand.Parameters.AddWithValue("@Apellido", "%" + txtApellido.Text + "%");
                    da.SelectCommand.Parameters.AddWithValue("@DNI", "%" + txtDNI.Text + "%");
                    da.SelectCommand.Parameters.AddWithValue("@Telefono", "%" + txtTelefono.Text + "%");
                    da.SelectCommand.Parameters.AddWithValue("@Correo", "%" + txtCorreo.Text + "%");
                    da.SelectCommand.Parameters.AddWithValue("@Tipo", "%" + txtTipo.Text + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                        dvgClientes.DataSource = dt;
                    else
                        MessageBox.Show("No se tiene registrado a ese cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar clientes: " + ex.Message);
            }
        }

        // -------- Guardar --------
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                MessageBox.Show("Debe rellenar todos los campos antes de agregar.");
                return;
            }

            if (!CorreoValido(txtCorreo.Text))
            {
                MessageBox.Show("El correo no es válido.");
                return;
            }

            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();

                    // Validar si ya existe cliente
                    string checkQuery = "SELECT COUNT(*) FROM Clientes WHERE DNI = @DNI";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@DNI", txtDNI.Text);
                    int existe = (int)checkCmd.ExecuteScalar();

                    if (existe > 0)
                    {
                        MessageBox.Show("El cliente que desea agregar ya existe.");
                        return;
                    }

                    DialogResult dr = MessageBox.Show("¿Desea agregar un nuevo cliente?", "Confirmación", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        string insertQuery = "INSERT INTO Clientes (Nombre, Apellido, FechaNac, DNI, Telefono, Correo, Tipo) " +
                                             "VALUES (@Nombre, @Apellido, @FechaNac, @DNI, @Telefono, @Correo, @Tipo)";
                        SqlCommand cmd = new SqlCommand(insertQuery, conn);
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                        cmd.Parameters.AddWithValue("@FechaNac", dtpFechaNac.Value);
                        cmd.Parameters.AddWithValue("@DNI", txtDNI.Text);
                        cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                        cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                        cmd.Parameters.AddWithValue("@Tipo", txtTipo.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("El cliente fue agregado con éxito.");
                        CargarClientes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cliente: " + ex.Message);
            }
        }

        // -------- Modificar --------
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dvgClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                MessageBox.Show("Debe completar todos los campos.");
                return;
            }

            DialogResult dr = MessageBox.Show("¿Desea guardar las modificaciones?", "Confirmación", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = ObtenerConexion())
                    {
                        conn.Open();
                        string updateQuery = "UPDATE Clientes SET Nombre=@Nombre, Apellido=@Apellido, FechaNac=@FechaNac, Telefono=@Telefono, Correo=@Correo, Tipo=@Tipo WHERE DNI=@DNI";
                        SqlCommand cmd = new SqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                        cmd.Parameters.AddWithValue("@FechaNac", dtpFechaNac.Value);
                        cmd.Parameters.AddWithValue("@DNI", txtDNI.Text);
                        cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                        cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                        cmd.Parameters.AddWithValue("@Tipo", txtTipo.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Se actualizaron los datos del cliente.");
                        CargarClientes();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar cliente: " + ex.Message);
                }
            }
        }

        // -------- Eliminar --------
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dvgClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                return;
            }

            DialogResult dr = MessageBox.Show("¿Desea eliminar al cliente?", "Confirmación", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = ObtenerConexion())
                    {
                        conn.Open();
                        string dni = dvgClientes.SelectedRows[0].Cells["DNI"].Value.ToString();
                        string deleteQuery = "DELETE FROM Clientes WHERE DNI=@DNI";
                        SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                        cmd.Parameters.AddWithValue("@DNI", dni);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("El cliente fue eliminado.");
                        CargarClientes();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar cliente: " + ex.Message);
                }
            }
        }

        // -------- Autocompletar al seleccionar --------
        private void dvgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dvgClientes.Rows[e.RowIndex];
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value.ToString();
                dtpFechaNac.Text = row.Cells["FechaNac"].Value.ToString();
                txtDNI.Text = row.Cells["DNI"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = row.Cells["Correo"].Value.ToString();
                txtTipo.Text = row.Cells["Tipo"].Value.ToString();
            }
        }
    }
}
