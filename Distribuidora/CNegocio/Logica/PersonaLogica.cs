using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica
{
    public class PersonaLogica : IPersonaLogica
    {
        private readonly IPersonaRepositorio _personaRepositorio;
        public PersonaLogica(IPersonaRepositorio personaRepositorio)
        {
            _personaRepositorio = personaRepositorio;
        }
        public async Task<List<PersonaDTO>> ObtenerPersonas()
        {
            var personas = await _personaRepositorio.ObtenerPersonas();
            return personas.Select(p => new PersonaDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Tipo_DocId = p.Tipo_DocId,
                Nro_Doc = p.Nro_Doc,
                CiudadId = p.CiudadId,
                Email = p.Email,
                Direccion = p.Direccion,
                Telefono = p.Telefono,
                EstadoId = p.EstadoId
            }).ToList();
        }
        public async Task<PersonaDTO> ObtenerPersonaPorId(int id)
        {
            var persona = await _personaRepositorio.ObtenerPersonaPorId(id);
            if (persona == null) return null;
            return new PersonaDTO
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Tipo_DocId = persona.Tipo_DocId,
                Nro_Doc = persona.Nro_Doc,
                CiudadId = persona.CiudadId,
                Email = persona.Email,
                Direccion = persona.Direccion,
                Telefono = persona.Telefono,
                EstadoId = persona.EstadoId
            };
        }
        public async Task CrearPersona(PersonaDTO personaDTO)
        {
            var persona = new Shared.Entities.Persona
            {
                Nombre = personaDTO.Nombre,
                Apellido = personaDTO.Apellido,
                Tipo_DocId = personaDTO.Tipo_DocId,
                Nro_Doc = personaDTO.Nro_Doc,
                CiudadId = personaDTO.CiudadId,
                Email = personaDTO.Email,
                Direccion = personaDTO.Direccion,
                Telefono = personaDTO.Telefono,
                EstadoId = personaDTO.EstadoId
            };
            await _personaRepositorio.CrearPersona(persona);
        }
        public async Task ActualizarPersona(PersonaDTO personaDTO)
        {
            var persona = new Shared.Entities.Persona
            {
                Id = personaDTO.Id,
                Nombre = personaDTO.Nombre,
                Apellido = personaDTO.Apellido,
                Tipo_DocId = personaDTO.Tipo_DocId,
                Nro_Doc = personaDTO.Nro_Doc,
                CiudadId = personaDTO.CiudadId,
                Email = personaDTO.Email,
                Direccion = personaDTO.Direccion,
                Telefono = personaDTO.Telefono,
                EstadoId = personaDTO.EstadoId
            };
            await _personaRepositorio.ActualizarPersona(persona);
        }
        public async Task EliminarPersona(int id)
        {
            await _personaRepositorio.EliminarPersona(id);
        }
        public async Task<List<PersonaDTO>> ObtenerPersonasPorDni(string dni)
        {
            var personas = await _personaRepositorio.ObtenerPersonasPorDni(dni);
            return personas.Select(p => new PersonaDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Tipo_DocId = p.Tipo_DocId,
                Nro_Doc = p.Nro_Doc,
                CiudadId = p.CiudadId,
                Email = p.Email,
                Direccion = p.Direccion,
                Telefono = p.Telefono,
                EstadoId = p.EstadoId
            }).ToList();
        }
    }
}
