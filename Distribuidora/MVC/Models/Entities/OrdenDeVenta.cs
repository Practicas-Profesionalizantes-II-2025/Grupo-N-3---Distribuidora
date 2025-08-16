namespace MVC.Models.Entities
{
    public class OrdenDeVenta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int FacturaId { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
        public int DistribuidorId { get; set; }
        public int EstadoId { get; set; }
    }
}
