using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.Data;
using CDatos.Repositorios.IRepositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
            return await _context.Persona.FindAsync(id);
        }
        public async Task<List<Persona>> ObtenerPersonas()
        {
            return await _context.Persona.ToListAsync();
        }
        public async Task<Persona> CrearPersona(Persona persona)
        {
            _context.Persona.Add(persona);
            await _context.SaveChangesAsync();
            return persona;
        }
        public void ActualizarPersona(Persona persona)
        {
            var personaExistente = _context.Persona.Find(persona.Id);
            if (personaExistente == null)
            {
                throw new Exception("persona no encontrado.");
            }
            personaExistente.Nombre = persona.Nombre;
            personaExistente.Apellido = persona.Apellido;
            personaExistente.Tipo_DocId = persona.Tipo_DocId;
            personaExistente.Nro_Doc = persona.Nro_Doc;
            personaExistente.CiudadId = persona.CiudadId;
            personaExistente.Telefono = persona.Telefono;
            personaExistente.Direccion = persona.Direccion;
            personaExistente.Email = persona.Email;

            _context.SaveChangesAsync();
        }
        public async Task EliminarPersona(int id)
        {
            var persona = await ObtenerPersonaPorId(id);
            if (persona != null)
            {
                _context.Persona.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Persona>> ObtenerPersonasPorDni(string dni)
        {
            return await _context.Persona
                .Where(c => c.Nro_Doc == dni)
                .ToListAsync();
        }
    }
}
