using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeraEntrega
{
    public partial class BackUp : Form
    {
        // Plantillas de cadena de conexión: {0} será reemplazado por el servidor (o '.' para local)
        private const string ConnectionStringTemplate = @"Data Source={0};Initial Catalog=ah;Integrated Security=True;TrustServerCertificate=True";
        private const string ConnectionStringMasterTemplate = @"Data Source={0};Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True";

        public BackUp()
        {
            InitializeComponent();
        }

        private void BackUp_Load(object sender, EventArgs e)
        {
            // Valores por defecto útiles al abrir el formulario
            if (string.IsNullOrWhiteSpace(txtServidor.Text))
                txtServidor.Text = "."; // servidor por defecto
            if (string.IsNullOrWhiteSpace(txtBaseDeDatos.Text))
                txtBaseDeDatos.Text = "RestauranteTallerBD"; // ejemplo: nombre de BD por defecto
            if (string.IsNullOrWhiteSpace(txtRutaGuardar.Text))
                txtRutaGuardar.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private string GetServerName()
        {
            // Si el textbox de servidor está vacío se usa '.' (local)
            return string.IsNullOrWhiteSpace(txtServidor.Text) ? "." : txtServidor.Text.Trim();
        }

        // --- 1. BOTÓN 'CONECTAR' ---
        private void btnConectar_Click(object sender, EventArgs e)
        {
            string serverName = GetServerName();
            string connectionString = string.Format(ConnectionStringMasterTemplate, serverName);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show($"Conexión exitosa con el servidor: {conn.DataSource}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar conectar: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- 2. BOTÓN 'EXAMINAR' ---
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Seleccione la carpeta donde guardar/buscar el Back Up";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtRutaGuardar.Text = fbd.SelectedPath;
                }
            }
        }

        // --- 3. BOTÓN 'CREAR BACK UP' ---
        private void btnCrearBackUp_Click(object sender, EventArgs e)
        {
            string dbName = txtBaseDeDatos.Text.Trim();
            string rutaGuardar = txtRutaGuardar.Text.Trim();

            if (string.IsNullOrEmpty(dbName) || string.IsNullOrEmpty(rutaGuardar))
            {
                MessageBox.Show("Debe ingresar la Base de Datos y la Ruta Guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string serverName = GetServerName();
            string connectionString = string.Format(ConnectionStringMasterTemplate, serverName);

            string nombreArchivo = $"{dbName}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            string rutaCompleta = Path.Combine(rutaGuardar, nombreArchivo);

            // Usar N'...' para soportar rutas con caracteres especiales
            string sqlQuery = $"BACKUP DATABASE [{dbName}] TO DISK = N'{rutaCompleta}' WITH INIT, STATS = 10";

            EjecutarComandoSQL(connectionString, sqlQuery, $"¡Back Up creado con éxito!\nArchivo: {rutaCompleta}");
        }

        // --- 4. BOTÓN 'RESTAURAR' ---
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            string dbName = txtBaseDeDatos.Text.Trim();
            string rutaBackUp = txtRutaGuardar.Text.Trim(); // Puede ser carpeta o archivo

            if (string.IsNullOrEmpty(dbName))
            {
                MessageBox.Show("Debe ingresar el nombre de la Base de Datos destino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si no se pasó un archivo .bak, pedirlo al usuario
            if (string.IsNullOrEmpty(rutaBackUp) || !rutaBackUp.EndsWith(".bak", StringComparison.OrdinalIgnoreCase) || !File.Exists(rutaBackUp))
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Archivos de Back Up (*.bak)|*.bak";
                    ofd.Title = "Seleccione el archivo .bak a restaurar";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        rutaBackUp = ofd.FileName;
                        txtRutaGuardar.Text = rutaBackUp;
                    }
                    else
                    {
                        return; // cancelado
                    }
                }
            }

            string serverName = GetServerName();
            string connectionString = string.Format(ConnectionStringMasterTemplate, serverName);

            // Restaurar: poner en SINGLE_USER, RESTORE WITH REPLACE, y volver a MULTI_USER
            string sqlQuery = $@"
USE master;
ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
RESTORE DATABASE [{dbName}] FROM DISK = N'{rutaBackUp}' WITH REPLACE;
ALTER DATABASE [{dbName}] SET MULTI_USER;
";

            EjecutarComandoSQL(connectionString, sqlQuery, $"¡Base de Datos [{dbName}] restaurada con éxito desde: {rutaBackUp}");
        }

        // --- EJECUTAR COMANDO SQL ---
        private void EjecutarComandoSQL(string connectionString, string sqlQuery, string successMessage)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        cmd.CommandTimeout = 600; // tiempo mayor para operaciones grandes
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show(successMessage, "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de SQL: {ex.Message}", "Error en Operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRutaGuardar_TextChanged(object sender, EventArgs e)
        {
            // Validación ligera: si la ruta no existe no hacemos nada pesado aquí.
        }

        private void txtBaseDeDatos_TextChanged(object sender, EventArgs e)
        {
            // No ejecutar lógica intensiva aquí.
        }

        // NUEVO manejador para txtServidor (vacío por ahora)
        private void txtServidor_TextChanged(object sender, EventArgs e)
        {
            // opcional: validar formato de instancia (por ejemplo .\SQLEXPRESS)
        }
    }
}
