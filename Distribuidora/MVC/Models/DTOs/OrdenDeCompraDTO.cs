using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MVC.Models.DTOs
{
    public class OrdenDeCompraDTO
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public EmpleadoDTO Empleado { get; set; }
        public DateTime FechaOrden { get; set; }
        public string Estado { get; set; }


        //View Model
        [ValidateNever]
        public int ProductoId { get; set; }
        [ValidateNever]
        public List<ProductoDTO> Productos { get; set; }
        [ValidateNever]
        public int ProveedorId { get; set; }
        [ValidateNever]
        public string ProveedorNombre { get; set; }
        [ValidateNever]
        public List<OrdenDeCompraProductoDTO> ProductosSeleccionados { get; set; } = new();
    }
}
