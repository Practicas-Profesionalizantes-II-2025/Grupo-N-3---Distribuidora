using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace CDatos.Repositorios.IRepositorios
{
    public interface IDistribuidorRepositorio
    {
        Task<List<Distribuidor>> ObtenerDistribuidores();
        Task<Distribuidor> ObtenerDistribuidorPorId(int id);
        Task<Distribuidor> CrearDistribuidor(Distribuidor distribuidor);
        void ActualizarDistribuidor(Distribuidor distribuidor);
        void EliminarDistribuidor(int id);
    }
}
