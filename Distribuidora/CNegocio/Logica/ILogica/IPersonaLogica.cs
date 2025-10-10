using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica.ILogica
{
    public interface IPersonaLogica
    {
        Task<List<PersonaDTO>> ObtenerPersonas();
        Task<PersonaDTO> ObtenerPersonaPorId(int id);
        Task<PersonaDTO> CrearPersona(PersonaDTO personaDTO);
        Task<PersonaDTO> ActualizarPersona(PersonaDTO personaDTO);
        Task EliminarPersona(int id);
        Task<List<PersonaDTO>> ObtenerPersonasPorDni(string dni);
    }
}
