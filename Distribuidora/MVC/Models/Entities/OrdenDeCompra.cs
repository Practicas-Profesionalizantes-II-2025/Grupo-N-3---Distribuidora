namespace MVC.Models.Entities
{
    public class OrdenDeCompra
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; } 
        public int DistribuidorId { get; set; }
        public Proveedor Distribuidor { get; set; }
        public DateTime FechaOrden { get; set; }
    }
}
