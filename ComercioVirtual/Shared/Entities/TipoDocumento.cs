using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public class TipoDocumento : EntityBase
    {
        public const int LengthNombre = 60;

        [MaxLength(
            LengthNombre,
            ErrorMessage = "El campo {0} no puede tener más de {1} caracteres."
        )]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? NombreTipoDocumento { get; set; }

        //public ICollection<Empleado> Empleados { get; } = new List<Empleado>(); // 1:n con Empleados

    }
}
