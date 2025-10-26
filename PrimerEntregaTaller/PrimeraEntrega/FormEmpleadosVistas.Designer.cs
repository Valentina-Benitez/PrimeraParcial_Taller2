namespace PrimeraEntrega
{
    partial class FormEmpleadosVistas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmpleadosVistas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Nacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contraseña = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.antiguedad = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.horasTrabajo = new System.Windows.Forms.Button();
            this.menosMesas = new System.Windows.Forms.Button();
            this.masMesas = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lNombre = new System.Windows.Forms.Label();
            this.bBuscar = new System.Windows.Forms.Button();
            this.textDNI = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.lDni = new System.Windows.Forms.Label();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.lApellido = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvEmpleados);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 418);
            this.panel1.TabIndex = 6;
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmpleados.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellido,
            this.DNI,
            this.Fecha_Nacimiento,
            this.Domicilio,
            this.Telefono,
            this.Gmail,
            this.Rol,
            this.Contraseña});
            this.dgvEmpleados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvEmpleados.Location = new System.Drawing.Point(0, 285);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.RowHeadersWidth = 51;
            this.dgvEmpleados.Size = new System.Drawing.Size(800, 133);
            this.dgvEmpleados.TabIndex = 8;
            this.dgvEmpleados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpleados_CellContentClick_1);
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "Apellido";
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.MinimumWidth = 6;
            this.Apellido.Name = "Apellido";
            // 
            // DNI
            // 
            this.DNI.DataPropertyName = "dni";
            this.DNI.HeaderText = "DNI";
            this.DNI.MinimumWidth = 6;
            this.DNI.Name = "DNI";
            // 
            // Fecha_Nacimiento
            // 
            this.Fecha_Nacimiento.DataPropertyName = "Fecha_Nacimiento";
            this.Fecha_Nacimiento.HeaderText = "Fecha de nacimiento";
            this.Fecha_Nacimiento.MinimumWidth = 6;
            this.Fecha_Nacimiento.Name = "Fecha_Nacimiento";
            // 
            // Domicilio
            // 
            this.Domicilio.DataPropertyName = "Domicilio";
            this.Domicilio.HeaderText = "Domicilio";
            this.Domicilio.MinimumWidth = 6;
            this.Domicilio.Name = "Domicilio";
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "Telefono";
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.MinimumWidth = 6;
            this.Telefono.Name = "Telefono";
            // 
            // Gmail
            // 
            this.Gmail.DataPropertyName = "Gmail";
            this.Gmail.HeaderText = "Gmail";
            this.Gmail.MinimumWidth = 6;
            this.Gmail.Name = "Gmail";
            // 
            // Rol
            // 
            this.Rol.DataPropertyName = "Rol";
            this.Rol.HeaderText = "Tipo de Usuario";
            this.Rol.MinimumWidth = 6;
            this.Rol.Name = "Rol";
            // 
            // Contraseña
            // 
            this.Contraseña.DataPropertyName = "Contraseña";
            this.Contraseña.HeaderText = "Contraseña";
            this.Contraseña.MinimumWidth = 6;
            this.Contraseña.Name = "Contraseña";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.antiguedad);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.horasTrabajo);
            this.panel2.Controls.Add(this.menosMesas);
            this.panel2.Controls.Add(this.masMesas);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 284);
            this.panel2.TabIndex = 7;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // antiguedad
            // 
            this.antiguedad.BackColor = System.Drawing.Color.LightBlue;
            this.antiguedad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.antiguedad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.antiguedad.Location = new System.Drawing.Point(403, 226);
            this.antiguedad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.antiguedad.Name = "antiguedad";
            this.antiguedad.Size = new System.Drawing.Size(118, 23);
            this.antiguedad.TabIndex = 23;
            this.antiguedad.Text = "Antigüedad";
            this.antiguedad.UseVisualStyleBackColor = false;
            this.antiguedad.Click += new System.EventHandler(this.antiguedad_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(433, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(365, 214);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // horasTrabajo
            // 
            this.horasTrabajo.BackColor = System.Drawing.Color.LightBlue;
            this.horasTrabajo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.horasTrabajo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horasTrabajo.Location = new System.Drawing.Point(272, 226);
            this.horasTrabajo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.horasTrabajo.Name = "horasTrabajo";
            this.horasTrabajo.Size = new System.Drawing.Size(118, 23);
            this.horasTrabajo.TabIndex = 22;
            this.horasTrabajo.Text = "Horas trabajadas";
            this.horasTrabajo.UseVisualStyleBackColor = false;
            this.horasTrabajo.Click += new System.EventHandler(this.horasTrabajo_Click);
            // 
            // menosMesas
            // 
            this.menosMesas.BackColor = System.Drawing.Color.LightBlue;
            this.menosMesas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.menosMesas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menosMesas.Location = new System.Drawing.Point(140, 226);
            this.menosMesas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.menosMesas.Name = "menosMesas";
            this.menosMesas.Size = new System.Drawing.Size(118, 23);
            this.menosMesas.TabIndex = 21;
            this.menosMesas.Text = "- Mesas atendidas";
            this.menosMesas.UseVisualStyleBackColor = false;
            this.menosMesas.Click += new System.EventHandler(this.menosMesas_Click);
            // 
            // masMesas
            // 
            this.masMesas.BackColor = System.Drawing.Color.LightBlue;
            this.masMesas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.masMesas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masMesas.Location = new System.Drawing.Point(9, 226);
            this.masMesas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.masMesas.Name = "masMesas";
            this.masMesas.Size = new System.Drawing.Size(118, 23);
            this.masMesas.TabIndex = 20;
            this.masMesas.Text = "+ Mesas atendidas";
            this.masMesas.UseVisualStyleBackColor = false;
            this.masMesas.Click += new System.EventHandler(this.masMesas_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lNombre);
            this.panel3.Controls.Add(this.bBuscar);
            this.panel3.Controls.Add(this.textDNI);
            this.panel3.Controls.Add(this.textNombre);
            this.panel3.Controls.Add(this.lDni);
            this.panel3.Controls.Add(this.textApellido);
            this.panel3.Controls.Add(this.lApellido);
            this.panel3.Location = new System.Drawing.Point(9, 48);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(314, 106);
            this.panel3.TabIndex = 19;
            // 
            // lNombre
            // 
            this.lNombre.AutoSize = true;
            this.lNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNombre.Location = new System.Drawing.Point(3, 11);
            this.lNombre.Name = "lNombre";
            this.lNombre.Size = new System.Drawing.Size(51, 15);
            this.lNombre.TabIndex = 13;
            this.lNombre.Text = "Nombre";
            // 
            // bBuscar
            // 
            this.bBuscar.BackColor = System.Drawing.Color.SkyBlue;
            this.bBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBuscar.Location = new System.Drawing.Point(219, 35);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(75, 23);
            this.bBuscar.TabIndex = 6;
            this.bBuscar.Text = "Buscar";
            this.bBuscar.UseVisualStyleBackColor = false;
            // 
            // textDNI
            // 
            this.textDNI.Location = new System.Drawing.Point(51, 64);
            this.textDNI.Name = "textDNI";
            this.textDNI.Size = new System.Drawing.Size(151, 20);
            this.textDNI.TabIndex = 18;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(51, 6);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(152, 20);
            this.textNombre.TabIndex = 16;
            // 
            // lDni
            // 
            this.lDni.AutoSize = true;
            this.lDni.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDni.Location = new System.Drawing.Point(3, 67);
            this.lDni.Name = "lDni";
            this.lDni.Size = new System.Drawing.Size(27, 15);
            this.lDni.TabIndex = 15;
            this.lDni.Text = "DNI";
            // 
            // textApellido
            // 
            this.textApellido.Location = new System.Drawing.Point(52, 35);
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(152, 20);
            this.textApellido.TabIndex = 17;
            // 
            // lApellido
            // 
            this.lApellido.AutoSize = true;
            this.lApellido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lApellido.Location = new System.Drawing.Point(3, 40);
            this.lApellido.Name = "lApellido";
            this.lApellido.Size = new System.Drawing.Size(51, 15);
            this.lApellido.TabIndex = 14;
            this.lApellido.Text = "Apellido";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(328, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // FormEmpleadosVistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 418);
            this.Controls.Add(this.panel1);
            this.Name = "FormEmpleadosVistas";
            this.Text = "FormEmpleadosVistas";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textDNI;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label lDni;
        private System.Windows.Forms.Label lApellido;
        private System.Windows.Forms.Label lNombre;
        private System.Windows.Forms.Button bBuscar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Nacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contraseña;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button masMesas;
        private System.Windows.Forms.Button horasTrabajo;
        private System.Windows.Forms.Button menosMesas;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button antiguedad;
    }
}