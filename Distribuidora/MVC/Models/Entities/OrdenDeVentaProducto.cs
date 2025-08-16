namespace MVC.Models.Entities
{
    public class OrdenDeVentaProducto
    {
        public int Id { get; set; }
        public int OrdenVentaId { get; set; }
        public int ProductoId { get; set; }
        public int CantidadProducto { get; set; }
    }
}
