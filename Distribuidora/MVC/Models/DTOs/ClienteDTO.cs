namespace MVC.Models.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public PersonaDTO Persona { get; set; }
        public int PersonaId { get; set; }
        public int EstadoId { get; set; }
    }
}
