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
        // --- CADENAS DE CONEXIÓN ---
        // Plantillas base para conectar a SQL Server con o sin base de datos específica
        private const string ConnectionStringTemplate = @"Data Source={0};Initial Catalog=ah;Integrated Security=True;TrustServerCertificate=True";
        private const string ConnectionStringMasterTemplate = @"Data Source={0};Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True";

        public BackUp()
        {
            InitializeComponent();
        }

        // --- EVENTO LOAD ---
        // Al cargar el formulario, se establecen valores predeterminados si los campos están vacíos
        private void BackUp_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServidor.Text))
                txtServidor.Text = "CARPINCHITO\\SQLEXPRESS";

            if (string.IsNullOrWhiteSpace(txtBaseDeDatos.Text))
                txtBaseDeDatos.Text = "RestauranteTallerBD";

            if (string.IsNullOrWhiteSpace(txtRutaGuardar.Text))
                txtRutaGuardar.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        // Devuelve el nombre del servidor ingresado o el local por defecto (.)
        private string GetServerName()
        {
            return string.IsNullOrWhiteSpace(txtServidor.Text) ? "." : txtServidor.Text.Trim();
        }

        // --- BOTÓN: CONECTAR ---
        // Verifica la conexión al servidor SQL ingresado por el usuario
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

        // --- BOTÓN: EXAMINAR ---
        // Permite seleccionar la carpeta donde se guardará o buscará el archivo de Back Up
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

        // --- BOTÓN: CREAR BACK UP ---
        // Genera una copia de seguridad (.bak) de la base de datos seleccionada
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

            // Se genera un nombre único para el archivo con fecha y hora
            string nombreArchivo = $"{dbName}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            string rutaCompleta = Path.Combine(rutaGuardar, nombreArchivo);

            // Comando SQL para crear el backup
            string sqlQuery = $"BACKUP DATABASE [{dbName}] TO DISK = N'{rutaCompleta}' WITH INIT, STATS = 10";

            EjecutarComandoSQL(connectionString, sqlQuery, $"¡Back Up creado con éxito!\nArchivo: {rutaCompleta}");
        }

        // --- BOTÓN: RESTAURAR ---
        // Restaura una base de datos desde un archivo .bak seleccionado
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            string dbName = txtBaseDeDatos.Text.Trim();
            string rutaBackUp = txtRutaGuardar.Text.Trim();

            if (string.IsNullOrEmpty(dbName))
            {
                MessageBox.Show("Debe ingresar el nombre de la Base de Datos destino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si la ruta no apunta a un .bak, se abre el explorador de archivos
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
                        return;
                    }
                }
            }

            string serverName = GetServerName();
            string connectionString = string.Format(ConnectionStringMasterTemplate, serverName);

            // Script SQL para restaurar la base de datos (modo exclusivo, restauración, y vuelta a multiusuario)
            string sqlQuery = $@"
USE master;
ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
RESTORE DATABASE [{dbName}] FROM DISK = N'{rutaBackUp}' WITH REPLACE;
ALTER DATABASE [{dbName}] SET MULTI_USER;
";

            EjecutarComandoSQL(connectionString, sqlQuery, $"¡Base de Datos [{dbName}] restaurada con éxito desde: {rutaBackUp}");
        }

        // --- MÉTODO GENERAL ---
        // Ejecuta comandos SQL (backup o restore) mostrando mensajes según el resultado
        private void EjecutarComandoSQL(string connectionString, string sqlQuery, string successMessage)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        cmd.CommandTimeout = 600; // Evita errores por operaciones largas
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

        // --- EVENTOS VACÍOS (reservados para validaciones futuras) ---
        private void txtRutaGuardar_TextChanged(object sender, EventArgs e) { }
        private void txtBaseDeDatos_TextChanged(object sender, EventArgs e) { }
        private void txtServidor_TextChanged(object sender, EventArgs e) { }
    }
}
