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
using System.Text.RegularExpressions;

namespace PrimeraEntrega
{
    public partial class FormClientesAdmin : Form
    {
        // Cadena de conexión al servidor SQL
        private string connectionString =
            @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";

        // ===========================================================
        // CONSTRUCTOR DEL FORMULARIO
        // Configura la interfaz, eventos y carga los datos iniciales
        // ===========================================================
        public FormClientesAdmin()
        {
            InitializeComponent();

            // Configuración inicial del DataGridView
            dvgClientes.AutoGenerateColumns = false; // Desactiva autogeneración de columnas
            dvgClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección completa de filas
            dvgClientes.MultiSelect = false; // Solo una fila a la vez
            dvgClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajuste automático de ancho
            dvgClientes.AllowUserToAddRows = false; // Evita que el usuario agregue filas manualmente

            // Se eliminan las columnas del diseñador y se crean programáticamente
            dvgClientes.Columns.Clear();
            CrearColumnasDgv();

            // Validaciones de entrada
            txtNombre.KeyPress += SoloLetras;
            txtApellido.KeyPress += SoloLetras;
            txtTipo.KeyPress += SoloLetras;
            txtDNI.KeyPress += SoloNumeros;
            txtTelefono.KeyPress += SoloNumeros;

            // Conectar los botones con sus respectivos métodos
            bBuscar.Click += bBuscar_Click;
            bGuardar.Click += bGuardar_Click;
            bModificar.Click += bModificar_Click;
            bEliminar.Click += bEliminar_Click;
            dvgClientes.CellClick += dvgClientes_CellClick;

            // Cargar los datos al iniciar el formulario
            CargarClientes();
        }

        // ===========================================================
        // MÉTODO: CrearColumnasDgv()
        // Define las columnas que se mostrarán en la grilla de clientes
        // ===========================================================
        private void CrearColumnasDgv()
        {
            var cNombre = new DataGridViewTextBoxColumn { Name = "nombre", DataPropertyName = "nombre", HeaderText = "Nombre" };
            var cApellido = new DataGridViewTextBoxColumn { Name = "apellido", DataPropertyName = "apellido", HeaderText = "Apellido" };
            var cFecha = new DataGridViewTextBoxColumn { Name = "fecha_nacimiento", DataPropertyName = "fecha_nacimiento", HeaderText = "Fecha Nac." };
            var cDni = new DataGridViewTextBoxColumn { Name = "dni", DataPropertyName = "dni", HeaderText = "DNI" };
            var cTelefono = new DataGridViewTextBoxColumn { Name = "telefono", DataPropertyName = "telefono", HeaderText = "Teléfono" };
            var cGmail = new DataGridViewTextBoxColumn { Name = "Gmail", DataPropertyName = "Gmail", HeaderText = "Correo" };
            var cTipo = new DataGridViewTextBoxColumn { Name = "tipo_cliente", DataPropertyName = "tipo_cliente", HeaderText = "Tipo" };

            dvgClientes.Columns.AddRange(new DataGridViewColumn[] { cNombre, cApellido, cFecha, cDni, cTelefono, cGmail, cTipo });
        }

        // ===========================================================
        // MÉTODO: ObtenerConexion()
        // Retorna una nueva conexión SQL abierta
        // ===========================================================
        private SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }

        // ===========================================================
        // MÉTODO: CargarClientes()
        // Carga todos los clientes de la base de datos en el DataGridView
        // ===========================================================
        private void CargarClientes()
        {
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT * FROM Cliente";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dvgClientes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        // ===========================================================
        // VALIDACIONES DE ENTRADA
        // Métodos auxiliares para restringir caracteres
        // ===========================================================
        private void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true; // Cancela si no es letra o espacio
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true; // Cancela si no es número
        }

        private bool CorreoValido(string correo)
        {
            // Usa expresión regular para validar formato de correo
            return Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        // ===========================================================
        // BOTÓN BUSCAR: Filtra clientes por coincidencia parcial
        // ===========================================================
        private void bBuscar_Click(object sender, EventArgs e)
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
                    string query = "SELECT * FROM Cliente WHERE " +
                                   "(nombre LIKE @Nombre OR @Nombre = '') AND " +
                                   "(apellido LIKE @Apellido OR @Apellido = '') AND " +
                                   "(dni LIKE @DNI OR @DNI = '') AND " +
                                   "(telefono LIKE @Telefono OR @Telefono = '') AND " +
                                   "(Gmail LIKE @Gmail OR @Gmail = '') AND " +
                                   "(tipo_cliente LIKE @Tipo OR @Tipo = '')";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", "%" + txtNombre.Text.Trim() + "%");
                    da.SelectCommand.Parameters.AddWithValue("@Apellido", "%" + txtApellido.Text.Trim() + "%");
                    da.SelectCommand.Parameters.AddWithValue("@DNI", "%" + txtDNI.Text.Trim() + "%");
                    da.SelectCommand.Parameters.AddWithValue("@Telefono", "%" + txtTelefono.Text.Trim() + "%");
                    da.SelectCommand.Parameters.AddWithValue("@Gmail", "%" + txtCorreo.Text.Trim() + "%");
                    da.SelectCommand.Parameters.AddWithValue("@Tipo", "%" + txtTipo.Text.Trim() + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dvgClientes.DataSource = dt;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("No se encontró ningún cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar clientes: " + ex.Message);
            }
        }

