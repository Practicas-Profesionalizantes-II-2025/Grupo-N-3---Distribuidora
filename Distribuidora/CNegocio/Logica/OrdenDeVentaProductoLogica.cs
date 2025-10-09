using CDatos.Repositorios;
using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNegocio.Logica
{
    public class OrdenDeVentaProductoLogica : IOrdenDeVentaProductoLogica
    {
        private readonly IOrdenDeVentaProductoRepositorio _ordenDeVentaProductoRepositorio;

        public OrdenDeVentaProductoLogica(IOrdenDeVentaProductoRepositorio ordenDeVentaProductoRepositorio)
        {
            _ordenDeVentaProductoRepositorio = ordenDeVentaProductoRepositorio ?? throw new ArgumentNullException(nameof(ordenDeVentaProductoRepositorio));
        }

        public async Task<List<OrdenDeVentaProductoDTO>> ObtenerOrdenesDeVentaProductos()
        {
            var ordenesDeVentaProductos = await _ordenDeVentaProductoRepositorio.ObtenerOrdenesDeVentaProductos();
            return ordenesDeVentaProductos.Select(o => new OrdenDeVentaProductoDTO
            {
                Id = o.Id,
                OrdenDeVentaId = o.OrdenDeVentaId,
                ProductoId = o.ProductoId,
                CantidadProducto = o.CantidadProducto
            }).ToList();
        }

        public async Task<OrdenDeVentaProductoDTO> ObtenerOrdenDeVentaProductoPorId(int id)
        {
            var ordenVentaProducto = await _ordenDeVentaProductoRepositorio.ObtenerOrdenDeVentaProductoPorId(id);
            if (ordenVentaProducto == null) return null;
            return new OrdenDeVentaProductoDTO
            {
                Id = ordenVentaProducto.Id,
                OrdenDeVentaId = ordenVentaProducto.OrdenDeVentaId,
                ProductoId = ordenVentaProducto.ProductoId,
                CantidadProducto = ordenVentaProducto.CantidadProducto
            };
        }

        public async Task<List<OrdenDeVentaProductoDTO>> ObtenerOrdenesDeVentaProductosPorOrdenDeVentaId(int ordenDeVentaId)
        {
            if (ordenDeVentaId <= 0)
                throw new ArgumentException("El ID de la orden de venta debe ser mayor que cero.", nameof(ordenDeVentaId));

            var ordenesDeVentaProducto = await _ordenDeVentaProductoRepositorio.ObtenerOrdenesDeVentaProductosPorOrdenDeVentaId(ordenDeVentaId);
            return ordenesDeVentaProducto.Select(o => new OrdenDeVentaProductoDTO
            {
                Id = o.Id,
                ProductoId = o.ProductoId,
                CantidadProducto = o.CantidadProducto,
                OrdenDeVentaId = o.OrdenDeVentaId
            }).ToList();
        }

        public async Task CrearOrdenDeVentaProducto(OrdenDeVentaProductoDTO ordenDeVentaProductoDTO)
        {
            if (ordenDeVentaProductoDTO == null)
                throw new ArgumentNullException(nameof(ordenDeVentaProductoDTO));

            if (ordenDeVentaProductoDTO.ProductoId <= 0)
                throw new ArgumentException("El ID del producto debe ser mayor que cero.", nameof(ordenDeVentaProductoDTO.ProductoId));

            if (ordenDeVentaProductoDTO.CantidadProducto <= 0)
                throw new ArgumentException("La cantidad del producto debe ser mayor que cero.", nameof(ordenDeVentaProductoDTO.CantidadProducto));

            var ordenDeVentaProducto = new OrdenDeVentaProducto
            {
                OrdenDeVentaId = ordenDeVentaProductoDTO.OrdenDeVentaId,
                ProductoId = ordenDeVentaProductoDTO.ProductoId,
                CantidadProducto = ordenDeVentaProductoDTO.CantidadProducto,

            };

            await _ordenDeVentaProductoRepositorio.CrearOrdenDeVentaProducto(ordenDeVentaProducto);
        }

        public async Task ActualizarOrdenDeVentaProducto(OrdenDeVentaProductoDTO ordenDeVentaProductoDTO)
        {
            if (ordenDeVentaProductoDTO == null)
                throw new ArgumentNullException(nameof(ordenDeVentaProductoDTO));

            if (ordenDeVentaProductoDTO.ProductoId <= 0)
                throw new ArgumentException("El ID del producto debe ser mayor que cero.", nameof(ordenDeVentaProductoDTO.ProductoId));

            if (ordenDeVentaProductoDTO.CantidadProducto <= 0)
                throw new ArgumentException("La cantidad del producto debe ser mayor que cero.", nameof(ordenDeVentaProductoDTO.CantidadProducto));

            var ordenDeVentaProducto = new OrdenDeVentaProducto
            {
                Id = ordenDeVentaProductoDTO.Id,
                ProductoId = ordenDeVentaProductoDTO.ProductoId,
                CantidadProducto = ordenDeVentaProductoDTO.CantidadProducto,
                OrdenDeVentaId = ordenDeVentaProductoDTO.OrdenDeVentaId,
            };
            _ordenDeVentaProductoRepositorio.ActualizarOrdenDeVentaProducto(ordenDeVentaProducto);
        }

        public async Task EliminarOrdenDeVentaProducto(int id)
        {
            _ordenDeVentaProductoRepositorio.EliminarOrdenDeVentaProducto(id);
        }
    }
}
