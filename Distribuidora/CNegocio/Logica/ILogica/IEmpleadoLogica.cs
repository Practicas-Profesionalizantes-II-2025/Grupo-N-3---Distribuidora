using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica.ILogica
{
    public interface IEmpleadoLogica
    {
        Task<List<EmpleadoDTO>> ObtenerEmpleados();
        Task<EmpleadoDTO> ObtenerEmpleadoPorId(int id);
        Task CrearEmpleado(EmpleadoDTO empleadoDTO);
        Task ActualizarEmpleado(EmpleadoDTO empleadoDTO);
        Task EliminarEmpleado(int id);
        Task<List<EmpleadoDTO>> ObtenerEmpleadosPorDni(string dni);
    }
}
