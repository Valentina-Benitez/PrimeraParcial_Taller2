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
using Taller_AppRestaurante;

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
                    //dvgReserva.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    dvgReserva.DataSource = dt;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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
            // ...
        }

        private void dvgReserva_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
