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
    public class EmpleadoRepositorio : IEmpleadoRepositorio
    {
        private readonly DataContext _context;
        private readonly IPersonaRepositorio _personaRepositorio;
        public EmpleadoRepositorio(DataContext context)
        {
            _context = context;
            _personaRepositorio = _personaRepositorio;
        }
        public async Task<List<Empleado>> ObtenerEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }
        public async Task<Empleado> ObtenerEmpleadoPorId(int id)
        {
            return await _context.Empleados.FindAsync(id);
        }
        public async Task<Empleado> CrearEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }
        public void ActualizarEmpleado(Empleado empleado)
        {
            var empleadoExistente = _context.Empleados.Find(empleado.Id);
            if (empleadoExistente == null)
            {
                throw new Exception("Empleado no encontrado.");
            }
            empleadoExistente.PersonaId = empleado.PersonaId;
            empleadoExistente.EstadoId = empleado.EstadoId;
            empleadoExistente.Foto = empleadoExistente.Foto;

            _context.SaveChanges();
        }
        public void EliminarEmpleado(int id)
        {
            var empleado = _context.Empleados.FirstOrDefault(x => x.Id == id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();
            }
        }
        public async Task<List<Empleado>> ObtenerEmpleadosPorDni(string dni)
        {
            var personaId = (_personaRepositorio.ObtenerPersonasPorDni(dni)).Id;
            return await _context.Empleados
                .Where(c => c.PersonaId == personaId)
                .ToListAsync();
        }
    }
}
