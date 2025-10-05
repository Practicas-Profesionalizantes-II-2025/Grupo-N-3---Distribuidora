namespace MVC.Models.DTOs
{
    public class DetalleOrdenCompraDTO
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public int EmpleadoId { get; set; }
        public int ProveedorId { get; set; }
        public DateTime FechaOrden { get; set; }
        public List<OrdenDeCompraProductoDTO> Productos { get; set; } = new();
    }
}
