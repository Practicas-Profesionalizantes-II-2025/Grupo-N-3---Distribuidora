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
            return await _context.OrdenDeCompra
              .Include(o => o.Productos) 
                  .ThenInclude(op => op.Producto)   
              .Include(o => o.Empleado)
              .Include(o => o.Proveedor)
              .ToListAsync();
        }
        public async Task<OrdenDeCompra> ObtenerOrdenDeCompraPorId(int id)
        {
            return await _context.OrdenDeCompra
               .Include(o => o.Productos)
                   .ThenInclude(op => op.Producto)
               .Include(o => o.Empleado)
               .Include(o => o.Proveedor)
               .FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task<OrdenDeCompra> CrearOrdenDeCompra(OrdenDeCompra ordenDeCompra)
        {
            _context.OrdenDeCompra.Add(ordenDeCompra);
            await _context.SaveChangesAsync();
            return ordenDeCompra;
        }
        public void ActualizarOrdenDeCompra(OrdenDeCompra ordenDeCompra)
        {
            var existente = _context.OrdenDeCompra
                           .Include(o => o.Productos)
                           .FirstOrDefault(o => o.Id == ordenDeCompra.Id);

            if (existente == null)
                throw new Exception("Orden de Compra no encontrada.");

            existente.FechaOrden = ordenDeCompra.FechaOrden;
            existente.EmpleadoId = ordenDeCompra.EmpleadoId;
            existente.ProveedorId = ordenDeCompra.ProveedorId;
            existente.Estado = ordenDeCompra.Estado;

            existente.Productos.Clear();

            foreach (var p in ordenDeCompra.Productos)
            {
                existente.Productos.Add(new OrdenDeCompraProducto
                {
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto
                });
            }

            _context.SaveChanges();
        }
        public void EliminarOrdenDeCompra(int id)
        {
            var orden = _context.OrdenDeCompra
                .Include(o => o.Productos) 
                .FirstOrDefault(x => x.Id == id);
            if (orden != null)
            {
                _context.OrdenDeCompra.Remove(orden);
                _context.SaveChanges();
            }
        }

        // Obtener lista de Ordenes de Compra segun el atributo de clave foranea (EmpleadoId, ClienteId, DistribuidorId)
        public async Task<List<OrdenDeCompra>> ObtenerOrdenesDeCompraPorDistribuidorId(int proveedorId)
        {
            return await _context.OrdenDeCompra
                  .Include(o => o.Productos)
                      .ThenInclude(op => op.Producto)
                  .Include(o => o.Empleado)
                  .Include(o => o.Proveedor)
                  .Where(c => c.ProveedorId == proveedorId)
                  .ToListAsync();
        }
        public async Task<List<OrdenDeCompra>> ObtenerOrdenesDeCompraPorEmpleadoId(int empleadoId)
        {
            return await _context.OrdenDeCompra
                 .Include(o => o.Productos)
                     .ThenInclude(op => op.Producto)
                 .Include(o => o.Empleado)
                 .Include(o => o.Proveedor)
                 .Where(c => c.EmpleadoId == empleadoId)
                 .ToListAsync();
        }
        public async Task<List<OrdenDeCompra>> ObtenerOrdenesDeCompraPorFecha(DateTime fecha)
        {
            return await _context.OrdenDeCompra
               .Include(o => o.Productos)
                   .ThenInclude(op => op.Producto)
               .Include(o => o.Empleado)
               .Include(o => o.Proveedor)
               .Where(c => c.FechaOrden == fecha)
               .ToListAsync();
        }
    }
}
