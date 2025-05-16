using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Sectores : EntityBase
    {
        public string Nombre { get; set; }
        public Estado estado { get; set; } = new Estado()
        {
            Descripcion = "'De alta"
        };

    }
}
