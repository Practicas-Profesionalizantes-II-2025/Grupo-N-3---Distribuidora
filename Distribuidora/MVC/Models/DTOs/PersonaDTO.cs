namespace MVC.Models.DTOs
{
    public class PersonaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Tipo_DocId { get; set; }
        public string Nro_Doc { get; set; }
        public int CiudadId { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int EstadoId { get; set; }

    }
}
