namespace MVC.Models.DTOs
{
    public class PersonaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Tipo_DocId { get; set; }
        public string Tipo_DocNombre { get; set; } // Propiedad de solo lectura para la vista
        public string Nro_Doc { get; set; }
        public int CiudadId { get; set; }
        public string NombreCiudad { get; set; } // Propiedad de solo lectura para la vista
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int EstadoId { get; set; }
        public string Estado { get; set; } // Propiedad de solo lectura para la vista
        public List<TipoDocumentoDTO> TiposDocumentos { get; set; } // Lista para el dropdown
        public List<CiudadDTO> Ciudades { get; set; } // Lista para el dropdown
        public List<EstadoDTO> Estados { get; set; } // Lista para el dropdown

    }
}
