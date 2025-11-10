using PrimeraEntrega;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using Taller_AppRestaurante;


namespace RestauranteApp
{
    public partial class Form3 : Form
    {
        // Constructor: inicializa componentes del formulario principal para el rol "empleado".
        public Form3()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Handler del botón "Reservas":
        // - Limpia el panel contenedor.
        // - Crea y configura FormRecepcionista para mostrarse embebido en el panel.
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

        // Handler del botón "Pedido":
        // - Limpia el panel contenedor.
        // - Crea y configura FormPedidos para mostrarse embebido en el panel.
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

        // Handler del botón "Cliente":
        // - Limpia el panel contenedor.
        // - Crea y configura FormClientes para mostrarse embebido en el panel.
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

        // Handler para cerrar sesión (imagen/pictureBox):
        // - Pregunta al usuario si desea cerrar sesión.
        // - Si confirma, oculta este formulario y muestra el login (Form1).
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "¿Desea cerrar sesión?",
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Oculta el formulario actual y muestra el formulario de login
                this.Hide();
                Form1 login = new Form1();
                login.Show();
            }
        }
        private void panelContenedor_Paint_1(object sender, PaintEventArgs e) { }
        private void pictureBox1_Usuario_Click(object sender, EventArgs e) { }
        private void panelContenedor_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
    }
}
