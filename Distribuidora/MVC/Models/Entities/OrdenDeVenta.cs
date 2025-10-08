namespace MVC.Models.Entities
{
    public class OrdenDeVenta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int DistribuidorId { get; set; }
        public Distribuidor Distribuidor { get; set; }
    }
}
