using gerente;
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
    public partial class FormPedidos : Form
    {
        public FormPedidos()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bPedido_Click(object sender, EventArgs e)
        {
            FormAgregarProductos formAgregarProductos = new FormAgregarProductos();
            formAgregarProductos.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FormPedidos_Load(object sender, EventArgs e)
        {

        }
    }
}
