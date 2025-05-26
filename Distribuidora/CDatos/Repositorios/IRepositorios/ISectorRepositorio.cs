using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.Repositorios.IRepositorios
{
    public interface ISectorRepositorio
    {
        Task<List<Sector>> ObtenerSectores();
        Task<Sector> ObtenerSectorPorId(int id);
        Task CrearSector(Sector sector);
        Task ActualizarSector(Sector sector);
        Task EliminarSectorAsync(int id);
        Task<List<Sector>> ObtenerSectoresPorNombre(string nombre);
    }
}
