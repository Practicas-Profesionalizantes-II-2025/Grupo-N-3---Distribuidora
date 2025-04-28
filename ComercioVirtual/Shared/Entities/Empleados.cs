namespace Shared.Entities
{
    public class Empleados : EntityBase
    {
        public Personas? Persona { get; set; }

        public string? Foto { get; set; } //Ver tema foto 
                                       //string ubicación de foto, ruta
        public Estados EstadoEmpleado { get; set; } = new Estados() { Descripcion = "Alta"};

        //// EF
        //public int PersonaId { get; set; }
        //public Persona Persona { get; set; } = null!;   
        //public int SectorId { get; set; }
        //public Sector Sector { get; set; } = null!; // 1:n con Sector

        //public ICollection<OrdenDeVenta>? OrdenesDeVenta { get; } = new List<OrdenDeVenta>(); // 1:n con OrdenDeVenta
        //public ICollection<OrdenDeCompra>? OrdenesDeCompra { get;} = new List<OrdenDeCompra>(); // 1:n con OrdenDeCompra

    }
}
