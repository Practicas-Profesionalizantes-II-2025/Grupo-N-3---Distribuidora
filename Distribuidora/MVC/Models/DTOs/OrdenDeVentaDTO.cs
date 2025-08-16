namespace MVC.Models.DTOs
{
    public class OrdenDeVentaDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int FacturaId { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
        public int DistribuidorId { get; set; }
    }
}
