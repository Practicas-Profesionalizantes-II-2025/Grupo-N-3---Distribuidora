using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace Shared.DTO_s.Categoria
{
    public class CrearDTOCategoria
    {
        public string Nombre { get; set; }
        public Shared.Entities.Estado estado { get; set; }
    }
}
