using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VirtualCommerce.TipoDoc
{
    public partial class CU_002___TipoDoc___Alta_Doc : Form
    {
        public CU_002___TipoDoc___Alta_Doc()
        {
            InitializeComponent();
        }

        private void button1_Canc_Alta_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void BTN_Conf_Alta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Nombre.Text.Trim()))
            {
                MessageBox.Show(
                    "Debe indicar el nombre del Producto",
                    "Ingreso de Datos...",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                tb_Nombre.Focus();

            }
            else
            {
                try
                {
                    await Negocio.CasoDeUso.TipoDocumento.Crear(
                        new Shared.Dtos.TipoDocumento.CrearDTOTipoDocumento
                        {
                            NombreTipoDocumento = tb_Nombre.Text.Trim(),
                        }
                    );
                }
                catch
                {
                    MessageBox.Show(
                        "Se presentó un problema al persistir la información",
                        "Persistencia de Datos...",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
              );
                }
            }
        }
    }
}



