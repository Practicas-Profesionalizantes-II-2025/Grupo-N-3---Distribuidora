namespace MVC.Models.DTOs
{
    public class ProductoDTOvista
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ProveedorId { get; set; }
        public int CategoriaId { get; set; }
        public float PrecioProducto { get; set; }
        public int Stock = 0;

        // Propiedades de solo lectura para la vista
        public string ProveedorNombre { get; set; }
        public string CategoriaNombre { get; set; }

        // Plantear como poner foto
    }
}
