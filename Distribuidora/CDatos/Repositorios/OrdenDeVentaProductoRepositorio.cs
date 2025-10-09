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
        public async Task<OrdenDeVentaProducto> CrearOrdenDeVentaProducto(OrdenDeVentaProducto ordenDeVentaProducto)
        {
            _context.OrdenDeVentaProducto.Add(ordenDeVentaProducto);
            await _context.SaveChangesAsync();
            return ordenDeVentaProducto;
        }
        public void ActualizarOrdenDeVentaProducto(OrdenDeVentaProducto ordenDeVentaProducto)
        {
            var ordenDeVentaProductoExistente = _context.OrdenDeVentaProducto.Find(ordenDeVentaProducto.Id);
            if (ordenDeVentaProductoExistente == null)
            {
                throw new Exception("Orden de Venta-Producto no encontrada.");
            }
            ordenDeVentaProductoExistente.ProductoId = ordenDeVentaProducto.ProductoId;
            ordenDeVentaProductoExistente.CantidadProducto = ordenDeVentaProducto.CantidadProducto;

            _context.SaveChangesAsync();
        }
        public void EliminarOrdenDeVentaProducto(int id)
        {
            var ordenDeVentaProducto = _context.OrdenDeVentaProducto.FirstOrDefault(x => x.Id == id);
            if (ordenDeVentaProducto != null)
            {
                _context.OrdenDeVentaProducto.Remove(ordenDeVentaProducto);
                _context.SaveChangesAsync();
            }
        }
        public async Task<List<OrdenDeVentaProducto>> ObtenerOrdenesDeVentaProductosPorOrdenDeVentaId(int ordenDeVentaId)
        {
            return await _context.OrdenDeVentaProducto
                .Where(ovp => ovp.OrdenDeVentaId == ordenDeVentaId)
                .ToListAsync();
        }
    }
}
