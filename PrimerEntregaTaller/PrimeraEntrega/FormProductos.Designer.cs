namespace gerente
{
    partial class FormProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProductos));
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
            this.lProductos = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lNombreProducto = new System.Windows.Forms.Label();
            this.lCategoria = new System.Windows.Forms.Label();
            this.lDescuento = new System.Windows.Forms.Label();
            this.lProvincia = new System.Windows.Forms.Label();
            this.lPrecio = new System.Windows.Forms.Label();
            this.lEstado = new System.Windows.Forms.Label();
            this.bAgregar = new System.Windows.Forms.Button();
            this.bEliminar = new System.Windows.Forms.Button();
            this.textNombreP = new System.Windows.Forms.TextBox();
            this.textCategoriaP = new System.Windows.Forms.TextBox();
            this.textDescuentoP = new System.Windows.Forms.TextBox();
            this.textProvinciaP = new System.Windows.Forms.TextBox();
            this.textPrecioP = new System.Windows.Forms.TextBox();
            this.textEstadoP = new System.Windows.Forms.TextBox();
            this.bModificar = new System.Windows.Forms.Button();
            this.bBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.dgvProductos.Location = new System.Drawing.Point(77, 309);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.Size = new System.Drawing.Size(896, 159);
            this.dgvProductos.TabIndex = 0;
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
            // lProductos
            // 
            this.lProductos.AutoSize = true;
            this.lProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProductos.Location = new System.Drawing.Point(865, 192);
            this.lProductos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lProductos.Name = "lProductos";
            this.lProductos.Size = new System.Drawing.Size(109, 25);
            this.lProductos.TabIndex = 1;
            this.lProductos.Text = "Productos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(833, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 174);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lNombreProducto
            // 
            this.lNombreProducto.AutoSize = true;
            this.lNombreProducto.Location = new System.Drawing.Point(51, 78);
            this.lNombreProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lNombreProducto.Name = "lNombreProducto";
            this.lNombreProducto.Size = new System.Drawing.Size(56, 16);
            this.lNombreProducto.TabIndex = 3;
            this.lNombreProducto.Text = "Nombre";
            // 
            // lCategoria
            // 
            this.lCategoria.AutoSize = true;
            this.lCategoria.Location = new System.Drawing.Point(51, 126);
            this.lCategoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lCategoria.Name = "lCategoria";
            this.lCategoria.Size = new System.Drawing.Size(66, 16);
            this.lCategoria.TabIndex = 4;
            this.lCategoria.Text = "Categoria";
            // 
            // lDescuento
            // 
            this.lDescuento.AutoSize = true;
            this.lDescuento.Location = new System.Drawing.Point(51, 182);
            this.lDescuento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lDescuento.Name = "lDescuento";
            this.lDescuento.Size = new System.Drawing.Size(72, 16);
            this.lDescuento.TabIndex = 5;
            this.lDescuento.Text = "Descuento";
            // 
            // lProvincia
            // 
            this.lProvincia.AutoSize = true;
            this.lProvincia.Location = new System.Drawing.Point(305, 71);
            this.lProvincia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lProvincia.Name = "lProvincia";
            this.lProvincia.Size = new System.Drawing.Size(63, 16);
            this.lProvincia.TabIndex = 6;
            this.lProvincia.Text = "Provincia";
            // 
            // lPrecio
            // 
            this.lPrecio.AutoSize = true;
            this.lPrecio.Location = new System.Drawing.Point(305, 124);
            this.lPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPrecio.Name = "lPrecio";
            this.lPrecio.Size = new System.Drawing.Size(46, 16);
            this.lPrecio.TabIndex = 7;
            this.lPrecio.Text = "Precio";
            // 
            // lEstado
            // 
            this.lEstado.AutoSize = true;
            this.lEstado.Location = new System.Drawing.Point(305, 182);
            this.lEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lEstado.Name = "lEstado";
            this.lEstado.Size = new System.Drawing.Size(50, 16);
            this.lEstado.TabIndex = 8;
            this.lEstado.Text = "Estado";
            // 
            // bAgregar
            // 
            this.bAgregar.BackColor = System.Drawing.Color.LightGreen;
            this.bAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAgregar.Location = new System.Drawing.Point(581, 55);
            this.bAgregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bAgregar.Name = "bAgregar";
            this.bAgregar.Size = new System.Drawing.Size(101, 30);
            this.bAgregar.TabIndex = 10;
            this.bAgregar.Text = "Agregar";
            this.bAgregar.UseVisualStyleBackColor = false;
            // 
            // bEliminar
            // 
            this.bEliminar.BackColor = System.Drawing.Color.Red;
            this.bEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEliminar.Location = new System.Drawing.Point(583, 170);
            this.bEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(100, 28);
            this.bEliminar.TabIndex = 11;
            this.bEliminar.Text = "Eliminar";
            this.bEliminar.UseVisualStyleBackColor = false;
            // 
            // textNombreP
            // 
            this.textNombreP.Location = new System.Drawing.Point(140, 69);
            this.textNombreP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textNombreP.Name = "textNombreP";
            this.textNombreP.Size = new System.Drawing.Size(132, 22);
            this.textNombreP.TabIndex = 12;
            // 
            // textCategoriaP
            // 
            this.textCategoriaP.Location = new System.Drawing.Point(140, 117);
            this.textCategoriaP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textCategoriaP.Name = "textCategoriaP";
            this.textCategoriaP.Size = new System.Drawing.Size(132, 22);
            this.textCategoriaP.TabIndex = 13;
            // 
            // textDescuentoP
            // 
            this.textDescuentoP.Location = new System.Drawing.Point(140, 174);
            this.textDescuentoP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textDescuentoP.Name = "textDescuentoP";
            this.textDescuentoP.Size = new System.Drawing.Size(132, 22);
            this.textDescuentoP.TabIndex = 14;
            // 
            // textProvinciaP
            // 
            this.textProvinciaP.Location = new System.Drawing.Point(381, 60);
            this.textProvinciaP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textProvinciaP.Name = "textProvinciaP";
            this.textProvinciaP.Size = new System.Drawing.Size(132, 22);
            this.textProvinciaP.TabIndex = 15;
            // 
            // textPrecioP
            // 
            this.textPrecioP.Location = new System.Drawing.Point(381, 116);
            this.textPrecioP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textPrecioP.Name = "textPrecioP";
            this.textPrecioP.Size = new System.Drawing.Size(132, 22);
            this.textPrecioP.TabIndex = 16;
            // 
            // textEstadoP
            // 
            this.textEstadoP.Location = new System.Drawing.Point(381, 174);
            this.textEstadoP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textEstadoP.Name = "textEstadoP";
            this.textEstadoP.Size = new System.Drawing.Size(132, 22);
            this.textEstadoP.TabIndex = 17;
            // 
            // bModificar
            // 
            this.bModificar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.bModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bModificar.Location = new System.Drawing.Point(583, 112);
            this.bModificar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bModificar.Name = "bModificar";
            this.bModificar.Size = new System.Drawing.Size(100, 30);
            this.bModificar.TabIndex = 18;
            this.bModificar.Text = "Modificar";
            this.bModificar.UseVisualStyleBackColor = false;
            // 
            // bBuscar
            // 
            this.bBuscar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bBuscar.Location = new System.Drawing.Point(243, 239);
            this.bBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(112, 37);
            this.bBuscar.TabIndex = 19;
            this.bBuscar.Text = "Buscar";
            this.bBuscar.UseVisualStyleBackColor = false;
            // 
            // FormProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1081, 482);
            this.Controls.Add(this.bBuscar);
            this.Controls.Add(this.bModificar);
            this.Controls.Add(this.textEstadoP);
            this.Controls.Add(this.textPrecioP);
            this.Controls.Add(this.textProvinciaP);
            this.Controls.Add(this.textDescuentoP);
            this.Controls.Add(this.textCategoriaP);
            this.Controls.Add(this.textNombreP);
            this.Controls.Add(this.bEliminar);
            this.Controls.Add(this.bAgregar);
            this.Controls.Add(this.lEstado);
            this.Controls.Add(this.lPrecio);
            this.Controls.Add(this.lProvincia);
            this.Controls.Add(this.lDescuento);
            this.Controls.Add(this.lCategoria);
            this.Controls.Add(this.lNombreProducto);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lProductos);
            this.Controls.Add(this.dgvProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormProductos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.FormProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Label lProductos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lNombreProducto;
        private System.Windows.Forms.Label lCategoria;
        private System.Windows.Forms.Label lDescuento;
        private System.Windows.Forms.Label lProvincia;
        private System.Windows.Forms.Label lPrecio;
        private System.Windows.Forms.Label lEstado;
        private System.Windows.Forms.Button bAgregar;
        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.TextBox textNombreP;
        private System.Windows.Forms.TextBox textCategoriaP;
        private System.Windows.Forms.TextBox textDescuentoP;
        private System.Windows.Forms.TextBox textProvinciaP;
        private System.Windows.Forms.TextBox textPrecioP;
        private System.Windows.Forms.TextBox textEstadoP;
        private System.Windows.Forms.Button bModificar;
        private System.Windows.Forms.Button bBuscar;
    }
}