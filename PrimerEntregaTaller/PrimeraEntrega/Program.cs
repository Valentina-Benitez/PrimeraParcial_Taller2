using gerente; // <-- Agrega esta línea
using PrimeraEntrega;
using RestauranteApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller_AppRestaurante
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormRecepcionista());
            //Application.Run(new PrimeraEntrega.Form1());
            //Application.Run(new PrimeraEntrega.Ventas());
            //Application.Run(new FormVentasAdmin());//es el principal de admin
            //Application.Run(new Form2());
           // Application.Run(new FormProductos());
            Application.Run(new Form1());
        }
    }
}
