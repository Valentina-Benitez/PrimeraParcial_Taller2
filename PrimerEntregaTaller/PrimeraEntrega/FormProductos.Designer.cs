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
            this.lProductos = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lNombreProducto = new System.Windows.Forms.Label();
            this.lCategoria = new System.Windows.Forms.Label();
            this.lDescuento = new System.Windows.Forms.Label();
            this.lPrecio = new System.Windows.Forms.Label();
            this.lEstado = new System.Windows.Forms.Label();
            this.bAgregar = new System.Windows.Forms.Button();
            this.bEliminar = new System.Windows.Forms.Button();
            this.textNombreP = new System.Windows.Forms.TextBox();
            this.textCategoriaP = new System.Windows.Forms.TextBox();
            this.textDescuentoP = new System.Windows.Forms.TextBox();
            this.textPrecioP = new System.Windows.Forms.TextBox();
            this.bModificar = new System.Windows.Forms.Button();
            this.bBuscar = new System.Windows.Forms.Button();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.bCancelar = new System.Windows.Forms.Button();
            this.cbEstadoP = new System.Windows.Forms.ComboBox();
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
            this.PrecioProducto,
            this.EstadoProducto,
            this.id_descripcion});
            this.dgvProductos.GridColor = System.Drawing.Color.LightBlue;
            this.dgvProductos.Location = new System.Drawing.Point(58, 251);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.Size = new System.Drawing.Size(672, 129);
            this.dgvProductos.TabIndex = 0;
            // 
            // lProductos
            // 
            this.lProductos.AutoSize = true;
            this.lProductos.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProductos.Location = new System.Drawing.Point(649, 156);
            this.lProductos.Name = "lProductos";
            this.lProductos.Size = new System.Drawing.Size(87, 19);
            this.lProductos.TabIndex = 1;
            this.lProductos.Text = "Productos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(625, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lNombreProducto
            // 
            this.lNombreProducto.AutoSize = true;
            this.lNombreProducto.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNombreProducto.Location = new System.Drawing.Point(38, 63);
            this.lNombreProducto.Name = "lNombreProducto";
            this.lNombreProducto.Size = new System.Drawing.Size(50, 14);
            this.lNombreProducto.TabIndex = 3;
            this.lNombreProducto.Text = "Nombre";
            // 
            // lCategoria
            // 
            this.lCategoria.AutoSize = true;
            this.lCategoria.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCategoria.Location = new System.Drawing.Point(38, 102);
            this.lCategoria.Name = "lCategoria";
            this.lCategoria.Size = new System.Drawing.Size(57, 14);
            this.lCategoria.TabIndex = 4;
            this.lCategoria.Text = "Categoria";
            // 
            // lDescuento
            // 
            this.lDescuento.AutoSize = true;
            this.lDescuento.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDescuento.Location = new System.Drawing.Point(38, 148);
            this.lDescuento.Name = "lDescuento";
            this.lDescuento.Size = new System.Drawing.Size(63, 14);
            this.lDescuento.TabIndex = 5;
            this.lDescuento.Text = "Descuento";
            // 
            // lPrecio
            // 
            this.lPrecio.AutoSize = true;
            this.lPrecio.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPrecio.Location = new System.Drawing.Point(229, 63);
            this.lPrecio.Name = "lPrecio";
            this.lPrecio.Size = new System.Drawing.Size(40, 14);
            this.lPrecio.TabIndex = 7;
            this.lPrecio.Text = "Precio";
            // 
            // lEstado
            // 
            this.lEstado.AutoSize = true;
            this.lEstado.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEstado.Location = new System.Drawing.Point(229, 102);
            this.lEstado.Name = "lEstado";
            this.lEstado.Size = new System.Drawing.Size(42, 14);
            this.lEstado.TabIndex = 8;
            this.lEstado.Text = "Estado";
            // 
            // bAgregar
            // 
            this.bAgregar.BackColor = System.Drawing.Color.LightGreen;
            this.bAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAgregar.Font = new System.Drawing.Font("Constantia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAgregar.Location = new System.Drawing.Point(436, 45);
            this.bAgregar.Name = "bAgregar";
            this.bAgregar.Size = new System.Drawing.Size(76, 24);
            this.bAgregar.TabIndex = 10;
            this.bAgregar.Text = "Agregar";
            this.bAgregar.UseVisualStyleBackColor = false;
            // 
            // bEliminar
            // 
            this.bEliminar.BackColor = System.Drawing.Color.Red;
            this.bEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEliminar.Font = new System.Drawing.Font("Constantia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEliminar.Location = new System.Drawing.Point(437, 138);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(75, 23);
            this.bEliminar.TabIndex = 11;
            this.bEliminar.Text = "Eliminar";
            this.bEliminar.UseVisualStyleBackColor = false;
            // 
            // textNombreP
            // 
            this.textNombreP.Location = new System.Drawing.Point(105, 56);
            this.textNombreP.Name = "textNombreP";
            this.textNombreP.Size = new System.Drawing.Size(100, 20);
            this.textNombreP.TabIndex = 12;
            // 
            // textCategoriaP
            // 
            this.textCategoriaP.Location = new System.Drawing.Point(105, 95);
            this.textCategoriaP.Name = "textCategoriaP";
            this.textCategoriaP.Size = new System.Drawing.Size(100, 20);
            this.textCategoriaP.TabIndex = 13;
            // 
            // textDescuentoP
            // 
            this.textDescuentoP.Location = new System.Drawing.Point(105, 141);
            this.textDescuentoP.Name = "textDescuentoP";
            this.textDescuentoP.Size = new System.Drawing.Size(100, 20);
            this.textDescuentoP.TabIndex = 14;
            // 
            // textPrecioP
            // 
            this.textPrecioP.Location = new System.Drawing.Point(304, 60);
            this.textPrecioP.Name = "textPrecioP";
            this.textPrecioP.Size = new System.Drawing.Size(100, 20);
            this.textPrecioP.TabIndex = 16;
            // 
            // bModificar
            // 
            this.bModificar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.bModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bModificar.Font = new System.Drawing.Font("Constantia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bModificar.Location = new System.Drawing.Point(437, 91);
            this.bModificar.Name = "bModificar";
            this.bModificar.Size = new System.Drawing.Size(75, 24);
            this.bModificar.TabIndex = 18;
            this.bModificar.Text = "Modificar";
            this.bModificar.UseVisualStyleBackColor = false;
            // 
            // bBuscar
            // 
            this.bBuscar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bBuscar.Font = new System.Drawing.Font("Constantia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBuscar.Location = new System.Drawing.Point(121, 199);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(84, 30);
            this.bBuscar.TabIndex = 19;
            this.bBuscar.Text = "Buscar";
            this.bBuscar.UseVisualStyleBackColor = false;
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
            // id_descripcion
            // 
            this.id_descripcion.HeaderText = "Descripcion";
            this.id_descripcion.MinimumWidth = 6;
            this.id_descripcion.Name = "id_descripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "Descripcion";
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(304, 145);
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(100, 20);
            this.textDescripcion.TabIndex = 21;
            // 
            // bCancelar
            // 
            this.bCancelar.BackColor = System.Drawing.Color.DarkSalmon;
            this.bCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bCancelar.Font = new System.Drawing.Font("Constantia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancelar.Location = new System.Drawing.Point(281, 199);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(84, 30);
            this.bCancelar.TabIndex = 22;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = false;
            // 
            // cbEstadoP
            // 
            this.cbEstadoP.FormattingEnabled = true;
            this.cbEstadoP.Location = new System.Drawing.Point(304, 102);
            this.cbEstadoP.Name = "cbEstadoP";
            this.cbEstadoP.Size = new System.Drawing.Size(100, 21);
            this.cbEstadoP.TabIndex = 23;
            // 
            // FormProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(811, 392);
            this.Controls.Add(this.cbEstadoP);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.textDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bBuscar);
            this.Controls.Add(this.bModificar);
            this.Controls.Add(this.textPrecioP);
            this.Controls.Add(this.textDescuentoP);
            this.Controls.Add(this.textCategoriaP);
            this.Controls.Add(this.textNombreP);
            this.Controls.Add(this.bEliminar);
            this.Controls.Add(this.bAgregar);
            this.Controls.Add(this.lEstado);
            this.Controls.Add(this.lPrecio);
            this.Controls.Add(this.lDescuento);
            this.Controls.Add(this.lCategoria);
            this.Controls.Add(this.lNombreProducto);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lProductos);
            this.Controls.Add(this.dgvProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormProductos";
            this.Text = "Productos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lProductos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lNombreProducto;
        private System.Windows.Forms.Label lCategoria;
        private System.Windows.Forms.Label lDescuento;
        private System.Windows.Forms.Label lPrecio;
        private System.Windows.Forms.Label lEstado;
        private System.Windows.Forms.Button bAgregar;
        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.TextBox textNombreP;
        private System.Windows.Forms.TextBox textCategoriaP;
        private System.Windows.Forms.TextBox textDescuentoP;
        private System.Windows.Forms.TextBox textPrecioP;
        private System.Windows.Forms.Button bModificar;
        private System.Windows.Forms.Button bBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_descripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.ComboBox cbEstadoP;
    }
}