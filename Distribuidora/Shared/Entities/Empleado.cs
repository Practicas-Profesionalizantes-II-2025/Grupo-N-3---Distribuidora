using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Empleado
    {
        public int Id { get; set; }
        public int SectorId { get; set; }
        public int PersonaId { get; set; }
        public string Foto { get; set; } //Ver tema foto string ubicación de foto, ruta
        public int EstadoId { get; set; }

    }
}
