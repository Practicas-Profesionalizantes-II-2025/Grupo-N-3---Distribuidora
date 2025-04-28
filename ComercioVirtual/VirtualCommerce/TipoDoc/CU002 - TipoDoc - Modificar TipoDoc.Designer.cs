namespace VirtualCommerce.TipoDoc
{
    partial class CU002___TipoDoc___Modificar_TipoDoc
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
            bt_Cancelar_Modif = new Button();
            BTN_Conf_Modif = new Button();
            lb_Nombre = new Label();
            tb_Nombre = new TextBox();
            lb_ModifDoc = new Label();
            label1 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(bt_Cancelar_Modif);
            panel2.Controls.Add(BTN_Conf_Modif);
            panel2.Controls.Add(lb_Nombre);
            panel2.Controls.Add(tb_Nombre);
            panel2.Location = new Point(0, 88);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(997, 455);
            panel2.TabIndex = 9;
            // 
            // bt_Cancelar_Modif
            // 
            bt_Cancelar_Modif.BackColor = Color.Black;
            bt_Cancelar_Modif.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bt_Cancelar_Modif.ForeColor = Color.White;
            bt_Cancelar_Modif.Location = new Point(652, 396);
            bt_Cancelar_Modif.Margin = new Padding(3, 2, 3, 2);
            bt_Cancelar_Modif.Name = "bt_Cancelar_Modif";
            bt_Cancelar_Modif.Size = new Size(170, 36);
            bt_Cancelar_Modif.TabIndex = 28;
            bt_Cancelar_Modif.Text = "Cancelar Modificación";
            bt_Cancelar_Modif.UseVisualStyleBackColor = false;
            bt_Cancelar_Modif.Click += bt_Cancelar_Modif_Click;
            // 
            // BTN_Conf_Modif
            // 
            BTN_Conf_Modif.BackColor = Color.Black;
            BTN_Conf_Modif.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BTN_Conf_Modif.ForeColor = Color.White;
            BTN_Conf_Modif.Location = new Point(652, 356);
            BTN_Conf_Modif.Margin = new Padding(3, 2, 3, 2);
            BTN_Conf_Modif.Name = "BTN_Conf_Modif";
            BTN_Conf_Modif.Size = new Size(170, 36);
            BTN_Conf_Modif.TabIndex = 27;
            BTN_Conf_Modif.Text = "Confirmar Modificacion";
            BTN_Conf_Modif.UseVisualStyleBackColor = false;
            BTN_Conf_Modif.Click += BTN_Conf_Modif_Click;
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
            // lb_ModifDoc
            // 
            lb_ModifDoc.AutoSize = true;
            lb_ModifDoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lb_ModifDoc.ForeColor = Color.Black;
            lb_ModifDoc.Location = new Point(49, 34);
            lb_ModifDoc.Name = "lb_ModifDoc";
            lb_ModifDoc.Size = new Size(203, 15);
            lb_ModifDoc.TabIndex = 30;
            lb_ModifDoc.Text = "MODIFICACION TIPO DOCUMENTO";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(909, 34);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 29;
            label1.Text = "KeProyecto";
            // 
            // CU002___TipoDoc___Modificar_TipoDoc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(1002, 541);
            Controls.Add(lb_ModifDoc);
            Controls.Add(label1);
            Controls.Add(panel2);
            Name = "CU002___TipoDoc___Modificar_TipoDoc";
            Text = "CU002___TipoDoc___Modificar_TipoDoc";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private Button bt_Cancelar_Modif;
        private Button BTN_Conf_Modif;
        private Label lb_Nombre;
        private TextBox tb_Nombre;
        private Label lb_ModifDoc;
        private Label label1;
    }
}