using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class OrdenDeCompra : EntityBase
    {
        public Empleados Empleado { get; set; }
        public Distribuidores Distribuidor { get; set; }
        public DateTime FechaOrden { get; set; }

    }
}
