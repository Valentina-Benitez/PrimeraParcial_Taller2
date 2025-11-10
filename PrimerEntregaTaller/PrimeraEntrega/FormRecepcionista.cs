using PrimeraEntrega;
using RestauranteApp;
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

namespace Taller_AppRestaurante
{
    public partial class FormRecepcionista : Form
    {
        // ==============================================================
        // CONSTRUCTOR PRINCIPAL
        // Configura la interfaz, el DataGridView y carga las reservas.
        // ==============================================================
        public FormRecepcionista()
        {
            InitializeComponent();

            txtBusqueda.DataBindings.Clear();
            txtBusqueda.Text = string.Empty;

            dvgReserva.AutoGenerateColumns = false;

            // Asocia las columnas con los campos de la base de datos
            Fecha1.DataPropertyName = "fecha_reserva";
            dni.DataPropertyName = "dni";
            Hora2.DataPropertyName = "hora";
            Mesa3.DataPropertyName = "mesa";
            Estado6.DataPropertyName = "estado";
            personas.DataPropertyName = "personas";

            // Configuración de ventana
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            ConfigurarDataGridView();
            CargarReserva();

            dvgReserva.CellClick += dvgReserva_CellClick;
        }

        // ==============================================================
        // MÉTODO: ConfigurarDataGridView()
        // Define estilo visual, comportamiento y columnas.
        // ==============================================================
        private void ConfigurarDataGridView()
        {
            dvgReserva.AutoGenerateColumns = false;
            dvgReserva.RowHeadersVisible = false;
            dvgReserva.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgReserva.MultiSelect = false;
            dvgReserva.AllowUserToAddRows = false;
            dvgReserva.AllowUserToResizeRows = false;
            dvgReserva.ReadOnly = true;

            // Estilo visual
            dvgReserva.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dvgReserva.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dvgReserva.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dvgReserva.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dvgReserva.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgReserva.RowTemplate.Height = 35;

            // Colores
            dvgReserva.DefaultCellStyle.BackColor = Color.White;
            dvgReserva.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dvgReserva.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dvgReserva.DefaultCellStyle.SelectionForeColor = Color.White;

            // Asegurar columna de ID
            if (!dvgReserva.Columns.Contains("id_reserva"))
            {
                DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
                colId.Name = "id_reserva";
                colId.DataPropertyName = "id_reserva";
                colId.Visible = false;
                dvgReserva.Columns.Add(colId);
            }
        }

        // ==============================================================
        // MÉTODO: CargarReserva()
        // Carga todas las reservas desde la base de datos.
        // ==============================================================
        private void CargarReserva()
        {
            try
            {
                using (SqlConnection con = ConexionDB.ObtenerConexion())
                {
                    con.Open();

                    string sql = @"
                SELECT 
                    r.id_reserva,
                    r.fecha_reserva,
                    r.dni,
                    r.hora,
                    r.mesa,
                    r.estado,
                    r.personas,
                    u.nombre + ' ' + u.apellido AS Empleado
                FROM Reserva r
                LEFT JOIN Usuario u ON r.id_usuario = u.id_usuario
                WHERE CAST(r.fecha_reserva AS DATE) = CAST(GETDATE() AS DATE)  -- 🔹 Solo las reservas de hoy
                ORDER BY r.hora ASC;"; // 

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dvgReserva.DataSource = dt;
                    dvgReserva.ClearSelection();
                }

                dvgReserva.RowTemplate.Height = 30;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reservas: " + ex.Message);
            }
        }


        // ==============================================================
        // BOTÓN: Agregar Pedido → abre FormAgregarProductos
        // ==============================================================
        private void bPedido_Click(object sender, EventArgs e)
        {
            FormAgregarProductos formAgregarProductos = new FormAgregarProductos();
            formAgregarProductos.ShowDialog();
        }

        // ==============================================================
        // EVENTO LOAD: configura el ComboBox de estado
        // ==============================================================
        private void FormRecepcionista_Load(object sender, EventArgs e)
        {
            comboEstad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboEstad.Items.Clear();
            comboEstad.Items.Add("pendiente");
            comboEstad.Items.Add("confirmada");
            comboEstad.Items.Add("cancelada");
        }

        // ==============================================================
        // EVENTO: txtBusqueda_TextChanged()
        // Filtra reservas en tiempo real por DNI.
        // ==============================================================
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dvgReserva.DataSource as DataTable;

                if (dt != null)
                {
                    string filtro = txtBusqueda.Text.Trim();

                    if (string.IsNullOrEmpty(filtro))
                        dt.DefaultView.RowFilter = string.Empty;
                    else
                        dt.DefaultView.RowFilter = $"dni LIKE '%{filtro}%'";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la búsqueda: " + ex.Message);
            }
        }

        // ==============================================================
        // VALIDACIÓN: solo números (para DNI o campos numéricos)
        // ==============================================================
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        // ==============================================================
        // MÉTODO: ClearForm()
        // Limpia todos los campos del formulario.
        // ==============================================================
        private void ClearForm()
        {
            dateTimePicker4.Value = DateTime.Today;
            textBox4.Clear();
            dateTimePicker3.Value = DateTime.Now;
            numericUpDown4.Value = numericUpDown4.Minimum;
            comboEstad.SelectedIndex = -1;
            numericUpDown3.Value = numericUpDown3.Minimum;
        }

