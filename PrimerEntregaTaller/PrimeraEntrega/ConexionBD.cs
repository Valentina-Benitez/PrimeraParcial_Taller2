using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace RestauranteApp
{
    public static class ConexionDB
    {
        // Cadena de conexión a tu nueva base de datos
        private static string connectionString =
            @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";

        // Método para obtener la conexión
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }
    }
}

