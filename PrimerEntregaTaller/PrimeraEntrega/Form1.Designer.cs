namespace PrimeraEntrega
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lDniInicio = new System.Windows.Forms.Label();
            this.lContraseñaInicio = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bInicio = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.lContraseñaInicio);
            this.panel1.Controls.Add(this.lDniInicio);
            this.panel1.Location = new System.Drawing.Point(186, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 132);
            this.panel1.TabIndex = 0;
            // 
            // lDniInicio
            // 
            this.lDniInicio.AutoSize = true;
            this.lDniInicio.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDniInicio.Location = new System.Drawing.Point(3, 33);
            this.lDniInicio.Name = "lDniInicio";
            this.lDniInicio.Size = new System.Drawing.Size(35, 23);
            this.lDniInicio.TabIndex = 0;
            this.lDniInicio.Text = "DNI";
            this.lDniInicio.Click += new System.EventHandler(this.label1_Click);
            // 
            // lContraseñaInicio
            // 
            this.lContraseñaInicio.AutoSize = true;
            this.lContraseñaInicio.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lContraseñaInicio.Location = new System.Drawing.Point(3, 85);
            this.lContraseñaInicio.Name = "lContraseñaInicio";
            this.lContraseñaInicio.Size = new System.Drawing.Size(86, 23);
            this.lContraseñaInicio.TabIndex = 1;
            this.lContraseñaInicio.Text = "Contraseña";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(276, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // bInicio
            // 
            this.bInicio.BackColor = System.Drawing.Color.SkyBlue;
            this.bInicio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bInicio.Location = new System.Drawing.Point(276, 288);
            this.bInicio.Name = "bInicio";
            this.bInicio.Size = new System.Drawing.Size(100, 25);
            this.bInicio.TabIndex = 2;
            this.bInicio.Text = "Iniciar";
            this.bInicio.UseVisualStyleBackColor = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(90, 33);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(164, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(90, 85);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(164, 20);
            this.textBox4.TabIndex = 3;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(671, 350);
            this.Controls.Add(this.bInicio);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lNombre;
        private System.Windows.Forms.Label lContraseña;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox LogoDelRestaurante;
        private System.Windows.Forms.PictureBox ojoAbierto;
        private System.Windows.Forms.PictureBox ojoCerrado;
        private System.Windows.Forms.Button bIniciar;
        private System.Windows.Forms.Label label1_Nombre;
        private System.Windows.Forms.Label label2_Contraseña;
        private System.Windows.Forms.TextBox textBox3_nombre;
        private System.Windows.Forms.TextBox textBox4_contraseña;
        private System.Windows.Forms.Button button1_iniciar;
        private System.Windows.Forms.PictureBox pictureBox1_LogoRestaurante;
        private System.Windows.Forms.PictureBox pictureBox2_ojoAbierto;
        private System.Windows.Forms.PictureBox pictureBox3_ojoCerrado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lDniInicio;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lContraseñaInicio;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bInicio;
    }
}

