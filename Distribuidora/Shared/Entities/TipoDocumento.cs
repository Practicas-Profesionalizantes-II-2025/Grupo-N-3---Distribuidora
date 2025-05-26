using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class TipoDocumento
    {
        public int Id { get; set; }
        public string NombreTipoDocumento { get; set; }
    }
}
