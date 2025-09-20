namespace PrimeraEntrega
{
    partial class FormProductosVistas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProductosVistas));
            this.bBuscar = new System.Windows.Forms.Button();
            this.textEstadoP = new System.Windows.Forms.TextBox();
            this.textPrecioP = new System.Windows.Forms.TextBox();
            this.textProvinciaP = new System.Windows.Forms.TextBox();
            this.textDescuentoP = new System.Windows.Forms.TextBox();
            this.textCategoriaP = new System.Windows.Forms.TextBox();
            this.textNombreP = new System.Windows.Forms.TextBox();
            this.lEstado = new System.Windows.Forms.Label();
            this.lPrecio = new System.Windows.Forms.Label();
            this.lProvincia = new System.Windows.Forms.Label();
            this.lDescuento = new System.Windows.Forms.Label();
            this.lCategoria = new System.Windows.Forms.Label();
            this.lNombreProducto = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lProductos = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProvinciaProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // bBuscar
            // 
            this.bBuscar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bBuscar.Location = new System.Drawing.Point(255, 190);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(84, 30);
            this.bBuscar.TabIndex = 38;
            this.bBuscar.Text = "Buscar";
            this.bBuscar.UseVisualStyleBackColor = false;
            this.bBuscar.Click += new System.EventHandler(this.bBuscar_Click);
            // 
            // textEstadoP
            // 
            this.textEstadoP.Location = new System.Drawing.Point(359, 137);
            this.textEstadoP.Name = "textEstadoP";
            this.textEstadoP.Size = new System.Drawing.Size(100, 20);
            this.textEstadoP.TabIndex = 36;
            // 
            // textPrecioP
            // 
            this.textPrecioP.Location = new System.Drawing.Point(359, 90);
            this.textPrecioP.Name = "textPrecioP";
            this.textPrecioP.Size = new System.Drawing.Size(100, 20);
            this.textPrecioP.TabIndex = 35;
            // 
            // textProvinciaP
            // 
            this.textProvinciaP.Location = new System.Drawing.Point(359, 45);
            this.textProvinciaP.Name = "textProvinciaP";
            this.textProvinciaP.Size = new System.Drawing.Size(100, 20);
            this.textProvinciaP.TabIndex = 34;
            // 
            // textDescuentoP
            // 
            this.textDescuentoP.Location = new System.Drawing.Point(178, 137);
            this.textDescuentoP.Name = "textDescuentoP";
            this.textDescuentoP.Size = new System.Drawing.Size(100, 20);
            this.textDescuentoP.TabIndex = 33;
            // 
            // textCategoriaP
            // 
            this.textCategoriaP.Location = new System.Drawing.Point(178, 91);
            this.textCategoriaP.Name = "textCategoriaP";
            this.textCategoriaP.Size = new System.Drawing.Size(100, 20);
            this.textCategoriaP.TabIndex = 32;
            // 
            // textNombreP
            // 
            this.textNombreP.Location = new System.Drawing.Point(178, 52);
            this.textNombreP.Name = "textNombreP";
            this.textNombreP.Size = new System.Drawing.Size(100, 20);
            this.textNombreP.TabIndex = 31;
            // 
            // lEstado
            // 
            this.lEstado.AutoSize = true;
            this.lEstado.Location = new System.Drawing.Point(302, 144);
            this.lEstado.Name = "lEstado";
            this.lEstado.Size = new System.Drawing.Size(40, 13);
            this.lEstado.TabIndex = 28;
            this.lEstado.Text = "Estado";
            // 
            // lPrecio
            // 
            this.lPrecio.AutoSize = true;
            this.lPrecio.Location = new System.Drawing.Point(302, 97);
            this.lPrecio.Name = "lPrecio";
            this.lPrecio.Size = new System.Drawing.Size(37, 13);
            this.lPrecio.TabIndex = 27;
            this.lPrecio.Text = "Precio";
            // 
            // lProvincia
            // 
            this.lProvincia.AutoSize = true;
            this.lProvincia.Location = new System.Drawing.Point(302, 54);
            this.lProvincia.Name = "lProvincia";
            this.lProvincia.Size = new System.Drawing.Size(51, 13);
            this.lProvincia.TabIndex = 26;
            this.lProvincia.Text = "Provincia";
            // 
            // lDescuento
            // 
            this.lDescuento.AutoSize = true;
            this.lDescuento.Location = new System.Drawing.Point(111, 144);
            this.lDescuento.Name = "lDescuento";
            this.lDescuento.Size = new System.Drawing.Size(59, 13);
            this.lDescuento.TabIndex = 25;
            this.lDescuento.Text = "Descuento";
            // 
            // lCategoria
            // 
            this.lCategoria.AutoSize = true;
            this.lCategoria.Location = new System.Drawing.Point(111, 98);
            this.lCategoria.Name = "lCategoria";
            this.lCategoria.Size = new System.Drawing.Size(52, 13);
            this.lCategoria.TabIndex = 24;
            this.lCategoria.Text = "Categoria";
            // 
            // lNombreProducto
            // 
            this.lNombreProducto.AutoSize = true;
            this.lNombreProducto.Location = new System.Drawing.Point(111, 59);
            this.lNombreProducto.Name = "lNombreProducto";
            this.lNombreProducto.Size = new System.Drawing.Size(44, 13);
            this.lNombreProducto.TabIndex = 23;
            this.lNombreProducto.Text = "Nombre";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(579, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // lProductos
            // 
            this.lProductos.AutoSize = true;
            this.lProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProductos.Location = new System.Drawing.Point(609, 175);
            this.lProductos.Name = "lProductos";
            this.lProductos.Size = new System.Drawing.Size(90, 20);
            this.lProductos.TabIndex = 21;
            this.lProductos.Text = "Productos";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreProducto,
            this.Categoria,
            this.Descuento,
            this.ProvinciaProducto,
            this.PrecioProducto,
            this.EstadoProducto,
            this.Stock,
            this.id_descripcion,
            this.Editar,
            this.Eliminar});
            this.dgvProductos.GridColor = System.Drawing.Color.LightBlue;
            this.dgvProductos.Location = new System.Drawing.Point(69, 267);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.Size = new System.Drawing.Size(672, 129);
            this.dgvProductos.TabIndex = 20;
            // 
            // NombreProducto
            // 
            this.NombreProducto.HeaderText = "Nombre";
            this.NombreProducto.MinimumWidth = 6;
            this.NombreProducto.Name = "NombreProducto";
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            // 
            // Descuento
            // 
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.MinimumWidth = 6;
            this.Descuento.Name = "Descuento";
            // 
            // ProvinciaProducto
            // 
            this.ProvinciaProducto.HeaderText = "Provincia";
            this.ProvinciaProducto.MinimumWidth = 6;
            this.ProvinciaProducto.Name = "ProvinciaProducto";
            // 
            // PrecioProducto
            // 
            this.PrecioProducto.HeaderText = "Precio";
            this.PrecioProducto.MinimumWidth = 6;
            this.PrecioProducto.Name = "PrecioProducto";
            // 
            // EstadoProducto
            // 
            this.EstadoProducto.HeaderText = "Estado";
            this.EstadoProducto.MinimumWidth = 6;
            this.EstadoProducto.Name = "EstadoProducto";
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 6;
            this.Stock.Name = "Stock";
            // 
            // id_descripcion
            // 
            this.id_descripcion.HeaderText = "Descripcion";
            this.id_descripcion.MinimumWidth = 6;
            this.id_descripcion.Name = "id_descripcion";
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.MinimumWidth = 6;
            this.Editar.Name = "Editar";
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.MinimumWidth = 6;
            this.Eliminar.Name = "Eliminar";
            // 
            // FormProductosVistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bBuscar);
            this.Controls.Add(this.textEstadoP);
            this.Controls.Add(this.textPrecioP);
            this.Controls.Add(this.textProvinciaP);
            this.Controls.Add(this.textDescuentoP);
            this.Controls.Add(this.textCategoriaP);
            this.Controls.Add(this.textNombreP);
            this.Controls.Add(this.lEstado);
            this.Controls.Add(this.lPrecio);
            this.Controls.Add(this.lProvincia);
            this.Controls.Add(this.lDescuento);
            this.Controls.Add(this.lCategoria);
            this.Controls.Add(this.lNombreProducto);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lProductos);
            this.Controls.Add(this.dgvProductos);
            this.Name = "FormProductosVistas";
            this.Text = "ProductosVistas";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bBuscar;
        private System.Windows.Forms.TextBox textEstadoP;
        private System.Windows.Forms.TextBox textPrecioP;
        private System.Windows.Forms.TextBox textProvinciaP;
        private System.Windows.Forms.TextBox textDescuentoP;
        private System.Windows.Forms.TextBox textCategoriaP;
        private System.Windows.Forms.TextBox textNombreP;
        private System.Windows.Forms.Label lEstado;
        private System.Windows.Forms.Label lPrecio;
        private System.Windows.Forms.Label lProvincia;
        private System.Windows.Forms.Label lDescuento;
        private System.Windows.Forms.Label lCategoria;
        private System.Windows.Forms.Label lNombreProducto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lProductos;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProvinciaProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_descripcion;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
    }
}