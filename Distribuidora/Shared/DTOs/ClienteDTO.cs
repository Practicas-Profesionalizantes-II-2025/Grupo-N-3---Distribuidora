using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public PersonaDTO Persona { get; set; }
        public int EstadoId { get; set; }
        public int PersonaId { get; set; } 
    }
}
