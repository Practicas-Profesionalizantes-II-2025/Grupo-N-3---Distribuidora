using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.TipoDocumento
{
    public class ModificarDTOTipoDocumento
    {
        public string? NombreTipoDocumento { get; set; }
        public Shared.Entities.Estados? Estado { get; set; }
    }
}
