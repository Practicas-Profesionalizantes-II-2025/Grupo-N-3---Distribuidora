using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class OrdenDeVentaDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int FacturaId { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
        public int DistribuidorId { get; set; }
    }
}
