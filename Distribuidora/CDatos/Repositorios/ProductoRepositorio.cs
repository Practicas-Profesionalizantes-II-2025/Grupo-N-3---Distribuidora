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
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly DataContext _context;
        public ProductoRepositorio(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Producto>> ObtenerProductos()
        {
            return await _context.Productos.ToListAsync();
        }
        public async Task<Producto> ObtenerProductoPorId(int id)
        {
            return await _context.Productos.FindAsync(id);
        }
        public async Task CrearProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }
        public async Task ActualizarProducto(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }
        public async Task EliminarProducto(int id)
        {
            var producto = await ObtenerProductoPorId(id);
            if (producto != null)
            {
                var productoExistente = _context.Productos.Find(producto.Id);
                if (productoExistente == null)
                {
                    throw new Exception("Producto no encontrado.");
                }
                productoExistente.PrecioProducto = producto.PrecioProducto;
                productoExistente.UnidadesProducto = producto.UnidadesProducto;
                productoExistente.ProveedorId = producto.ProveedorId;
                productoExistente.Nombre = producto.Nombre;

                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Producto>> ObtenerProductosPorProveedorId(int proveedorId)
        {
            return await _context.Productos
                .Where(p => p.ProveedorId == proveedorId)
                .ToListAsync();
        }
        public async Task<List<Producto>> ObtenerProductosPorNombre(string nombre)
        {
            return await _context.Productos
                .Where(p => p.Nombre.Contains(nombre))
                .ToListAsync();
        }
        public async Task<List<Producto>> ObtenerProductosPorCategoriaId(int categoriaId)
        {
            return await _context.Productos
                .Where(p => p.CategoriaId == categoriaId)
                .ToListAsync();
        }
    }
}
