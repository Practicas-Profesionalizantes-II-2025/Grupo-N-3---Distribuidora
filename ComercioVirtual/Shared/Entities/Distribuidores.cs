namespace Shared.Entities;

    public class Distribuidores : EntityBase
    {
        public string? Nombre {  get; set; }
        public string? Telefono {  get; set; }
        public string? Email {  get; set; }

        // EF

        //public ICollection<OrdenDeVenta>? OrdenesDeVenta { get; } = new List<OrdenDeVenta>();  // 1:n con OrdenDeVenta
        //public int IdCiudad {  get; set; }
        //public Ciudad Ciudad { get; set; } = null!; // 1:n con Ciudad
    }
