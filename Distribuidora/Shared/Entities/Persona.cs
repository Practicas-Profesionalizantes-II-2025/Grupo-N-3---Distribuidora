using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Persona : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public TipoDocumento Tipo_Doc { get; set; }
        public string Nro_Doc { get; set; }
        public Ciudades Ciudad { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

    }
}
