namespace MVC.Models.DTOs
{
    public class OrdenDeVentaProductoDTO
    {
        public int Id { get; set; }
        public int OrdenDeVentaId { get; set; }
        public int ProductoId { get; set; }
        public int CantidadProducto { get; set; }
        public string NombreProducto { get; set; }
        public float PrecioUnitario { get; set; }
        public int DistribuidorId { get; set; }
        public string DistribuidorNombre { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public int EmpleadoId { get; set; }
        public string EmpleadoNombre { get; set; }

    }
}
