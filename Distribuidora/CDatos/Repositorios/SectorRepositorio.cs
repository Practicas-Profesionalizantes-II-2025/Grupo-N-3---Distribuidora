using CDatos.Data;
using CDatos.Repositorios.IRepositorios;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.Repositorios
{
    public class SectorRepositorio : ISectorRepositorio
    {
        private readonly DataContext _context;
        public SectorRepositorio(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Sector>> ObtenerSectores()
        {
            return await _context.Sectores.ToListAsync();
        }
        public async Task<Sector> ObtenerSectorPorId(int id)
        {
            return await _context.Sectores.FindAsync(id);
        }
        public async Task CrearSector(Sector sector)
        {
            _context.Sectores.Add(sector);
            await _context.SaveChangesAsync();
        }
        public async Task ActualizarSector(Sector sector)
        {
            var sectorExistente = _context.Sectores.Find(sector.Id);
            if (sectorExistente == null)
            {
                throw new Exception("Sector no encontrada.");
            }
            sectorExistente.Nombre = sector.Nombre;
            sectorExistente.EstadoId = sector.EstadoId;

            await _context.SaveChangesAsync();
        }
        public async Task EliminarSectorAsync(int id)
        {
            var sector = await ObtenerSectorPorId(id);
            if (sector != null)
            {
                _context.Sectores.Remove(sector);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Sector>> ObtenerSectoresPorNombre(string nombre)
        {
            return await _context.Sectores.Where(s => s.Nombre.Contains(nombre)).ToListAsync();
        }

    }
}
