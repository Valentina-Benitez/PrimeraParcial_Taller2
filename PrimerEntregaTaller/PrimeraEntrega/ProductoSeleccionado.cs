using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraEntrega
{
    public class ProductoSeleccionado  
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        private int cantidad = 1;
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = (value < 1) ? 1 : value; }
        }
    }
}
