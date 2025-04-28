namespace CPresentacion
{
    partial class CU_003____cliente____Armado_interfaz__Cliente
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
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            C1 = new DataGridViewTextBoxColumn();
            C2 = new DataGridViewTextBoxColumn();
            C3 = new DataGridViewTextBoxColumn();
            C4 = new DataGridViewTextBoxColumn();
            C5 = new DataGridViewTextBoxColumn();
            C6 = new DataGridViewTextBoxColumn();
            C7 = new DataGridViewTextBoxColumn();
            C8 = new DataGridViewTextBoxColumn();
            textBox2_Filtro_Busqueda = new TextBox();
            textBox1_Busqueda_Cliente = new TextBox();
            button1_Buscar_Cliente = new Button();
            panel3 = new Panel();
            label_DNI = new Label();
            label_ApellidoyNombre = new Label();
            label_Estado = new Label();
            label_Email = new Label();
            label_CodigoPostal = new Label();
            label_Ciudad = new Label();
            label_Direccion = new Label();
            label_CodigoCliente = new Label();
            label3_Estado_Cliente = new Label();
            label3_Email_Cliente = new Label();
            label3_CP_Cliente = new Label();
            label3_Ciudad_Cliente = new Label();
            label3_Direccion_Cliente = new Label();
            label3_DNI_Cliente = new Label();
            label3_Apell = new Label();
            label3_Cod_Cliente = new Label();
            BTN_Eliminar = new Button();
            BTN_Modificar = new Button();
            BTN_Agregar = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InfoText;
            panel1.Location = new Point(2, 86);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(995, 2);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(909, 34);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 2;
            label1.Text = "KeProyecto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(49, 34);
            label2.Name = "label2";
            label2.Size = new Size(124, 15);
            label2.TabIndex = 3;
            label2.Text = "NUESTROS CLIENTES";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(textBox2_Filtro_Busqueda);
            panel2.Controls.Add(textBox1_Busqueda_Cliente);
            panel2.Controls.Add(button1_Buscar_Cliente);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(2, 88);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(995, 451);
            panel2.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { C1, C2, C3, C4, C5, C6, C7, C8 });
            dataGridView1.Location = new Point(16, 255);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(962, 181);
            dataGridView1.TabIndex = 14;
            // 
            // C1
            // 
            C1.HeaderText = "Código Cliente";
            C1.Name = "C1";
            // 
            // C2
            // 
            C2.HeaderText = "Apellido Y Nombre";
            C2.Name = "C2";
            // 
            // C3
            // 
            C3.HeaderText = "DNI";
            C3.Name = "C3";
            // 
            // C4
            // 
            C4.HeaderText = "Dirección ";
            C4.Name = "C4";
            // 
            // C5
            // 
            C5.HeaderText = "Ciudad";
            C5.Name = "C5";
            // 
            // C6
            // 
            C6.HeaderText = "Código Postal";
            C6.Name = "C6";
            // 
            // C7
            // 
            C7.HeaderText = "E-mail";
            C7.Name = "C7";
            // 
            // C8
            // 
            C8.HeaderText = "Estado";
            C8.Name = "C8";
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
            textBox1_Busqueda_Cliente.Text = "Buscar cliente...";
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
            panel3.Controls.Add(label_DNI);
            panel3.Controls.Add(label_ApellidoyNombre);
            panel3.Controls.Add(label_Estado);
            panel3.Controls.Add(label_Email);
            panel3.Controls.Add(label_CodigoPostal);
            panel3.Controls.Add(label_Ciudad);
            panel3.Controls.Add(label_Direccion);
            panel3.Controls.Add(label_CodigoCliente);
            panel3.Controls.Add(label3_Estado_Cliente);
            panel3.Controls.Add(label3_Email_Cliente);
            panel3.Controls.Add(label3_CP_Cliente);
            panel3.Controls.Add(label3_Ciudad_Cliente);
            panel3.Controls.Add(label3_Direccion_Cliente);
            panel3.Controls.Add(label3_DNI_Cliente);
            panel3.Controls.Add(label3_Apell);
            panel3.Controls.Add(label3_Cod_Cliente);
            panel3.Controls.Add(BTN_Eliminar);
            panel3.Controls.Add(BTN_Modificar);
            panel3.Controls.Add(BTN_Agregar);
            panel3.Location = new Point(16, 11);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(965, 199);
            panel3.TabIndex = 0;
            // 
            // label_DNI
            // 
            label_DNI.AutoSize = true;
            label_DNI.Location = new Point(149, 57);
            label_DNI.Margin = new Padding(2, 0, 2, 0);
            label_DNI.Name = "label_DNI";
            label_DNI.Size = new Size(16, 15);
            label_DNI.TabIndex = 21;
            label_DNI.Text = "...";
            // 
            // label_ApellidoyNombre
            // 
            label_ApellidoyNombre.AutoSize = true;
            label_ApellidoyNombre.Location = new Point(149, 34);
            label_ApellidoyNombre.Margin = new Padding(2, 0, 2, 0);
            label_ApellidoyNombre.Name = "label_ApellidoyNombre";
            label_ApellidoyNombre.Size = new Size(16, 15);
            label_ApellidoyNombre.TabIndex = 20;
            label_ApellidoyNombre.Text = "...";
            // 
            // label_Estado
            // 
            label_Estado.AutoSize = true;
            label_Estado.Location = new Point(149, 169);
            label_Estado.Margin = new Padding(2, 0, 2, 0);
            label_Estado.Name = "label_Estado";
            label_Estado.Size = new Size(16, 15);
            label_Estado.TabIndex = 19;
            label_Estado.Text = "...";
            // 
            // label_Email
            // 
            label_Email.AutoSize = true;
            label_Email.Location = new Point(149, 146);
            label_Email.Margin = new Padding(2, 0, 2, 0);
            label_Email.Name = "label_Email";
            label_Email.Size = new Size(16, 15);
            label_Email.TabIndex = 18;
            label_Email.Text = "...";
            // 
            // label_CodigoPostal
            // 
            label_CodigoPostal.AutoSize = true;
            label_CodigoPostal.Location = new Point(149, 123);
            label_CodigoPostal.Margin = new Padding(2, 0, 2, 0);
            label_CodigoPostal.Name = "label_CodigoPostal";
            label_CodigoPostal.Size = new Size(16, 15);
            label_CodigoPostal.TabIndex = 17;
            label_CodigoPostal.Text = "...";
            // 
            // label_Ciudad
            // 
            label_Ciudad.AutoSize = true;
            label_Ciudad.Location = new Point(149, 101);
            label_Ciudad.Margin = new Padding(2, 0, 2, 0);
            label_Ciudad.Name = "label_Ciudad";
            label_Ciudad.Size = new Size(16, 15);
            label_Ciudad.TabIndex = 16;
            label_Ciudad.Text = "...";
            // 
            // label_Direccion
            // 
            label_Direccion.AutoSize = true;
            label_Direccion.Location = new Point(149, 79);
            label_Direccion.Margin = new Padding(2, 0, 2, 0);
            label_Direccion.Name = "label_Direccion";
            label_Direccion.Size = new Size(16, 15);
            label_Direccion.TabIndex = 15;
            label_Direccion.Text = "...";
            // 
            // label_CodigoCliente
            // 
            label_CodigoCliente.AutoSize = true;
            label_CodigoCliente.Location = new Point(149, 13);
            label_CodigoCliente.Margin = new Padding(2, 0, 2, 0);
            label_CodigoCliente.Name = "label_CodigoCliente";
            label_CodigoCliente.Size = new Size(16, 15);
            label_CodigoCliente.TabIndex = 14;
            label_CodigoCliente.Text = "...";
            // 
            // label3_Estado_Cliente
            // 
            label3_Estado_Cliente.AutoSize = true;
            label3_Estado_Cliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3_Estado_Cliente.Location = new Point(10, 169);
            label3_Estado_Cliente.Name = "label3_Estado_Cliente";
            label3_Estado_Cliente.Size = new Size(46, 15);
            label3_Estado_Cliente.TabIndex = 10;
            label3_Estado_Cliente.Text = "Estado:";
            // 
            // label3_Email_Cliente
            // 
            label3_Email_Cliente.AutoSize = true;
            label3_Email_Cliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3_Email_Cliente.Location = new Point(10, 146);
            label3_Email_Cliente.Name = "label3_Email_Cliente";
            label3_Email_Cliente.Size = new Size(44, 15);
            label3_Email_Cliente.TabIndex = 9;
            label3_Email_Cliente.Text = "E-mail:";
            // 
            // label3_CP_Cliente
            // 
            label3_CP_Cliente.AutoSize = true;
            label3_CP_Cliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3_CP_Cliente.Location = new Point(10, 123);
            label3_CP_Cliente.Name = "label3_CP_Cliente";
            label3_CP_Cliente.Size = new Size(84, 15);
            label3_CP_Cliente.TabIndex = 8;
            label3_CP_Cliente.Text = "Código Postal:";
            // 
            // label3_Ciudad_Cliente
            // 
            label3_Ciudad_Cliente.AutoSize = true;
            label3_Ciudad_Cliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3_Ciudad_Cliente.Location = new Point(10, 101);
            label3_Ciudad_Cliente.Name = "label3_Ciudad_Cliente";
            label3_Ciudad_Cliente.Size = new Size(47, 15);
            label3_Ciudad_Cliente.TabIndex = 7;
            label3_Ciudad_Cliente.Text = "Ciudad:";
            // 
            // label3_Direccion_Cliente
            // 
            label3_Direccion_Cliente.AutoSize = true;
            label3_Direccion_Cliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3_Direccion_Cliente.Location = new Point(10, 79);
            label3_Direccion_Cliente.Name = "label3_Direccion_Cliente";
            label3_Direccion_Cliente.Size = new Size(63, 15);
            label3_Direccion_Cliente.TabIndex = 6;
            label3_Direccion_Cliente.Text = "Dirección:";
            // 
            // label3_DNI_Cliente
            // 
            label3_DNI_Cliente.AutoSize = true;
            label3_DNI_Cliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3_DNI_Cliente.Location = new Point(10, 57);
            label3_DNI_Cliente.Name = "label3_DNI_Cliente";
            label3_DNI_Cliente.Size = new Size(32, 15);
            label3_DNI_Cliente.TabIndex = 5;
            label3_DNI_Cliente.Text = "DNI:";
            label3_DNI_Cliente.Click += label3_Click;
            // 
            // label3_Apell
            // 
            label3_Apell.AutoSize = true;
            label3_Apell.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3_Apell.Location = new Point(10, 34);
            label3_Apell.Name = "label3_Apell";
            label3_Apell.Size = new Size(111, 15);
            label3_Apell.TabIndex = 4;
            label3_Apell.Text = "Apellido y nombre:";
            // 
            // label3_Cod_Cliente
            // 
            label3_Cod_Cliente.AutoSize = true;
            label3_Cod_Cliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3_Cod_Cliente.Location = new Point(10, 13);
            label3_Cod_Cliente.Name = "label3_Cod_Cliente";
            label3_Cod_Cliente.Size = new Size(89, 15);
            label3_Cod_Cliente.TabIndex = 3;
            label3_Cod_Cliente.Text = "Código cliente:";
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
            BTN_Eliminar.Click += button2_Click;
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
            // CU_003____cliente____Armado_interfaz__Cliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(1002, 541);
            Controls.Add(panel2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CU_003____cliente____Armado_interfaz__Cliente";
            Text = "CU_003____cliente____Armado_interfaz__Cliente";
            Load += CU_003____cliente____Armado_interfaz__Cliente_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Panel panel2;
        private Panel panel3;
        private Button BTN_Eliminar;
        private Button BTN_Modificar;
        private Button BTN_Agregar;
        private Label label3_Cod_Cliente;
        private Label label3_Apell;
        private Label label3_DNI_Cliente;
        private Label label3_Email_Cliente;
        private Label label3_CP_Cliente;
        private Label label3_Ciudad_Cliente;
        private Label label3_Direccion_Cliente;
        private Button button1_Buscar_Cliente;
        private Label label3_Estado_Cliente;
        private TextBox textBox2_Filtro_Busqueda;
        private TextBox textBox1_Busqueda_Cliente;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn C1;
        private DataGridViewTextBoxColumn C2;
        private DataGridViewTextBoxColumn C3;
        private DataGridViewTextBoxColumn C4;
        private DataGridViewTextBoxColumn C5;
        private DataGridViewTextBoxColumn C6;
        private DataGridViewTextBoxColumn C7;
        private DataGridViewTextBoxColumn C8;
        private Label label_CodigoCliente;
        private Label label_DNI;
        private Label label_ApellidoyNombre;
        private Label label_Estado;
        private Label label_Email;
        private Label label_CodigoPostal;
        private Label label_Ciudad;
        private Label label_Direccion;
    }
}