using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Clase estática que almacena los datos del usuario actualmente logueado en el sistema.
// Permite acceder desde cualquier parte del programa a la información básica de sesión.
public static class SesionActual
{
    // ID único del usuario que inició sesión
    public static int IdUsuario { get; set; }

    // Nombre del usuario en sesión
    public static string NombreUsuario { get; set; }

    // Rol del usuario (por ejemplo: Administrador, Cliente, Recepcionista, etc.)
    public static string Rol { get; set; }
}
