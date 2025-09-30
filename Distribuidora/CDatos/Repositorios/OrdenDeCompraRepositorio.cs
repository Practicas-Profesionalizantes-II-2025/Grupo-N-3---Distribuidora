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
            return await _context.OrdenCompra
              .Include(o => o.Productos) // <--- Incluye la relación
                  .ThenInclude(op => op.Producto)     // <--- Opcional, si querés info del producto
              .Include(o => o.Empleado)
              .Include(o => o.Distribuidor)
              .ToListAsync();
        }
        public async Task<OrdenDeCompra> ObtenerOrdenDeCompraPorId(int id)
        {
            return await _context.OrdenCompra
               .Include(o => o.Productos)
                   .ThenInclude(op => op.Producto)
               .Include(o => o.Empleado)
               .Include(o => o.Distribuidor)
               .FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task<OrdenDeCompra> CrearOrdenDeCompra(OrdenDeCompra ordenDeCompra)
        {
            _context.OrdenCompra.Add(ordenDeCompra);
            await _context.SaveChangesAsync();
            return ordenDeCompra;
        }
        public void ActualizarOrdenDeCompra(OrdenDeCompra ordenDeCompra)
        {
            var ordenDeCompraExistente = _context.OrdenCompra.Find(ordenDeCompra.Id);
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
            var orden = _context.OrdenCompra
                .Include(o => o.Productos) // asegurar que EF borre los hijos si está cascade
                .FirstOrDefault(x => x.Id == id);
            if (orden != null)
            {
                _context.OrdenCompra.Remove(orden);
                _context.SaveChanges();
            }
        }

        // Obtener lista de Ordenes de Compra segun el atributo de clave foranea (EmpleadoId, ClienteId, DistribuidorId)

        public async Task<List<OrdenDeCompra>> ObtenerOrdenesDeCompraPorDistribuidorId(int distribuidorId)
        {
            return await _context.OrdenCompra
                  .Include(o => o.Productos)
                      .ThenInclude(op => op.Producto)
                  .Include(o => o.Empleado)
                  .Include(o => o.Distribuidor)
                  .Where(c => c.DistribuidorId == distribuidorId)
                  .ToListAsync();
        }
        public async Task<List<OrdenDeCompra>> ObtenerOrdenesDeCompraPorEmpleadoId(int empleadoId)
        {
            return await _context.OrdenCompra
                 .Include(o => o.Productos)
                     .ThenInclude(op => op.Producto)
                 .Include(o => o.Empleado)
                 .Include(o => o.Distribuidor)
                 .Where(c => c.EmpleadoId == empleadoId)
                 .ToListAsync();
        }
        public async Task<List<OrdenDeCompra>> ObtenerOrdenesDeCompraPorFecha(DateTime fecha)
        {
            return await _context.OrdenCompra
               .Include(o => o.Productos)
                   .ThenInclude(op => op.Producto)
               .Include(o => o.Empleado)
               .Include(o => o.Distribuidor)
               .Where(c => c.FechaOrden == fecha)
               .ToListAsync();
        }
    }
}
