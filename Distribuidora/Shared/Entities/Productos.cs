using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Productos 
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public const int LengthNombre = 20;
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
        public int UnidadesProducto { get; set; }
        public float PrecioProducto { get; set; }
        public int Stock = 0;
        
        
        public Proveedores Proveedor { get; set; } = null!; // 1:n con Proveedor 
        public int ProveedorId { get; set; }
        public Categoria? Categoria { get; set; }
        public int CategoriaId { get; set; }    // 1:n con Categoria 

        public List<OrdenDeCompra> OrdenesDeCompra { get; } = []; // n:n con OrdenDeCompra
        public ICollection<OrdenDeVentaProducto>? OrdenDeVentaProductos { get; set; } // n:n con OrdenDeVenta


    }
}
