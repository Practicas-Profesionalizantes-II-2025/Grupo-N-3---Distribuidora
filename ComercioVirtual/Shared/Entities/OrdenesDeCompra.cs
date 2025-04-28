namespace Shared.Entities
{
    public class OrdenesDeCompra : EntityBase
    {
        public Empleados? Empleado {  get; set; }
        public Distribuidores? Distribuidor {  get; set; } 
        public DateTime FechaOrden {  get; set; }


        //EF
        //public Factura? Factura { get; set; }    // 1:1 Con Factura
        //public int FacturaId { get; set; }
        //public Empleado? Empleado { get; set; }
        //public int EmpleadoId { get; set; } // 1:n con Empleado
        //public List<Producto> Productos { get; } = []; // n:n con Producto
    }
}
