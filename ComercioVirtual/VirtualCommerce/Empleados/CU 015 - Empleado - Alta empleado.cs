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
    public partial class CU___015___Empleado___Alta_empleado : Form
    {
        public CU___015___Empleado___Alta_empleado()
        {
            InitializeComponent();
            var tiposDocumentos = await Negocio.CasoDeUso.TipoDocumento.ObtenerTodo();
            cb_TipoDoc.DataSource = tiposDocumentos;
            cb_TipoDoc.DisplayMember = "NombreTipoDocumento";
            cb_TipoDoc.ValueMember = "Id";

            var ciudades = await Negocio.CasoDeUso.Ciudades.ObtenerTodo();
            cb_Ciudad.DataSource = ciudades;
            cb_Ciudad.DisplayMember = "Nombre"; // "Nombre" es la propiedad que se muestra en la lista desplegable
            cb_Ciudad.ValueMember = "Id";       // "Id" es la clave asociada

            cb_TipoDoc.SelectedIndex = -1;
            cb_Ciudad.SelectedIndex = -1;
        }

    }
}
