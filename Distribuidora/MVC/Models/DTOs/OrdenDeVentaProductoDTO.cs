namespace MVC.Models.DTOs
{
    public class OrdenDeVentaProductoDTO
    {
        public int Id { get; set; }
        public int OrdenVentaId { get; set; }
        public int ProductoId { get; set; }
        public int CantidadProducto { get; set; }
    }
}
