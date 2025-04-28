namespace Shared.Entities

{
    public class Ciudades : EntityBase
    {
        public string? Nombre { get; set; }
        public string? Cp { get; set; }
        public string? Acp {  get; set; }

        // EF
        //public int ProvinciaId { get; set; } 
        //public Provincia? Provincia { get; set; }           // 1:n con Provincia (Es la hija de Provincia)                            

        //public ICollection<Persona> Personas { get; } = new List<Persona>(); // 1:n con Personas (Es padre de Persona)
        //public ICollection<Proveedor> Proveedores { get; } = new List<Proveedor>(); // 1:n con Personas (Es padre de Proveedor)
        //public ICollection<Distribuidor> Distribuidores { get; } = new List<Distribuidor>(); // 1:n con Personas (Es padre de Distribuidor)

    }
}
