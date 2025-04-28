using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.OrdenesDeCompra
{
    public class ModificarDTOOrdenesDeCompra
    {
        public Shared.Entities.Empleados? Empleado { get; set; }
        public Shared.Entities.Distribuidores? Distribuidor { get; set; }
        public DateTime FechaOrden { get; set; }
    }
}
