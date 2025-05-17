using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO_s.OrdenDeCompra
{
    public class ModificarDTOOrdenCompra
    {
        public int IdOrdenCompra {  get; set; }
        public Shared.Entities.Empleados? Empleado { get; set; }
        public Shared.Entities.Distribuidores? Distribuidor { get; set; }
        public DateTime FechaOrden { get; set; }
    }
}
