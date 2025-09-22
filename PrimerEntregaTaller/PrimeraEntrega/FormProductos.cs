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

using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace gerente
{
    public partial class FormProductos : Form
    {
        private string connectionString = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";

        public FormProductos()
        {
            InitializeComponent();

            // ------------------- Configurar DataGridView -------------------
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.Columns.Clear();
            CrearColumnasDgv();

            // ------------------- Validaciones -------------------
            textNombreP.KeyPress += SoloLetras;
            textCategoriaP.KeyPress += SoloLetras;
            textDescuentoP.KeyPress += SoloNumeros;
            textPrecioP.KeyPress += SoloNumeros;

            // ------------------- ComboBox estado -------------------
            cbEstadoP.Items.Clear();
            cbEstadoP.Items.Add("Disponible");
            cbEstadoP.Items.Add("No Disponible");
            cbEstadoP.DropDownStyle = ComboBoxStyle.DropDownList;

            // ------------------- Enlazar botones -------------------
            bAgregar.Click -= bAgregar_Click; bAgregar.Click += bAgregar_Click;
            bModificar.Click -= bModificar_Click; bModificar.Click += bModificar_Click;
            bEliminar.Click -= bEliminar_Click; bEliminar.Click += bEliminar_Click;
            bBuscar.Click -= bBuscar_Click; bBuscar.Click += bBuscar_Click;
            bCancelar.Click -= bCancelar_Click; bCancelar.Click += bCancelar_Click;
            dgvProductos.CellClick -= dgvProductos_CellClick; dgvProductos.CellClick += dgvProductos_CellClick;

            // ------------------- Cargar productos -------------------
            CargarProductos();
        }

        #region DataGridView Columnas
        private void CrearColumnasDgv()
        {
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nombre", DataPropertyName = "nombre", HeaderText = "Nombre" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "categoria", DataPropertyName = "categoria", HeaderText = "Categoría" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "descuento", DataPropertyName = "descuento", HeaderText = "Descuento" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "descripcion", DataPropertyName = "descripcion", HeaderText = "Descripción" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "estado", DataPropertyName = "estado", HeaderText = "Estado" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "precio", DataPropertyName = "precio", HeaderText = "Precio" });
        }
        #endregion

        #region Conexión
        private SqlConnection ObtenerConexion() => new SqlConnection(connectionString);
        #endregion

        #region Validaciones
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
        #endregion

        #region CRUD Productos

        private void CargarProductos()
        {
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT nombre, categoria, descuento, descripcion, estado, precio FROM Producto";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProductos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bAgregar_Click(object sender, EventArgs e)
        {
            if (!CamposCompletos())
            {
                MessageBox.Show("Complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = ObtenerConexion())
            {
                conn.Open();

                // Evitar duplicados
                string checkQuery = "SELECT COUNT(*) FROM Producto WHERE nombre=@nombre AND categoria=@categoria";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@nombre", textNombreP.Text.Trim());
                    checkCmd.Parameters.AddWithValue("@categoria", textCategoriaP.Text.Trim());
                    int existe = (int)checkCmd.ExecuteScalar();
                    if (existe > 0)
                    {
                        MessageBox.Show("El producto ya existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Insertar producto
                string query = @"INSERT INTO Producto (nombre, categoria, descuento, descripcion, estado, precio) 
                                 VALUES (@nombre, @categoria, @descuento, @descripcion, @estado, @precio)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", textNombreP.Text.Trim());
                    cmd.Parameters.AddWithValue("@categoria", textCategoriaP.Text.Trim());
                    cmd.Parameters.AddWithValue("@descuento", decimal.Parse(textDescuentoP.Text));
                    cmd.Parameters.AddWithValue("@descripcion", textDescripcion.Text.Trim());
                    cmd.Parameters.AddWithValue("@estado", cbEstadoP.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@precio", decimal.Parse(textPrecioP.Text));
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
            CargarProductos();
        }

        private void bModificar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreOriginal = dgvProductos.CurrentRow.Cells["nombre"].Value.ToString();
            string categoriaOriginal = dgvProductos.CurrentRow.Cells["categoria"].Value.ToString();

            using (SqlConnection conn = ObtenerConexion())
            {
                conn.Open();
                string query = @"UPDATE Producto SET 
                                nombre=@nombre, categoria=@categoria, descuento=@descuento, descripcion=@descripcion, estado=@estado, precio=@precio
                                WHERE nombre=@nombreOriginal AND categoria=@categoriaOriginal";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", textNombreP.Text.Trim());
                    cmd.Parameters.AddWithValue("@categoria", textCategoriaP.Text.Trim());
                    cmd.Parameters.AddWithValue("@descuento", decimal.Parse(textDescuentoP.Text));
                    cmd.Parameters.AddWithValue("@descripcion", textDescripcion.Text.Trim());
                    cmd.Parameters.AddWithValue("@estado", cbEstadoP.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@precio", decimal.Parse(textPrecioP.Text));
                    cmd.Parameters.AddWithValue("@nombreOriginal", nombreOriginal);
                    cmd.Parameters.AddWithValue("@categoriaOriginal", categoriaOriginal);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Producto modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
            CargarProductos();
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = dgvProductos.CurrentRow.Cells["nombre"].Value.ToString();
            string categoria = dgvProductos.CurrentRow.Cells["categoria"].Value.ToString();

            var dr = MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            using (SqlConnection conn = ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM Producto WHERE nombre=@nombre AND categoria=@categoria";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
            CargarProductos();
        }

        #endregion

        #region Buscar y Cancelar

        private void bBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNombreP.Text) &&
                string.IsNullOrWhiteSpace(textCategoriaP.Text) &&
                string.IsNullOrWhiteSpace(textDescuentoP.Text) &&
                string.IsNullOrWhiteSpace(textDescripcion.Text) &&
                string.IsNullOrWhiteSpace(textPrecioP.Text) &&
                cbEstadoP.SelectedIndex == -1)
            {
                MessageBox.Show("Rellene uno o más campos para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT nombre, categoria, descuento, descripcion, estado, precio FROM Producto WHERE 1=1";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    if (!string.IsNullOrWhiteSpace(textNombreP.Text)) { query += " AND nombre LIKE @nombre"; cmd.Parameters.AddWithValue("@nombre", "%" + textNombreP.Text.Trim() + "%"); }
                    if (!string.IsNullOrWhiteSpace(textCategoriaP.Text)) { query += " AND categoria LIKE @categoria"; cmd.Parameters.AddWithValue("@categoria", "%" + textCategoriaP.Text.Trim() + "%"); }
                    if (!string.IsNullOrWhiteSpace(textDescuentoP.Text)) { query += " AND descuento=@descuento"; cmd.Parameters.AddWithValue("@descuento", decimal.Parse(textDescuentoP.Text)); }
                    if (!string.IsNullOrWhiteSpace(textDescripcion.Text)) { query += " AND descripcion LIKE @descripcion"; cmd.Parameters.AddWithValue("@descripcion", "%" + textDescripcion.Text.Trim() + "%"); }
                    if (cbEstadoP.SelectedIndex != -1) { query += " AND estado=@estado"; cmd.Parameters.AddWithValue("@estado", cbEstadoP.SelectedItem.ToString()); }
                    if (!string.IsNullOrWhiteSpace(textPrecioP.Text)) { query += " AND precio=@precio"; cmd.Parameters.AddWithValue("@precio", decimal.Parse(textPrecioP.Text)); }

                    cmd.CommandText = query;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron productos con esos datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                    else
                    {
                        dgvProductos.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            MessageBox.Show("Formulario limpiado correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Helpers UI

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

            textNombreP.Text = fila.Cells["nombre"].Value?.ToString();
            textCategoriaP.Text = fila.Cells["categoria"].Value?.ToString();
            textDescuentoP.Text = fila.Cells["descuento"].Value?.ToString();
            textDescripcion.Text = fila.Cells["descripcion"].Value?.ToString();
            textPrecioP.Text = fila.Cells["precio"].Value?.ToString();

            var estado = fila.Cells["estado"].Value?.ToString();
            cbEstadoP.SelectedItem = estado;
        }

        private bool CamposCompletos()
        {
            return !string.IsNullOrWhiteSpace(textNombreP.Text) &&
                   !string.IsNullOrWhiteSpace(textCategoriaP.Text) &&
                   !string.IsNullOrWhiteSpace(textDescuentoP.Text) &&
                   !string.IsNullOrWhiteSpace(textDescripcion.Text) &&
                   !string.IsNullOrWhiteSpace(textPrecioP.Text) &&
                   cbEstadoP.SelectedIndex != -1;
        }

        private void LimpiarFormulario()
        {
            textNombreP.Clear();
            textCategoriaP.Clear();
            textDescuentoP.Clear();
            textDescripcion.Clear();
            textPrecioP.Clear();
            cbEstadoP.SelectedIndex = -1;
            dgvProductos.ClearSelection();
        }

        #endregion

        private void bEliminar_Click_1(object sender, EventArgs e)
        {

        }

        private void FormProductos_Load(object sender, EventArgs e)
        {

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
