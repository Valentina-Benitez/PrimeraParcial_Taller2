using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Taller_AppRestaurante
{
    public partial class FormClientes : Form
    {
        // ===========================================================
        // CONSTRUCTOR DEL FORMULARIO
        // Configura los eventos, columnas y carga inicial de datos
        // ===========================================================
        public FormClientes()
        {
            InitializeComponent();

            this.Load += FormAgregarCliente_Load; // Evento de carga

            // Configuración del DataGridView (sin autogenerar columnas)
            dvgClientes.AutoGenerateColumns = false;

            // Asigna cada columna del DataGridView a un campo de la tabla Cliente
            Column1.DataPropertyName = "nombre";
            Column5.DataPropertyName = "apellido";
            Column3.DataPropertyName = "fecha_nacimiento";
            Colum4.DataPropertyName = "dni";
            Column6.DataPropertyName = "telefono";
            Column2.DataPropertyName = "Gmail";
            Column4.DataPropertyName = "tipo_cliente";

            // Carga inicial de clientes desde la base de datos
            CargarClientes();

            // Evento de búsqueda dinámica
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
        }

        // ===========================================================
        // MÉTODO: ObtenerConexion()
        // Retorna una conexión abierta a la base de datos del restaurante
        // ===========================================================
        private SqlConnection ObtenerConexion()
        {
            string cadena = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";
            return new SqlConnection(cadena);
        }

        // ===========================================================
        // EVENTO LOAD: se ejecuta al iniciar el formulario
        // Carga las opciones del combo tipo de cliente
        // ===========================================================
        private void FormAgregarCliente_Load(object sender, EventArgs e)
        {
            comboTipo.Items.Add("VIP");
            comboTipo.Items.Add("Frecuente");
            comboTipo.Items.Add("Nuevo");
        }

        // ===========================================================
        // MÉTODO: CargarClientes()
        // Trae todos los clientes desde la base de datos y los muestra
        // ===========================================================
        private void CargarClientes()
        {
            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Cliente", con);
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
        // BOTÓN GUARDAR: Inserta un nuevo cliente en la base de datos
        // ===========================================================
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // Captura los datos ingresados por el usuario
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string Gmail = txtCorreo.Text.Trim();
            DateTime fecha_nacimiento = dtpFechaNac.Value;
            string dni = txtDNI.Text.Trim();
            string tipo_cliente = comboTipo.Text.Trim();

            // Validación de campos vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(telefono) ||
                string.IsNullOrEmpty(Gmail) || string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(tipo_cliente))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();
                    string query = @"INSERT INTO Cliente(nombre, apellido, fecha_nacimiento, dni, telefono, Gmail, tipo_cliente)
                                     VALUES (@nombre, @apellido, @fecha_nacimiento, @dni, @telefono, @Gmail, @tipo_cliente)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Asignación de parámetros
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", fecha_nacimiento);
                        cmd.Parameters.AddWithValue("@dni", dni);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@Gmail", Gmail);
                        cmd.Parameters.AddWithValue("@tipo_cliente", tipo_cliente);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cliente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();   // Limpia los campos después de guardar
                CargarClientes();  // Refresca la lista de clientes
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cliente: " + ex.Message);
            }
        }

        // ===========================================================
        // BOTÓN CANCELAR: Limpia los campos del formulario
        // ===========================================================
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // ===========================================================
        // MÉTODO: LimpiarCampos()
        // Restaura los controles del formulario a su estado inicial
        // ===========================================================
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDNI.Clear();
            dtpFechaNac.Value = DateTime.Today;
        }

        // ===========================================================
        // EVENTO: txtBusqueda_TextChanged
        // Filtra los clientes por nombre o DNI mientras se escribe
        // ===========================================================
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();
                    string query = "SELECT * FROM Cliente WHERE nombre LIKE @busqueda OR dni LIKE @busqueda";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@busqueda", "%" + txtBusqueda.Text.Trim() + "%");
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dvgClientes.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la búsqueda: " + ex.Message);
            }
        }

        // ===========================================================
        // EVENTOS DE INTERFAZ (sin lógica funcional relevante)
        // ===========================================================
        private void dvgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e) { }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e) { }
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e) { }
        private void txtCorreo_TextChanged(object sender, EventArgs e) { }
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void txtApellido_TextChanged(object sender, EventArgs e) { }
        private void FormClientes_Load(object sender, EventArgs e) { }
        private void dvgClientes_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void panel2_Paint_1(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void txtBusqueda_TextChanged_1(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }

        // ===========================================================
        // VALIDACIONES DE ENTRADA (solo letras, números, correo válido)
        // ===========================================================
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite letras, espacios y teclas de control
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y teclas de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            // Verifica que el correo tenga al menos un "@"
            if (!txtCorreo.Text.Contains("@"))
            {
                MessageBox.Show("El correo debe contener @", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
            }
        }

        // Eventos sin uso actual (se mantienen por compatibilidad del diseñador)
        private void txtApellido_TextChanged_1(object sender, EventArgs e) { }
        private void txtTipo_TextChanged(object sender, EventArgs e) { }
        private void txtNombre_TextChanged_1(object sender, EventArgs e) { }
        private void txtDNI_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
