namespace MVC.Models.DTOs
{
    public class EmpleadoDTO
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string Foto { get; set; } //Ver tema foto string ubicación de foto, ruta
        public int EstadoId { get; set; }
    }
}
