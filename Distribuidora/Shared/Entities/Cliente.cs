using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public int EstadoId { get; set; }
    }
}
