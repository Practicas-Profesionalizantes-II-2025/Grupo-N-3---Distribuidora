using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Productos
{
    public class ModificarDTOProductos
    {
        public string? Nombre { get; set; }
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
        public int UnidadesProducto { get; set; }
        public int PrecioProducto { get; set; }
    }
}