        // ===========================================================
        // BOTÓN GUARDAR: Inserta un nuevo cliente en la base de datos
        // ===========================================================
        private void bGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                MessageBox.Show("Debe rellenar todos los campos.");
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

                    // Verifica si ya existe un cliente con el mismo DNI
                    string checkQuery = "SELECT COUNT(*) FROM Cliente WHERE dni = @DNI";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@DNI", txtDNI.Text.Trim());
                    int existe = (int)checkCmd.ExecuteScalar();

                    if (existe > 0)
                    {
                        MessageBox.Show("El cliente que desea agregar ya existe.");
                        return;
                    }

                    var dr = MessageBox.Show("¿Desea agregar un nuevo cliente?", "Confirmación", MessageBoxButtons.YesNo);
                    if (dr != DialogResult.Yes) return;

                    // Inserta el nuevo cliente
                    string insertQuery = "INSERT INTO Cliente (nombre, apellido, fecha_nacimiento, dni, telefono, Gmail, tipo_cliente) " +
                                         "VALUES (@Nombre, @Apellido, @FechaNac, @DNI, @Telefono, @Gmail, @Tipo)";
                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@FechaNac", dtpFechaNac.Value.Date);
                    cmd.Parameters.AddWithValue("@DNI", txtDNI.Text.Trim());
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gmail", txtCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Tipo", txtTipo.Text.Trim());
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("El cliente fue agregado con éxito.");
                    LimpiarFormulario();
                    CargarClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cliente: " + ex.Message);
            }
        }

        // ===========================================================
        // BOTÓN MODIFICAR: Actualiza datos de un cliente existente
        // ===========================================================
        private void bModificar_Click(object sender, EventArgs e)
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

            var dr = MessageBox.Show("¿Desea guardar las modificaciones?", "Confirmación", MessageBoxButtons.YesNo);
            if (dr != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    string updateQuery = "UPDATE Cliente SET nombre=@Nombre, apellido=@Apellido, fecha_nacimiento=@FechaNac, telefono=@Telefono, Gmail=@Gmail, tipo_cliente=@Tipo WHERE dni=@DNI";
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@FechaNac", dtpFechaNac.Value.Date);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gmail", txtCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Tipo", txtTipo.Text.Trim());
                    cmd.Parameters.AddWithValue("@DNI", txtDNI.Text.Trim());

                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0)
                        MessageBox.Show("Se actualizaron los datos del cliente.");
                    else
                        MessageBox.Show("No se encontró el cliente para actualizar.");

                    LimpiarFormulario();
                    CargarClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar cliente: " + ex.Message);
            }
        }

        // ===========================================================
        // BOTÓN ELIMINAR: Borra un cliente según su DNI
        // ===========================================================
        private void bEliminar_Click(object sender, EventArgs e)
        {
            if (dvgClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                return;
            }

            var dr = MessageBox.Show("¿Desea eliminar al cliente?", "Confirmación", MessageBoxButtons.YesNo);
            if (dr != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    string dni = GetCellString(dvgClientes.SelectedRows[0], "dni");

                    string deleteQuery = "DELETE FROM Cliente WHERE dni=@DNI";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@DNI", dni);

                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0)
                        MessageBox.Show("El cliente fue eliminado.");
                    else
                        MessageBox.Show("No se encontró el cliente para eliminar.");

                    LimpiarFormulario();
                    CargarClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar cliente: " + ex.Message);
            }
        }

        // ===========================================================
        // EVENTO: dvgClientes_CellClick()
        // Carga los datos de la fila seleccionada en los campos
        // ===========================================================
        private void dvgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dvgClientes.Rows[e.RowIndex];

            txtNombre.Text = GetCellString(row, "nombre");
            txtApellido.Text = GetCellString(row, "apellido");
            txtDNI.Text = GetCellString(row, "dni");
            txtTelefono.Text = GetCellString(row, "telefono");
            txtCorreo.Text = GetCellString(row, "Gmail");
            txtTipo.Text = GetCellString(row, "tipo_cliente");

            var val = row.Cells["fecha_nacimiento"].Value;
            if (val != null && val != DBNull.Value && DateTime.TryParse(val.ToString(), out DateTime fecha))
                dtpFechaNac.Value = fecha;
            else
                dtpFechaNac.Value = DateTime.Today;
        }

        // ===========================================================
        // MÉTODOS AUXILIARES
        // ===========================================================
        private string GetCellString(DataGridViewRow row, string columnName)
        {
            if (row == null) return string.Empty;
            var cell = row.Cells[columnName];
            if (cell == null || cell.Value == null || cell.Value == DBNull.Value) return string.Empty;
            return cell.Value.ToString();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtTipo.Clear();
            dtpFechaNac.Value = DateTime.Today;
            dvgClientes.ClearSelection();
        }

        // Eventos visuales sin lógica (mantenidos por diseño)
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void panel2_Paint_1(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
    }
}
