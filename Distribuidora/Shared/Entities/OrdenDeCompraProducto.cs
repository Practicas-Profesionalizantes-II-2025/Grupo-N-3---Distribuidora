using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class OrdenDeCompraProducto 
    {
        public int IdOrdenCompraProd {  get; set; }
        public Productos Producto { get; set; }
        public int IdProducto { get; set; }
        public OrdenDeCompra OrdenDeCompra { get; set; }
        public int IdOrdenDeCompra { get; set; }
        public int CantidadProducto {  get; set; }
    }
}
