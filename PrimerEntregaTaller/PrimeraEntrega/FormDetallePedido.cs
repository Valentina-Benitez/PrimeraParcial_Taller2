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
    public partial class FormDetallePedido : Form
    {
        public FormDetallePedido()
        {
            InitializeComponent();
        }

        public int PedidoId { get; set; }

        private void FormDetallePedido_Load(object sender, EventArgs e)
        {
            // Aquí debes agregar el código para cargar los datos en el DataGridView del formulario de detalle.
            // Ejemplo de pseudo-código:
            // var listaDeProductos = ObtenerProductosDelPedido(PedidoId);
            // dataGridView1.DataSource = listaDeProductos;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
