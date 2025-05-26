using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica.ILogica
{
    public interface IEstadoLogica
    {
        Task<List<EstadoDTO>> ObtenerEstados();
        Task<EstadoDTO> ObtenerEstadoPorId(int id);
        Task CrearEstado(EstadoDTO estadoDTO);
        Task ActualizarEstado(EstadoDTO estadoDTO);
        Task EliminarEstado(int id);
    }
}
