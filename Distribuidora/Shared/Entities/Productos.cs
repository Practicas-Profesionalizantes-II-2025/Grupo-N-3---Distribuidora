using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Productos : EntityBase
    {
        public string Nombre { get; set; }
        public const int LengthNombre = 20;
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
        public int UnidadesProducto { get; set; }
        public float PrecioProducto { get; set; }
        public int Stock = 0;
        // Plantear como poner foto

    }
}
