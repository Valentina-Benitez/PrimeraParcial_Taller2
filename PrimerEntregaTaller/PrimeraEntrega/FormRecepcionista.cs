using PrimeraEntrega;
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
            Nombre4.DataPropertyName = "nombre";
            Hora2.DataPropertyName = "hora";
            Mesa3.DataPropertyName = "mesa";
            Estado6.DataPropertyName = "estado";
            Personas5.DataPropertyName = "personas";

            this.WindowState = FormWindowState.Maximized;

            CargarReserva();
        }

        private SqlConnection ObtenerConexion()
        {
            string cadena = @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";
            return new SqlConnection(cadena);

        }
        private void CargarReserva()
        {
            try
            {
                using (SqlConnection con = ObtenerConexion())
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Reserva", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                   // dvgReserva.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    dvgReserva.DataSource = dt;

                    // Ajusta automáticamente el ancho de las columnas
                    //dvgReserva.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    // Ajusta automáticamente la altura de las filas
                    // dvgReserva.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    // dvgReserva.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dvgReserva.RowTemplate.Height = 30; 

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
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
                        // Filtra por coincidencia parcial en la columna "nombre"
                        dt.DefaultView.RowFilter = $"nombre LIKE '%{filtro}%'";
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
            // Permitir solo letras, tecla de borrado (Backspace) y espacio
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // cancela la tecla
            }
        }
    }
}
