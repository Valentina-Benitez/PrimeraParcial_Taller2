namespace PrimeraEntrega
{
    partial class BackUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.btnCrearBackUp = new System.Windows.Forms.Button();
            this.btnConectar = new System.Windows.Forms.Button();
            this.txtRutaGuardar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBaseDeDatos = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.labelServidor = new System.Windows.Forms.Label();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnRestaurar);
            this.panel1.Controls.Add(this.btnCrearBackUp);
            this.panel1.Controls.Add(this.btnConectar);
            this.panel1.Controls.Add(this.btnExaminar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1371, 533);
            this.panel1.TabIndex = 0;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.BackColor = System.Drawing.Color.LightCyan;
            this.btnRestaurar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnRestaurar.Location = new System.Drawing.Point(408, 336);
            this.btnRestaurar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(163, 37);
            this.btnRestaurar.TabIndex = 8;
            this.btnRestaurar.Text = "Restaurar Desde";
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnCrearBackUp
            // 
            this.btnCrearBackUp.BackColor = System.Drawing.Color.LightCyan;
            this.btnCrearBackUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCrearBackUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearBackUp.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCrearBackUp.Location = new System.Drawing.Point(725, 336);
            this.btnCrearBackUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrearBackUp.Name = "btnCrearBackUp";
            this.btnCrearBackUp.Size = new System.Drawing.Size(163, 37);
            this.btnCrearBackUp.TabIndex = 7;
            this.btnCrearBackUp.Text = "Crear Back Up (.zip)";
            this.btnCrearBackUp.UseVisualStyleBackColor = false;
            this.btnCrearBackUp.Click += new System.EventHandler(this.btnCrearBackUp_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.Color.LightCyan;
            this.btnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConectar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnConectar.Location = new System.Drawing.Point(1019, 169);
            this.btnConectar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(123, 37);
            this.btnConectar.TabIndex = 6;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // txtRutaGuardar
            // 
            this.txtRutaGuardar.Location = new System.Drawing.Point(264, 112);
            this.txtRutaGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRutaGuardar.Name = "txtRutaGuardar";
            this.txtRutaGuardar.Size = new System.Drawing.Size(505, 22);
            this.txtRutaGuardar.TabIndex = 5;
            this.txtRutaGuardar.TextChanged += new System.EventHandler(this.txtRutaGuardar_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.LightSlateGray;
            this.label3.Location = new System.Drawing.Point(33, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ruta Guardar:";
            // 
            // txtBaseDeDatos
            // 
            this.txtBaseDeDatos.Location = new System.Drawing.Point(264, 69);
            this.txtBaseDeDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBaseDeDatos.Name = "txtBaseDeDatos";
            this.txtBaseDeDatos.Size = new System.Drawing.Size(505, 22);
            this.txtBaseDeDatos.TabIndex = 3;
            this.txtBaseDeDatos.TextChanged += new System.EventHandler(this.txtBaseDeDatos_TextChanged);
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(264, 25);
            this.txtServidor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(505, 22);
            this.txtServidor.TabIndex = 2;
            this.txtServidor.TextChanged += new System.EventHandler(this.txtServidor_TextChanged);
            // 
            // labelServidor
            // 
            this.labelServidor.AutoSize = true;
            this.labelServidor.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelServidor.ForeColor = System.Drawing.Color.LightSlateGray;
            this.labelServidor.Location = new System.Drawing.Point(33, 16);
            this.labelServidor.Name = "labelServidor";
            this.labelServidor.Size = new System.Drawing.Size(104, 31);
            this.labelServidor.TabIndex = 10;
            this.labelServidor.Text = "Servidor";
            // 
            // btnExaminar
            // 
            this.btnExaminar.BackColor = System.Drawing.Color.LightCyan;
            this.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnExaminar.Location = new System.Drawing.Point(1019, 232);
            this.btnExaminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(123, 37);
            this.btnExaminar.TabIndex = 9;
            this.btnExaminar.Text = "Examinar ...";
            this.btnExaminar.UseVisualStyleBackColor = false;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.LightSlateGray;
            this.label2.Location = new System.Drawing.Point(33, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Base de datos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightSlateGray;
            this.label1.Location = new System.Drawing.Point(601, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Back Up";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.labelServidor);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtServidor);
            this.panel2.Controls.Add(this.txtRutaGuardar);
            this.panel2.Controls.Add(this.txtBaseDeDatos);
            this.panel2.Location = new System.Drawing.Point(93, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(901, 153);
            this.panel2.TabIndex = 11;
            // 
            // BackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 533);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BackUp";
            this.Text = "BackUp";
            this.Load += new System.EventHandler(this.BackUp_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Button btnCrearBackUp;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.TextBox txtRutaGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBaseDeDatos;
        // NUEVOS campos
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label labelServidor;
        private System.Windows.Forms.Panel panel2;
    }
}