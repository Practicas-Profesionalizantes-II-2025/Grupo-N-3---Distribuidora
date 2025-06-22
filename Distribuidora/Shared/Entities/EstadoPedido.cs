using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class EstadoPedido
    {
        int Id { get; set; }
        string Descripcion { get; set; }  // "Pendiente" - "Finalizado" - "Cancelado"
    }
}
