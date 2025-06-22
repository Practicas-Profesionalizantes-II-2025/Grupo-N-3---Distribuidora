using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica
{
    public class ProductoLogica : IProductoLogica
    {
        private readonly IProductoRepositorio _IProductoRepositorio;
        public ProductoLogica(IProductoRepositorio IProductoRepositorio)
        {
            _IProductoRepositorio = IProductoRepositorio;
        }
        public async Task<List<ProductoDTO>> ObtenerProductos()
        {
            var productos = await _IProductoRepositorio.ObtenerProductos();
            return productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                PrecioProducto = p.PrecioProducto,
                Stock = p.Stock,
                ProveedorId = p.ProveedorId
            }).ToList();
        }
        public async Task<ProductoDTO> ObtenerProductoPorId(int id)
        {
            var producto = await _IProductoRepositorio.ObtenerProductoPorId(id);
            return new ProductoDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                PrecioProducto = producto.PrecioProducto,
                Stock = producto.Stock,
                ProveedorId = producto.ProveedorId
            };
        }
        public async Task CrearProducto(ProductoDTO productoDTO)
        {
            var producto = new Producto
            {
                Id = productoDTO.Id,
                Nombre = productoDTO.Nombre,
                PrecioProducto = productoDTO.PrecioProducto,
                Stock = productoDTO.Stock,
                ProveedorId = productoDTO.ProveedorId
            };
            await _IProductoRepositorio.CrearProducto(producto);
        }
        public async Task ActualizarProducto(ProductoDTO productoDTO)
        {
            var producto = new Producto
            {
                Id = productoDTO.Id,
                Nombre = productoDTO.Nombre,
                PrecioProducto = productoDTO.PrecioProducto,
                Stock = productoDTO.Stock,
                ProveedorId = productoDTO.ProveedorId
            };
            await _IProductoRepositorio.ActualizarProducto(producto);
        }
        public async Task EliminarProducto(int id)
        {
            await _IProductoRepositorio.EliminarProducto(id);
        }
        public async Task<List<ProductoDTO>> ObtenerProductosPorProveedorId(int proveedorId)
        {
            var productos = await _IProductoRepositorio.ObtenerProductosPorProveedorId(proveedorId);
            return productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                PrecioProducto = p.PrecioProducto,
                Stock = p.Stock,
                ProveedorId = p.ProveedorId
            }).ToList();
        }
        public async Task<List<ProductoDTO>> ObtenerProductosPorNombre(string nombre)
        {
            var productos = await _IProductoRepositorio.ObtenerProductosPorNombre(nombre);
            return productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                PrecioProducto = p.PrecioProducto,
                Stock = p.Stock,
                ProveedorId = p.ProveedorId
            }).ToList();
        }
        public async Task<List<ProductoDTO>> ObtenerProductosPorCategoriaId(int categoriaId)
        {
            var productos = await _IProductoRepositorio.ObtenerProductosPorCategoriaId(categoriaId);
            return productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                PrecioProducto = p.PrecioProducto,
                Stock = p.Stock,
                ProveedorId = p.ProveedorId
            }).ToList();
        }
    }
}
