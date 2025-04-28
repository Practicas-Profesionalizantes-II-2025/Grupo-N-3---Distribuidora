namespace Shared.Entities
{
    public class Categorias : EntityBase
    {
        public string? Nombre { get; set; }
        public Estados? estado { get; set; } = new Estados()
        {
            Descripcion = "'De alta"
        };

        // EF

        //public ICollection<Producto>? Productos { get; } = new List<Producto>();  // 1:n con Producto
    }
}


