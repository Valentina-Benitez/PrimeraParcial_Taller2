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
            this.panel2 = new System.Windows.Forms.Panel();
            this.bInicio = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textDni = new System.Windows.Forms.TextBox();
            this.lContraseñaInicio = new System.Windows.Forms.Label();
            this.lDniInicio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 488);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.bInicio);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(297, 48);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.panel2.Size = new System.Drawing.Size(350, 400);
            this.panel2.TabIndex = 6;
            // 
            // bInicio
            // 
            this.bInicio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bInicio.BackColor = System.Drawing.Color.RoyalBlue;
            this.bInicio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bInicio.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bInicio.ForeColor = System.Drawing.Color.White;
            this.bInicio.Location = new System.Drawing.Point(115, 338);
            this.bInicio.Name = "bInicio";
            this.bInicio.Size = new System.Drawing.Size(112, 44);
            this.bInicio.TabIndex = 2;
            this.bInicio.Text = "Ingresar";
            this.bInicio.UseVisualStyleBackColor = false;
            this.bInicio.Click += new System.EventHandler(this.bInicio_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(115, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.textBox4);
            this.panel3.Controls.Add(this.textDni);
            this.panel3.Controls.Add(this.lContraseñaInicio);
            this.panel3.Controls.Add(this.lDniInicio);
            this.panel3.Location = new System.Drawing.Point(32, 204);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(293, 128);
            this.panel3.TabIndex = 0;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(126, 76);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(164, 22);
            this.textBox4.TabIndex = 3;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textDni
            // 
            this.textDni.Location = new System.Drawing.Point(126, 27);
            this.textDni.Name = "textDni";
            this.textDni.Size = new System.Drawing.Size(164, 22);
            this.textDni.TabIndex = 2;
            this.textDni.TextChanged += new System.EventHandler(this.textDni_TextChanged_1);
            // 
            // lContraseñaInicio
            // 
            this.lContraseñaInicio.AutoSize = true;
            this.lContraseñaInicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lContraseñaInicio.ForeColor = System.Drawing.Color.White;
            this.lContraseñaInicio.Location = new System.Drawing.Point(3, 72);
            this.lContraseñaInicio.Name = "lContraseñaInicio";
            this.lContraseñaInicio.Size = new System.Drawing.Size(118, 28);
            this.lContraseñaInicio.TabIndex = 1;
            this.lContraseñaInicio.Text = "Contraseña";
            // 
            // lDniInicio
            // 
            this.lDniInicio.AutoSize = true;
            this.lDniInicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDniInicio.ForeColor = System.Drawing.Color.White;
            this.lDniInicio.Location = new System.Drawing.Point(3, 23);
            this.lDniInicio.Name = "lDniInicio";
            this.lDniInicio.Size = new System.Drawing.Size(49, 28);
            this.lDniInicio.TabIndex = 0;
            this.lDniInicio.Text = "DNI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(62, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 41);
            this.label1.TabIndex = 4;
            this.label1.Text = "Inicio de sesión";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(942, 488);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bInicio;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textDni;
        private System.Windows.Forms.Label lContraseñaInicio;
        private System.Windows.Forms.Label lDniInicio;
        private System.Windows.Forms.Label label1;
    }
}

