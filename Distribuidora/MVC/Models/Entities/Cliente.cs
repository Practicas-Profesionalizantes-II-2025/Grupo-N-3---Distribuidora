namespace MVC.Models.Entities

{
    public class Cliente
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
        public int EstadoId { get; set; }
    }
}
