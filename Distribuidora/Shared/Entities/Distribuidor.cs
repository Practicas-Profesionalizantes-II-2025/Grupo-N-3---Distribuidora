using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Distribuidor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CuilCuit { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int CiudadId { get; set; }
    }
}
