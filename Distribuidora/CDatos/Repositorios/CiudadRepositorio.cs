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
    public class CiudadRepositorio : ICiudadRepositorio
    {
        private readonly DataContext _context;
        public CiudadRepositorio(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Ciudad>> ObtenerCiudades()
        {
            return await _context.Ciudad.ToListAsync();
        }
        public async Task<Ciudad> ObtenerCiudadPorId(int id)
        {
            return await _context.Ciudad.FindAsync(id);
        }
        public async Task<Ciudad> CrearCiudad(Ciudad ciudad)
        {
            _context.Ciudad.Add(ciudad);
            await _context.SaveChangesAsync();
            return ciudad;
        }
        public void ActualizarCiudad(Ciudad ciudad)
        {
            var ciudadExistente = _context.Ciudad.Find(ciudad.Id);
            if (ciudadExistente == null)
            {
                throw new Exception("Ciudad no encontrada.");
            }
            ciudadExistente.Nombre = ciudad.Nombre;

            _context.SaveChanges();
        }
        public void EliminarCiudad(int id)
        {
            var Ciudad = _context.Ciudad.FirstOrDefault(x => x.Id == id);
            if (Ciudad != null)
            {
                _context.Ciudad.Remove(Ciudad);
                _context.SaveChanges();
            }
        }
    }
}
