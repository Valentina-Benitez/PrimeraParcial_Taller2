namespace gerente
{
    partial class Empleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Empleados));
            this.lNombre = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bEliminar = new System.Windows.Forms.Button();
            this.bModificar = new System.Windows.Forms.Button();
            this.bBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bAgregar = new System.Windows.Forms.Button();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.cbTipoUsuario = new System.Windows.Forms.ComboBox();
            this.textReContraseña = new System.Windows.Forms.TextBox();
            this.textContraseña = new System.Windows.Forms.TextBox();
            this.textGmail = new System.Windows.Forms.TextBox();
            this.textTelefono = new System.Windows.Forms.TextBox();
            this.textDomicilio = new System.Windows.Forms.TextBox();
            this.textDni = new System.Windows.Forms.TextBox();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.lRepContraseña = new System.Windows.Forms.Label();
            this.lContraseña = new System.Windows.Forms.Label();
            this.lTipoUsuario = new System.Windows.Forms.Label();
            this.lGmail = new System.Windows.Forms.Label();
            this.lTelefono = new System.Windows.Forms.Label();
            this.lDomicilio = new System.Windows.Forms.Label();
            this.lFechaNacimiento = new System.Windows.Forms.Label();
            this.lDni = new System.Windows.Forms.Label();
            this.lApellido = new System.Windows.Forms.Label();
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // lNombre
            // 
            this.lNombre.AutoSize = true;
            this.lNombre.Location = new System.Drawing.Point(41, 50);
            this.lNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lNombre.Name = "lNombre";
            this.lNombre.Size = new System.Drawing.Size(56, 16);
            this.lNombre.TabIndex = 0;
            this.lNombre.Text = "Nombre";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.bCancelar);
            this.panel1.Controls.Add(this.bEliminar);
            this.panel1.Controls.Add(this.bModificar);
            this.panel1.Controls.Add(this.bBuscar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.bAgregar);
            this.panel1.Controls.Add(this.dtpFechaNac);
            this.panel1.Controls.Add(this.cbTipoUsuario);
            this.panel1.Controls.Add(this.textReContraseña);
            this.panel1.Controls.Add(this.textContraseña);
            this.panel1.Controls.Add(this.textGmail);
            this.panel1.Controls.Add(this.textTelefono);
            this.panel1.Controls.Add(this.textDomicilio);
            this.panel1.Controls.Add(this.textDni);
            this.panel1.Controls.Add(this.textApellido);
            this.panel1.Controls.Add(this.textNombre);
            this.panel1.Controls.Add(this.lRepContraseña);
            this.panel1.Controls.Add(this.lContraseña);
            this.panel1.Controls.Add(this.lTipoUsuario);
            this.panel1.Controls.Add(this.lGmail);
            this.panel1.Controls.Add(this.lTelefono);
            this.panel1.Controls.Add(this.lDomicilio);
            this.panel1.Controls.Add(this.lFechaNacimiento);
            this.panel1.Controls.Add(this.lDni);
            this.panel1.Controls.Add(this.lApellido);
            this.panel1.Controls.Add(this.lNombre);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 300);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // bCancelar
            // 
            this.bCancelar.BackColor = System.Drawing.Color.DarkSalmon;
            this.bCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bCancelar.Font = new System.Drawing.Font("Constantia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancelar.Location = new System.Drawing.Point(231, 246);
            this.bCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(100, 28);
            this.bCancelar.TabIndex = 24;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = false;
            // 
            // bEliminar
            // 
            this.bEliminar.BackColor = System.Drawing.Color.DarkSalmon;
            this.bEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bEliminar.Font = new System.Drawing.Font("Constantia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEliminar.Location = new System.Drawing.Point(679, 246);
            this.bEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(79, 30);
            this.bEliminar.TabIndex = 23;
            this.bEliminar.Text = "Eliminar";
            this.bEliminar.UseVisualStyleBackColor = false;
            // 
            // bModificar
            // 
            this.bModificar.BackColor = System.Drawing.Color.SkyBlue;
            this.bModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bModificar.Font = new System.Drawing.Font("Constantia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bModificar.Location = new System.Drawing.Point(561, 246);
            this.bModificar.Margin = new System.Windows.Forms.Padding(4);
            this.bModificar.Name = "bModificar";
            this.bModificar.Size = new System.Drawing.Size(85, 30);
            this.bModificar.TabIndex = 22;
            this.bModificar.Text = "Modificar";
            this.bModificar.UseVisualStyleBackColor = false;
            // 
            // bBuscar
            // 
            this.bBuscar.BackColor = System.Drawing.Color.SkyBlue;
            this.bBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bBuscar.Font = new System.Drawing.Font("Constantia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBuscar.Location = new System.Drawing.Point(85, 247);
            this.bBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(100, 28);
            this.bBuscar.TabIndex = 21;
            this.bBuscar.Text = "Buscar";
            this.bBuscar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(851, 218);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Empleados";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(844, 41);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 151);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // bAgregar
            // 
            this.bAgregar.BackColor = System.Drawing.Color.LightGreen;
            this.bAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAgregar.Font = new System.Drawing.Font("Constantia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAgregar.Location = new System.Drawing.Point(392, 247);
            this.bAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.bAgregar.Name = "bAgregar";
            this.bAgregar.Size = new System.Drawing.Size(100, 28);
            this.bAgregar.TabIndex = 20;
            this.bAgregar.Text = "Agregar";
            this.bAgregar.UseVisualStyleBackColor = false;
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Location = new System.Drawing.Point(188, 155);
            this.dtpFechaNac.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(201, 22);
            this.dtpFechaNac.TabIndex = 19;
            // 
            // cbTipoUsuario
            // 
            this.cbTipoUsuario.FormattingEnabled = true;
            this.cbTipoUsuario.Location = new System.Drawing.Point(595, 113);
            this.cbTipoUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.cbTipoUsuario.Name = "cbTipoUsuario";
            this.cbTipoUsuario.Size = new System.Drawing.Size(200, 24);
            this.cbTipoUsuario.TabIndex = 18;
            // 
            // textReContraseña
            // 
            this.textReContraseña.Location = new System.Drawing.Point(595, 198);
            this.textReContraseña.Margin = new System.Windows.Forms.Padding(4);
            this.textReContraseña.Name = "textReContraseña";
            this.textReContraseña.Size = new System.Drawing.Size(200, 22);
            this.textReContraseña.TabIndex = 17;
            // 
            // textContraseña
            // 
            this.textContraseña.Location = new System.Drawing.Point(595, 146);
            this.textContraseña.Margin = new System.Windows.Forms.Padding(4);
            this.textContraseña.Name = "textContraseña";
            this.textContraseña.Size = new System.Drawing.Size(200, 22);
            this.textContraseña.TabIndex = 16;
            // 
            // textGmail
            // 
            this.textGmail.Location = new System.Drawing.Point(595, 74);
            this.textGmail.Margin = new System.Windows.Forms.Padding(4);
            this.textGmail.Name = "textGmail";
            this.textGmail.Size = new System.Drawing.Size(200, 22);
            this.textGmail.TabIndex = 15;
            // 
            // textTelefono
            // 
            this.textTelefono.Location = new System.Drawing.Point(595, 41);
            this.textTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.textTelefono.Name = "textTelefono";
            this.textTelefono.Size = new System.Drawing.Size(200, 22);
            this.textTelefono.TabIndex = 14;
            // 
            // textDomicilio
            // 
            this.textDomicilio.Location = new System.Drawing.Point(188, 194);
            this.textDomicilio.Margin = new System.Windows.Forms.Padding(4);
            this.textDomicilio.Name = "textDomicilio";
            this.textDomicilio.Size = new System.Drawing.Size(200, 22);
            this.textDomicilio.TabIndex = 13;
            // 
            // textDni
            // 
            this.textDni.Location = new System.Drawing.Point(188, 121);
            this.textDni.Margin = new System.Windows.Forms.Padding(4);
            this.textDni.Name = "textDni";
            this.textDni.Size = new System.Drawing.Size(200, 22);
            this.textDni.TabIndex = 12;
            // 
            // textApellido
            // 
            this.textApellido.Location = new System.Drawing.Point(188, 84);
            this.textApellido.Margin = new System.Windows.Forms.Padding(4);
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(201, 22);
            this.textApellido.TabIndex = 11;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(188, 42);
            this.textNombre.Margin = new System.Windows.Forms.Padding(4);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(201, 22);
            this.textNombre.TabIndex = 10;
            // 
            // lRepContraseña
            // 
            this.lRepContraseña.AutoSize = true;
            this.lRepContraseña.Location = new System.Drawing.Point(448, 198);
            this.lRepContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lRepContraseña.Name = "lRepContraseña";
            this.lRepContraseña.Size = new System.Drawing.Size(123, 16);
            this.lRepContraseña.TabIndex = 9;
            this.lRepContraseña.Text = "Repetir Contraseña";
            // 
            // lContraseña
            // 
            this.lContraseña.AutoSize = true;
            this.lContraseña.Location = new System.Drawing.Point(448, 155);
            this.lContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lContraseña.Name = "lContraseña";
            this.lContraseña.Size = new System.Drawing.Size(76, 16);
            this.lContraseña.TabIndex = 8;
            this.lContraseña.Text = "Contraseña";
            // 
            // lTipoUsuario
            // 
            this.lTipoUsuario.AutoSize = true;
            this.lTipoUsuario.Location = new System.Drawing.Point(448, 117);
            this.lTipoUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lTipoUsuario.Name = "lTipoUsuario";
            this.lTipoUsuario.Size = new System.Drawing.Size(104, 16);
            this.lTipoUsuario.TabIndex = 7;
            this.lTipoUsuario.Text = "Tipo de Usuario";
            // 
            // lGmail
            // 
            this.lGmail.AutoSize = true;
            this.lGmail.Location = new System.Drawing.Point(448, 82);
            this.lGmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lGmail.Name = "lGmail";
            this.lGmail.Size = new System.Drawing.Size(42, 16);
            this.lGmail.TabIndex = 6;
            this.lGmail.Text = "Gmail";
            // 
            // lTelefono
            // 
            this.lTelefono.AutoSize = true;
            this.lTelefono.Location = new System.Drawing.Point(448, 44);
            this.lTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lTelefono.Name = "lTelefono";
            this.lTelefono.Size = new System.Drawing.Size(61, 16);
            this.lTelefono.TabIndex = 5;
            this.lTelefono.Text = "Telefono";
            // 
            // lDomicilio
            // 
            this.lDomicilio.AutoSize = true;
            this.lDomicilio.Location = new System.Drawing.Point(41, 198);
            this.lDomicilio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lDomicilio.Name = "lDomicilio";
            this.lDomicilio.Size = new System.Drawing.Size(63, 16);
            this.lDomicilio.TabIndex = 4;
            this.lDomicilio.Text = "Domicilio";
            // 
            // lFechaNacimiento
            // 
            this.lFechaNacimiento.AutoSize = true;
            this.lFechaNacimiento.Location = new System.Drawing.Point(41, 162);
            this.lFechaNacimiento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lFechaNacimiento.Name = "lFechaNacimiento";
            this.lFechaNacimiento.Size = new System.Drawing.Size(135, 16);
            this.lFechaNacimiento.TabIndex = 3;
            this.lFechaNacimiento.Text = "Fecha de Nacimiento";
            // 
            // lDni
            // 
            this.lDni.AutoSize = true;
            this.lDni.Location = new System.Drawing.Point(41, 129);
            this.lDni.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lDni.Name = "lDni";
            this.lDni.Size = new System.Drawing.Size(30, 16);
            this.lDni.TabIndex = 2;
            this.lDni.Text = "DNI";
            // 
            // lApellido
            // 
            this.lApellido.AutoSize = true;
            this.lApellido.Location = new System.Drawing.Point(41, 92);
            this.lApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lApellido.Name = "lApellido";
            this.lApellido.Size = new System.Drawing.Size(57, 16);
            this.lApellido.TabIndex = 1;
            this.lApellido.Text = "Apellido";
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
            this.dgvEmpleados.Location = new System.Drawing.Point(0, 296);
            this.dgvEmpleados.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.RowHeadersWidth = 51;
            this.dgvEmpleados.Size = new System.Drawing.Size(1081, 186);
            this.dgvEmpleados.TabIndex = 4;
            this.dgvEmpleados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpleados_CellContentClick);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.MinimumWidth = 6;
            this.Apellido.Name = "Apellido";
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.MinimumWidth = 6;
            this.DNI.Name = "DNI";
            // 
            // Fecha_Nacimiento
            // 
            this.Fecha_Nacimiento.HeaderText = "Fecha de nacimiento";
            this.Fecha_Nacimiento.MinimumWidth = 6;
            this.Fecha_Nacimiento.Name = "Fecha_Nacimiento";
            // 
            // Domicilio
            // 
            this.Domicilio.HeaderText = "Domicilio";
            this.Domicilio.MinimumWidth = 6;
            this.Domicilio.Name = "Domicilio";
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.MinimumWidth = 6;
            this.Telefono.Name = "Telefono";
            // 
            // Gmail
            // 
            this.Gmail.HeaderText = "Gmail";
            this.Gmail.MinimumWidth = 6;
            this.Gmail.Name = "Gmail";
            // 
            // Rol
            // 
            this.Rol.HeaderText = "Tipo de Usuario";
            this.Rol.MinimumWidth = 6;
            this.Rol.Name = "Rol";
            // 
            // Contraseña
            // 
            this.Contraseña.HeaderText = "Contraseña";
            this.Contraseña.MinimumWidth = 6;
            this.Contraseña.Name = "Contraseña";
            // 
            // Empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 482);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvEmpleados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Empleados";
            this.Text = "Empleados";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lNombre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lRepContraseña;
        private System.Windows.Forms.Label lContraseña;
        private System.Windows.Forms.Label lTipoUsuario;
        private System.Windows.Forms.Label lGmail;
        private System.Windows.Forms.Label lTelefono;
        private System.Windows.Forms.Label lDomicilio;
        private System.Windows.Forms.Label lFechaNacimiento;
        private System.Windows.Forms.Label lDni;
        private System.Windows.Forms.Label lApellido;
        private System.Windows.Forms.TextBox textContraseña;
        private System.Windows.Forms.TextBox textGmail;
        private System.Windows.Forms.TextBox textTelefono;
        private System.Windows.Forms.TextBox textDomicilio;
        private System.Windows.Forms.TextBox textDni;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Button bAgregar;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.ComboBox cbTipoUsuario;
        private System.Windows.Forms.TextBox textReContraseña;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Nacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contraseña;
        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.Button bModificar;
        private System.Windows.Forms.Button bBuscar;
        private System.Windows.Forms.Button bCancelar;
    }
}