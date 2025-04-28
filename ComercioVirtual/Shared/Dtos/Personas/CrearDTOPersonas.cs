using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Personas
{
    public class CrearDTOPersonas
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public Shared.Entities.TipoDocumento? Tipo_Doc { get; set; }
        public string? Nro_Doc { get; set; }
        public Shared.Entities.Ciudades? Ciudad { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
    }
}
