using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO_s.OrdenDeVenta
{
    public class CrearDTOOrdenVenta
    {
        public DateTime Fecha { get; set; }
        public Shared.Entities.Facturas? Factura { get; set; }
        public Shared.Entities.Empleados? Empleado { get; set; }
        public Shared.Entities.Clientes? Cliente { get; set; }
        public Shared.Entities.Distribuidores? Distribuidor { get; set; }

    }
}
