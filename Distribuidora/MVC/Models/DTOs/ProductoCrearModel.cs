namespace MVC.Models.DTOs
{
    public class ProductoCrearModel
    {
        // listas de Categorias y Proveedores
        public List<ProveedorDTO> Proveedores { get; set; }
        public List<CategoriaDTO> Categorias { get; set; }
    }
}
