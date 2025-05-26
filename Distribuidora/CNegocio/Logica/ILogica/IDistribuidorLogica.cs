using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace CNegocio.Logica.ILogica
{
    public interface IDistribuidorLogica
    {
        Task<List<DistribuidorDTO>> ObtenerDistribuidores();
        Task<DistribuidorDTO> ObtenerDistribuidorPorId(int id);
        Task CrearDistribuidor(DistribuidorDTO distribuidorDTO);
        Task ActualizarDistribuidor(DistribuidorDTO distribuidorDTO);
        Task EliminarDistribuidor(int id);
    }
}
