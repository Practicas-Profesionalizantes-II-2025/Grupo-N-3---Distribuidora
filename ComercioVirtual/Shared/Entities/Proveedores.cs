namespace Shared.Entities
{
    public class Proveedores : EntityBase
    {
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono {  get; set; }
        public string? Email { get; set; }

        // EF

        //public ICollection<Producto> Productos { get; } = new List<Producto>(); // 1:n con Producto
        //public int IdCiudad { get; set; }
        //public Ciudad Ciudad { get; set; } = null!; // 1:n con Ciudad
    }
}
