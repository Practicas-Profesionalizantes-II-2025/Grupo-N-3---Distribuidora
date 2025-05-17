using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Facturas
    {
        public int IdFactura { get; set; }
        public int numeroFactura { get; set; }
        public OrdenDeVenta? OrdenDeVenta { get; set; }
        public OrdenDeCompra? OrdenDeCompra { get; set; }
    }
}
