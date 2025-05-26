using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class OrdenDeVentaProductoDTO
    {
        public int Id { get; set; }
        public int OrdenVentaId { get; set; }
        public int ProductoId { get; set; }
        public int CantidadProducto { get; set; }
    }
}
