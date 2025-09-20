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

namespace PrimeraEntrega
{
    public partial class PrincipalAdmi : Form
    {
        public PrincipalAdmi()
        {
            InitializeComponent();
        }

        private void bEmpleados_Click(object sender, EventArgs e)
        {

            panelAdmin.Controls.Clear();

            Empleados formSecundario = new Empleados();


            formSecundario.TopLevel = false;
            formSecundario.FormBorderStyle = FormBorderStyle.None;
            formSecundario.Dock = DockStyle.Fill;

            panelAdmin.Controls.Add(formSecundario);

            formSecundario.Show();

        }

        private void bProductos_Click(object sender, EventArgs e)
        {

        }

        private void bVentas_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
