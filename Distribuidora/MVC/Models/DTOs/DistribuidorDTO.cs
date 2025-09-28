using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MVC.Models.DTOs
{
    public class DistribuidorDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CuilCuit { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int CiudadId { get; set; }
        
        [ValidateNever]
        public string CiudadNombre { get; set; }

        [ValidateNever]
        public List<CiudadDTO> Ciudades { get; set; } = new List<CiudadDTO>(); // Lista para el dropdown
    }
}
