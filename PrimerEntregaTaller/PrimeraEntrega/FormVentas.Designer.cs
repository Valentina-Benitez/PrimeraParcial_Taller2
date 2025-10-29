namespace PrimeraEntrega
{
    partial class FormVentas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.NroVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VerFactura = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.chartVentas);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.dgvVentas);
            this.panel1.Controls.Add(this.dtpDesde);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpHasta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1424, 580);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Reporte de Ventas";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LightBlue;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(53, 317);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(144, 28);
            this.button5.TabIndex = 10;
            this.button5.Text = "Por Tipo de pago";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // chartVentas
            // 
            chartArea3.Name = "ChartArea1";
            this.chartVentas.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartVentas.Legends.Add(legend3);
            this.chartVentas.Location = new System.Drawing.Point(719, 26);
            this.chartVentas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartVentas.Name = "chartVentas";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartVentas.Series.Add(series3);
            this.chartVentas.Size = new System.Drawing.Size(692, 336);
            this.chartVentas.TabIndex = 6;
            this.chartVentas.Text = "chart1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(570, 101);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "Filtrar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(53, 151);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(144, 28);
            this.button4.TabIndex = 9;
            this.button4.Text = "Por vendedor";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(53, 236);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 28);
            this.button3.TabIndex = 8;
            this.button3.Text = "Por cliente";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dgvVentas
            // 
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentas.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroVenta,
            this.NroPedido,
            this.Fecha,
            this.Empleado,
            this.Cliente,
            this.TipoPago,
            this.VerFactura});
            this.dgvVentas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvVentas.Location = new System.Drawing.Point(13, 396);
            this.dgvVentas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.Size = new System.Drawing.Size(1398, 171);
            this.dgvVentas.TabIndex = 1;
            this.dgvVentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // NroVenta
            // 
            this.NroVenta.DataPropertyName = "NroVenta";
            this.NroVenta.HeaderText = "Nro Venta";
            this.NroVenta.MinimumWidth = 6;
            this.NroVenta.Name = "NroVenta";
            // 
            // NroPedido
            // 
            this.NroPedido.DataPropertyName = "NroPedido";
            this.NroPedido.HeaderText = "Nro Pedido";
            this.NroPedido.MinimumWidth = 6;
            this.NroPedido.Name = "NroPedido";
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.MinimumWidth = 6;
            this.Fecha.Name = "Fecha";
            // 
            // Empleado
            // 
            this.Empleado.DataPropertyName = "Empleado";
            this.Empleado.HeaderText = "Empleado";
            this.Empleado.MinimumWidth = 6;
            this.Empleado.Name = "Empleado";
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.MinimumWidth = 6;
            this.Cliente.Name = "Cliente";
            // 
            // TipoPago
            // 
            this.TipoPago.DataPropertyName = "TipoPago";
            this.TipoPago.HeaderText = "Tipo pago";
            this.TipoPago.MinimumWidth = 6;
            this.TipoPago.Name = "TipoPago";
            // 
            // VerFactura
            // 
            this.VerFactura.HeaderText = "Ver factura";
            this.VerFactura.MinimumWidth = 6;
            this.VerFactura.Name = "VerFactura";
            this.VerFactura.Text = "Factura";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(135, 49);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(193, 22);
            this.dtpDesde.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(376, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha Hasta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha Desde";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(486, 50);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(193, 22);
            this.dtpHasta.TabIndex = 4;
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 580);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormVentas";
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.FormVentas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPago;
        private System.Windows.Forms.DataGridViewButtonColumn VerFactura;
    }
}