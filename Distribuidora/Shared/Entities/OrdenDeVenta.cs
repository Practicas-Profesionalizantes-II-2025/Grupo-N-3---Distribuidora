using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class OrdenDeVenta 
    {
        public int IdOrdenVenta { get; set; }
        public DateTime Fecha { get; set; }
        public Facturas Factura { get; set; }
        public int FacturaId { get; set; }
        public Empleados Empleado { get; set; }
        public int EmpleadoId { get; set; } // 1:n con OrdenDeVenta
        public Clientes Cliente { get; set; }
        public Distribuidores Distribuidor { get; set; }
        public int DistribuidorId { get; set; }   // 1:n con Distribuidor
        public int ClienteId { get; set; }   // 1:n con Cliente
        public ICollection<OrdenDeVentaProducto>? OrdenDeVenta_Productos { get; set; } // n:n con Producto


    }
}
