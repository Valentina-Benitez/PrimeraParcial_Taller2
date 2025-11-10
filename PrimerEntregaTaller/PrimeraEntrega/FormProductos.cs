using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace gerente
{
    public partial class FormProductos : Form
    {
        // ==============================================================
        // CADENA DE CONEXIÓN PRINCIPAL
        // ==============================================================
        private string connectionString = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";

        // ==============================================================
        // CONSTRUCTOR: Inicializa componentes, eventos y configuraciones
        // ==============================================================
        public FormProductos()
        {
            InitializeComponent();

            // -------- CONFIGURACIÓN DEL DATAGRIDVIEW --------
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.Columns.Clear();
            CrearColumnasDgv(); // crea las columnas manualmente

            // -------- VALIDACIONES DE ENTRADA --------
            textNombreP.KeyPress += SoloLetras;
            textDescuentoP.KeyPress += SoloNumeros;
            textPrecioP.KeyPress += SoloNumeros;

            // -------- CONFIGURACIÓN DEL COMBOBOX ESTADO --------
            cbEstadoP.Items.Clear();
            cbEstadoP.Items.Add("Disponible");
            cbEstadoP.Items.Add("No Disponible");
            cbEstadoP.DropDownStyle = ComboBoxStyle.DropDownList;

            // -------- ENLAZAR EVENTOS DE BOTONES --------
            bAgregar.Click -= bAgregar_Click; bAgregar.Click += bAgregar_Click;
            bModificar.Click -= bModificar_Click; bModificar.Click += bModificar_Click;
            bEliminar.Click -= bEliminar_Click; bEliminar.Click += bEliminar_Click;
            bBuscar.Click -= bBuscar_Click; bBuscar.Click += bBuscar_Click;
            bCancelar.Click -= bCancelar_Click; bCancelar.Click += bCancelar_Click;
            dgvProductos.CellClick -= dgvProductos_CellClick; dgvProductos.CellClick += dgvProductos_CellClick;

            // -------- CARGA INICIAL DE PRODUCTOS --------
            CargarProductos();
        }

        // ==============================================================
        // SECCIÓN: CREACIÓN DE COLUMNAS DEL DGV
        // ==============================================================
        private void CrearColumnasDgv()
        {
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "nombre", DataPropertyName = "nombre", HeaderText = "Nombre" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "categoria", DataPropertyName = "categoria", HeaderText = "Categoría" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "descuento", DataPropertyName = "descuento", HeaderText = "Descuento" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "descripcion", DataPropertyName = "descripcion", HeaderText = "Descripción" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "estado", DataPropertyName = "estado", HeaderText = "Estado" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { Name = "precio", DataPropertyName = "precio", HeaderText = "Precio" });
        }

        // ==============================================================
        // MÉTODO: ObtenerConexion()
        // Retorna una conexión a la base de datos.
        // ==============================================================
        private SqlConnection ObtenerConexion() => new SqlConnection(connectionString);

        // ==============================================================
        // VALIDACIONES DE ENTRADA
        // ==============================================================
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

        // ==============================================================
        // CRUD DE PRODUCTOS
        // ==============================================================
        private void CargarProductos()
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                string query = "SELECT id_producto, nombre, categoria, descripcion, estado, precio, descuento FROM Producto";
                SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dgvProductos.DataSource = tabla;
            }
        }

        // ==============================================================
        // BOTÓN: AGREGAR PRODUCTO
        // ==============================================================
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

                // Verifica duplicados por nombre y categoría
                string checkQuery = "SELECT COUNT(*) FROM Producto WHERE nombre=@nombre AND categoria=@categoria";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@nombre", textNombreP.Text.Trim());
                    checkCmd.Parameters.AddWithValue("@categoria", comboCategoria.Text.Trim());
                    int existe = (int)checkCmd.ExecuteScalar();

                    if (existe > 0)
                    {
                        MessageBox.Show("El producto ya existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Inserta el nuevo producto
                string query = @"INSERT INTO Producto (nombre, categoria, descuento, descripcion, estado, precio) 
                                 VALUES (@nombre, @categoria, @descuento, @descripcion, @estado, @precio)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", textNombreP.Text.Trim());
                    cmd.Parameters.AddWithValue("@categoria", comboCategoria.Text.Trim());
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

        // ==============================================================
        // BOTÓN: MODIFICAR PRODUCTO
        // ==============================================================
        private void bModificar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un producto del listado para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CamposCompletos())
            {
                MessageBox.Show("Debe completar todos los campos antes de modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
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
                        cmd.Parameters.AddWithValue("@categoria", comboCategoria.Text.Trim());
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==============================================================
        // BOTÓN: ELIMINAR (DAR DE BAJA)
        // ==============================================================
        private void bEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un producto para darlo de baja.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = dgvProductos.CurrentRow.Cells["nombre"].Value.ToString();
            string categoria = dgvProductos.CurrentRow.Cells["categoria"].Value.ToString();

            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    conn.Open();

                    // Verifica estado actual
                    string queryVerificar = "SELECT estado FROM Producto WHERE nombre=@nombre AND categoria=@categoria";
                    SqlCommand cmdVerificar = new SqlCommand(queryVerificar, conn);
                    cmdVerificar.Parameters.AddWithValue("@nombre", nombre);
                    cmdVerificar.Parameters.AddWithValue("@categoria", categoria);
                    string estadoActual = cmdVerificar.ExecuteScalar()?.ToString();

                    if (estadoActual == "No Disponible")
                    {
                        MessageBox.Show("Este producto ya está dado de baja.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Confirmación
                    DialogResult confirmar = MessageBox.Show("¿Está seguro de dar de baja este producto?",
                                                             "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmar == DialogResult.No) return;

                    // Actualiza estado a "No Disponible"
                    string queryActualizar = "UPDATE Producto SET estado='No Disponible' WHERE nombre=@nombre AND categoria=@categoria";
                    SqlCommand cmdActualizar = new SqlCommand(queryActualizar, conn);
                    cmdActualizar.Parameters.AddWithValue("@nombre", nombre);
                    cmdActualizar.Parameters.AddWithValue("@categoria", categoria);
                    cmdActualizar.ExecuteNonQuery();

                    MessageBox.Show("El producto fue dado de baja correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarProductos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar el estado del producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==============================================================
        // BOTÓN: BUSCAR PRODUCTOS POR CRITERIOS
        // ==============================================================
        private void bBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNombreP.Text) &&
                string.IsNullOrWhiteSpace(comboCategoria.Text) &&
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

                    // Filtros dinámicos según los campos llenos
                    if (!string.IsNullOrWhiteSpace(textNombreP.Text)) { query += " AND nombre LIKE @nombre"; cmd.Parameters.AddWithValue("@nombre", "%" + textNombreP.Text.Trim() + "%"); }
                    if (!string.IsNullOrWhiteSpace(comboCategoria.Text)) { query += " AND categoria LIKE @categoria"; cmd.Parameters.AddWithValue("@categoria", "%" + comboCategoria.Text.Trim() + "%"); }
                    if (!string.IsNullOrWhiteSpace(textDescuentoP.Text)) { query += " AND descuento=@descuento"; cmd.Parameters.AddWithValue("@descuento", decimal.Parse(textDescuentoP.Text)); }
                    if (!string.IsNullOrWhiteSpace(textDescripcion.Text)) { query += " AND descripcion LIKE @descripcion"; cmd.Parameters.AddWithValue("@descripcion", "%" + textDescripcion.Text.Trim() + "%"); }
                    if (cbEstadoP.SelectedIndex != -1) { query += " AND estado=@estado"; cmd.Parameters.AddWithValue("@estado", cbEstadoP.SelectedItem.ToString()); }
                    if (!string.IsNullOrWhiteSpace(textPrecioP.Text)) { query += " AND precio=@precio"; cmd.Parameters.AddWithValue("@precio", decimal.Parse(textPrecioP.Text)); }

                    cmd.CommandText = query;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("No se encontraron productos con esos datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        dgvProductos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==============================================================
        // BOTÓN: CANCELAR
        // Limpia campos y recarga la lista completa
        // ==============================================================
        private void bCancelar_Click(object sender, EventArgs e)
        {
            if (!CamposCompletos())
            {
                MessageBox.Show("El formulario ya está vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProductos();
                return;
            }

            LimpiarFormulario();
            CargarProductos();

            MessageBox.Show("Formulario limpiado y lista de productos recargada correctamente.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==============================================================
        // EVENTO: Al hacer clic en una fila del DGV → llena los campos
        // ==============================================================
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

            textNombreP.Text = fila.Cells["nombre"].Value?.ToString();
            comboCategoria.Text = fila.Cells["categoria"].Value?.ToString();
            textDescuentoP.Text = fila.Cells["descuento"].Value?.ToString();
            textDescripcion.Text = fila.Cells["descripcion"].Value?.ToString();
            textPrecioP.Text = fila.Cells["precio"].Value?.ToString();

            var estado = fila.Cells["estado"].Value?.ToString();
            cbEstadoP.SelectedItem = estado;
        }

        // ==============================================================
        // MÉTODOS AUXILIARES (Helpers UI)
        // ==============================================================
        private bool CamposCompletos()
        {
            return !(string.IsNullOrWhiteSpace(textNombreP.Text) &&
                     string.IsNullOrWhiteSpace(comboCategoria.Text) &&
                     string.IsNullOrWhiteSpace(textDescuentoP.Text) &&
                     string.IsNullOrWhiteSpace(textDescripcion.Text) &&
                     string.IsNullOrWhiteSpace(textPrecioP.Text) &&
                     cbEstadoP.SelectedIndex == -1);
        }

        private void LimpiarFormulario()
        {
            textNombreP.Clear();
            textDescuentoP.Clear();
            textDescripcion.Clear();
            textPrecioP.Clear();
            cbEstadoP.SelectedIndex = -1;
            comboCategoria.SelectedIndex = -1;
            dgvProductos.ClearSelection();
        }

        // ==============================================================
        // EVENTO LOAD: configura categorías al abrir el formulario
        // ==============================================================
        private void FormProductos_Load(object sender, EventArgs e)
        {
            comboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCategoria.Items.AddRange(new[] { "Comida", "Bebida" });
        }
    }
}
