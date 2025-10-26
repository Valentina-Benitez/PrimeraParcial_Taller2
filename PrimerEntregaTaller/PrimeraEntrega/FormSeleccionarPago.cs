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
    public partial class FormSeleccionarPago : Form
    {
        public FormSeleccionarPago()
        {
            InitializeComponent();
        }

        private void comboPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string TipoDePagoSeleccionado { get; private set; }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (comboPago.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un método de pago.");
                return;
            }

            TipoDePagoSeleccionado = comboPago.SelectedItem.ToString();
            DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
