namespace MVC.Models.DTOs
{
    public class OrdenDeCompraDTO
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public EmpleadoDTO Empleado { get; set; }
        public int DistribuidorId { get; set; }
        public ProveedorDTO Distribuidor { get; set; }
        public DateTime FechaOrden { get; set; }
    }
}
