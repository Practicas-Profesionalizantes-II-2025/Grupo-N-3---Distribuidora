namespace MVC.Models.Entities
{
    public class OrdenDeCompraProducto
    {
        public int Id { get; set; }
        public int OrdenDeCompraId { get; set; }
        public int ProductoId { get; set; }
        public int CantidadProducto { get; set; }
    }
}
