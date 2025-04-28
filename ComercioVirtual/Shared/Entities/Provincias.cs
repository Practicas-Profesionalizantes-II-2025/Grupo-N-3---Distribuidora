using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public class Provincias : EntityBase
    {
        public const int lenghtNombre = 60; // Campo {1}

        [MaxLength(
            lenghtNombre,
            ErrorMessage = "El campo {0} no puede tener más de {1} caracteres."
        )]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? Nombre { get; set; } // Campo {0}
        public Estados? estado { get; set; }


        // EF

        //public ICollection<Ciudad>? Ciudades { get; } = new List<Ciudad>();

    }
}
