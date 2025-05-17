using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Clientes 
    {
        public int IdCliente { get; set; }
        public Persona Persona { get; set; }
        public int PersonaId { get; set; }
        public Estado EstadoCliente { get; set; }
        public ICollection<OrdenDeVenta>? OrdenesDeVenta { get; } = new List<OrdenDeVenta>(); // 1:n con OrdenDeVenta

    }
}
