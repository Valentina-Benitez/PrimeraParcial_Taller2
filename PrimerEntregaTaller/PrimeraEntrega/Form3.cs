using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using Taller_AppRestaurante;


namespace RestauranteApp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bReservas_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();

            FormRecepcionista formSecundario = new FormRecepcionista();


            formSecundario.TopLevel = false;
            formSecundario.FormBorderStyle = FormBorderStyle.None;
            formSecundario.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formSecundario);

            formSecundario.Show();
        }

        private void bPedido_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();

            FormPedidos formSecundario = new FormPedidos();


            formSecundario.TopLevel = false;
            formSecundario.FormBorderStyle = FormBorderStyle.None;
            formSecundario.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formSecundario);

            formSecundario.Show();
        }

        private void bCliente_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();

            FormClientes formSecundario = new FormClientes();


            formSecundario.TopLevel = false;
            formSecundario.FormBorderStyle = FormBorderStyle.None;
            formSecundario.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formSecundario);

            formSecundario.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panelContenedor_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
