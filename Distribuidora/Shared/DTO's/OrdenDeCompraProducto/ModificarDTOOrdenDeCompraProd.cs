using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace Shared.DTO_s.OrdenDeCompraProducto
{
    public class ModificarDTOOrdenDeCompraProd
    {
        public Productos Producto { get; set; }
        public Shared.Entities.OrdenDeCompra OrdenDeCompra { get; set; }
    }
}
