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
    public class OrdenDeVentaProductoRepositorio : IOrdenDeVentaProductoRepositorio
    {
        private readonly DataContext _context;
        public OrdenDeVentaProductoRepositorio(DataContext context)
        {
            _context = context;
        }
        public async Task<List<OrdenDeVentaProducto>> ObtenerOrdenesDeVentaProductos()
        {
            return await _context.OrdenDeVentaProducto.ToListAsync();
        }
        public async Task<OrdenDeVentaProducto> ObtenerOrdenDeVentaProductoPorId(int id)
        {
            return await _context.OrdenDeVentaProducto.FindAsync(id);
        }
        public async Task CrearOrdenDeVentaProducto(OrdenDeVentaProducto ordenDeVentaProducto)
        {
            _context.OrdenDeVentaProducto.Add(ordenDeVentaProducto);
            await _context.SaveChangesAsync();
        }
        public async Task ActualizarOrdenDeVentaProducto(OrdenDeVentaProducto ordenDeVentaProducto)
        {
            var ordenDeVentaProductoExistente = _context.OrdenDeVentaProducto.Find(ordenDeVentaProducto.Id);
            if (ordenDeVentaProductoExistente == null)
            {
                throw new Exception("Orden de Venta-Producto no encontrada.");
            }
            ordenDeVentaProductoExistente.ProductoId = ordenDeVentaProducto.ProductoId;
            ordenDeVentaProductoExistente.CantidadProducto = ordenDeVentaProducto.CantidadProducto;

            await _context.SaveChangesAsync();
        }
        public async Task EliminarOrdenDeVentaProducto(int id)
        {
            var ordenDeVentaProducto = await ObtenerOrdenDeVentaProductoPorId(id);
            if (ordenDeVentaProducto != null)
            {
                _context.OrdenDeVentaProducto.Remove(ordenDeVentaProducto);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<OrdenDeVentaProducto>> ObtenerOrdenesDeVentaProductosPorOrdenDeVentaId(int ordenDeVentaId)
        {
            return await _context.OrdenDeVentaProducto
                .Where(ovp => ovp.OrdenVentaId == ordenDeVentaId)
                .ToListAsync();
        }
    }
}
