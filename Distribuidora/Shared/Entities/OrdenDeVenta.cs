using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class OrdenDeVenta
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }   
        public int DistribuidorId { get; set; }
        public Distribuidor Distribuidor { get; set; }
        public DateTime FechaOrden { get; set; }
        public List<OrdenDeVentaProducto> Productos { get; set; } = new();
        public string? Estado { get; set; }
    }
}
