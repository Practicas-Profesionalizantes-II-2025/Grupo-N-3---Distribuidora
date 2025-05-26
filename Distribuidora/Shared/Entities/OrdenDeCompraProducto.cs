using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class OrdenDeCompraProducto
    {
        public int Id { get; set; }
        public int OrdenDeCompraId { get; set; }
        public int ProductoId { get; set; }
        public int CantidadProducto { get; set; }
    }
}
