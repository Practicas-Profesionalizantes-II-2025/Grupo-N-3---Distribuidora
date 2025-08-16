namespace MVC.Models.DTOs
{
    public class OrdenDeCompraProductoDTO
    {
        public int Id { get; set; }
        public int OrdenDeCompraId { get; set; }
        public int ProductoId { get; set; }
        public int CantidadProducto { get; set; }
    }
}
