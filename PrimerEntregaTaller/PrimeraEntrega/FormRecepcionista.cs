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
        public FormRecepcionista()
        {
            InitializeComponent();

            // Desactivar generación automática de columnas
            dvgReserva.AutoGenerateColumns = false;

            // Asignar DataPropertyName a cada columna
            Fecha1.DataPropertyName = "fecha_reserva";
            dni.DataPropertyName = "dni";
            Hora2.DataPropertyName = "hora";
            Mesa3.DataPropertyName = "mesa";
            Estado6.DataPropertyName = "estado";
            Personas5.DataPropertyName = "personas";

            this.WindowState = FormWindowState.Maximized;

            CargarReserva();
        }

           private void CargarReserva()
        {
            try
            {
                using (SqlConnection con = ConexionDB.ObtenerConexion())
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Reserva", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dvgReserva.DataSource = dt;

                    dvgReserva.RowTemplate.Height = 30;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reservas: " + ex.Message);
            }
        }

        private void bPedido_Click(object sender, EventArgs e)
        {
            // Crea una INSTANCIA de tu formulario
            FormAgregarProductos formAgregarProductos = new FormAgregarProductos();

            // Llama a ShowDialog() en la INSTANCIA, no en la clase.
            formAgregarProductos.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            // Puedes dejarlo vacío si no necesitas lógica personalizada
        }

        private void FormRecepcionista_Load(object sender, EventArgs e)
        {
            comboEstad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboEstad.Items.Clear();
            comboEstad.Items.Add("confirmada");
            comboEstad.Items.Add("pendiente");
            comboEstad.Items.Add("cancelada");
        }

        private void dvgReserva_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Si ya tenés un DataTable cargado en el DataGridView
                DataTable dt = dvgReserva.DataSource as DataTable;

                if (dt != null)
                {
                    string filtro = txtBusqueda.Text.Trim();

                    if (string.IsNullOrEmpty(filtro))
                    {
                        // Quita el filtro y muestra todo
                        dt.DefaultView.RowFilter = string.Empty;
                    }
                    else
                    {
                        // Filtra por coincidencia parcial en la columna "dni"
                        dt.DefaultView.RowFilter = $"dni LIKE '%{filtro}%'";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la búsqueda: " + ex.Message);
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo numeros, tecla de borrado (Backspace) y espacio
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // cancela la tecla
            }
        }

        private void ClearForm()
        {
            dateTimePicker4.Value = DateTime.Today;
            textBox4.Clear();
            dateTimePicker3.Value = DateTime.Now; // Corregido: DateTimePicker no tiene Clear, se reinicia el valor
            numericUpDown4.Value = numericUpDown4.Minimum; // Corregido: NumericUpDown no tiene Clear, se reinicia el valor
            comboEstad.SelectedIndex = -1;
            numericUpDown3.Value = numericUpDown3.Minimum; // Corregido: NumericUpDown no tiene Clear, se reinicia el valor
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ✅ Validar que todos los campos estén completos antes de insertar
            if (string.IsNullOrWhiteSpace(textBox4.Text) ||
                comboEstad.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(numericUpDown4.Text) ||
                string.IsNullOrWhiteSpace(numericUpDown3.Text))
            {
                MessageBox.Show("Debe completar todos los campos antes de guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el número de personas sea correcto
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
                        {
                            MessageBox.Show("Reserva agregada correctamente.");
                            CargarReserva();
                            ClearForm(); // opcional si querés limpiar los campos después
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar la reserva.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la reserva: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que haya una fila seleccionada
                if (dvgReserva.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una reserva para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que los campos estén completos
                if (string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(dateTimePicker3.Text) ||
                    string.IsNullOrWhiteSpace(numericUpDown4.Text) ||
                    comboEstad.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(numericUpDown3.Text))
                {
                    MessageBox.Show("Debe completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Intentar convertir personas a número
                if (!int.TryParse(numericUpDown3.Text.Trim(), out int personas))
                {
                    MessageBox.Show("Ingrese un número válido de personas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el ID de la reserva (supongo que la columna PK se llama id_reserva)
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

                // Limpiar campos y recargar DataGridView
                ClearForm();
                CargarReserva();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Limpiar todos los campos
            ClearForm();

            // Deseleccionar cualquier fila del DataGridView
            if (dvgReserva.CurrentRow != null)
                dvgReserva.ClearSelection();
        }

        private void dvgReserva_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dvgReserva.CurrentRow != null)
            {
                DataGridViewRow fila = dvgReserva.CurrentRow;

                // FECHA
                var fechaValor = fila.Cells["Fecha1"].Value;
                if (fechaValor != null && fechaValor != DBNull.Value && DateTime.TryParse(fechaValor.ToString(), out DateTime fecha))
                {
                    dateTimePicker4.Value = fecha;
                }
                else
                {
                    dateTimePicker4.Value = DateTime.Today;
                }

                // DNI
                textBox4.Text = fila.Cells["dni"].Value?.ToString() ?? "";

                // HORA
                dateTimePicker3.Text = fila.Cells["Hora2"].Value?.ToString() ?? "";

                // MESA
                if (fila.Cells["Mesa3"].Value != null && fila.Cells["Mesa3"].Value != DBNull.Value)
                    numericUpDown4.Value = Convert.ToDecimal(fila.Cells["Mesa3"].Value);
                else
                    numericUpDown4.Value = numericUpDown4.Minimum;

                // ESTADO
                string estado = fila.Cells["Estado6"].Value?.ToString();
                if (!string.IsNullOrEmpty(estado) && comboEstad.Items.Contains(estado))
                    comboEstad.SelectedItem = estado;
                else
                    comboEstad.SelectedIndex = -1;

                // PERSONAS
                var personasValor = fila.Cells["Personas5"].Value;
                if (personasValor != null && decimal.TryParse(personasValor.ToString(), out decimal personas))
                {
                    numericUpDown3.Value = personas;
                }
                else
                {
                    numericUpDown3.Value = numericUpDown3.Minimum;
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
