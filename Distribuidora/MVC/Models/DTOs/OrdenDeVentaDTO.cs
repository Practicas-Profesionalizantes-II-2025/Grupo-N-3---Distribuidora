using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MVC.Models.DTOs
{
    public class OrdenDeVentaDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }

        //View Model
        [ValidateNever]
        public int EmpleadoId { get; set; }
        [ValidateNever]
        public string NombreEmpleado { get; set; }
        [ValidateNever]
        public int ClienteId { get; set; }
        [ValidateNever]
        public string ClienteNombre { get; set; }
        [ValidateNever]
        public int DistribuidorId { get; set; }
        [ValidateNever]
        public string DistribuidorNombre { get; set; }

        //Productos disponibles para crear
        [ValidateNever]
        public List<ProductoDTO> Productos { get; set; } = new List<ProductoDTO>();

        // Productos seleccionados en la orden (para detalle)
        [ValidateNever]
        public List<OrdenDeVentaProductoDTO> ProductosSeleccionados { get; set; } = new();
    }
}
