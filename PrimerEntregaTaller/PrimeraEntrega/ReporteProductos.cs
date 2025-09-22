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
    public partial class ReporteProductos : Form
    {
        public ReporteProductos()
        {
            InitializeComponent();
            this.Load += ReporteProductos_Load;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ReporteProductos_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

            // Crear tabla de ejemplo
            DataTable dt = new DataTable();
            dt.Columns.Add("id_producto");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Nro_ventas");

            // Agregar filas estáticas de prueba
            dt.Rows.Add("1", "Pizza Napolitana", "120");
            dt.Rows.Add("2", "Milanesa con papas", "95");
            dt.Rows.Add("3", "Empanadas", "150");
            dt.Rows.Add("4", "Hamburguesa completa", "80");
            dt.Rows.Add("5", "Lomito", "110");

            // Cargar al DataGridView
            dataGridView1.DataSource = dt;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
