using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class OrdenDeCompra 
    {
        public int IdOrdenCompra {  get; set; }
        public Distribuidores Distribuidor { get; set; }
        public DateTime FechaOrden { get; set; }
        public Facturas? Factura { get; set; }    // 1:1 Con Factura
        public int FacturaId { get; set; }
        public Empleados Empleado { get; set; }
        public int EmpleadoId { get; set; } // 1:n con Empleado
        public List<Productos> Productos { get; } = []; // n:n con Producto


    }
}
