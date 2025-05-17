using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Proveedores 
    {
        public int IdProveedor {  get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public ICollection<Productos> Productos { get; } = new List<Productos>(); // 1:n con Producto
        public int IdCiudad { get; set; }
        public Ciudades Ciudad { get; set; } = null!; // 1:n con Ciudad

    }
}