        // ==============================================================
        // BOTÓN: Agregar Reserva
        // Inserta una nueva reserva en la base de datos.
        // ==============================================================
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) ||
                comboEstad.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(numericUpDown4.Text) ||
                string.IsNullOrWhiteSpace(numericUpDown3.Text))
            {
                MessageBox.Show("Debe completar todos los campos antes de guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(numericUpDown3.Text.Trim(), out int personas) || personas <= 0)
            {
                MessageBox.Show("Ingrese un número válido de personas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = ConexionDB.ObtenerConexion())
                {
                    con.Open();

                    string sql = @"
                        INSERT INTO Reserva (fecha_reserva, dni, hora, mesa, estado, personas, id_usuario)
                        VALUES (@fecha, @dni, @hora, @mesa, @estado, @personas, @id_usuario)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@fecha", dateTimePicker4.Value.Date);
                        cmd.Parameters.AddWithValue("@dni", textBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@hora", dateTimePicker3.Text.Trim());
                        cmd.Parameters.AddWithValue("@mesa", numericUpDown4.Text.Trim());
                        cmd.Parameters.AddWithValue("@estado", comboEstad.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@personas", personas);
                        cmd.Parameters.AddWithValue("@id_usuario", SesionActual.IdUsuario);

                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                            MessageBox.Show("✅ Reserva agregada correctamente.");
                        else
                            MessageBox.Show("No se pudo agregar la reserva.");

                        CargarReserva();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la reserva: " + ex.Message);
            }
        }

        // ==============================================================
        // BOTÓN: Modificar Reserva
        // Actualiza los datos de una reserva existente.
        // ==============================================================
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dvgReserva.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una reserva para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(dateTimePicker3.Text) ||
                    string.IsNullOrWhiteSpace(numericUpDown4.Text) ||
                    comboEstad.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(numericUpDown3.Text))
                {
                    MessageBox.Show("Debe completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(numericUpDown3.Text.Trim(), out int personas))
                {
                    MessageBox.Show("Ingrese un número válido de personas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idReserva = Convert.ToInt32(dvgReserva.CurrentRow.Cells["id_reserva"].Value);

                using (SqlConnection con = ConexionDB.ObtenerConexion())
                {
                    con.Open();

                    string update = @"
                        UPDATE Reserva
                        SET fecha_reserva = @fecha,
                            dni = @dni,
                            hora = @hora,
                            mesa = @mesa,
                            estado = @estado,
                            personas = @personas
                        WHERE id_reserva = @id";

                    using (SqlCommand cmd = new SqlCommand(update, con))
                    {
                        cmd.Parameters.AddWithValue("@fecha", dateTimePicker4.Value.Date);
                        cmd.Parameters.AddWithValue("@dni", textBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@hora", dateTimePicker3.Text.Trim());
                        cmd.Parameters.AddWithValue("@mesa", numericUpDown4.Text.Trim());
                        cmd.Parameters.AddWithValue("@estado", comboEstad.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@personas", personas);
                        cmd.Parameters.AddWithValue("@id", idReserva);

                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                            MessageBox.Show("Reserva modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("No se encontró la reserva para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                ClearForm();
                CargarReserva();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==============================================================
        // BOTÓN: Cancelar → limpia los campos con confirmación visual
        // ==============================================================
        private void button1_Click(object sender, EventArgs e)
        {
            bool estaVacio =
                string.IsNullOrWhiteSpace(textBox4.Text) &&
                comboEstad.SelectedIndex == -1 &&
                numericUpDown4.Value == numericUpDown4.Minimum &&
                numericUpDown3.Value == numericUpDown3.Minimum;

            if (estaVacio)
            {
                MessageBox.Show("El formulario ya está vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ClearForm();

            if (dvgReserva.CurrentRow != null)
                dvgReserva.ClearSelection();
        }

        // ==============================================================
        // EVENTO: dvgReserva_CellClick()
        // Carga los datos de la fila seleccionada al formulario.
        // ==============================================================
        private void dvgReserva_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dvgReserva.Rows.Count == 0)
                return;

            DataGridViewRow fila = dvgReserva.Rows[e.RowIndex];

            if (fila.DataBoundItem is DataRowView vista)
            {
                DataRow row = vista.Row;

                // Fecha
                if (row["fecha_reserva"] != DBNull.Value &&
                    DateTime.TryParse(row["fecha_reserva"].ToString(), out DateTime fecha))
                    dateTimePicker4.Value = fecha;
                else
                    dateTimePicker4.Value = DateTime.Today;

                // DNI
                textBox4.Text = row["dni"]?.ToString() ?? "";

                // Hora
                dateTimePicker3.Text = row["hora"]?.ToString() ?? "";

                // Mesa
                if (row["mesa"] != DBNull.Value &&
                    decimal.TryParse(row["mesa"].ToString(), out decimal mesaVal))
                    numericUpDown4.Value = Math.Min(Math.Max(mesaVal, numericUpDown4.Minimum), numericUpDown4.Maximum);
                else
                    numericUpDown4.Value = numericUpDown4.Minimum;

                // Estado
                string estado = row["estado"]?.ToString();
                if (!string.IsNullOrEmpty(estado) && comboEstad.Items.Contains(estado))
                    comboEstad.SelectedItem = estado;
                else
                    comboEstad.SelectedIndex = -1;

                // Personas
                if (row["personas"] != DBNull.Value &&
                    decimal.TryParse(row["personas"].ToString(), out decimal personasVal))
                    numericUpDown3.Value = Math.Min(Math.Max(personasVal, numericUpDown3.Minimum), numericUpDown3.Maximum);
                else
                    numericUpDown3.Value = numericUpDown3.Minimum;
            }
        }
    }
}
