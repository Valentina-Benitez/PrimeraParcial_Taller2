using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            this.WindowState = FormWindowState.Maximized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del formulario de nueva reserva
            FormNuevaReserva formularioReserva = new FormNuevaReserva();

            // Muestra el formulario en pantalla
            formularioReserva.ShowDialog();
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

        }
    }
}
