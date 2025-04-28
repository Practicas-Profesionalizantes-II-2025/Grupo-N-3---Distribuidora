namespace CPresentacion
{
    partial class CU_020___Producto___Armado_interfaz
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
            label2_Producto = new Label();
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            dataGridView_InterfazProductos = new DataGridView();
            C1 = new DataGridViewTextBoxColumn();
            C2 = new DataGridViewTextBoxColumn();
            C3 = new DataGridViewTextBoxColumn();
            C4 = new DataGridViewTextBoxColumn();
            C5 = new DataGridViewTextBoxColumn();
            C6 = new DataGridViewTextBoxColumn();
            textBox2_Filtro_Busqueda = new TextBox();
            textBox1_Busqueda_Cliente = new TextBox();
            button1_Buscar_Cliente = new Button();
            panel3 = new Panel();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            label3_CP_Cliente = new Label();
            label3_Ciudad_Cliente = new Label();
            label3_Direccion_Cliente = new Label();
            label3_DNI_Cliente = new Label();
            label3_Apell = new Label();
            label3_Cod_Producto = new Label();
            BTN_Eliminar = new Button();
            BTN_Modificar = new Button();
            BTN_Agregar = new Button();
            label_codigoProducto = new Label();
            label_NombreProducto = new Label();
            label_Proveedor = new Label();
            label_Categoria = new Label();
            label_Unidades = new Label();
            label_PrecioUnitario = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_InterfazProductos).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2_Producto
            // 
            label2_Producto.AutoSize = true;
            label2_Producto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2_Producto.ForeColor = Color.Black;
            label2_Producto.Location = new Point(49, 34);
            label2_Producto.Name = "label2_Producto";
            label2_Producto.Size = new Size(144, 15);
            label2_Producto.TabIndex = 9;
            label2_Producto.Text = "NUESTROS PRODUCTOS";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(909, 34);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 8;
            label1.Text = "KeProyecto";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InfoText;
            panel1.Location = new Point(0, 86);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(995, 2);
            panel1.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dataGridView_InterfazProductos);
            panel2.Controls.Add(textBox2_Filtro_Busqueda);
            panel2.Controls.Add(textBox1_Busqueda_Cliente);
            panel2.Controls.Add(button1_Buscar_Cliente);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(0, 88);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(995, 451);
            panel2.TabIndex = 11;
            // 
            // dataGridView_InterfazProductos
            // 
            dataGridView_InterfazProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_InterfazProductos.Columns.AddRange(new DataGridViewColumn[] { C1, C2, C3, C4, C5, C6 });
            dataGridView_InterfazProductos.Location = new Point(16, 262);
            dataGridView_InterfazProductos.Margin = new Padding(2, 1, 2, 1);
            dataGridView_InterfazProductos.Name = "dataGridView_InterfazProductos";
            dataGridView_InterfazProductos.RowHeadersWidth = 82;
            dataGridView_InterfazProductos.Size = new Size(965, 180);
            dataGridView_InterfazProductos.TabIndex = 14;
            // 
            // C1
            // 
            C1.HeaderText = "Código Producto";
            C1.Name = "C1";
            // 
            // C2
            // 
            C2.HeaderText = "Nombre Producto";
            C2.Name = "C2";
            // 
            // C3
            // 
            C3.HeaderText = "Proveedor";
            C3.Name = "C3";
            // 
            // C4
            // 
            C4.HeaderText = "Categoría";
            C4.Name = "C4";
            // 
            // C5
            // 
            C5.HeaderText = "Unidades";
            C5.Name = "C5";
            // 
            // C6
            // 
            C6.HeaderText = "Precio Unitario ";
            C6.Name = "C6";
            // 
            // textBox2_Filtro_Busqueda
            // 
            textBox2_Filtro_Busqueda.BackColor = SystemColors.ScrollBar;
            textBox2_Filtro_Busqueda.Location = new Point(424, 223);
            textBox2_Filtro_Busqueda.Margin = new Padding(3, 2, 3, 2);
            textBox2_Filtro_Busqueda.Name = "textBox2_Filtro_Busqueda";
            textBox2_Filtro_Busqueda.Size = new Size(391, 23);
            textBox2_Filtro_Busqueda.TabIndex = 13;
            textBox2_Filtro_Busqueda.Text = "Filtro de búsqueda...";
            // 
            // textBox1_Busqueda_Cliente
            // 
            textBox1_Busqueda_Cliente.BackColor = SystemColors.ScrollBar;
            textBox1_Busqueda_Cliente.Location = new Point(16, 223);
            textBox1_Busqueda_Cliente.Margin = new Padding(3, 2, 3, 2);
            textBox1_Busqueda_Cliente.Name = "textBox1_Busqueda_Cliente";
            textBox1_Busqueda_Cliente.Size = new Size(391, 23);
            textBox1_Busqueda_Cliente.TabIndex = 12;
            textBox1_Busqueda_Cliente.Text = "Buscar producto...";
            // 
            // button1_Buscar_Cliente
            // 
            button1_Buscar_Cliente.BackColor = Color.Black;
            button1_Buscar_Cliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1_Buscar_Cliente.ForeColor = Color.White;
            button1_Buscar_Cliente.Location = new Point(830, 214);
            button1_Buscar_Cliente.Margin = new Padding(3, 2, 3, 2);
            button1_Buscar_Cliente.Name = "button1_Buscar_Cliente";
            button1_Buscar_Cliente.Size = new Size(148, 36);
            button1_Buscar_Cliente.TabIndex = 11;
            button1_Buscar_Cliente.Text = "Buscar";
            button1_Buscar_Cliente.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ScrollBar;
            panel3.Controls.Add(label_PrecioUnitario);
            panel3.Controls.Add(label_Unidades);
            panel3.Controls.Add(label_Categoria);
            panel3.Controls.Add(label_Proveedor);
            panel3.Controls.Add(label_NombreProducto);
            panel3.Controls.Add(label_codigoProducto);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(label3_CP_Cliente);
            panel3.Controls.Add(label3_Ciudad_Cliente);
            panel3.Controls.Add(label3_Direccion_Cliente);
            panel3.Controls.Add(label3_DNI_Cliente);
            panel3.Controls.Add(label3_Apell);
            panel3.Controls.Add(label3_Cod_Producto);
            panel3.Controls.Add(BTN_Eliminar);
            panel3.Controls.Add(BTN_Modificar);
            panel3.Controls.Add(BTN_Agregar);
            panel3.Location = new Point(16, 11);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(965, 199);
            panel3.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(686, 94);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 9;
            label3.Text = "FOTO";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(601, 2);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(208, 194);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // label3_CP_Cliente
            // 
            label3_CP_Cliente.AutoSize = true;
            label3_CP_Cliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3_CP_Cliente.Location = new Point(10, 123);
            label3_CP_Cliente.Name = "label3_CP_Cliente";
            label3_CP_Cliente.Size = new Size(91, 15);
            label3_CP_Cliente.TabIndex = 8;
            label3_CP_Cliente.Text = "Precio unitario:";
            // 
            // label3_Ciudad_Cliente
            // 
            label3_Ciudad_Cliente.AutoSize = true;
            label3_Ciudad_Cliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3_Ciudad_Cliente.Location = new Point(10, 101);
            label3_Ciudad_Cliente.Name = "label3_Ciudad_Cliente";
            label3_Ciudad_Cliente.Size = new Size(61, 15);
            label3_Ciudad_Cliente.TabIndex = 7;
            label3_Ciudad_Cliente.Text = "Unidades:";
            // 
            // label3_Direccion_Cliente
            // 
            label3_Direccion_Cliente.AutoSize = true;
            label3_Direccion_Cliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3_Direccion_Cliente.Location = new Point(10, 79);
            label3_Direccion_Cliente.Name = "label3_Direccion_Cliente";
            label3_Direccion_Cliente.Size = new Size(63, 15);
            label3_Direccion_Cliente.TabIndex = 6;
            label3_Direccion_Cliente.Text = "Categoría:";
            // 
            // label3_DNI_Cliente
            // 
            label3_DNI_Cliente.AutoSize = true;
            label3_DNI_Cliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3_DNI_Cliente.Location = new Point(10, 57);
            label3_DNI_Cliente.Name = "label3_DNI_Cliente";
            label3_DNI_Cliente.Size = new Size(69, 15);
            label3_DNI_Cliente.TabIndex = 5;
            label3_DNI_Cliente.Text = "Proveedor:";
            // 
            // label3_Apell
            // 
            label3_Apell.AutoSize = true;
            label3_Apell.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3_Apell.Location = new Point(10, 34);
            label3_Apell.Name = "label3_Apell";
            label3_Apell.Size = new Size(110, 15);
            label3_Apell.TabIndex = 4;
            label3_Apell.Text = "Nombre producto:";
            // 
            // label3_Cod_Producto
            // 
            label3_Cod_Producto.AutoSize = true;
            label3_Cod_Producto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3_Cod_Producto.Location = new Point(10, 13);
            label3_Cod_Producto.Name = "label3_Cod_Producto";
            label3_Cod_Producto.Size = new Size(102, 15);
            label3_Cod_Producto.TabIndex = 3;
            label3_Cod_Producto.Text = "Código Producto:";
            // 
            // BTN_Eliminar
            // 
            BTN_Eliminar.BackColor = Color.Black;
            BTN_Eliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BTN_Eliminar.ForeColor = Color.White;
            BTN_Eliminar.Location = new Point(815, 83);
            BTN_Eliminar.Margin = new Padding(3, 2, 3, 2);
            BTN_Eliminar.Name = "BTN_Eliminar";
            BTN_Eliminar.Size = new Size(148, 36);
            BTN_Eliminar.TabIndex = 2;
            BTN_Eliminar.Text = "Eliminar";
            BTN_Eliminar.UseVisualStyleBackColor = false;
            // 
            // BTN_Modificar
            // 
            BTN_Modificar.BackColor = Color.Black;
            BTN_Modificar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BTN_Modificar.ForeColor = Color.White;
            BTN_Modificar.Location = new Point(815, 43);
            BTN_Modificar.Margin = new Padding(3, 2, 3, 2);
            BTN_Modificar.Name = "BTN_Modificar";
            BTN_Modificar.Size = new Size(148, 36);
            BTN_Modificar.TabIndex = 1;
            BTN_Modificar.Text = "Modificar";
            BTN_Modificar.UseVisualStyleBackColor = false;
            BTN_Modificar.Click += BTN_Modificar_Click;
            // 
            // BTN_Agregar
            // 
            BTN_Agregar.BackColor = Color.Black;
            BTN_Agregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BTN_Agregar.ForeColor = Color.White;
            BTN_Agregar.Location = new Point(815, 2);
            BTN_Agregar.Margin = new Padding(3, 2, 3, 2);
            BTN_Agregar.Name = "BTN_Agregar";
            BTN_Agregar.Size = new Size(148, 36);
            BTN_Agregar.TabIndex = 0;
            BTN_Agregar.Text = "Agregar";
            BTN_Agregar.UseVisualStyleBackColor = false;
            BTN_Agregar.Click += BTN_Agregar_Click;
            // 
            // label_codigoProducto
            // 
            label_codigoProducto.AutoSize = true;
            label_codigoProducto.Location = new Point(149, 13);
            label_codigoProducto.Margin = new Padding(2, 0, 2, 0);
            label_codigoProducto.Name = "label_codigoProducto";
            label_codigoProducto.Size = new Size(16, 15);
            label_codigoProducto.TabIndex = 12;
            label_codigoProducto.Text = "...";
            // 
            // label_NombreProducto
            // 
            label_NombreProducto.AutoSize = true;
            label_NombreProducto.Location = new Point(149, 34);
            label_NombreProducto.Margin = new Padding(2, 0, 2, 0);
            label_NombreProducto.Name = "label_NombreProducto";
            label_NombreProducto.Size = new Size(16, 15);
            label_NombreProducto.TabIndex = 13;
            label_NombreProducto.Text = "...";
            // 
            // label_Proveedor
            // 
            label_Proveedor.AutoSize = true;
            label_Proveedor.Location = new Point(149, 57);
            label_Proveedor.Margin = new Padding(2, 0, 2, 0);
            label_Proveedor.Name = "label_Proveedor";
            label_Proveedor.Size = new Size(16, 15);
            label_Proveedor.TabIndex = 14;
            label_Proveedor.Text = "...";
            // 
            // label_Categoria
            // 
            label_Categoria.AutoSize = true;
            label_Categoria.Location = new Point(149, 79);
            label_Categoria.Margin = new Padding(2, 0, 2, 0);
            label_Categoria.Name = "label_Categoria";
            label_Categoria.Size = new Size(16, 15);
            label_Categoria.TabIndex = 15;
            label_Categoria.Text = "...";
            // 
            // label_Unidades
            // 
            label_Unidades.AutoSize = true;
            label_Unidades.Location = new Point(149, 101);
            label_Unidades.Margin = new Padding(2, 0, 2, 0);
            label_Unidades.Name = "label_Unidades";
            label_Unidades.Size = new Size(16, 15);
            label_Unidades.TabIndex = 16;
            label_Unidades.Text = "...";
            // 
            // label_PrecioUnitario
            // 
            label_PrecioUnitario.AutoSize = true;
            label_PrecioUnitario.Location = new Point(149, 123);
            label_PrecioUnitario.Margin = new Padding(2, 0, 2, 0);
            label_PrecioUnitario.Name = "label_PrecioUnitario";
            label_PrecioUnitario.Size = new Size(16, 15);
            label_PrecioUnitario.TabIndex = 17;
            label_PrecioUnitario.Text = "...";
            // 
            // CU_020___Producto___Armado_interfaz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(1002, 540);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label2_Producto);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CU_020___Producto___Armado_interfaz";
            Text = "CU_020___Producto___Armado_interfaz";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_InterfazProductos).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2_Producto;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private TextBox textBox2_Filtro_Busqueda;
        private TextBox textBox1_Busqueda_Cliente;
        private Button button1_Buscar_Cliente;
        private Panel panel3;
        private Label label3;
        public PictureBox pictureBox1;
        private Label label3_CP_Cliente;
        private Label label3_Ciudad_Cliente;
        private Label label3_Direccion_Cliente;
        private Label label3_DNI_Cliente;
        private Label label3_Apell;
        private Label label3_Cod_Producto;
        private Button BTN_Eliminar;
        private Button BTN_Modificar;
        private Button BTN_Agregar;
        private DataGridView dataGridView_InterfazProductos;
        private DataGridViewTextBoxColumn C1;
        private DataGridViewTextBoxColumn C2;
        private DataGridViewTextBoxColumn C3;
        private DataGridViewTextBoxColumn C4;
        private DataGridViewTextBoxColumn C5;
        private DataGridViewTextBoxColumn C6;
        private Label label_Unidades;
        private Label label_Categoria;
        private Label label_Proveedor;
        private Label label_NombreProducto;
        private Label label_codigoProducto;
        private Label label_PrecioUnitario;
    }
}