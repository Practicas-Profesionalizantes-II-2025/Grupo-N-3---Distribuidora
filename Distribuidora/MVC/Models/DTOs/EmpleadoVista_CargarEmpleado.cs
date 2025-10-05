namespace MVC.Models.DTOs
{
    public class EmpleadoVista_CargarEmpleadoDTO
    {
        public List<CiudadDTO> ciudades { get; set; } = new List<CiudadDTO>();
        public List<TipoDocumentoDTO> tiposDocumentos { get; set; } = new List<TipoDocumentoDTO>();
        public List<SectorDTO> sectores { get; set; } = new List<SectorDTO>();
        public EmpleadoDTO empleado { get; set; } = new EmpleadoDTO();
    }
}
