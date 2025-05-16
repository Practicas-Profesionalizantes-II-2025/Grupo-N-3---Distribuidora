using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Categoria : EntityBase
    {
        public string Nombre { get; set; }
        public Estado estado { get; set; } = new Estado()
        {
            Descripcion ="De alta"
        };
        public ICollection<Productos> Productos { get; } = new List<Productos>();

    }
}
