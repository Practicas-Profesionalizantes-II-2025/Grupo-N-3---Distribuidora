namespace MVC.Models.DTOs
{
    public class ProductoEditarModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ProveedorId { get; set; }
        public int CategoriaId { get; set; }
        public float PrecioProducto { get; set; }
        public int Stock { get; set; }

        // listas de Categorias y Proveedores
        public List<ProveedorDTO> Proveedores { get; set; }
        public List<CategoriaDTO> Categorias { get; set; }
    }
}
