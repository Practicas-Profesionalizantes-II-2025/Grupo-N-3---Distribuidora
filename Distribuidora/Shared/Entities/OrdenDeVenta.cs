using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class OrdenDeVenta : EntityBase
    {
        public DateTime Fecha { get; set; }
        public Facturas Factura { get; set; }
        public Empleados Empleado { get; set; }
        public Clientes Cliente { get; set; }
        public Distribuidores Distribuidor { get; set; }

    }
}
