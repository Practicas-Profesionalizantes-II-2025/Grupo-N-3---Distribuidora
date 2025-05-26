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
    public class OrdenDeVentaRepositorio : IOrdenDeVentaRepositorio
    {
        private readonly DataContext _context;
        public OrdenDeVentaRepositorio(DataContext context)
        {
            _context = context;
        }
        public async Task<List<OrdenDeVenta>> ObtenerOrdenesDeVenta()
        {
            return await _context.OrdenesDeVenta.ToListAsync();
        }
        public async Task<OrdenDeVenta> ObtenerOrdenDeVentaPorId(int id)
        {
            return await _context.OrdenesDeVenta.FindAsync(id);
        }
        public async Task CrearOrdenDeVenta(OrdenDeVenta ordenDeVenta)
        {
            _context.OrdenesDeVenta.Add(ordenDeVenta);
            await _context.SaveChangesAsync();
        }
        public async Task ActualizarOrdenDeVenta(OrdenDeVenta ordenDeVenta)
        {
            var ordenDeVentaExistente = _context.OrdenesDeVenta.Find(ordenDeVenta.Id);
            if (ordenDeVentaExistente == null)
            {
                throw new Exception("Orden de Venta no encontrada.");
            }
            ordenDeVentaExistente.FacturaId = ordenDeVenta.FacturaId;
            ordenDeVentaExistente.DistribuidorId = ordenDeVenta.DistribuidorId;
            ordenDeVentaExistente.ClienteId = ordenDeVenta.ClienteId;
            ordenDeVentaExistente.EmpleadoId = ordenDeVenta.EmpleadoId;
            ordenDeVentaExistente.Fecha = ordenDeVenta.Fecha;

            await _context.SaveChangesAsync();
        }
        public async Task EliminarOrdenDeVentaAsync(int id)
        {
            var ordenDeVenta = await ObtenerOrdenDeVentaPorId(id);
            if (ordenDeVenta != null)
            {
                _context.OrdenesDeVenta.Remove(ordenDeVenta);
                await _context.SaveChangesAsync();
            }
        }
        // Obtener lista de Ordenes de venta segun el atributo de clave foranea (EmpleadoId, ClienteId, DistribuidorId)
        public async Task<List<OrdenDeVenta>> ObtenerOrdenesDeVentaPorEmpleadoId(int empleadoId)
        {
            return await _context.OrdenesDeVenta
                .Where(c => c.EmpleadoId == empleadoId)
                .ToListAsync();
        }
        public async Task<List<OrdenDeVenta>> ObtenerOrdenesDeVentaPorClienteId(int clienteId)
        {
            return await _context.OrdenesDeVenta
                .Where(c => c.ClienteId == clienteId)
                .ToListAsync();
        }
        public async Task<List<OrdenDeVenta>> ObtenerOrdenesDeVentaPorDistribuidoraId(int distribuidoraId)
        {
            return await _context.OrdenesDeVenta
                .Where(c => c.ClienteId == distribuidoraId)
                .ToListAsync();
        }
    }
}
