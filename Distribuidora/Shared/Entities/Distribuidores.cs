using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Distribuidores 
    {
        public int IdDistribuidor { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public ICollection<OrdenDeVenta>? OrdenesDeVenta { get; } = new List<OrdenDeVenta>();  // 1:n con OrdenDeVenta
        public int IdCiudad {  get; set; }
        public Ciudades Ciudad { get; set; } = null!; // 1:n con Ciudad

    }
}
