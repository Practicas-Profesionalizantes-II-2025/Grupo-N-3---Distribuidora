using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class OrdenDeVentaProducto 
    {
        public int IdOrdenVentaProd {  get; set; }
        public int CantidadProducto { get; set; }
        public OrdenDeVenta? OrdenDeVenta { get; set; }
        public int IdOrdenDeVenta { get; set; }

        public Productos? Producto { get; set; }
        public int IdProducto { get; set; }

    }
}
