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
            return await _context.OrdenDeVenta
                .Include(o => o.Productos)
                    .ThenInclude(op => op.Producto)
                .Include(o => o.Empleado)
                .Include(o => o.Distribuidor)
                .Include(o => o.Cliente)
                .ToListAsync();
        }
        public async Task<OrdenDeVenta> ObtenerOrdenDeVentaPorId(int id)
        {
            return await _context.OrdenDeVenta
                .Include(o => o.Productos)
                    .ThenInclude(op => op.Producto)
                .Include(o => o.Empleado)
                .Include(o => o.Distribuidor)
                .Include(o => o.Cliente)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task<OrdenDeVenta> CrearOrdenDeVenta(OrdenDeVenta ordenDeVenta)
        {
            _context.OrdenDeVenta.Add(ordenDeVenta);
            await _context.SaveChangesAsync();
            return ordenDeVenta;
        }
        public void ActualizarOrdenDeVenta(OrdenDeVenta ordenDeVenta)
        {
            var existente = _context.OrdenDeVenta
                           .Include(o => o.Productos)
                           .FirstOrDefault(o => o.Id == ordenDeVenta.Id);

            if (existente == null)
                throw new Exception("Orden de Venta no encontrada.");

            existente.FechaOrden = ordenDeVenta.FechaOrden;
            existente.EmpleadoId = ordenDeVenta.EmpleadoId;
            existente.DistribuidorId = ordenDeVenta.DistribuidorId;
            existente.ClienteId = ordenDeVenta.ClienteId;
            existente.Estado = ordenDeVenta.Estado;

            existente.Productos.Clear();

            foreach (var p in ordenDeVenta.Productos)
            {
                existente.Productos.Add(new OrdenDeVentaProducto
                {
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto
                });
            }
            _context.SaveChanges();
        }
        public void EliminarOrdenDeVenta(int id)
        {
            var orden = _context.OrdenDeVenta
               .Include(o => o.Productos)
               .FirstOrDefault(x => x.Id == id);
            if (orden != null)
            {
                _context.OrdenDeVenta.Remove(orden);
                _context.SaveChanges();
            }
        }
        // Obtener lista de Ordenes de venta segun el atributo de clave foranea (EmpleadoId, ClienteId, DistribuidorId)
        public async Task<List<OrdenDeVenta>> ObtenerOrdenesDeVentaPorEmpleadoId(int empleadoId)
        {
            return await _context.OrdenDeVenta
                .Where(c => c.EmpleadoId == empleadoId)
                .ToListAsync();
        }
        public async Task<List<OrdenDeVenta>> ObtenerOrdenesDeVentaPorClienteId(int clienteId)
        {
            return await _context.OrdenDeVenta
                .Where(c => c.ClienteId == clienteId)
                .ToListAsync();
        }
        public async Task<List<OrdenDeVenta>> ObtenerOrdenesDeVentaPorDistribuidoraId(int distribuidoraId)
        {
            return await _context.OrdenDeVenta
                .Where(c => c.DistribuidorId == distribuidoraId)
                .ToListAsync();
        }
    }
}
