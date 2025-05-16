using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class OrdenDeCompraProducto : EntityBase
    {
        public Productos Producto { get; set; }
        public OrdenDeCompra OrdenDeCompra { get; set; }

    }
}
