using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class OrdenDeCompraDTO
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int ProveedorId { get; set; }
        public DateTime FechaOrden { get; set; }
        public List<OrdenDeCompraProductoDTO> Productos { get; set; } = new();
        public string Estado { get; set; }
    }
}
