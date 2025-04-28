using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Empleados
{
    public class CrearDTOEmpleados
    {
        public Shared.Entities.Personas? Persona { get; set; }
        public string? Foto { get; set; } //Ver tema foto 
                                          //string ubicación de foto, ruta
        public Shared.Entities.Estados? EstadoEmpleado { get; set; }
    }
}
