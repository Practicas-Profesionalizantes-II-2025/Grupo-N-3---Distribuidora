using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace Shared.DTO_s.Empleados
{
    public class ModificarDTOEmpleado
    {
        public int IdEmpleado { get; set; }
        public Shared.Entities.Persona Persona { get; set; }
    }
}
