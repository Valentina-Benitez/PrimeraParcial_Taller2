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
            this.btnExaminar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            // NUEVOS CONTROLES: servidor
            this.labelServidor = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.btnRestaurar);
            this.panel1.Controls.Add(this.btnCrearBackUp);
            this.panel1.Controls.Add(this.btnConectar);
            this.panel1.Controls.Add(this.txtRutaGuardar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtBaseDeDatos);
            this.panel1.Controls.Add(this.txtServidor); // añadido
            this.panel1.Controls.Add(this.labelServidor); // añadido
            this.panel1.Controls.Add(this.btnExaminar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 433);
            this.panel1.TabIndex = 0;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.BackColor = System.Drawing.Color.LightBlue;
            this.btnRestaurar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnRestaurar.Location = new System.Drawing.Point(559, 315);
            this.btnRestaurar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(122, 30);
            this.btnRestaurar.TabIndex = 8;
            this.btnRestaurar.Text = "Restaurar Desde";
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnCrearBackUp
            // 
            this.btnCrearBackUp.BackColor = System.Drawing.Color.LightBlue;
            this.btnCrearBackUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCrearBackUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearBackUp.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCrearBackUp.Location = new System.Drawing.Point(318, 315);
            this.btnCrearBackUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnCrearBackUp.Name = "btnCrearBackUp";
            this.btnCrearBackUp.Size = new System.Drawing.Size(122, 30);
            this.btnCrearBackUp.TabIndex = 7;
            this.btnCrearBackUp.Text = "Crear Back Up (.zip)";
            this.btnCrearBackUp.UseVisualStyleBackColor = false;
            this.btnCrearBackUp.Click += new System.EventHandler(this.btnCrearBackUp_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.Color.LightBlue;
            this.btnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConectar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnConectar.Location = new System.Drawing.Point(750, 149);
            this.btnConectar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(92, 30);
            this.btnConectar.TabIndex = 6;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // txtRutaGuardar
            // 
            this.txtRutaGuardar.Location = new System.Drawing.Point(300, 216);
            this.txtRutaGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.txtRutaGuardar.Name = "txtRutaGuardar";
            this.txtRutaGuardar.Size = new System.Drawing.Size(380, 20);
            this.txtRutaGuardar.TabIndex = 5;
            this.txtRutaGuardar.TextChanged += new System.EventHandler(this.txtRutaGuardar_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.LightSlateGray;
            this.label3.Location = new System.Drawing.Point(155, 214);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ruta Guardar:";
            // 
            // txtBaseDeDatos
            // 
            this.txtBaseDeDatos.Location = new System.Drawing.Point(300, 187);
            this.txtBaseDeDatos.Margin = new System.Windows.Forms.Padding(2);
            this.txtBaseDeDatos.Name = "txtBaseDeDatos";
            this.txtBaseDeDatos.Size = new System.Drawing.Size(380, 20);
            this.txtBaseDeDatos.TabIndex = 3;
            this.txtBaseDeDatos.TextChanged += new System.EventHandler(this.txtBaseDeDatos_TextChanged);
            // 
            // NUEVO: txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(300, 157);
            this.txtServidor.Margin = new System.Windows.Forms.Padding(2);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(380, 20);
            this.txtServidor.TabIndex = 2;
            this.txtServidor.TextChanged += new System.EventHandler(this.txtServidor_TextChanged);
            // 
            // btnExaminar
            // 
            this.btnExaminar.BackColor = System.Drawing.Color.LightBlue;
            this.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnExaminar.Location = new System.Drawing.Point(750, 209);
            this.btnExaminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(92, 30);
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
            this.label2.Location = new System.Drawing.Point(155, 184);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Base de datos";
            // 
            // NUEVO: labelServidor
            // 
            this.labelServidor.AutoSize = true;
            this.labelServidor.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelServidor.ForeColor = System.Drawing.Color.LightSlateGray;
            this.labelServidor.Location = new System.Drawing.Point(155, 152);
            this.labelServidor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelServidor.Name = "labelServidor";
            this.labelServidor.Size = new System.Drawing.Size(78, 25);
            this.labelServidor.TabIndex = 10;
            this.labelServidor.Text = "Servidor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightSlateGray;
            this.label1.Location = new System.Drawing.Point(451, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Back Up";
            // 
            // BackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 433);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BackUp";
            this.Text = "BackUp";
            this.Load += new System.EventHandler(this.BackUp_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}