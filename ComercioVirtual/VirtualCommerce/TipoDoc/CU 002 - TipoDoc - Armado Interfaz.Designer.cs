namespace VirtualCommerce.TipoDoc
{
    partial class CU_002___TipoDoc___Armado_Interfaz
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
            panel2 = new Panel();
            dataGridView_TipoDocumento = new DataGridView();
            textBox2_Filtro_Busqueda = new TextBox();
            textBox1_Busqueda_Cliente = new TextBox();
            btn_buscar = new Button();
            panel3 = new Panel();
            label_TipoDocumento = new Label();
            label_codigoDocumento = new Label();
            lb_Nombre = new Label();
            lb_CodDoc = new Label();
            btn_eliminar = new Button();
            btn_modificar = new Button();
            btn_Agregar = new Button();
            lb_TipoDoc = new Label();
            lb_KeProyecto = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_TipoDocumento).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dataGridView_TipoDocumento);
            panel2.Controls.Add(textBox2_Filtro_Busqueda);
            panel2.Controls.Add(textBox1_Busqueda_Cliente);
            panel2.Controls.Add(btn_buscar);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(4, 188);
            panel2.Margin = new Padding(6, 4, 6, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1848, 962);
            panel2.TabIndex = 5;
            // 
            // dataGridView_TipoDocumento
            // 
            dataGridView_TipoDocumento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_TipoDocumento.Location = new Point(30, 544);
            dataGridView_TipoDocumento.Margin = new Padding(6);
            dataGridView_TipoDocumento.Name = "dataGridView_TipoDocumento";
            dataGridView_TipoDocumento.RowHeadersWidth = 82;
            dataGridView_TipoDocumento.Size = new Size(1787, 386);
            dataGridView_TipoDocumento.TabIndex = 14;
            dataGridView_TipoDocumento.CellContentClick += dataGridView_TipoDocumento_CellContentClick;
            // 
            // textBox2_Filtro_Busqueda
            // 
            textBox2_Filtro_Busqueda.BackColor = SystemColors.ScrollBar;
            textBox2_Filtro_Busqueda.Location = new Point(787, 476);
            textBox2_Filtro_Busqueda.Margin = new Padding(6, 4, 6, 4);
            textBox2_Filtro_Busqueda.Name = "textBox2_Filtro_Busqueda";
            textBox2_Filtro_Busqueda.Size = new Size(723, 39);
            textBox2_Filtro_Busqueda.TabIndex = 13;
            textBox2_Filtro_Busqueda.Text = "Filtro de búsqueda...";
            // 
            // textBox1_Busqueda_Cliente
            // 
            textBox1_Busqueda_Cliente.BackColor = SystemColors.ScrollBar;
            textBox1_Busqueda_Cliente.Location = new Point(30, 476);
            textBox1_Busqueda_Cliente.Margin = new Padding(6, 4, 6, 4);
            textBox1_Busqueda_Cliente.Name = "textBox1_Busqueda_Cliente";
            textBox1_Busqueda_Cliente.Size = new Size(723, 39);
            textBox1_Busqueda_Cliente.TabIndex = 12;
            textBox1_Busqueda_Cliente.Text = "Buscar cliente...";
            // 
            // btn_buscar
            // 
            btn_buscar.BackColor = Color.Black;
            btn_buscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_buscar.ForeColor = Color.White;
            btn_buscar.Location = new Point(1541, 457);
            btn_buscar.Margin = new Padding(6, 4, 6, 4);
            btn_buscar.Name = "btn_buscar";
            btn_buscar.Size = new Size(275, 77);
            btn_buscar.TabIndex = 11;
            btn_buscar.Text = "Buscar";
            btn_buscar.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ScrollBar;
            panel3.Controls.Add(label_TipoDocumento);
            panel3.Controls.Add(label_codigoDocumento);
            panel3.Controls.Add(lb_Nombre);
            panel3.Controls.Add(lb_CodDoc);
            panel3.Controls.Add(btn_eliminar);
            panel3.Controls.Add(btn_modificar);
            panel3.Controls.Add(btn_Agregar);
            panel3.Location = new Point(30, 23);
            panel3.Margin = new Padding(6, 4, 6, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(1792, 425);
            panel3.TabIndex = 0;
            // 
            // label_TipoDocumento
            // 
            label_TipoDocumento.AutoSize = true;
            label_TipoDocumento.Location = new Point(277, 73);
            label_TipoDocumento.Margin = new Padding(4, 0, 4, 0);
            label_TipoDocumento.Name = "label_TipoDocumento";
            label_TipoDocumento.Size = new Size(29, 32);
            label_TipoDocumento.TabIndex = 6;
            label_TipoDocumento.Text = "...";
            // 
            // label_codigoDocumento
            // 
            label_codigoDocumento.AutoSize = true;
            label_codigoDocumento.Location = new Point(277, 28);
            label_codigoDocumento.Margin = new Padding(4, 0, 4, 0);
            label_codigoDocumento.Name = "label_codigoDocumento";
            label_codigoDocumento.Size = new Size(29, 32);
            label_codigoDocumento.TabIndex = 5;
            label_codigoDocumento.Text = "...";
            // 
            // lb_Nombre
            // 
            lb_Nombre.AutoSize = true;
            lb_Nombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lb_Nombre.Location = new Point(19, 73);
            lb_Nombre.Margin = new Padding(6, 0, 6, 0);
            lb_Nombre.Name = "lb_Nombre";
            lb_Nombre.Size = new Size(248, 32);
            lb_Nombre.TabIndex = 4;
            lb_Nombre.Text = "Tipo de Documento:";
            // 
            // lb_CodDoc
            // 
            lb_CodDoc.AutoSize = true;
            lb_CodDoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lb_CodDoc.Location = new Point(19, 28);
            lb_CodDoc.Margin = new Padding(6, 0, 6, 0);
            lb_CodDoc.Name = "lb_CodDoc";
            lb_CodDoc.Size = new Size(241, 32);
            lb_CodDoc.TabIndex = 3;
            lb_CodDoc.Text = "Código documento:";
            // 
            // btn_eliminar
            // 
            btn_eliminar.BackColor = Color.Black;
            btn_eliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_eliminar.ForeColor = Color.White;
            btn_eliminar.Location = new Point(1514, 177);
            btn_eliminar.Margin = new Padding(6, 4, 6, 4);
            btn_eliminar.Name = "btn_eliminar";
            btn_eliminar.Size = new Size(275, 77);
            btn_eliminar.TabIndex = 2;
            btn_eliminar.Text = "Eliminar";
            btn_eliminar.UseVisualStyleBackColor = false;
            // 
            // btn_modificar
            // 
            btn_modificar.BackColor = Color.Black;
            btn_modificar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_modificar.ForeColor = Color.White;
            btn_modificar.Location = new Point(1514, 92);
            btn_modificar.Margin = new Padding(6, 4, 6, 4);
            btn_modificar.Name = "btn_modificar";
            btn_modificar.Size = new Size(275, 77);
            btn_modificar.TabIndex = 1;
            btn_modificar.Text = "Modificar";
            btn_modificar.UseVisualStyleBackColor = false;
            btn_modificar.Click += BTN_Modificar_Click;
            // 
            // btn_Agregar
            // 
            btn_Agregar.BackColor = Color.Black;
            btn_Agregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_Agregar.ForeColor = Color.White;
            btn_Agregar.Location = new Point(1514, 4);
            btn_Agregar.Margin = new Padding(6, 4, 6, 4);
            btn_Agregar.Name = "btn_Agregar";
            btn_Agregar.Size = new Size(275, 77);
            btn_Agregar.TabIndex = 0;
            btn_Agregar.Text = "Agregar";
            btn_Agregar.UseVisualStyleBackColor = false;
            btn_Agregar.Click += BTN_Agregar_Click;
            // 
            // lb_TipoDoc
            // 
            lb_TipoDoc.AutoSize = true;
            lb_TipoDoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lb_TipoDoc.ForeColor = Color.Black;
            lb_TipoDoc.Location = new Point(91, 73);
            lb_TipoDoc.Margin = new Padding(6, 0, 6, 0);
            lb_TipoDoc.Name = "lb_TipoDoc";
            lb_TipoDoc.Size = new Size(243, 32);
            lb_TipoDoc.TabIndex = 7;
            lb_TipoDoc.Text = "TIPO DOCUMENTOS";
            // 
            // lb_KeProyecto
            // 
            lb_KeProyecto.AutoSize = true;
            lb_KeProyecto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lb_KeProyecto.ForeColor = Color.Black;
            lb_KeProyecto.Location = new Point(1688, 73);
            lb_KeProyecto.Margin = new Padding(6, 0, 6, 0);
            lb_KeProyecto.Name = "lb_KeProyecto";
            lb_KeProyecto.Size = new Size(145, 32);
            lb_KeProyecto.TabIndex = 6;
            lb_KeProyecto.Text = "KeProyecto";
            // 
            // CU_002___TipoDoc___Armado_Interfaz
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(1844, 1190);
            Controls.Add(lb_TipoDoc);
            Controls.Add(lb_KeProyecto);
            Controls.Add(panel2);
            ForeColor = SystemColors.ControlText;
            Margin = new Padding(6);
            Name = "CU_002___TipoDoc___Armado_Interfaz";
            Text = "CU_002___TipoDoc___Armado_Interfaz";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_TipoDocumento).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private DataGridView dataGridView_TipoDocumento;
        private TextBox textBox2_Filtro_Busqueda;
        private TextBox textBox1_Busqueda_Cliente;
        private Panel panel3;
        private Label lb_Nombre;
        private Label lb_CodDoc;
        private Button btn_eliminar;
        private Button btn_modificar;
        private Button btn_Agregar;
        private Label lb_TipoDoc;
        private Label lb_KeProyecto;
        private Button btn_buscar;
        private Label label_TipoDocumento;
        private Label label_codigoDocumento;
    }
}