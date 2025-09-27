using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MVC.Models.DTOs
{
    public class PersonaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Tipo_DocId { get; set; }
        [ValidateNever]
        public string Tipo_DocNombre { get; set; } // Propiedad de solo lectura para la vista
        public string Nro_Doc { get; set; }
        public int CiudadId { get; set; }
        [ValidateNever]
        public string NombreCiudad { get; set; } // Propiedad de solo lectura para la vista
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int EstadoId { get; set; }
        [ValidateNever]
        public string Estado { get; set; }
        // Propiedad de solo lectura para la vista
        [ValidateNever]
        public List<TipoDocumentoDTO> TiposDocumentos { get; set; } = new List<TipoDocumentoDTO>(); // Lista para el dropdown
        [ValidateNever]
        public List<CiudadDTO> Ciudades { get; set; } = new List<CiudadDTO>(); // Lista para el dropdown
        [ValidateNever]
        public List<EstadoDTO> Estados { get; set; } = new List<EstadoDTO>(); // Lista para el dropdown

    }
}
