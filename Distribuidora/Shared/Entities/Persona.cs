using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Persona
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
        public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
        public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();


    }
}
