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
    public class EstadoRepositorio : IEstadoRepositorio
    {
        private readonly DataContext _context;
        public EstadoRepositorio(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Estado>> ObtenerEstados()
        {
            return await _context.Estados.ToListAsync();
        }
        public async Task<Estado> ObtenerEstadoPorId(int id)
        {
            return await _context.Estados.FindAsync(id);
        }
        public async Task<Estado> CrearEstado(Estado estado)
        {
            _context.Estados.Add(estado);
            await _context.SaveChangesAsync();
            return estado;
        }
        public void ActualizarEstado(Estado estado)
        {
            var estadoExistente = _context.Estados.Find(estado.Id);
            if (estadoExistente == null)
            {
                throw new Exception("Estado no encontrada.");
            }
            estadoExistente.Descripcion = estado.Descripcion;

            _context.SaveChanges();
        }
        public void EliminarEstado(int id)
        {
            var estado = _context.Estados.FirstOrDefault(x => x.Id == id);
            if (estado != null)
            {
                _context.Estados.Remove(estado);
                _context.SaveChanges();
            }
        }
    }
}
