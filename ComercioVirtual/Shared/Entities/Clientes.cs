namespace Shared.Entities

{
    public class Clientes : EntityBase
    {
        public Personas? Persona { get; set; }
        public Estados? EstadoCliente { get; set; }

        //Ver como implementar el ID (no el que hereda de persona)

        // EF
        //public int PersonaId { get; set; }  
        //public Persona Persona { get; set; } = null!;
        //public ICollection<OrdenDeVenta>? OrdenesDeVenta { get; } = new List<OrdenDeVenta>(); // 1:n con OrdenDeVenta

    }
}
