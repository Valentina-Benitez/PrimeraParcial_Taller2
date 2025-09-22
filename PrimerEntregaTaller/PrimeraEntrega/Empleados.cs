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

        // Roles válidos
        private readonly string[] RolesValidos = new[] { "Empleado", "Gerente", "Administrador" };

        public Empleados()
        {
            InitializeComponent();

            // ------------------- Preparación del DataGridView -------------------
            // Evitamos la generación automática de columnas y limpiamos las columnas del diseñador
            dgvEmpleados.AutoGenerateColumns = false;
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.MultiSelect = false;
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.Columns.Clear();
            CrearColumnasDgv(); // creamos columnas programáticamente para evitar duplicadas

            // ------------------- Vincular validaciones de teclado -------------------
            textNombre.KeyPress += SoloLetras;
            textApellido.KeyPress += SoloLetras;
            textDni.KeyPress += SoloNumeros;
            textTelefono.KeyPress += SoloNumeros;
            textGmail.KeyPress += SinEspacios;
            textContraseña.KeyPress += SinEspacios;
            textReContraseña.KeyPress += SinEspacios;

            // ------------------- Poblamos combo de roles -------------------
            cbTipoUsuario.Items.Clear();
            cbTipoUsuario.Items.AddRange(RolesValidos);

            // ------------------- Aseguramos que los botones tengan sus handlers -------------------
            // (esto enlaza los botones en runtime en caso de que no estén enlazados desde el diseñador)
            bAgregar.Click -= btnAgregar_Click; // quitar por seguridad antes de agregar
            bAgregar.Click += btnAgregar_Click;
            bModificar.Click -= btnModificar_Click;
            bModificar.Click += btnModificar_Click;
            bEliminar.Click -= btnEliminar_Click;
            bEliminar.Click += btnEliminar_Click;
            dgvEmpleados.CellClick -= dgvEmpleados_CellClick;
            dgvEmpleados.CellClick += dgvEmpleados_CellClick;
            bBuscar.Click -= bBuscar_Click; bBuscar.Click += bBuscar_Click;
            bCancelar.Click -= bCancelar_Click; bCancelar.Click += bCancelar_Click;

            // ------------------- Cargar datos -------------------
            CargarUsuarios();
        }

        #region DataGridView Columnas (creación programática)

        /// <summary>
        /// Crea las columnas del DataGridView con DataPropertyName que coincida
        /// con el resultado del SELECT (ver CargarUsuarios).
        /// NOTA: en la consulta SELECT aliasamos la columna 'contraseña' como 'contrasena'
        /// para evitar problemas con caracteres especiales en los nombres.
        /// </summary>
        private void CrearColumnasDgv()
        {
            var cId = new DataGridViewTextBoxColumn { Name = "id_usuario", DataPropertyName = "id_usuario", HeaderText = "ID", ReadOnly = true };
            var cNombre = new DataGridViewTextBoxColumn { Name = "nombre", DataPropertyName = "nombre", HeaderText = "Nombre" };
            var cApellido = new DataGridViewTextBoxColumn { Name = "apellido", DataPropertyName = "apellido", HeaderText = "Apellido" };
            var cDni = new DataGridViewTextBoxColumn { Name = "dni", DataPropertyName = "dni", HeaderText = "DNI" };
            var cTelefono = new DataGridViewTextBoxColumn { Name = "telefono", DataPropertyName = "telefono", HeaderText = "Teléfono" };
            var cGmail = new DataGridViewTextBoxColumn { Name = "Gmail", DataPropertyName = "Gmail", HeaderText = "Gmail" };
            var cRol = new DataGridViewTextBoxColumn { Name = "rol", DataPropertyName = "rol", HeaderText = "Rol" };
            var cFecha = new DataGridViewTextBoxColumn { Name = "fecha_nacimiento", DataPropertyName = "fecha_nacimiento", HeaderText = "Fecha Nac." };
            var cDomicilio = new DataGridViewTextBoxColumn { Name = "domicilio", DataPropertyName = "domicilio", HeaderText = "Domicilio" };
            // contraseña la traemos con alias "contrasena" (sin ñ) para evitar problemas con nombres
            var cContra = new DataGridViewTextBoxColumn { Name = "contrasena", DataPropertyName = "contrasena", HeaderText = "Contraseña", Visible = false }; // ocultamos la contraseña en la grilla

            dgvEmpleados.Columns.AddRange(new DataGridViewColumn[] { cId, cNombre, cApellido, cDni, cTelefono, cGmail, cRol, cFecha, cDomicilio, cContra });
        }

        #endregion

        #region Conexión

        private SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }

        #endregion

        #region Validaciones de entrada

        private void SoloLetras(object sender, KeyPressEventArgs e)
        {
            // Permite letras, espacio y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }

            // Bloquea vocales acentuadas y otros caracteres especiales
            string noPermitidos = "áéíóúÁÉÍÓÚüÜ";
            if (noPermitidos.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            // Permite números y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void SinEspacios(object sender, KeyPressEventArgs e)
        {
            // Evita espacios en campos como gmail/contraseña
            if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private bool ValidarCorreo(string correo)
        {
            // Validación simple que exige dominio gmail.com (según tu requerimiento)
            string patron = @"^[a-zA-Z0-9._%+-]+@";
            return Regex.IsMatch(correo, patron);
        }

        private bool ValidarContraseñasIguales()
        {
            return textContraseña.Text == textReContraseña.Text;
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
        /// NOTA: aliasamos [contraseña] AS contrasena para evitar caracteres especiales.
        /// </summary>
        private void CargarUsuarios()
        {
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();

                    string query =
                        "SELECT id_usuario, nombre, apellido, dni, telefono, Gmail, rol, fecha_nacimiento, domicilio, [contraseña] AS contrasena " +
                        "FROM Usuario";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Asignamos la fuente (liberamos primero para evitar referencias antiguas)
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

                if (!ValidarCorreo(textGmail.Text))
                {
                    MessageBox.Show("El correo debe ser válido y terminar en @gmail.com.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarContraseñasIguales())
                {
                    MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarRolSeleccionado())
                {
                    MessageBox.Show("Seleccione un rol válido (Empleado, Gerente, Administrador).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();

                    // Evitar duplicados por DNI o Gmail
                    string check = "SELECT COUNT(*) FROM Usuario WHERE dni = @dni OR Gmail = @gmail";
                    using (SqlCommand checkCmd = new SqlCommand(check, con))
                    {
                        checkCmd.Parameters.AddWithValue("@dni", textDni.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@gmail", textGmail.Text.Trim());
                        int existe = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (existe > 0)
                        {
                            MessageBox.Show("Ya existe un usuario con ese DNI o Gmail.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Insert (usamos [contraseña] entre corchetes porque tiene ñ)
                    string insert =
                        "INSERT INTO Usuario (nombre, apellido, dni, telefono, Gmail, rol, fecha_nacimiento, domicilio, [contraseña]) " +
                        "VALUES (@nombre, @apellido, @dni, @telefono, @gmail, @rol, @fecha_nacimiento, @domicilio, @contrasena)";

                    using (SqlCommand cmd = new SqlCommand(insert, con))
                    {
                        cmd.Parameters.AddWithValue("@nombre", textNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellido", textApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@dni", textDni.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefono", textTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@gmail", textGmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@rol", cbTipoUsuario.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNac.Value.Date);
                        cmd.Parameters.AddWithValue("@domicilio", textDomicilio.Text.Trim());
                        cmd.Parameters.AddWithValue("@contrasena", textContraseña.Text); // en produccion, guardar hash en lugar de texto
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                if (!ValidarCorreo(textGmail.Text))
                {
                    MessageBox.Show("El correo debe ser válido y terminar en @gmail.com.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarContraseñasIguales())
                {
                    MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    string update =
                        "UPDATE Usuario SET nombre=@nombre, apellido=@apellido, dni=@dni, telefono=@telefono, Gmail=@gmail, rol=@rol, fecha_nacimiento=@fecha_nacimiento, domicilio=@domicilio, [contraseña]=@contrasena " +
                        "WHERE id_usuario=@id";

                    using (SqlCommand cmd = new SqlCommand(update, con))
                    {
                        cmd.Parameters.AddWithValue("@nombre", textNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellido", textApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@dni", textDni.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefono", textTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@gmail", textGmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@rol", cbTipoUsuario.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNac.Value.Date);
                        cmd.Parameters.AddWithValue("@domicilio", textDomicilio.Text.Trim());
                        cmd.Parameters.AddWithValue("@contrasena", textContraseña.Text);
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
        // ---------------------- BOTÓN BUSCAR ----------------------
        private void bBuscar_Click(object sender, EventArgs e)
        {
            // Verificar si todos los campos están vacíos
            if (string.IsNullOrWhiteSpace(textNombre.Text) &&
                string.IsNullOrWhiteSpace(textApellido.Text) &&
                string.IsNullOrWhiteSpace(textDni.Text) &&
                string.IsNullOrWhiteSpace(textTelefono.Text) &&
                string.IsNullOrWhiteSpace(textGmail.Text) &&
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
                    string query = "SELECT id_usuario, nombre, apellido, dni, telefono, Gmail, rol, fecha_nacimiento, domicilio, [contraseña] AS contrasena FROM Usuario WHERE 1=1";
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
                    if (!string.IsNullOrWhiteSpace(textGmail.Text))
                    {
                        query += " AND Gmail LIKE @gmail";
                        cmd.Parameters.AddWithValue("@gmail", "%" + textGmail.Text.Trim() + "%");
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
                string.IsNullOrWhiteSpace(textGmail.Text) &&
                cbTipoUsuario.SelectedIndex == -1 &&
                string.IsNullOrWhiteSpace(textContraseña.Text) &&
                string.IsNullOrWhiteSpace(textReContraseña.Text) &&
                string.IsNullOrWhiteSpace(textDomicilio.Text))
            {
                MessageBox.Show("El formulario ya está limpio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ClearForm();
            MessageBox.Show("Formulario limpiado correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                   !string.IsNullOrWhiteSpace(textGmail.Text) &&
                   cbTipoUsuario.SelectedIndex != -1 &&
                   !string.IsNullOrWhiteSpace(textContraseña.Text) &&
                   !string.IsNullOrWhiteSpace(textReContraseña.Text) &&
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
            textGmail.Text = GetCellString(fila, "Gmail");
            cbTipoUsuario.SelectedItem = GetCellString(fila, "rol");

            // Fecha (segura)
            var val = fila.Cells["fecha_nacimiento"].Value;
            if (val != null && val != DBNull.Value && DateTime.TryParse(val.ToString(), out DateTime fecha))
                dtpFechaNac.Value = fecha;
            else
                dtpFechaNac.Value = DateTime.Today;

            textDomicilio.Text = GetCellString(fila, "domicilio");

            // contraseña viene del alias 'contrasena'
            string contra = GetCellString(fila, "contrasena");
            textContraseña.Text = contra;
            textReContraseña.Text = contra;
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
            textGmail.Clear();
            textContraseña.Clear();
            textReContraseña.Clear();
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
    }
}

