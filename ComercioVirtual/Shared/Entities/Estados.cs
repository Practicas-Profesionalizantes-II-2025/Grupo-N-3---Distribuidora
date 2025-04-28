namespace Shared.Entities
{
    public class Estados : EntityBase
    {
        public string? Descripcion { get; set; }    // "De Baja" - "De Alta"

        // EF
        //public ICollection<OrdenDeVenta>? OrdenesDeVentas { get; } = new List<OrdenDeVenta>();  // 1:n con OrdenesDeVenta
    }
}
