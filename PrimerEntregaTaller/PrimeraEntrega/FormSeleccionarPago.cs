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
        // ==============================================================
        // CONSTRUCTOR PRINCIPAL
        // Inicializa el formulario para la selección del método de pago.
        // ==============================================================
        public FormSeleccionarPago()
        {
            InitializeComponent();
        }

        // ==============================================================
        // EVENTO: comboPago_SelectedIndexChanged
        // (Actualmente sin lógica, puede usarse para mostrar detalles
        // adicionales del método de pago seleccionado si se desea)
        // ==============================================================
        private void comboPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // ==============================================================
        // PROPIEDAD: TipoDePagoSeleccionado
        // Guarda el tipo de pago elegido por el usuario (Ej: "Efectivo", "Tarjeta").
        // ==============================================================
        public string TipoDePagoSeleccionado { get; private set; }

        // ==============================================================
        // BOTÓN: Confirmar
        // Valida la selección y devuelve el tipo de pago al formulario llamador.
        // ==============================================================
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Verificar que se haya seleccionado un método de pago
            if (comboPago.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un método de pago.");
                return;
            }

            // Guardar el valor seleccionado
            TipoDePagoSeleccionado = comboPago.SelectedItem.ToString();

            // Cerrar el formulario indicando que la selección fue correcta
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
