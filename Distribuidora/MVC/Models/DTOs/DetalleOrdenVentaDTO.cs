namespace MVC.Models.DTOs
{
    public class DetalleOrdenVentaDTO
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public int EmpleadoId { get; set; }
        public int DistribuidorId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public List<OrdenDeVentaProductoDTO> Productos { get; set; } = new();
    }
}
