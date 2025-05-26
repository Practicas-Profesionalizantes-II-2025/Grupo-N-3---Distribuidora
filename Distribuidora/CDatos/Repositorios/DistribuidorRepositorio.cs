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
    public class DistribuidorRepositorio : IDistribuidorRepositorio
    {
        private readonly DataContext _context;

        public DistribuidorRepositorio(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Distribuidor>> ObtenerDistribuidores()
        {
            return await _context.Distribuidores.ToListAsync();
        }
        public async Task<Distribuidor> ObtenerDistribuidorPorId(int id)
        {
            return await _context.Distribuidores.FindAsync(id);
        }
        public async Task<Distribuidor> CrearDistribuidor(Distribuidor distribuidor)
        {
            _context.Distribuidores.Add(distribuidor);
            await _context.SaveChangesAsync();
            return distribuidor;
        }
        public void ActualizarDistribuidor(Distribuidor distribuidor)
        {
            var distribuidorExistente = _context.Distribuidores.Find(distribuidor.Id);
            if (distribuidorExistente == null)
            {
                throw new Exception("Distribuidor no encontrado.");
            }
            distribuidorExistente.Nombre = distribuidor.Nombre;
            distribuidorExistente.Email = distribuidor.Email;
            distribuidorExistente.Telefono = distribuidor.Telefono;

            _context.SaveChanges();
        }
        public void EliminarDistribuidor(int id)
        {
            var Distribuidor = _context.Distribuidores.FirstOrDefault(x => x.Id == id);
            if (Distribuidor != null)
            {
                _context.Distribuidores.Remove(Distribuidor);
                _context.SaveChanges();
            }
        }
    }
}
