namespace RestauranteApp
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bCliente = new System.Windows.Forms.Button();
            this.bPedido = new System.Windows.Forms.Button();
            this.lProductos = new System.Windows.Forms.Label();
            this.bFacturacion = new System.Windows.Forms.Button();
            this.bReservas = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lVentas = new System.Windows.Forms.Label();
            this.pictureBox1_Usuario = new System.Windows.Forms.PictureBox();
            this.lEmpleados = new System.Windows.Forms.Label();
            this.ltitulo = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_Usuario)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 65);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(808, 401);
            this.panelContenedor.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightBlue;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.bCliente);
            this.panel4.Controls.Add(this.bPedido);
            this.panel4.Controls.Add(this.lProductos);
            this.panel4.Controls.Add(this.bFacturacion);
            this.panel4.Controls.Add(this.bReservas);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.lVentas);
            this.panel4.Controls.Add(this.pictureBox1_Usuario);
            this.panel4.Controls.Add(this.lEmpleados);
            this.panel4.Controls.Add(this.ltitulo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(808, 65);
            this.panel4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(574, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Clientes";
            // 
            // bCliente
            // 
            this.bCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bCliente.BackgroundImage")));
            this.bCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCliente.Location = new System.Drawing.Point(535, 25);
            this.bCliente.Name = "bCliente";
            this.bCliente.Size = new System.Drawing.Size(34, 37);
            this.bCliente.TabIndex = 8;
            this.bCliente.UseVisualStyleBackColor = true;
            this.bCliente.Click += new System.EventHandler(this.bCliente_Click);
            // 
            // bPedido
            // 
            this.bPedido.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bPedido.BackgroundImage")));
            this.bPedido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bPedido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPedido.Location = new System.Drawing.Point(292, 24);
            this.bPedido.Name = "bPedido";
            this.bPedido.Size = new System.Drawing.Size(34, 38);
            this.bPedido.TabIndex = 0;
            this.bPedido.UseVisualStyleBackColor = true;
            this.bPedido.Click += new System.EventHandler(this.bPedido_Click);
            // 
            // lProductos
            // 
            this.lProductos.AutoSize = true;
            this.lProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProductos.Location = new System.Drawing.Point(448, 36);
            this.lProductos.Name = "lProductos";
            this.lProductos.Size = new System.Drawing.Size(71, 15);
            this.lProductos.TabIndex = 4;
            this.lProductos.Text = "Facturacion";
            // 
            // bFacturacion
            // 
            this.bFacturacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bFacturacion.BackgroundImage")));
            this.bFacturacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bFacturacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFacturacion.Location = new System.Drawing.Point(409, 24);
            this.bFacturacion.Name = "bFacturacion";
            this.bFacturacion.Size = new System.Drawing.Size(34, 37);
            this.bFacturacion.TabIndex = 0;
            this.bFacturacion.UseVisualStyleBackColor = true;
            this.bFacturacion.Click += new System.EventHandler(this.bFacturacion_Click);
            // 
            // bReservas
            // 
            this.bReservas.BackColor = System.Drawing.Color.LightBlue;
            this.bReservas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bReservas.BackgroundImage")));
            this.bReservas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bReservas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bReservas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bReservas.Location = new System.Drawing.Point(175, 24);
            this.bReservas.Name = "bReservas";
            this.bReservas.Size = new System.Drawing.Size(29, 37);
            this.bReservas.TabIndex = 7;
            this.bReservas.UseVisualStyleBackColor = false;
            this.bReservas.Click += new System.EventHandler(this.bReservas_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(769, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lVentas
            // 
            this.lVentas.AutoSize = true;
            this.lVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVentas.Location = new System.Drawing.Point(332, 36);
            this.lVentas.Name = "lVentas";
            this.lVentas.Size = new System.Drawing.Size(52, 15);
            this.lVentas.TabIndex = 5;
            this.lVentas.Text = "Pedidos";
            // 
            // pictureBox1_Usuario
            // 
            this.pictureBox1_Usuario.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1_Usuario.Image")));
            this.pictureBox1_Usuario.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1_Usuario.Name = "pictureBox1_Usuario";
            this.pictureBox1_Usuario.Size = new System.Drawing.Size(30, 31);
            this.pictureBox1_Usuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1_Usuario.TabIndex = 2;
            this.pictureBox1_Usuario.TabStop = false;
            // 
            // lEmpleados
            // 
            this.lEmpleados.AutoSize = true;
            this.lEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEmpleados.Location = new System.Drawing.Point(210, 36);
            this.lEmpleados.Name = "lEmpleados";
            this.lEmpleados.Size = new System.Drawing.Size(58, 15);
            this.lEmpleados.TabIndex = 1;
            this.lEmpleados.Text = "Reservas";
            // 
            // ltitulo
            // 
            this.ltitulo.AutoSize = true;
            this.ltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltitulo.Location = new System.Drawing.Point(29, 24);
            this.ltitulo.Name = "ltitulo";
            this.ltitulo.Size = new System.Drawing.Size(140, 20);
            this.ltitulo.TabIndex = 0;
            this.ltitulo.Text = "Sabor Argentino";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 466);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panel4);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form3";
            this.Text = "Form3_Recepcionista";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_Usuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button bPedido;
        private System.Windows.Forms.Button bFacturacion;
        private System.Windows.Forms.Button bReservas;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lVentas;
        private System.Windows.Forms.Label lProductos;
        private System.Windows.Forms.PictureBox pictureBox1_Usuario;
        private System.Windows.Forms.Label lEmpleados;
        private System.Windows.Forms.Label ltitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bCliente;
    }
}