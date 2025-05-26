using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace CDatos.Repositorios.IRepositorios
{
    public interface ICiudadRepositorio
    {
        Task<List<Ciudad>> ObtenerCiudades();
        Task<Ciudad> ObtenerCiudadPorId(int id);
        Task<Ciudad> CrearCiudad(Ciudad ciudad);
        void ActualizarCiudad(Ciudad ciudad);
        void EliminarCiudad(int id);
    }
}
