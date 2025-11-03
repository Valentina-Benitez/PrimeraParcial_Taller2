namespace PrimeraEntrega
{
    partial class FormPrincipalAdmi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipalAdmi));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.bBackUp = new System.Windows.Forms.Button();
            this.bProductos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bVentas = new System.Windows.Forms.Button();
            this.bCliente = new System.Windows.Forms.Button();
            this.bEmpleados = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lVentas = new System.Windows.Forms.Label();
            this.lProductos = new System.Windows.Forms.Label();
            this.pictureBox1_Usuario = new System.Windows.Forms.PictureBox();
            this.lEmpleados = new System.Windows.Forms.Label();
            this.ltitulo = new System.Windows.Forms.Label();
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_Usuario)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelAdmin, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.35312F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.64688F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1371, 674);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bBackUp);
            this.panel1.Controls.Add(this.bProductos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bVentas);
            this.panel1.Controls.Add(this.bCliente);
            this.panel1.Controls.Add(this.bEmpleados);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.lVentas);
            this.panel1.Controls.Add(this.lProductos);
            this.panel1.Controls.Add(this.pictureBox1_Usuario);
            this.panel1.Controls.Add(this.lEmpleados);
            this.panel1.Controls.Add(this.ltitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1363, 82);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1085, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "Back Up";
            // 
            // bBackUp
            // 
            this.bBackUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bBackUp.BackgroundImage")));
            this.bBackUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bBackUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bBackUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBackUp.Location = new System.Drawing.Point(1032, 28);
            this.bBackUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bBackUp.Name = "bBackUp";
            this.bBackUp.Size = new System.Drawing.Size(45, 46);
            this.bBackUp.TabIndex = 19;
            this.bBackUp.UseVisualStyleBackColor = true;
            this.bBackUp.Click += new System.EventHandler(this.bBackUp_Click);
            // 
            // bProductos
            // 
            this.bProductos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bProductos.BackgroundImage")));
            this.bProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bProductos.Location = new System.Drawing.Point(504, 27);
            this.bProductos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bProductos.Name = "bProductos";
            this.bProductos.Size = new System.Drawing.Size(45, 46);
            this.bProductos.TabIndex = 9;
            this.bProductos.UseVisualStyleBackColor = true;
            this.bProductos.Click += new System.EventHandler(this.bProductos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(747, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Clientes";
            // 
            // bVentas
            // 
            this.bVentas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bVentas.BackgroundImage")));
            this.bVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bVentas.Location = new System.Drawing.Point(871, 30);
            this.bVentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bVentas.Name = "bVentas";
            this.bVentas.Size = new System.Drawing.Size(45, 46);
            this.bVentas.TabIndex = 8;
            this.bVentas.UseVisualStyleBackColor = true;
            this.bVentas.Click += new System.EventHandler(this.bVentas_Click);
            // 
            // bCliente
            // 
            this.bCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bCliente.BackgroundImage")));
            this.bCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCliente.Location = new System.Drawing.Point(693, 30);
            this.bCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bCliente.Name = "bCliente";
            this.bCliente.Size = new System.Drawing.Size(45, 46);
            this.bCliente.TabIndex = 17;
            this.bCliente.UseVisualStyleBackColor = true;
            this.bCliente.Click += new System.EventHandler(this.bCliente_Click);
            // 
            // bEmpleados
            // 
            this.bEmpleados.BackColor = System.Drawing.Color.LightBlue;
            this.bEmpleados.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bEmpleados.BackgroundImage")));
            this.bEmpleados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bEmpleados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEmpleados.Location = new System.Drawing.Point(309, 27);
            this.bEmpleados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bEmpleados.Name = "bEmpleados";
            this.bEmpleados.Size = new System.Drawing.Size(39, 46);
            this.bEmpleados.TabIndex = 16;
            this.bEmpleados.UseVisualStyleBackColor = false;
            this.bEmpleados.Click += new System.EventHandler(this.bEmpleados_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1299, 10);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lVentas
            // 
            this.lVentas.AutoSize = true;
            this.lVentas.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVentas.Location = new System.Drawing.Point(924, 44);
            this.lVentas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lVentas.Name = "lVentas";
            this.lVentas.Size = new System.Drawing.Size(50, 19);
            this.lVentas.TabIndex = 14;
            this.lVentas.Text = "Ventas";
            // 
            // lProductos
            // 
            this.lProductos.AutoSize = true;
            this.lProductos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProductos.Location = new System.Drawing.Point(557, 41);
            this.lProductos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lProductos.Name = "lProductos";
            this.lProductos.Size = new System.Drawing.Size(75, 20);
            this.lProductos.TabIndex = 13;
            this.lProductos.Text = "Productos";
            // 
            // pictureBox1_Usuario
            // 
            this.pictureBox1_Usuario.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1_Usuario.Image")));
            this.pictureBox1_Usuario.Location = new System.Drawing.Point(4, 5);
            this.pictureBox1_Usuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1_Usuario.Name = "pictureBox1_Usuario";
            this.pictureBox1_Usuario.Size = new System.Drawing.Size(59, 69);
            this.pictureBox1_Usuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1_Usuario.TabIndex = 12;
            this.pictureBox1_Usuario.TabStop = false;
            // 
            // lEmpleados
            // 
            this.lEmpleados.AutoSize = true;
            this.lEmpleados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEmpleados.Location = new System.Drawing.Point(357, 42);
            this.lEmpleados.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lEmpleados.Name = "lEmpleados";
            this.lEmpleados.Size = new System.Drawing.Size(83, 20);
            this.lEmpleados.TabIndex = 11;
            this.lEmpleados.Text = "Empleados";
            // 
            // ltitulo
            // 
            this.ltitulo.AutoSize = true;
            this.ltitulo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltitulo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.ltitulo.Location = new System.Drawing.Point(71, 33);
            this.ltitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ltitulo.Name = "ltitulo";
            this.ltitulo.Size = new System.Drawing.Size(180, 32);
            this.ltitulo.TabIndex = 10;
            this.ltitulo.Text = "Administrador";
            // 
            // panelAdmin
            // 
            this.panelAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdmin.Location = new System.Drawing.Point(4, 94);
            this.panelAdmin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(1363, 576);
            this.panelAdmin.TabIndex = 1;
            this.panelAdmin.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAdmin_Paint);
            // 
            // FormPrincipalAdmi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 674);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormPrincipalAdmi";
            this.Text = "Form4";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_Usuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelAdmin;
        private System.Windows.Forms.Button bVentas;
        private System.Windows.Forms.Button bProductos;
        private System.Windows.Forms.Button bEmpleados;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lVentas;
        private System.Windows.Forms.Label lProductos;
        private System.Windows.Forms.PictureBox pictureBox1_Usuario;
        private System.Windows.Forms.Label lEmpleados;
        private System.Windows.Forms.Label ltitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bCliente;
        private System.Windows.Forms.Button bBackUp;
        private System.Windows.Forms.Label label2;
    }
}