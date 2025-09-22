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
        // Cadena de conexión a SQL Server
        private string connectionString =
            @"Data Source=DIAMELA\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";

        public FormClientesAdmin()
        {
            InitializeComponent();

            // ⚙️ Configuración inicial del DataGridView
            dvgClientes.AutoGenerateColumns = false;           // Evita que SQL cree columnas duplicadas automáticamente
            dvgClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección de filas completas
            dvgClientes.MultiSelect = false;                   // Permite seleccionar solo una fila
            dvgClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajuste automático de columnas
            dvgClientes.AllowUserToAddRows = false;            // No deja al usuario agregar filas manualmente

            // Se eliminan las columnas del diseñador y se crean programáticamente las correctas
            dvgClientes.Columns.Clear();
            CrearColumnasDgv();

            // 🔒 Restricciones en campos (solo letras o solo números)
            txtNombre.KeyPress += SoloLetras;
            txtApellido.KeyPress += SoloLetras;
            txtTipo.KeyPress += SoloLetras;
            txtDNI.KeyPress += SoloNumeros;
            txtTelefono.KeyPress += SoloNumeros;

            // 🔗 Conectar los botones y eventos con sus métodos
            bBuscar.Click += bBuscar_Click;
            bGuardar.Click += bGuardar_Click;
            bModificar.Click += bModificar_Click;
            bEliminar.Click += bEliminar_Click;
            dvgClientes.CellClick += dvgClientes_CellClick;

            // 📥 Cargar la lista de clientes al iniciar
            CargarClientes();
        }

        // ----------------- CREACIÓN DE COLUMNAS -----------------
        private void CrearColumnasDgv()
        {
            // Se crean columnas con el mismo nombre que en la tabla SQL
            var cId = new DataGridViewTextBoxColumn { Name = "id_cliente", DataPropertyName = "id_cliente", HeaderText = "ID", ReadOnly = true };
            var cNombre = new DataGridViewTextBoxColumn { Name = "nombre", DataPropertyName = "nombre", HeaderText = "Nombre" };
            var cApellido = new DataGridViewTextBoxColumn { Name = "apellido", DataPropertyName = "apellido", HeaderText = "Apellido" };
            var cFecha = new DataGridViewTextBoxColumn { Name = "fecha_nacimiento", DataPropertyName = "fecha_nacimiento", HeaderText = "Fecha Nac." };
            var cDni = new DataGridViewTextBoxColumn { Name = "dni", DataPropertyName = "dni", HeaderText = "DNI" };
            var cTelefono = new DataGridViewTextBoxColumn { Name = "telefono", DataPropertyName = "telefono", HeaderText = "Teléfono" };
            var cGmail = new DataGridViewTextBoxColumn { Name = "Gmail", DataPropertyName = "Gmail", HeaderText = "Correo" };
            var cTipo = new DataGridViewTextBoxColumn { Name = "tipo_cliente", DataPropertyName = "tipo_cliente", HeaderText = "Tipo" };

            dvgClientes.Columns.AddRange(new DataGridViewColumn[] { cId, cNombre, cApellido, cFecha, cDni, cTelefono, cGmail, cTipo });
        }

        // ----------------- CONEXIÓN A BASE DE DATOS -----------------
        private SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }

        // ----------------- CARGAR CLIENTES -----------------
        private void CargarClientes()
        {
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT * FROM Cliente"; // Obtiene todos los clientes
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dvgClientes.DataSource = dt; // Se cargan los datos en la grilla
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        // ----------------- RESTRICCIONES DE INPUT -----------------
        private void SoloLetras(object sender, KeyPressEventArgs e)
        {
            // Solo permite letras, espacio o teclas de control (backspace, etc.)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y teclas de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private bool CorreoValido(string correo)
        {
            // Verifica que el correo tenga un formato válido con Regex
            return Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        // ----------------- BUSCAR CLIENTE -----------------
        private void bBuscar_Click(object sender, EventArgs e)
        {
            // Verifica que haya al menos un campo de búsqueda completado
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
                    // Se buscan coincidencias en la tabla con filtros parciales (LIKE)
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

        // ----------------- GUARDAR CLIENTE NUEVO -----------------
        private void bGuardar_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
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

            // Validación del correo
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

                    // Verifica que no exista otro cliente con el mismo DNI
                    string checkQuery = "SELECT COUNT(*) FROM Cliente WHERE dni = @DNI";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@DNI", txtDNI.Text.Trim());
                    int existe = (int)checkCmd.ExecuteScalar();

                    if (existe > 0)
                    {
                        MessageBox.Show("El cliente que desea agregar ya existe.");
                        return;
                    }

                    // Confirmación del usuario
                    var dr = MessageBox.Show("¿Desea agregar un nuevo cliente?", "Confirmación", MessageBoxButtons.YesNo);
                    if (dr != DialogResult.Yes) return;

                    // Inserta nuevo cliente en la BD
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
                    ClearForm();    // Limpia los campos del formulario
                    CargarClientes(); // Refresca la grilla
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cliente: " + ex.Message);
            }
        }

        // ----------------- MODIFICAR CLIENTE -----------------
        private void bModificar_Click(object sender, EventArgs e)
        {
            if (dvgClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                return;
            }

            // Validación de campos
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

                    // Actualiza los datos del cliente según el DNI
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

                    ClearForm();
                    CargarClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar cliente: " + ex.Message);
            }
        }

        // ----------------- ELIMINAR CLIENTE -----------------
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
                    // Obtiene el DNI del cliente seleccionado
                    string dni = GetCellString(dvgClientes.SelectedRows[0], "dni");

                    // Elimina el cliente de la base de datos
                    string deleteQuery = "DELETE FROM Cliente WHERE dni=@DNI";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@DNI", dni);

                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0)
                        MessageBox.Show("El cliente fue eliminado.");
                    else
                        MessageBox.Show("No se encontró el cliente para eliminar.");

                    ClearForm();
                    CargarClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar cliente: " + ex.Message);
            }
        }

        // ----------------- AUTOCOMPLETAR CAMPOS AL SELECCIONAR UNA FILA -----------------
        private void dvgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dvgClientes.Rows[e.RowIndex];

            // Rellena los TextBox con los datos de la fila seleccionada
            txtNombre.Text = GetCellString(row, "nombre");
            txtApellido.Text = GetCellString(row, "apellido");
            txtDNI.Text = GetCellString(row, "dni");
            txtTelefono.Text = GetCellString(row, "telefono");
            txtCorreo.Text = GetCellString(row, "Gmail");
            txtTipo.Text = GetCellString(row, "tipo_cliente");

            // Manejo de la fecha de nacimiento
            var val = row.Cells["fecha_nacimiento"].Value;
            if (val != null && val != DBNull.Value && DateTime.TryParse(val.ToString(), out DateTime fecha))
                dtpFechaNac.Value = fecha;
            else
                dtpFechaNac.Value = DateTime.Today;
        }

        // ----------------- HELPERS -----------------
        private string GetCellString(DataGridViewRow row, string columnName)
        {
            if (row == null) return string.Empty;
            var cell = row.Cells[columnName];
            if (cell == null || cell.Value == null || cell.Value == DBNull.Value) return string.Empty;
            return cell.Value.ToString();
        }

        // Limpia todos los campos del formulario
        private void ClearForm()
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
    }
}


