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
    public class OrdenDeCompraRepositorio : IOrdenDeCompraRepositorio
    {
        private readonly DataContext _context;
        public OrdenDeCompraRepositorio(DataContext context)
        {
            _context = context;
        }
        public async Task<List<OrdenDeCompra>> ObtenerOrdenesDeCompra()
        {
            return await _context.OrdenesDeCompra.ToListAsync();
        }
        public async Task<OrdenDeCompra> ObtenerOrdenDeCompraPorId(int id)
        {
            return await _context.OrdenesDeCompra.FindAsync(id);
        }
        public async Task<OrdenDeCompra> CrearOrdenDeCompra(OrdenDeCompra ordenDeCompra)
        {
            _context.OrdenesDeCompra.Add(ordenDeCompra);
            await _context.SaveChangesAsync();
            return ordenDeCompra;
        }
        public void ActualizarOrdenDeCompra(OrdenDeCompra ordenDeCompra)
        {
            var ordenDeCompraExistente = _context.OrdenesDeCompra.Find(ordenDeCompra.Id);
            if (ordenDeCompra == null)
            {
                throw new Exception("Orden de Compra no encontrada.");
            }
            ordenDeCompraExistente.FechaOrden = ordenDeCompra.FechaOrden;
            ordenDeCompraExistente.EmpleadoId = ordenDeCompra.Id;
            ordenDeCompraExistente.DistribuidorId = ordenDeCompra.DistribuidorId;

            _context.SaveChanges();
        }
        public void EliminarOrdenDeCompra(int id)
        {
            var OrdenDeCompra = _context.OrdenesDeCompra.FirstOrDefault(x => x.Id == id);
            if (OrdenDeCompra != null)
            {
                _context.OrdenesDeCompra.Remove(OrdenDeCompra);
                _context.SaveChanges();
            }
        }

        // Obtener lista de Ordenes de Compra segun el atributo de clave foranea (EmpleadoId, ClienteId, DistribuidorId)

        public async Task<List<OrdenDeCompra>> ObtenerOrdenesDeCompraPorDistribuidorId(int distribuidorId)
        {
            return await _context.OrdenesDeCompra
                .Where(c => c.DistribuidorId == distribuidorId)
                .ToListAsync();
        }
        public async Task<List<OrdenDeCompra>> ObtenerOrdenesDeCompraPorEmpleadoId(int empleadoId)
        {
            return await _context.OrdenesDeCompra
                .Where(c => c.EmpleadoId == empleadoId)
                .ToListAsync();
        }
        public async Task<List<OrdenDeCompra>> ObtenerOrdenesDeCompraPorFecha(DateTime fecha)
        {
            return await _context.OrdenesDeCompra
                .Where(c => c.FechaOrden == fecha)
                .ToListAsync();
        }
    }
}
