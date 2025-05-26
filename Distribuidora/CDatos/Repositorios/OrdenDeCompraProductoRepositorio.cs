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
    public class OrdenDeCompraProductoRepositorio : IOrdenDeCompraProductoRepositorio
    {
        private readonly DataContext _context;
        public OrdenDeCompraProductoRepositorio(DataContext context)
        {
            _context = context;
        }
        public async Task<List<OrdenDeCompraProducto>> ObtenerOrdenesDeCompraProducto()
        {
            return await _context.OrdenesDeCompraProducto.ToListAsync();
        }
        public async Task<OrdenDeCompraProducto> ObtenerOrdenDeCompraProductoPorId(int id)
        {
            return await _context.OrdenesDeCompraProducto.FindAsync(id);
        }
        public async Task<OrdenDeCompraProducto> CrearOrdenDeCompraProducto(OrdenDeCompraProducto ordenDeCompraProducto)
        {
            _context.OrdenesDeCompraProducto.Add(ordenDeCompraProducto);
            await _context.SaveChangesAsync();
            return ordenDeCompraProducto;
        }
        public void ActualizarOrdenDeCompraProducto(OrdenDeCompraProducto ordenDeCompraProducto)
        {
            var OrdenDeCompraProductoExistente = _context.OrdenesDeCompraProducto.Find(ordenDeCompraProducto.Id);
            if (OrdenDeCompraProductoExistente == null)
            {
                throw new Exception("Orden de Compra-Producto no encontrada.");
            }
            OrdenDeCompraProductoExistente.ProductoId = ordenDeCompraProducto.ProductoId;
            OrdenDeCompraProductoExistente.CantidadProducto = ordenDeCompraProducto.CantidadProducto;

            _context.SaveChanges();
        }
        public void EliminarOrdenDeCompraProducto(int id)
        {
            var ordenDeCompraProducto = _context.OrdenesDeCompraProducto.FirstOrDefault(x => x.Id == id);
            if (ordenDeCompraProducto != null)
            {
                _context.OrdenesDeCompraProducto.Remove(ordenDeCompraProducto);
                _context.SaveChanges();
            }
        }
        public async Task<List<OrdenDeCompraProducto>> ObtenerOrdenesDeCompraProductoPorOrdenDeCompraId(int ordenDeCompraId)
        {
            return await _context.OrdenesDeCompraProducto
                .Where(c => c.OrdenDeCompraId == ordenDeCompraId)
                .ToListAsync();
        }
    }
}
