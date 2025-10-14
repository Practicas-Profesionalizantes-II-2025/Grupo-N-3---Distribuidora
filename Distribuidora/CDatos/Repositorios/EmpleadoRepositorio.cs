using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.Data;
using CDatos.Repositorios.IRepositorios;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using CDatos.Encriptador;

namespace CDatos.Repositorios
{
    public class EmpleadoRepositorio : IEmpleadoRepositorio
    {
        private readonly DataContext _context;
        private readonly IPersonaRepositorio _personaRepositorio;
        public EmpleadoRepositorio(DataContext context, IPersonaRepositorio personaRepositorio)
        {
            _context = context;
            _personaRepositorio = personaRepositorio;
        }
        public async Task<List<Empleado>> ObtenerEmpleados()
        {
            return await _context.Empleado
                .Include(c => c.Persona)
                .ToListAsync();
        }
        public async Task<Empleado> ObtenerEmpleadoPorId(int id)
        {
            return await _context.Empleado
               .Include(c => c.Persona)
               .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<string> GetContraseniaHasheadaEmpleadoPorDni(string dni)
        {
            var empleado = await _context.Empleado
                .Include(c => c.Persona)
                .FirstOrDefaultAsync(c => c.Persona.Nro_Doc == dni);
            if (empleado == null)
            {
                throw new Exception($"No hay ningun empleado con dni: {dni}");
            }
            return empleado.Contrasenia;
        }
        public async Task<Empleado> CrearEmpleado(Empleado empleado)
        {
            empleado.Contrasenia = Encriptador.Encriptador.GetSHA256(empleado.Contrasenia);

            // Asegurás que EF no intente insertar la persona de nuevo
            _context.Entry(empleado).Reference(e => e.Persona).IsModified = false;
            _context.Entry(empleado).State = EntityState.Added;

            _context.Empleado.Add(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }
        public async Task ActualizarEmpleado(Empleado empleado)
        {
            var empleadoExistente = await _context.Empleado.FindAsync(empleado.Id);
            if (empleadoExistente == null)
            {
                throw new Exception("Empleado no encontrado.");
            }
            empleadoExistente.PersonaId = empleado.PersonaId;
            empleadoExistente.EstadoId = empleado.EstadoId;

            await _context.SaveChangesAsync();
        }
        public void EliminarEmpleado(int id)
        {
            var empleado = _context.Empleado.FirstOrDefault(x => x.Id == id);
            if (empleado != null)
            {
                _context.Empleado.Remove(empleado);
                _context.SaveChanges();
            }
        }
        public async Task<List<Empleado>> ObtenerEmpleadosPorDni(string dni)
        {
            var persona = await _personaRepositorio.ObtenerPersonasPorDni(dni);

            if (persona == null || !persona.Any())
                return new List<Empleado>();

            var personaId = persona.First().Id;

            return await _context.Empleado
                .Include(e => e.Persona) 
                .Where(e => e.PersonaId == personaId)
                .ToListAsync();

            //var personaId = (_personaRepositorio.ObtenerPersonasPorDni(dni)).Id;
            //return await _context.Empleado
            //    .Where(c => c.PersonaId == personaId)
            //    .ToListAsync();
        }
        public async Task<Persona> ObtenerPersonaPorEmpleadoId(int empleadoId)
        {
            var empleado = await _context.Empleado
                .Include(c => c.Persona)
                .FirstOrDefaultAsync(c => c.Id == empleadoId);

            return empleado?.Persona;
        }
    }
}
