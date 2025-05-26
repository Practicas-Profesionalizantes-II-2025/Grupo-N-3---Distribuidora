using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.Repositorios.IRepositorios
{
    public interface IEstadoRepositorio
    {
        Task<List<Shared.Entities.Estado>> ObtenerEstados();
        Task<Shared.Entities.Estado> ObtenerEstadoPorId(int id);
        Task<Shared.Entities.Estado> CrearEstado(Shared.Entities.Estado estado);
        void ActualizarEstado(Shared.Entities.Estado estado);
        void EliminarEstado(int id);
    }
}
