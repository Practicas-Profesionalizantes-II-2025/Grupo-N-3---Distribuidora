using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Clientes : EntityBase
    {
        public Persona Persona { get; set; }
        public Estado EstadoCliente { get; set; }

    }
}
