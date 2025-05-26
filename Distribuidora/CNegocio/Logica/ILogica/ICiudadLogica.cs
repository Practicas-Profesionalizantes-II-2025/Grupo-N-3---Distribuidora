using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace CNegocio.Logica.ILogica
{
    public interface ICiudadLogica
    {
        Task<List<CiudadDTO>> ObtenerCiudades();
        Task<CiudadDTO> ObtenerCiudadPorId(int id);
        Task CrearCiudad(CiudadDTO ciudadDTO);
        Task ActualizarCiudad(CiudadDTO ciudadDTO);
        Task EliminarCiudad(int id);
    }
}
