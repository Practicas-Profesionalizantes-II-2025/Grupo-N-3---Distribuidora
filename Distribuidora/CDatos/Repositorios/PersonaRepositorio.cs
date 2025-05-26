using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.Data;
using CDatos.Repositorios.IRepositorios;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace CDatos.Repositorios
{
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private readonly DataContext _context;
        public PersonaRepositorio(DataContext context)
        {
            _context = context;
        }
        public async Task<Persona> ObtenerPersonaPorId(int id)
        {
            return await _context.Personas.FindAsync(id);
        }
        public async Task<List<Persona>> ObtenerPersonas()
        {
            return await _context.Personas.ToListAsync();
        }
        public async Task CrearPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
        }
        public async Task ActualizarPersona(Persona persona)
        {
            var personaExistente = _context.Personas.Find(persona.Id);
            if (personaExistente == null)
            {
                throw new Exception("Persona no encontrada.");
            }
            personaExistente.Email = persona.Email;
            personaExistente.CiudadId = persona.CiudadId;
            personaExistente.Direccion = persona.Direccion;
            personaExistente.EstadoId = persona.EstadoId;
            personaExistente.Apellido = persona.Apellido;

            await _context.SaveChangesAsync();
        }
        public async Task EliminarPersona(int id)
        {
            var persona = await ObtenerPersonaPorId(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Persona>> ObtenerPersonasPorDni(string dni)
        {
            return await _context.Personas
                .Where(c => c.Nro_Doc == dni)
                .ToListAsync();
        }
    }
}
