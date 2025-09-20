namespace gerente
{
    partial class Productos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Productos));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.label7 = new System.Windows.Forms.Label();
            this.bAgregar = new System.Windows.Forms.Button();
            this.bEliminar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dataGridView1.GridColor = System.Drawing.Color.LightBlue;
            this.dataGridView1.Location = new System.Drawing.Point(77, 309);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(896, 159);
            this.dataGridView1.TabIndex = 0;
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
            this.lProductos.Click += new System.EventHandler(this.lProductos_Click);
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
            this.lEstado.Location = new System.Drawing.Point(305, 169);
            this.lEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lEstado.Name = "lEstado";
            this.lEstado.Size = new System.Drawing.Size(50, 16);
            this.lEstado.TabIndex = 8;
            this.lEstado.Text = "Estado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 236);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Stock";
            // 
            // bAgregar
            // 
            this.bAgregar.BackColor = System.Drawing.Color.LightGreen;
            this.bAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAgregar.Location = new System.Drawing.Point(580, 126);
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
            this.bEliminar.Location = new System.Drawing.Point(581, 224);
            this.bEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(100, 28);
            this.bEliminar.TabIndex = 11;
            this.bEliminar.Text = "Eliminar";
            this.bEliminar.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(140, 69);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(140, 117);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 22);
            this.textBox2.TabIndex = 13;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(140, 174);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(132, 22);
            this.textBox3.TabIndex = 14;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(381, 60);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(132, 22);
            this.textBox4.TabIndex = 15;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(381, 116);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(132, 22);
            this.textBox5.TabIndex = 16;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(381, 160);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(132, 22);
            this.textBox6.TabIndex = 17;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(140, 228);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(132, 22);
            this.textBox7.TabIndex = 18;
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1081, 482);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bEliminar);
            this.Controls.Add(this.bAgregar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lEstado);
            this.Controls.Add(this.lPrecio);
            this.Controls.Add(this.lProvincia);
            this.Controls.Add(this.lDescuento);
            this.Controls.Add(this.lCategoria);
            this.Controls.Add(this.lNombreProducto);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lProductos);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Productos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bAgregar;
        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
    }
}