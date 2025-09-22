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
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            // Evitar que se autogenere si ya tenés columnas diseñadas en el diseñador
            dataGridView1.AutoGenerateColumns = false;

            // Crear un DataTable para simular los datos
            DataTable dt = new DataTable();
            dt.Columns.Add("Estado");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Tipo_de_pedido");
            dt.Columns.Add("Producto");
            dt.Columns.Add("Cliente");
            dt.Columns.Add("Detalles");

            // Agregar filas estáticas de ejemplo
            dt.Rows.Add("Entregado", "22/09/2025", "Mesa", "Pizza Napolitana", "Juan Pérez", "Con bebida incluida");
            dt.Rows.Add("Pendiente", "22/09/2025", "Mesa", "Milanesa con papas", "María López", "Sin sal en la ensalada");
            dt.Rows.Add("Cancelado", "21/09/2025", "Mesa", "Empanadas", "Pedro Gómez", "Cancelado por el cliente");
            dt.Rows.Add("Entregado", "20/09/2025", "Delivery", "Lomito", "Claudia Fernández", "Promo 2x1");
            dt.Rows.Add("Entregado", "21/09/2025", "Mesa", "Pizza Napolitana", "Juan Pérez", "Sin bebida incluida");
            dt.Rows.Add("Entregado", "24/08/2025", "Mesa", "Milanesa con papas", "María López", "Sin sal en la ensalada");
            dt.Rows.Add("Cancelado", "25/08/2025", "Mesa", "Empanadas", "Pedro Gómez", "Cancelado por el cliente");
            dt.Rows.Add("Entregado", "26/08/2025", "Delivery", "Lomito", "Claudia Fernández", "Promo 2x1");

            // Asignar al DataGridView
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
