using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class OrdenDeCompra
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int DistribuidorId { get; set; }
        public DateTime FechaOrden { get; set; }
    }
}
