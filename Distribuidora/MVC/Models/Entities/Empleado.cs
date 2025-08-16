namespace MVC.Models.Entities

{
    public class Empleado
    {
        public int Id { get; set; }
        public int SectorId { get; set; }
        public int PersonaId { get; set; }
        public string Foto { get; set; } //Ver tema foto string ubicación de foto, ruta
        public int EstadoId { get; set; }

    }
}
