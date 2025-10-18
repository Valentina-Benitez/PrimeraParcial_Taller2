using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace gerente
{
    public partial class Empleados : Form
    {
        private string connectionString = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";
        // Roles válidos
        private readonly string[] RolesValidos = new[] { "Empleado", "Gerente", "Administrador" };

        public Empleados()
        {
            InitializeComponent();

            // Preparación del DataGridView 
            dgvEmpleados.AutoGenerateColumns = false;
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.MultiSelect = false;
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.Columns.Clear();
            CrearColumnasDgv(); // creamos columnas

            // Vincular validaciones de teclado 
            textNombre.KeyPress += SoloLetras;
            textApellido.KeyPress += SoloLetras;
            textDni.KeyPress += SoloNumeros;
            textTelefono.KeyPress += SoloNumeros;
            textCorreo.KeyPress += SinEspacios;
            // Nota: textContraseña y textReContraseña fueron eliminados (ahora la contraseña se genera automáticamente)

            // Poblamos combo de roles 
            cbTipoUsuario.Items.Clear();
            cbTipoUsuario.Items.AddRange(RolesValidos);

            // enlaza los botones con las funciones (asegurate que los nombres de botones coincidan con tu diseñador)
            bAgregar.Click -= btnAgregar_Click;
            bAgregar.Click += btnAgregar_Click;
            bModificar.Click -= btnModificar_Click;
            bModificar.Click += btnModificar_Click;
            bEliminar.Click -= btnEliminar_Click;
            bEliminar.Click += btnEliminar_Click;
            dgvEmpleados.CellClick -= dgvEmpleados_CellClick;
            dgvEmpleados.CellClick += dgvEmpleados_CellClick;
            bBuscar.Click -= bBuscar_Click; bBuscar.Click += bBuscar_Click;
            bCancelar.Click -= bCancelar_Click; bCancelar.Click += bCancelar_Click;

            CargarUsuarios();
        }

        private void CrearColumnasDgv()
        {
            var cId = new DataGridViewTextBoxColumn { Name = "id_usuario", DataPropertyName = "id_usuario", HeaderText = "ID", ReadOnly = true };
            var cNombre = new DataGridViewTextBoxColumn { Name = "nombre", DataPropertyName = "nombre", HeaderText = "Nombre" };
            var cApellido = new DataGridViewTextBoxColumn { Name = "apellido", DataPropertyName = "apellido", HeaderText = "Apellido" };
            var cDni = new DataGridViewTextBoxColumn { Name = "dni", DataPropertyName = "dni", HeaderText = "DNI" };
            var cTelefono = new DataGridViewTextBoxColumn { Name = "telefono", DataPropertyName = "telefono", HeaderText = "Teléfono" };
            var cCorreo = new DataGridViewTextBoxColumn { Name = "correo", DataPropertyName = "correo", HeaderText = "Correo" };
            var cRol = new DataGridViewTextBoxColumn { Name = "rol", DataPropertyName = "rol", HeaderText = "Rol" };
            var cFecha = new DataGridViewTextBoxColumn { Name = "fecha_nacimiento", DataPropertyName = "fecha_nacimiento", HeaderText = "Fecha Nac." };
            var cDomicilio = new DataGridViewTextBoxColumn { Name = "domicilio", DataPropertyName = "domicilio", HeaderText = "Domicilio" };
            // contraseña la traemos con alias "contraseña" (sin ñ) para evitar problemas con nombres
            var cContra = new DataGridViewTextBoxColumn { Name = "contraseña", DataPropertyName = "contraseña", HeaderText = "Contraseña", Visible = false }; // ocultamos la contraseña en la grilla

            dgvEmpleados.Columns.AddRange(new DataGridViewColumn[] { cId, cNombre, cApellido, cDni, cTelefono, cCorreo, cRol, cFecha, cDomicilio, cContra });
        }

        #region Conexión

        private SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }

        #endregion

        // ============================
        // MÉTODO PARA GENERAR CONTRASEÑA ALEATORIA
        // ============================
        private string GenerarContraseña(int longitud = 10)
        {
            const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%&*?";
            var sb = new StringBuilder();
            // usar RNGCryptoServiceProvider sería más seguro, pero Random es suficiente para propósito interno
            var rnd = new Random();
            for (int i = 0; i < longitud; i++)
            {
                sb.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return sb.ToString();
        }

        // ============================
        // MÉTODO PARA ENVIAR EL CORREO
        // ============================
        private void EnviarCorreoContraseña(string destinatario, string nombreEmpleado, string contraseñaGenerada)
        {
            try
            {
                // 🔹 Datos del remitente (CAMBIA ESTOS DATOS por tu cuenta y clave de aplicación)
                string remitente = "isasoto375@gmail.com";   // tu correo Correo
                string claveApp = "klms bqxl nvfs tutm"; // contraseña de aplicación generada en Google
               // string destinatario = correo;
                // 🔹 Configurar mensaje
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(remitente, "Restaurante");
                mail.To.Add(destinatario); // ✅ destinatario es el correo que ingresó el usuario
                mail.Subject = "Credenciales de acceso - Restaurante";
                mail.Body =
                    $"Hola {nombreEmpleado},\r\n\r\n" +
                    $"Se ha creado tu cuenta en el sistema del Restaurante.\r\n\r\n" +
                    $"Tu contraseña generada automáticamente es:\r\n\r\n" +
                    $"👉 {contraseñaGenerada}\r\n\r\n" +
                    $"Por favor, cámbiala luego de iniciar sesión.\r\n\r\n" +
                    $"Saludos,\r\nEquipo de Administración.";
                mail.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(remitente, claveApp);
                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"El correo no pudo enviarse.\nError: {ex.Message}\n\n" +
                                $"👉 La contraseña generada para el empleado es:\n{contraseñaGenerada}",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region Validaciones de entrada

        private void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }

            string noPermitidos = "@?¿'%&/()·!¡-_.:,;";
            if (noPermitidos.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void SinEspacios(object sender, KeyPressEventArgs e)
        {
            // Evita espacios en campos como correo
            if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private bool ValidarCorreo(string correo)
        {
            try
            {
                var addr = new MailAddress(correo);
                return true;
            }
            catch
            {
                return false;
            }
        }


        private bool ValidarRolSeleccionado()
        {
            if (cbTipoUsuario.SelectedIndex < 0) return false;
            var val = cbTipoUsuario.SelectedItem.ToString();
            return Array.Exists(RolesValidos, r => r == val);
        }

        #endregion

        #region Operaciones CRUD

        /// <summary>
        /// Carga todos los usuarios desde la tabla Usuario.
        /// NOTA: aliasamos [contraseña] AS contraseña para evitar caracteres especiales.
        /// </summary>
        private void CargarUsuarios()
        {
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();

                    string query =
                        "SELECT id_usuario, nombre, apellido, dni, telefono, Correo, rol, fecha_nacimiento, domicilio, [contraseña] AS contraseña " +
                        "FROM Usuario";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvEmpleados.DataSource = null;
                    dgvEmpleados.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CamposCompletos())
                {
                    MessageBox.Show("Debe completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarCorreo(textCorreo.Text))
                {
                    MessageBox.Show("El correo debe ser válido y terminar en @.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarRolSeleccionado())
                {
                    MessageBox.Show("Seleccione un rol válido (Empleado, Gerente, Administrador).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string contraseñaGenerada = GenerarContraseña();

                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();

                    // Evitar duplicados por DNI o correo
                    string check = "SELECT COUNT(*) FROM Usuario WHERE dni = @dni OR Correo = @correo";
                    using (SqlCommand checkCmd = new SqlCommand(check, con))
                    {
                        checkCmd.Parameters.AddWithValue("@dni", textDni.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@correo", textCorreo.Text.Trim());
                        int existe = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (existe > 0)
                        {
                            MessageBox.Show("Ya existe un usuario con ese DNI o Correo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Insert (usamos [contraseña] entre corchetes porque tiene ñ)
                    string insert =
                        "INSERT INTO Usuario (nombre, apellido, dni, telefono, Correo, rol, fecha_nacimiento, domicilio, [contraseña]) " +
                        "VALUES (@nombre, @apellido, @dni, @telefono, @correo, @rol, @fecha_nacimiento, @domicilio, @contraseña)";

                    using (SqlCommand cmd = new SqlCommand(insert, con))
                    {
                        cmd.Parameters.AddWithValue("@nombre", textNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellido", textApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@dni", textDni.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefono", textTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@correo", textCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@rol", cbTipoUsuario.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNac.Value.Date);
                        cmd.Parameters.AddWithValue("@domicilio", textDomicilio.Text.Trim());
                        cmd.Parameters.AddWithValue("@contraseña", contraseñaGenerada); // en produccion, guardar hash en lugar de texto
                        cmd.ExecuteNonQuery();
                    }
                }

                // Enviar contraseña al correo (si falla, el método mostrará la contraseña)
                EnviarCorreoContraseña(textCorreo.Text.Trim(), textNombre.Text.Trim(), contraseñaGenerada);

                MessageBox.Show($"Usuario agregado correctamente.\nSe envió la contraseña al correo {textCorreo.Text}.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmpleados.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un usuario para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!CamposCompletos())
                {
                    MessageBox.Show("Debe completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarCorreo(textCorreo.Text))
                {
                    MessageBox.Show("El correo debe ser válido y tener @.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarRolSeleccionado())
                {
                    MessageBox.Show("Seleccione un rol válido (Empleado, Gerente, Administrador).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(GetCellString(dgvEmpleados.CurrentRow, "id_usuario"));

                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();

                    // Nota: no modificamos la contraseña aquí. Para cambiarla, usar ResetearContraseñaSeleccionada()
                    string update =
                        "UPDATE Usuario SET nombre=@nombre, apellido=@apellido, dni=@dni, telefono=@telefono, correo=@correo, rol=@rol, fecha_nacimiento=@fecha_nacimiento, domicilio=@domicilio " +
                        "WHERE id_usuario=@id";

                    using (SqlCommand cmd = new SqlCommand(update, con))
                    {
                        cmd.Parameters.AddWithValue("@nombre", textNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellido", textApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@dni", textDni.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefono", textTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@correo", textCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@rol", cbTipoUsuario.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNac.Value.Date);
                        cmd.Parameters.AddWithValue("@domicilio", textDomicilio.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", id);

                        int filas = cmd.ExecuteNonQuery();
                        if (filas > 0)
                            MessageBox.Show("Usuario modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("No se encontró el usuario para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                ClearForm();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método público para resetear la contraseña de la fila seleccionada (puede enlazarse a un botón aparte)
        public void ResetearContraseñaSeleccionada()
        {
            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario para resetear la contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(GetCellString(dgvEmpleados.CurrentRow, "id_usuario"));
            string nombre = GetCellString(dgvEmpleados.CurrentRow, "nombre");
            string mail = GetCellString(dgvEmpleados.CurrentRow, "correo");

            string nuevaContra = GenerarContraseña();

            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();
                    string update = "UPDATE Usuario SET [contraseña]=@contraseña WHERE id_usuario=@id";
                    using (SqlCommand cmd = new SqlCommand(update, con))
                    {
                        cmd.Parameters.AddWithValue("@contraseña", nuevaContra);
                        cmd.Parameters.AddWithValue("@id", id);
                        int filas = cmd.ExecuteNonQuery();
                        if (filas > 0)
                        {
                            EnviarCorreoContraseña(mail, nombre, nuevaContra);
                            MessageBox.Show("Contraseña reseteada y enviada al correo del usuario.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el usuario para resetear la contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al resetear la contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------- BOTÓN BUSCAR ----------------------
        private void bBuscar_Click(object sender, EventArgs e)
        {
            // Verificar si todos los campos están vacíos
            if (string.IsNullOrWhiteSpace(textNombre.Text) &&
                string.IsNullOrWhiteSpace(textApellido.Text) &&
                string.IsNullOrWhiteSpace(textDni.Text) &&
                string.IsNullOrWhiteSpace(textTelefono.Text) &&
                string.IsNullOrWhiteSpace(textCorreo.Text) &&
                cbTipoUsuario.SelectedIndex == -1 &&
                string.IsNullOrWhiteSpace(textDomicilio.Text))
            {
                MessageBox.Show("Rellene uno o más campos para poder buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();

                    // Construimos la consulta dinámicamente
                    string query = "SELECT id_usuario, nombre, apellido, dni, telefono, correo, rol, fecha_nacimiento, domicilio, [contraseña] AS contraseña FROM Usuario WHERE 1=1";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    if (!string.IsNullOrWhiteSpace(textNombre.Text))
                    {
                        query += " AND nombre LIKE @nombre";
                        cmd.Parameters.AddWithValue("@nombre", "%" + textNombre.Text.Trim() + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(textApellido.Text))
                    {
                        query += " AND apellido LIKE @apellido";
                        cmd.Parameters.AddWithValue("@apellido", "%" + textApellido.Text.Trim() + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(textDni.Text))
                    {
                        query += " AND dni LIKE @dni";
                        cmd.Parameters.AddWithValue("@dni", "%" + textDni.Text.Trim() + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(textTelefono.Text))
                    {
                        query += " AND telefono LIKE @telefono";
                        cmd.Parameters.AddWithValue("@telefono", "%" + textTelefono.Text.Trim() + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(textCorreo.Text))
                    {
                        query += " AND correo LIKE @correo";
                        cmd.Parameters.AddWithValue("@correo", "%" + textCorreo.Text.Trim() + "%");
                    }
                    if (cbTipoUsuario.SelectedIndex != -1)
                    {
                        query += " AND rol = @rol";
                        cmd.Parameters.AddWithValue("@rol", cbTipoUsuario.SelectedItem.ToString());
                    }
                    if (!string.IsNullOrWhiteSpace(textDomicilio.Text))
                    {
                        query += " AND domicilio LIKE @domicilio";
                        cmd.Parameters.AddWithValue("@domicilio", "%" + textDomicilio.Text.Trim() + "%");
                    }

                    cmd.CommandText = query;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 🔹 Comprobar si hay resultados
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay ningún empleado que tenga esos datos en la base de datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dgvEmpleados.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ---------------------- BOTÓN CANCELAR ----------------------
        private void bCancelar_Click(object sender, EventArgs e)
        {
            // Verificar si todos los campos están vacíos
            if (string.IsNullOrWhiteSpace(textNombre.Text) &&
                string.IsNullOrWhiteSpace(textApellido.Text) &&
                string.IsNullOrWhiteSpace(textDni.Text) &&
                string.IsNullOrWhiteSpace(textTelefono.Text) &&
                string.IsNullOrWhiteSpace(textCorreo.Text) &&
                cbTipoUsuario.SelectedIndex == -1 &&
                string.IsNullOrWhiteSpace(textDomicilio.Text))
            {
                MessageBox.Show("El formulario ya está limpio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ClearForm();
            MessageBox.Show("Formulario limpiado correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmpleados.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un usuario para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(GetCellString(dgvEmpleados.CurrentRow, "id_usuario"));

                var dr = MessageBox.Show("¿Está seguro de eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;

                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Usuario WHERE id_usuario=@id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int filas = cmd.ExecuteNonQuery();
                        if (filas > 0)
                            MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("No se encontró el usuario para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                ClearForm();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Helpers UI

        private bool CamposCompletos()
        {
            return !string.IsNullOrWhiteSpace(textNombre.Text) &&
                   !string.IsNullOrWhiteSpace(textApellido.Text) &&
                   !string.IsNullOrWhiteSpace(textDni.Text) &&
                   !string.IsNullOrWhiteSpace(textTelefono.Text) &&
                   !string.IsNullOrWhiteSpace(textCorreo.Text) &&
                   cbTipoUsuario.SelectedIndex != -1 &&
                   !string.IsNullOrWhiteSpace(textDomicilio.Text);
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvEmpleados.Rows[e.RowIndex];

            textNombre.Text = GetCellString(fila, "nombre");
            textApellido.Text = GetCellString(fila, "apellido");
            textDni.Text = GetCellString(fila, "dni");
            textTelefono.Text = GetCellString(fila, "telefono");
            textCorreo.Text = GetCellString(fila, "Correo");
            cbTipoUsuario.SelectedItem = GetCellString(fila, "rol");

            // Fecha (segura)
            var val = fila.Cells["fecha_nacimiento"].Value;
            if (val != null && val != DBNull.Value && DateTime.TryParse(val.ToString(), out DateTime fecha))
                dtpFechaNac.Value = fecha;
            else
                dtpFechaNac.Value = DateTime.Today;

            textDomicilio.Text = GetCellString(fila, "domicilio");

            // No cargamos la contraseña en campos (la mantenemos oculta en la grilla)
        }

        /// <summary>
        /// Obtiene el valor de una celda como string respetando nulos.
        /// </summary>
        private string GetCellString(DataGridViewRow row, string columnName)
        {
            if (row == null) return string.Empty;
            if (!dgvEmpleados.Columns.Contains(columnName)) return string.Empty;
            var cell = row.Cells[columnName];
            if (cell == null || cell.Value == null || cell.Value == DBNull.Value) return string.Empty;
            return cell.Value.ToString();
        }

        private void ClearForm()
        {
            textNombre.Clear();
            textApellido.Clear();
            textDni.Clear();
            textTelefono.Clear();
            textCorreo.Clear();
            textDomicilio.Clear();
            cbTipoUsuario.SelectedIndex = -1;
            dtpFechaNac.Value = DateTime.Today;
            dgvEmpleados.ClearSelection();
        }

        #endregion

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
