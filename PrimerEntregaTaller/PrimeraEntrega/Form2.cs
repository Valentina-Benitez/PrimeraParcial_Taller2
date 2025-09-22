
using PrimeraEntrega;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace gerente
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void lEmpleados_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Empleados_Click(object sender, EventArgs e)
        {
            
        }

        

        private void bEmpleados_Click(object sender, EventArgs e)
        {
           
            panelContenedor.Controls.Clear();

            FormEmpleadosVistas formSecundario = new FormEmpleadosVistas();

          
            formSecundario.TopLevel = false;
            formSecundario.FormBorderStyle = FormBorderStyle.None;
            formSecundario.Dock = DockStyle.Fill; 

            panelContenedor.Controls.Add(formSecundario);

            formSecundario.Show();

        }

        private void bProductos_Click(object sender, EventArgs e)
        {
            // se asegura de que no haya otros formularios abiertos
            panelContenedor.Controls.Clear();

            // Crea una nueva instancia del formulario que voy a mostrar
            ReporteProductos formSecundario = new ReporteProductos();

            // Configura el formulario para que se comporte como un control
            formSecundario.TopLevel = false;
            formSecundario.FormBorderStyle = FormBorderStyle.None;
            formSecundario.Dock = DockStyle.Fill; 

            // Agrega el formulario al panel
            panelContenedor.Controls.Add(formSecundario);

            // Muestra el formulario
            formSecundario.Show();

        }

       
        

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
           "¿Desea cerrar sesión?",
           "Confirmar",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question
           );

            if (result == DialogResult.Yes)
            {
                // Si querés cerrar todo el programa:
                //Application.Exit();

                // O si querés volver al formulario de Login en lugar de cerrar todo:
                this.Hide();
                Form1 login = new Form1();
                login.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bVentas_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();

            FormVentas formSecundario = new FormVentas();

            // Configura el formulario para que se comporte como un control
            formSecundario.TopLevel = false;
            formSecundario.FormBorderStyle = FormBorderStyle.None;
            formSecundario.Dock = DockStyle.Fill;

            // Agrega el formulario al panel
            panelContenedor.Controls.Add(formSecundario);

            // Muestra el formulario
            formSecundario.Show();

        }
    }
}
