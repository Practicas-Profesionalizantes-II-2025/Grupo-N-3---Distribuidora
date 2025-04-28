using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.OrdenesDeCompra_Producto
{
    public class ModificarDTOOrdenesDeCompra_Producto
    {
        public Shared.Entities.Productos? Producto { get; set; }
        public Shared.Entities.OrdenesDeCompra? OrdenDeCompra { get; set; }
    }
}
