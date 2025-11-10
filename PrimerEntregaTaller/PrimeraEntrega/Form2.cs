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
    
    /// Formulario principal para el rol "gerente".
    /// Contiene botones que cargan vistas secundarias dentro de un panel contenedor.
    public partial class Form2 : Form
    {
        /// Constructor.
        /// Inicializa componentes del formulario.
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// Handler del botón "Empleados".
        /// Propósito: Limpiar el panel contenedor y cargar el formulario FormEmpleadosVistas
        /// como control hijo, configurándolo para ocupar todo el panel.
        private void bEmpleados_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();

            FormEmpleadosVistas formSecundario = new FormEmpleadosVistas();

            // Configura el formulario secundario para comportarse como control embebido
            formSecundario.TopLevel = false;
            formSecundario.FormBorderStyle = FormBorderStyle.None;
            formSecundario.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formSecundario);

            formSecundario.Show();
        }

        /// Handler del botón "Productos".
        /// Propósito: Limpiar el panel contenedor y cargar el reporte de productos (ReporteProductos)
        /// como control hijo configurado para llenar el panel.
        private void bProductos_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();

            ReporteProductos formSecundario = new ReporteProductos();

            // Configura el formulario para que se comporte como un control embebido
            formSecundario.TopLevel = false;
            formSecundario.FormBorderStyle = FormBorderStyle.None;
            formSecundario.Dock = DockStyle.Fill;

            // Agrega y muestra el formulario en el panel contenedor
            panelContenedor.Controls.Add(formSecundario);
            formSecundario.Show();
        }

        /// Handler vacío para el evento Paint del panel2.
        /// Mantener vacío o añadir lógica de dibujo si se necesita personalizar la UI.
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        /// Handler para el click en el PictureBox que cierra sesión.
        /// Propósito: Preguntar al usuario si quiere cerrar sesión y, en caso afirmativo,
        /// ocultar el formulario actual y mostrar el formulario de login (Form1).
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
                // Oculta el formulario del gerente y vuelve al login
                this.Hide();
                Form1 login = new Form1();
                login.Show();
            }
        }

        /// <summary>
        /// Handler vacío para el evento Paint del panel1.
        /// </summary>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Handler del botón "Ventas".
        /// Propósito: Limpiar el panel contenedor y cargar el formulario FormVentas
        /// (vistas de ventas) como control hijo para mostrar estadísticas y listados.
        /// </summary>
        private void bVentas_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();

            FormVentas formSecundario = new FormVentas();

            // Configura el formulario para que se comporte como control embebido
            formSecundario.TopLevel = false;
            formSecundario.FormBorderStyle = FormBorderStyle.None;
            formSecundario.Dock = DockStyle.Fill;

            // Agrega y muestra el formulario en el panel contenedor
            panelContenedor.Controls.Add(formSecundario);
            formSecundario.Show();
        }

        // Métodos auxiliares/handlers vacíos generados por el diseñador.
        // Conservar o eliminar según convenga; actualmente no realizan acciones.
        private void ltitulo_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click_1(object sender, EventArgs e) { }
        private void lEmpleados_Click(object sender, EventArgs e) { }
        private void pictureBox2_Empleados_Click(object sender, EventArgs e) { }
    }
}
