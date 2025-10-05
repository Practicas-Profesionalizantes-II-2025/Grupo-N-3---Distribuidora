using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MVC.Models.DTOs
{
    public class OrdenDeCompraDTO
    {
        public int Id { get; set; }
        public DateTime FechaOrden { get; set; }
        public string Estado { get; set; }


        //View Model
        [ValidateNever]
        public int EmpleadoId { get; set; }
        [ValidateNever]
        public string NombreEmpleado { get; set; }
        [ValidateNever]
        public int ProveedorId { get; set; }
        [ValidateNever]
        public string ProveedorNombre { get; set; }

        //Productos disponibles para crear
        [ValidateNever]
        public List<ProductoDTO> Productos { get; set; } = new List<ProductoDTO>();

        // Productos seleccionados en la orden (para detalle)
        [ValidateNever]
        public List<OrdenDeCompraProductoDTO> ProductosSeleccionados { get; set; } = new();
    }
}
