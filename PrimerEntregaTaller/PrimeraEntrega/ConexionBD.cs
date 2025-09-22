using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient; //Libreria para trabajar con sql server.

namespace RestauranteApp
{
    public static class ConexionDB
    {
        // Acá guardo la cadena de conexión a mi base de datos SQL Server ---- Data Source: nombre del servidor SQL ---- Initial Catalog: nombre de mi base de datos
        // Integrated Security=True: uso la autenticación de Windows (no usuario/contraseña) --- TrustServerCertificate=True: evita errores de certificado
        private static string connectionString =
            @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";

        // Método para obtener la conexión
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }
    }
}

