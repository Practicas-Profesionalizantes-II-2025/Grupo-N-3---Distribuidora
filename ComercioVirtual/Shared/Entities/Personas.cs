using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Personas : EntityBase
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public TipoDocumento? Tipo_Doc { get; set; } 
        public string? Nro_Doc { get; set; }
        public Ciudades? Ciudad { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        // EF

        //public Cliente? Cliente { get; set; } // 1:1 con Persona
        //public Empleado? Empleado { get; set; }  // 1:1 con Persona
        //public int CiudadId { get; set; }
        //public Ciudad Ciudad { get; set; } = null!; // 1:n con Ciudad (Esla hija)
    }
}
