using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class OrdenDeCompra
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
        public DateTime FechaOrden { get; set; }
        public List<OrdenDeCompraProducto> Productos { get; set; } = new();
        public string? Estado { get; set; } 
    }
}
