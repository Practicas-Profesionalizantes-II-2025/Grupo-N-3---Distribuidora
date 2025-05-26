using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace CDatos.Repositorios.IRepositorios
{
    public interface IPersonaRepositorio
    {
        Task<Persona> ObtenerPersonaPorId(int id);
        Task<List<Persona>> ObtenerPersonas();
        Task CrearPersona(Persona persona);
        Task ActualizarPersona(Persona persona);
        Task EliminarPersona(int id);
        Task<List<Persona>> ObtenerPersonasPorDni(string dni);
    }
}
