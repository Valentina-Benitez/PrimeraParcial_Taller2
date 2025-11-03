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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Nacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contraseña = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFiltrarMes = new System.Windows.Forms.Button();
            this.chartEmpleados = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtnHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.PedidosTomados = new System.Windows.Forms.Button();
            this.VentasRealizadas = new System.Windows.Forms.Button();
            this.ReservasRegistradas = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1371, 612);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.dgvEmpleados);
            this.panel2.Controls.Add(this.btnFiltrarMes);
            this.panel2.Controls.Add(this.chartEmpleados);
            this.panel2.Controls.Add(this.dtpDesde);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtnHasta);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.PedidosTomados);
            this.panel2.Controls.Add(this.VentasRealizadas);
            this.panel2.Controls.Add(this.ReservasRegistradas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1371, 612);
            this.panel2.TabIndex = 7;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
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
            this.Correo,
            this.Rol,
            this.Contraseña});
            this.dgvEmpleados.Location = new System.Drawing.Point(0, 432);
            this.dgvEmpleados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.RowHeadersWidth = 51;
            this.dgvEmpleados.Size = new System.Drawing.Size(1371, 156);
            this.dgvEmpleados.TabIndex = 8;
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
            // Correo
            // 
            this.Correo.DataPropertyName = "Correo";
            this.Correo.HeaderText = "Correo";
            this.Correo.MinimumWidth = 6;
            this.Correo.Name = "Correo";
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
            // btnFiltrarMes
            // 
            this.btnFiltrarMes.BackColor = System.Drawing.Color.LightBlue;
            this.btnFiltrarMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrarMes.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarMes.Location = new System.Drawing.Point(552, 105);
            this.btnFiltrarMes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFiltrarMes.Name = "btnFiltrarMes";
            this.btnFiltrarMes.Size = new System.Drawing.Size(109, 34);
            this.btnFiltrarMes.TabIndex = 29;
            this.btnFiltrarMes.Text = "Por mes";
            this.btnFiltrarMes.UseVisualStyleBackColor = false;
            this.btnFiltrarMes.Click += new System.EventHandler(this.btnFiltrarMes_Click_1);
            // 
            // chartEmpleados
            // 
            chartArea2.Name = "ChartArea1";
            this.chartEmpleados.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartEmpleados.Legends.Add(legend2);
            this.chartEmpleados.Location = new System.Drawing.Point(697, 32);
            this.chartEmpleados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartEmpleados.Name = "chartEmpleados";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartEmpleados.Series.Add(series2);
            this.chartEmpleados.Size = new System.Drawing.Size(699, 374);
            this.chartEmpleados.TabIndex = 28;
            this.chartEmpleados.Text = "Empleados";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(129, 57);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(193, 22);
            this.dtpDesde.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 23);
            this.label2.TabIndex = 26;
            this.label2.Text = "Fecha Desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(375, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 23);
            this.label3.TabIndex = 25;
            this.label3.Text = "Fecha Hasta";
            // 
            // dtnHasta
            // 
            this.dtnHasta.Location = new System.Drawing.Point(485, 57);
            this.dtnHasta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtnHasta.Name = "dtnHasta";
            this.dtnHasta.Size = new System.Drawing.Size(185, 22);
            this.dtnHasta.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSlateGray;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 38);
            this.label1.TabIndex = 19;
            this.label1.Text = "Reporte de Empleados";
            // 
            // PedidosTomados
            // 
            this.PedidosTomados.BackColor = System.Drawing.Color.LightBlue;
            this.PedidosTomados.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PedidosTomados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PedidosTomados.Location = new System.Drawing.Point(52, 134);
            this.PedidosTomados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PedidosTomados.Name = "PedidosTomados";
            this.PedidosTomados.Size = new System.Drawing.Size(175, 47);
            this.PedidosTomados.TabIndex = 23;
            this.PedidosTomados.Text = "Pedidos tomados";
            this.PedidosTomados.UseVisualStyleBackColor = false;
            this.PedidosTomados.Click += new System.EventHandler(this.PedidosTomados_Click);
            // 
            // VentasRealizadas
            // 
            this.VentasRealizadas.BackColor = System.Drawing.Color.LightBlue;
            this.VentasRealizadas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.VentasRealizadas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VentasRealizadas.Location = new System.Drawing.Point(52, 317);
            this.VentasRealizadas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VentasRealizadas.Name = "VentasRealizadas";
            this.VentasRealizadas.Size = new System.Drawing.Size(175, 47);
            this.VentasRealizadas.TabIndex = 22;
            this.VentasRealizadas.Text = "Ventas realizadas";
            this.VentasRealizadas.UseVisualStyleBackColor = false;
            this.VentasRealizadas.Click += new System.EventHandler(this.VentasRealizadas_Click);
            // 
            // ReservasRegistradas
            // 
            this.ReservasRegistradas.BackColor = System.Drawing.Color.LightBlue;
            this.ReservasRegistradas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ReservasRegistradas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReservasRegistradas.Location = new System.Drawing.Point(52, 229);
            this.ReservasRegistradas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReservasRegistradas.Name = "ReservasRegistradas";
            this.ReservasRegistradas.Size = new System.Drawing.Size(175, 47);
            this.ReservasRegistradas.TabIndex = 21;
            this.ReservasRegistradas.Text = "Reservas registradas";
            this.ReservasRegistradas.UseVisualStyleBackColor = false;
            this.ReservasRegistradas.Click += new System.EventHandler(this.ReservasRegistradas_Click_1);
            // 
            // FormEmpleadosVistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 612);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormEmpleadosVistas";
            this.Text = "FormEmpleadosVistas";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEmpleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button VentasRealizadas;
        private System.Windows.Forms.Button ReservasRegistradas;
        private System.Windows.Forms.Button PedidosTomados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtnHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEmpleados;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Nacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contraseña;
        private System.Windows.Forms.Button btnFiltrarMes;
    }
}