using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Taller_AppRestaurante
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();

            // Desactivar generación automática de columnas
            dvgClientes.AutoGenerateColumns = false;

            // Asignar DataPropertyName a cada columna
            Column1.DataPropertyName = "nombre";
            Column5.DataPropertyName = "apellido";
            Column3.DataPropertyName = "fecha_nacimiento";
            Colum4.DataPropertyName = "dni";
            Column6.DataPropertyName = "telefono";
            Column2.DataPropertyName = "Gmail";
            Column4.DataPropertyName = "tipo_cliente";

            // Cargar clientes
            CargarClientes();

            // Evento de búsqueda
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
        }

        private SqlConnection ObtenerConexion()
        {
            string cadena = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";
            return new SqlConnection(cadena);
        }

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

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string Gmail = txtCorreo.Text.Trim();
            DateTime fecha_nacimiento = dtpFechaNac.Value;
            string dni = txtDNI.Text.Trim();
            string tipo_cliente = txtTipo.Text.Trim();

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
                LimpiarCampos();
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cliente: " + ex.Message);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDNI.Clear();
            txtTipo.Clear();
            dtpFechaNac.Value = DateTime.Today;
        }

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

    }
}
