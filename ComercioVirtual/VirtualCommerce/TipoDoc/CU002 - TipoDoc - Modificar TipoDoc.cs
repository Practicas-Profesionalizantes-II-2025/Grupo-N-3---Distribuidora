using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualCommerce.TipoDoc
{
    public partial class CU002___TipoDoc___Modificar_TipoDoc : Form
    {
        public CU002___TipoDoc___Modificar_TipoDoc()
        {
            InitializeComponent();
        }

        private void bt_Cancelar_Modif_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_Conf_Modif_Click(object sender, EventArgs e)
        {
            Shared.Dtos.TipoDocumento.ModificarDTOTipoDocumento modificarDTO = new Shared.Dtos.TipoDocumento.ModificarDTOTipoDocumento
            {
                NombreTipoDocumento = tb_Nombre.Text.Trim(),
            };
            //await Negocio.CasoDeUso.TipoDocumento.Modificar(int.Parse(lblIdRegistro.Text),// Ver como es el tema de que selecionas el regsitro y agarre el id
            //    modificarDTO
            //);
        }
    }
}
