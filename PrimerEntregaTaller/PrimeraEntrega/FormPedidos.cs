using gerente;
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
            // 1. Verifica si hay una fila seleccionada en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // 2. Obtén el ID del pedido de la fila seleccionada
                int pedidoId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["No Pedido"].Value);

                // 3. Crea una instancia del formulario de detalle
                FormDetallePedido formDetalle = new FormDetallePedido();

                // 4. Asigna el ID del pedido a la propiedad del formulario de detalle
                formDetalle.PedidoId = pedidoId;

                // 5. Muestra el formulario de detalle como una ventana modal
                formDetalle.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un pedido de la lista.");
            }
        }

        private void bPedido_Click(object sender, EventArgs e)
        {
            // Crea una INSTANCIA de tu formulario
            FormAgregarProductos formAgregarProductos = new FormAgregarProductos();

            // Llama a ShowDialog() en la INSTANCIA, no en la clase.
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
