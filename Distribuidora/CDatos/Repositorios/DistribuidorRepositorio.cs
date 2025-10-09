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
    public class DistribuidorRepositorio : IDistribuidorRepositorio
    {
        private readonly DataContext _context;
        public DistribuidorRepositorio(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Distribuidor>> ObtenerDistribuidores()
        {
            return await _context.Distribuidor.ToListAsync();
        }
        public async Task<Distribuidor> ObtenerDistribuidorPorId(int id)
        {
            return await _context.Distribuidor.FindAsync(id);
        }
        public async Task<Distribuidor> CrearDistribuidor(Distribuidor distribuidor)
        {
            _context.Distribuidor.Add(distribuidor);
            await _context.SaveChangesAsync();
            return distribuidor;
        }
        public void ActualizarDistribuidor(Distribuidor distribuidor)
        {
            var distribuidorExistente = _context.Distribuidor.Find(distribuidor.Id);
            if (distribuidorExistente == null)
            {
                throw new Exception("Distribuidor no encontrado.");
            }
            distribuidorExistente.Nombre = distribuidor.Nombre;
            distribuidorExistente.Telefono = distribuidor.Telefono;
            distribuidorExistente.Direccion = distribuidor.Direccion;
            distribuidorExistente.CiudadId = distribuidor.CiudadId;

            _context.SaveChangesAsync();
        }
        public void EliminarDistribuidor(int id)
        {
            var Distribuidor = _context.Distribuidor.FirstOrDefault(x => x.Id == id);
            if (Distribuidor != null)
            {
                _context.Distribuidor.Remove(Distribuidor);
                _context.SaveChanges();
            }
        }
    }
}
