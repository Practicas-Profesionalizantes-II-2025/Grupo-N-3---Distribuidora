namespace MVC.Models.DTOs
{
    public class DetalleOrdenVentaDTO
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public int EmpleadoId { get; set; }
        public int DistribuidorId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaOrden { get; set; }
        public List<OrdenDeVentaProductoDTO> ProductosSeleccionados { get; set; } = new();
    }
}
