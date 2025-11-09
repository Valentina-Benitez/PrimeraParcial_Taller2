using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // Librería para trabajar con SQL Server

namespace RestauranteApp
{
    // Clase estática que centraliza la conexión con la base de datos del restaurante.
    // Permite obtener una conexión lista para usar en cualquier parte del sistema.
    public static class ConexionDB
    {
        // Cadena de conexión al servidor SQL Server.
        // Data Source: nombre del servidor
        // Initial Catalog: nombre de la base de datos
        // Integrated Security=True: usa autenticación de Windows
        // TrustServerCertificate=True: evita errores por certificados no confiables
        private static string connectionString =
            @"Data Source=CARPINCHITO\SQLEXPRESS;Initial Catalog=RestauranteTallerBD;Integrated Security=True;TrustServerCertificate=True";

        // Devuelve una nueva conexión SQL utilizando la cadena configurada
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }
    }
}
