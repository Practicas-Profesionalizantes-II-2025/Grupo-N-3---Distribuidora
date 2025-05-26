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
            return await _context.Ciudades.ToListAsync();
        }
        public async Task<Ciudad> ObtenerCiudadPorId(int id)
        {
            return await _context.Ciudades.FindAsync(id);
        }
        public async Task<Ciudad> CrearCiudad(Ciudad ciudad)
        {
            _context.Ciudades.Add(ciudad);
            await _context.SaveChangesAsync();
            return ciudad;
        }
        public void ActualizarCiudad(Ciudad ciudad)
        {
            var ciudadExistente = _context.Ciudades.Find(ciudad.Id);
            if (ciudadExistente == null)
            {
                throw new Exception("Ciudad no encontrada.");
            }
            ciudadExistente.Nombre = ciudad.Nombre;
            ciudadExistente.Cp = ciudad.Cp;
            ciudadExistente.Acp = ciudad.Acp;

            _context.SaveChanges();
        }
        public void EliminarCiudad(int id)
        {
            var Ciudad = _context.Ciudades.FirstOrDefault(x => x.Id == id);
            if (Ciudad != null)
            {
                _context.Ciudades.Remove(Ciudad);
                _context.SaveChanges();
            }
        }
    }
}
