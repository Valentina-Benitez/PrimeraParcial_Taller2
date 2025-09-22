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
    public partial class FormVentasAdmin : Form
    {
        public FormVentasAdmin()
        {
            InitializeComponent();
        }


        private void FormVentasAdmin_Load(object sender, EventArgs e)
        {
            // Evitar que se autogenere si ya tenés columnas diseñadas en el diseñador
            dgvVentas.AutoGenerateColumns = false;

            // Crear un DataTable para simular los datos
            DataTable dt = new DataTable();
            dt.Columns.Add("Nro Venta");
            dt.Columns.Add("NroPedido");
            dt.Columns.Add("Empleado");
            dt.Columns.Add("Cliente");
            dt.Columns.Add("Mesa");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Total");
            dt.Columns.Add("TipoPago");
            dt.Columns.Add("Descripcion");

            // Agregar filas estáticas de ejemplo
            dt.Rows.Add("1", "1001", "Juan Pérez", "María López", "5", "22/09/2025", "2500", "Efectivo", "Pago completo");
            dt.Rows.Add("2", "1002", "Ana García", "Pedro Gómez", "2", "21/09/2025", "3800", "Tarjeta", "Con propina");
            dt.Rows.Add("3", "1003", "Carlos Ruiz", "Laura Díaz", "8", "20/09/2025", "1500", "MercadoPago", "Promo 2x1");
            dt.Rows.Add("4", "1004", "Luis Torres", "Claudia Fernández", "1", "19/09/2025", "5000", "Efectivo", "Cumpleaños");

            // Asignar al DataGridView
            dgvVentas.DataSource = dt;
        }

        private void txtPedido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMesa_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // cancela la tecla
            }
        }

        private void txtMesa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // cancela la tecla
            }
        }

        private void txtPedido_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // cancela la tecla
            }
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // cancela la tecla
            }
        }

        private void txtEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // cancela la tecla
            }
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // cancela la tecla
            }
        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // cancela la tecla
            }
        }
    }
}
