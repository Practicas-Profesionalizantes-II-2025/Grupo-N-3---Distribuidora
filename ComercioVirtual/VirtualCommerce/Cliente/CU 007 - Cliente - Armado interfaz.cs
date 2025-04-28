using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPresentacion
{
    public partial class CU_003____cliente____Armado_interfaz__Cliente : Form
    {
        public CU_003____cliente____Armado_interfaz__Cliente()
        {
            InitializeComponent();
        }

        private void CU_003____cliente____Armado_interfaz__Cliente_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTN_Agregar_Click(object sender, EventArgs e)
        {
            CU_010___Cliente___Confirmar_Alta interfazClienteAgregar = new CU_010___Cliente___Confirmar_Alta();
            interfazClienteAgregar.ShowDialog();
        }

        private void BTN_Modificar_Click(object sender, EventArgs e)
        {
            CU_007___Cliente___Modificar_Cliente interfazClienteModificar = new CU_007___Cliente___Modificar_Cliente();
            interfazClienteModificar.ShowDialog();
        }
    }
}
