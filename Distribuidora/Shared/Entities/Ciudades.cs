using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Ciudades : EntityBase
    {
        public string Nombre { get; set; }
        public string Cp { get; set; }
        public string Acp { get; set; }

    }
}
