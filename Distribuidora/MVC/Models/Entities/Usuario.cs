namespace MVC.Models.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public int PersonaId { get; set; }
        public int EstadoId { get; set; }
    }
}
