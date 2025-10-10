using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica.ILogica
{
    public interface IDistribuidorLogica
    {
        Task<List<DistribuidorDTO>> ObtenerDistribuidores();
        Task<DistribuidorDTO> ObtenerDistribuidorPorId(int id);
        Task<DistribuidorDTO> CrearDistribuidor(DistribuidorDTO DistribuidorDTO);
        Task<DistribuidorDTO> ActualizarDistribuidor(DistribuidorDTO DistribuidorDTO);
        Task EliminarDistribuidor(int id);
    }
}
