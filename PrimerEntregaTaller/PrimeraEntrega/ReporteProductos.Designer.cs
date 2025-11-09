namespace PrimeraEntrega
{
    partial class ReporteProductos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAltas = new System.Windows.Forms.Button();
            this.btnMes = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnBajas = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categorias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ventas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMenosVendidos = new System.Windows.Forms.Button();
            this.dateTimePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMasVendidos = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnAltas);
            this.panel2.Controls.Add(this.btnMes);
            this.panel2.Controls.Add(this.chart1);
            this.panel2.Controls.Add(this.btnBajas);
            this.panel2.Controls.Add(this.dgvProductos);
            this.panel2.Controls.Add(this.btnMenosVendidos);
            this.panel2.Controls.Add(this.dateTimePickerHasta);
            this.panel2.Controls.Add(this.dateTimePickerDesde);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnMasVendidos);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 475);
            this.panel2.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightSlateGray;
            this.label6.Location = new System.Drawing.Point(154, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 30);
            this.label6.TabIndex = 9;
            this.label6.Text = "Reporte de Productos";
            // 
            // btnAltas
            // 
            this.btnAltas.BackColor = System.Drawing.Color.LightBlue;
            this.btnAltas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAltas.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAltas.Location = new System.Drawing.Point(175, 213);
            this.btnAltas.Margin = new System.Windows.Forms.Padding(2);
            this.btnAltas.Name = "btnAltas";
            this.btnAltas.Size = new System.Drawing.Size(108, 23);
            this.btnAltas.TabIndex = 12;
            this.btnAltas.Text = "Altas";
            this.btnAltas.UseVisualStyleBackColor = false;
            // 
            // btnMes
            // 
            this.btnMes.BackColor = System.Drawing.Color.LightBlue;
            this.btnMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMes.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMes.Location = new System.Drawing.Point(414, 181);
            this.btnMes.Margin = new System.Windows.Forms.Padding(2);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(82, 28);
            this.btnMes.TabIndex = 7;
            this.btnMes.Text = "Mes";
            this.btnMes.UseVisualStyleBackColor = false;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(537, 62);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(479, 260);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            // 
            // btnBajas
            // 
            this.btnBajas.BackColor = System.Drawing.Color.LightBlue;
            this.btnBajas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBajas.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajas.Location = new System.Drawing.Point(30, 213);
            this.btnBajas.Margin = new System.Windows.Forms.Padding(2);
            this.btnBajas.Name = "btnBajas";
            this.btnBajas.Size = new System.Drawing.Size(108, 23);
            this.btnBajas.TabIndex = 11;
            this.btnBajas.Text = "Bajas";
            this.btnBajas.UseVisualStyleBackColor = false;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombres,
            this.categorias,
            this.ventas,
            this.estado});
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvProductos.Location = new System.Drawing.Point(0, 349);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.Size = new System.Drawing.Size(1028, 126);
            this.dgvProductos.TabIndex = 7;
            // 
            // nombres
            // 
            this.nombres.HeaderText = "Nombre";
            this.nombres.Name = "nombres";
            // 
            // categorias
            // 
            this.categorias.HeaderText = "Categoria";
            this.categorias.Name = "categorias";
            // 
            // ventas
            // 
            this.ventas.HeaderText = "Nro de Ventas";
            this.ventas.Name = "ventas";
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            // 
            // btnMenosVendidos
            // 
            this.btnMenosVendidos.BackColor = System.Drawing.Color.LightBlue;
            this.btnMenosVendidos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMenosVendidos.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenosVendidos.Location = new System.Drawing.Point(175, 165);
            this.btnMenosVendidos.Margin = new System.Windows.Forms.Padding(2);
            this.btnMenosVendidos.Name = "btnMenosVendidos";
            this.btnMenosVendidos.Size = new System.Drawing.Size(108, 23);
            this.btnMenosVendidos.TabIndex = 10;
            this.btnMenosVendidos.Text = "Menos Vendido";
            this.btnMenosVendidos.UseVisualStyleBackColor = false;
            // 
            // dateTimePickerHasta
            // 
            this.dateTimePickerHasta.Location = new System.Drawing.Point(365, 96);
            this.dateTimePickerHasta.Name = "dateTimePickerHasta";
            this.dateTimePickerHasta.Size = new System.Drawing.Size(145, 20);
            this.dateTimePickerHasta.TabIndex = 7;
            // 
            // dateTimePickerDesde
            // 
            this.dateTimePickerDesde.Location = new System.Drawing.Point(102, 95);
            this.dateTimePickerDesde.Name = "dateTimePickerDesde";
            this.dateTimePickerDesde.Size = new System.Drawing.Size(144, 20);
            this.dateTimePickerDesde.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha Desde";
            // 
            // btnMasVendidos
            // 
            this.btnMasVendidos.BackColor = System.Drawing.Color.LightBlue;
            this.btnMasVendidos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMasVendidos.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasVendidos.Location = new System.Drawing.Point(30, 165);
            this.btnMasVendidos.Margin = new System.Windows.Forms.Padding(2);
            this.btnMasVendidos.Name = "btnMasVendidos";
            this.btnMasVendidos.Size = new System.Drawing.Size(108, 23);
            this.btnMasVendidos.TabIndex = 8;
            this.btnMasVendidos.Text = "Mas Vendido";
            this.btnMasVendidos.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(276, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha Hasta";
            // 
            // ReporteProductos
            // 
            this.ClientSize = new System.Drawing.Size(1031, 476);
            this.Controls.Add(this.panel2);
            this.Name = "ReporteProductos";
            this.Text = "         ";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn nro_ventas;
        private System.Windows.Forms.Button bajaProductos;
        private System.Windows.Forms.Button menosVendido;
        private System.Windows.Forms.Button btnMasVendido;
        private System.Windows.Forms.Button altaProductos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMasVendidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerDesde;
        private System.Windows.Forms.DateTimePicker dateTimePickerHasta;
        private System.Windows.Forms.Button btnBajas;
        private System.Windows.Forms.Button btnMenosVendidos;
        private System.Windows.Forms.Button btnAltas;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn categorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn ventas;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
    }
}