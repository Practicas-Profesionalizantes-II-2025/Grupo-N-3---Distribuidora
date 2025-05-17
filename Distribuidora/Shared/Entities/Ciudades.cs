using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Ciudades 
    {
        public int IdCiudad {  get; set; }
        public string Nombre { get; set; }
        public string Cp { get; set; }
        public string Acp { get; set; }
        public ICollection<Persona> Personas { get; } = new List<Persona>(); // 1:n con Personas (Es padre de Persona)
        public ICollection<Proveedores> Proveedores { get; } = new List<Proveedores>(); // 1:n con Personas (Es padre de Proveedor)
        public ICollection<Distribuidores> Distribuidores { get; } = new List<Distribuidores>(); // 1:n con Personas (Es padre de Distribuidor)


    }
}
