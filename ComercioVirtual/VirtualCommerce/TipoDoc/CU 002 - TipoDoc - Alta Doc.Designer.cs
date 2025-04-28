namespace VirtualCommerce.TipoDoc
{
    partial class CU_002___TipoDoc___Alta_Doc
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
            lb_AltaDoc = new Label();
            label1 = new Label();
            tb_Nombre = new TextBox();
            lb_Nombre = new Label();
            BTN_Conf_Alta = new Button();
            button1_Canc_Alta = new Button();
            panel2 = new Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lb_AltaDoc
            // 
            lb_AltaDoc.AutoSize = true;
            lb_AltaDoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lb_AltaDoc.ForeColor = Color.Black;
            lb_AltaDoc.Location = new Point(49, 34);
            lb_AltaDoc.Name = "lb_AltaDoc";
            lb_AltaDoc.Size = new Size(143, 15);
            lb_AltaDoc.TabIndex = 10;
            lb_AltaDoc.Text = "ALTA TIPO DOCUMENTO";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(909, 34);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 9;
            label1.Text = "KeProyecto";
            // 
            // tb_Nombre
            // 
            tb_Nombre.BackColor = SystemColors.ScrollBar;
            tb_Nombre.Location = new Point(49, 60);
            tb_Nombre.Margin = new Padding(3, 2, 3, 2);
            tb_Nombre.Name = "tb_Nombre";
            tb_Nombre.Size = new Size(391, 23);
            tb_Nombre.TabIndex = 14;
            tb_Nombre.Text = "Tipo de Documento.";
            // 
            // lb_Nombre
            // 
            lb_Nombre.AutoSize = true;
            lb_Nombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lb_Nombre.Location = new Point(49, 36);
            lb_Nombre.Name = "lb_Nombre";
            lb_Nombre.Size = new Size(122, 15);
            lb_Nombre.TabIndex = 21;
            lb_Nombre.Text = "Tipo De Documento:";
            // 
            // BTN_Conf_Alta
            // 
            BTN_Conf_Alta.BackColor = Color.Black;
            BTN_Conf_Alta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BTN_Conf_Alta.ForeColor = Color.White;
            BTN_Conf_Alta.Location = new Point(652, 356);
            BTN_Conf_Alta.Margin = new Padding(3, 2, 3, 2);
            BTN_Conf_Alta.Name = "BTN_Conf_Alta";
            BTN_Conf_Alta.Size = new Size(170, 36);
            BTN_Conf_Alta.TabIndex = 27;
            BTN_Conf_Alta.Text = "Confirmar alta";
            BTN_Conf_Alta.UseVisualStyleBackColor = false;
            BTN_Conf_Alta.Click += BTN_Conf_Alta_Click;
            // 
            // button1_Canc_Alta
            // 
            button1_Canc_Alta.BackColor = Color.Black;
            button1_Canc_Alta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1_Canc_Alta.ForeColor = Color.White;
            button1_Canc_Alta.Location = new Point(652, 396);
            button1_Canc_Alta.Margin = new Padding(3, 2, 3, 2);
            button1_Canc_Alta.Name = "button1_Canc_Alta";
            button1_Canc_Alta.Size = new Size(170, 36);
            button1_Canc_Alta.TabIndex = 28;
            button1_Canc_Alta.Text = "Cancelar alta";
            button1_Canc_Alta.UseVisualStyleBackColor = false;
            button1_Canc_Alta.Click += button1_Canc_Alta_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(button1_Canc_Alta);
            panel2.Controls.Add(BTN_Conf_Alta);
            panel2.Controls.Add(lb_Nombre);
            panel2.Controls.Add(tb_Nombre);
            panel2.Location = new Point(0, 88);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(997, 455);
            panel2.TabIndex = 8;
            // 
            // CU_002___TipoDoc___Alta_Doc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(1002, 541);
            Controls.Add(lb_AltaDoc);
            Controls.Add(label1);
            Controls.Add(panel2);
            Name = "CU_002___TipoDoc___Alta_Doc";
            Text = "CU_002___TipoDoc___Alta_Doc";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cb_Ciudad;
        private ComboBox cb_TipoDoc;
        private Label label3;
        private TextBox textBox1;
        private Button BTN_Conf_Modif;
        private Label label7_CP;
        private Label label6_Ciudad;
        private Label label5_Domicilio;
        private Label label4_Email;
        private Label label3_DNI;
        private Label label2;
        private Label label3_Apell;
        private TextBox textBox6_CP;
        private TextBox textBox4_Domicilio;
        private TextBox textBox3_Email;
        private Label lb_AltaDoc;
        private Label label1;
        private TextBox tb_Nombre;
        private Label lb_Nombre;
        private Button BTN_Conf_Alta;
        private Button button1_Canc_Alta;
        private Panel panel2;
        private TextBox textBox1_Apellido;
    }
}