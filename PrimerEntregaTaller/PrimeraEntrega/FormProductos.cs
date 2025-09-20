using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gerente
{
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
            textNombreP.KeyPress += SoloLetras;
            textCategoriaP.KeyPress += SoloLetras;
            textDescuentoP.KeyPress += SoloNumeros;
            textProvinciaP.KeyPress += SoloLetras;
            textEstadoP.KeyPress += SoloNumeros;
            textPrecioP.KeyPress += SoloNumeros;
        }
        private void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; 
            }
        }


        
        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNombreP.Text) ||
                string.IsNullOrWhiteSpace(textCategoriaP.Text) ||
                string.IsNullOrWhiteSpace(textDescuentoP.Text) ||
                string.IsNullOrWhiteSpace(textProvinciaP.Text) ||
                string.IsNullOrWhiteSpace(textEstadoP.Text) ||
                string.IsNullOrWhiteSpace(textPrecioP.Text))
                {
                MessageBox.Show("Debe completar todos los campos antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          

            MessageBox.Show("Producto guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lProductos_Click(object sender, EventArgs e)
        {

        }

        private void Productos_Load(object sender, EventArgs e)
        {

        }

        private void lCategoria_Click(object sender, EventArgs e)
        {

        }
    }
}
