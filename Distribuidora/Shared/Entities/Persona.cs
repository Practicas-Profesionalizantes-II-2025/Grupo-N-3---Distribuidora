using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Persona 
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public TipoDocumento Tipo_Doc { get; set; }
        public string Nro_Doc { get; set; }
        public Ciudades Ciudad { get; set; }// 1:n con Ciudad (Esla hija)
        public int CiudadId { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public Clientes? Cliente { get; set; } // 1:1 con Persona
        public Empleados? Empleado { get; set; }  // 1:1 con Persona
    }
}
