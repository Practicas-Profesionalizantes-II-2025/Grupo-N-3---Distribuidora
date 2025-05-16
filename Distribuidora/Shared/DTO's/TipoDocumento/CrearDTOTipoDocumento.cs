using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO_s.TipoDocumento
{
    public class CrearDTOTipoDocumento
    {
        public string NombreTipoDocumento { get; set; }
        public Shared.Entities.Estado estado { get; set; }
    }
}
