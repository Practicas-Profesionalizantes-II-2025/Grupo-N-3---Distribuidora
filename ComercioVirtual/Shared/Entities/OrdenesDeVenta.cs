namespace Shared.Entities
{
    public class OrdenesDeVenta : EntityBase
    {
        public DateTime Fecha {  get; set; }
        public Facturas? Factura { get; set; }
        public Empleados? Empleado { get; set; }
        public Clientes? Cliente { get; set; }
        public Distribuidores? Distribuidor { get; set; }

        // EF
        //public Factura? Factura { get; set; }    // 1:1 Con Factura
        //public int FacturaId { get; set; }
        //public Empleado? Empleado { get; set; }
        //public int EmpleadoId { get; set; } // 1:n con OrdenDeVenta
        //public Estado? Estado { get; set; }
        //public int EstadoId { get; set; }   // 1:n con Estado
        //public Cliente? Cliente { get; set; }
        //public int ClienteId { get; set; }   // 1:n con Cliente
        //public Distribuidor? Distribuidor { get; set; }
        //public int DistribuidorId { get; set; }   // 1:n con Distribuidor
        //public ICollection<OrdenDeVenta_Producto>? OrdenDeVenta_Productos { get; set; } // n:n con Producto



    }
}
