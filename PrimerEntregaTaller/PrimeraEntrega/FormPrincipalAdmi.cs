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
    public partial class FormPrincipalAdmi : Form
    {
        public FormPrincipalAdmi()
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
            // se asegura de que no haya otros formularios abiertos
            panelAdmin.Controls.Clear();

            // Crea una nueva instancia del formulario que voy a mostrar
            FormProductos formSecundario = new FormProductos();

            // Configura el formulario para que se comporte como un control
            formSecundario.TopLevel = false;
            formSecundario.FormBorderStyle = FormBorderStyle.None;
            formSecundario.Dock = DockStyle.Fill;

            // Agrega el formulario al panel
            panelAdmin.Controls.Add(formSecundario);

            // Muestra el formulario
            formSecundario.Show();
        }

        private void bVentas_Click(object sender, EventArgs e)
        {
            panelAdmin.Controls.Clear();

            Form4 formSecundario = new Form4();


            formSecundario.TopLevel = false;
            formSecundario.FormBorderStyle = FormBorderStyle.None;
            formSecundario.Dock = DockStyle.Fill;

            panelAdmin.Controls.Add(formSecundario);

            formSecundario.Show();

        }
        private void bCliente_Click(object sender, EventArgs e)
        {

            panelAdmin.Controls.Clear();

            FormClientesAdmin formSecundario = new FormClientesAdmin();


            formSecundario.TopLevel = false;
            formSecundario.FormBorderStyle = FormBorderStyle.None;
            formSecundario.Dock = DockStyle.Fill;

            panelAdmin.Controls.Add(formSecundario);

            formSecundario.Show();

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
