using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Sectores 
    {
        public int IdSector { get; set; }
        public string Nombre { get; set; }
        public Estado estado { get; set; } = new Estado()
        {
            Descripcion = "'De alta"
        };
        public ICollection<Empleados> Empleados { get; } = new List<Empleados>(); // 1:n con Empleados


    }
}
