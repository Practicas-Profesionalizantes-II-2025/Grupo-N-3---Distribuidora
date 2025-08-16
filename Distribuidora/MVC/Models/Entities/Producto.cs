namespace MVC.Models.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ProveedorId { get; set; }
        public int CategoriaId { get; set; }
        public float PrecioProducto { get; set; }
        public int Stock = 0;
        // Plantear como poner foto
    }
}
