using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using Shared.Entities;

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
            return ordenesDeVentaProductos?.Select(ovp => new OrdenDeVentaProductoDTO
            {
                Id = ovp.Id,
                ProductoId = ovp.ProductoId,
                CantidadProducto = ovp.CantidadProducto,
                OrdenVentaId = ovp.OrdenVentaId
            }).ToList() ?? new List<OrdenDeVentaProductoDTO>();
        }

        public async Task<OrdenDeVentaProductoDTO> ObtenerOrdenDeVentaProductoPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));

            var ordenDeVentaProducto = await _ordenDeVentaProductoRepositorio.ObtenerOrdenDeVentaProductoPorId(id);
            if (ordenDeVentaProducto == null)
                throw new KeyNotFoundException($"No se encontró un registro con ID {id}.");

            return new OrdenDeVentaProductoDTO
            {
                Id = ordenDeVentaProducto.Id,
                ProductoId = ordenDeVentaProducto.ProductoId,
                CantidadProducto = ordenDeVentaProducto.CantidadProducto,
                OrdenVentaId = ordenDeVentaProducto.OrdenVentaId
            };
        }

        public async Task<List<OrdenDeVentaProductoDTO>> ObtenerOrdenesDeVentaProductosPorOrdenDeVentaId(int ordenDeVentaId)
        {
            if (ordenDeVentaId <= 0)
                throw new ArgumentException("El ID de la orden de venta debe ser mayor que cero.", nameof(ordenDeVentaId));

            var ordenesDeVentaProducto = await _ordenDeVentaProductoRepositorio.ObtenerOrdenesDeVentaProductosPorOrdenDeVentaId(ordenDeVentaId);
            return ordenesDeVentaProducto?.Select(o => new OrdenDeVentaProductoDTO
            {
                Id = o.Id,
                ProductoId = o.ProductoId,
                CantidadProducto = o.CantidadProducto,
                OrdenVentaId = o.OrdenVentaId
            }).ToList() ?? new List<OrdenDeVentaProductoDTO>();
        }

        public async Task CrearOrdenDeVentaProducto(OrdenDeVentaProductoDTO ordenDeVentaProductoDTO)
        {
            if (ordenDeVentaProductoDTO == null)
                throw new ArgumentNullException(nameof(ordenDeVentaProductoDTO));

            if (ordenDeVentaProductoDTO.ProductoId <= 0)
                throw new ArgumentException("El ID del producto debe ser mayor que cero.", nameof(ordenDeVentaProductoDTO.ProductoId));

            if (ordenDeVentaProductoDTO.OrdenVentaId <= 0)
                throw new ArgumentException("El ID de la orden de venta debe ser mayor que cero.", nameof(ordenDeVentaProductoDTO.OrdenVentaId));

            if (ordenDeVentaProductoDTO.CantidadProducto <= 0)
                throw new ArgumentException("La cantidad del producto debe ser mayor que cero.", nameof(ordenDeVentaProductoDTO.CantidadProducto));

            var nuevoOrdenDeVentaProducto = new OrdenDeVentaProducto
            {
                ProductoId = ordenDeVentaProductoDTO.ProductoId,
                CantidadProducto = ordenDeVentaProductoDTO.CantidadProducto,
                OrdenVentaId = ordenDeVentaProductoDTO.OrdenVentaId
            };

            await _ordenDeVentaProductoRepositorio.CrearOrdenDeVentaProducto(nuevoOrdenDeVentaProducto);
        }

        public async Task ActualizarOrdenDeVentaProducto(OrdenDeVentaProductoDTO ordenDeVentaProductoDTO)
        {
            if (ordenDeVentaProductoDTO == null)
                throw new ArgumentNullException(nameof(ordenDeVentaProductoDTO));

            if (ordenDeVentaProductoDTO.Id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(ordenDeVentaProductoDTO.Id));

            if (ordenDeVentaProductoDTO.ProductoId <= 0)
                throw new ArgumentException("El ID del producto debe ser mayor que cero.", nameof(ordenDeVentaProductoDTO.ProductoId));

            if (ordenDeVentaProductoDTO.OrdenVentaId <= 0)
                throw new ArgumentException("El ID de la orden de venta debe ser mayor que cero.", nameof(ordenDeVentaProductoDTO.OrdenVentaId));

            if (ordenDeVentaProductoDTO.CantidadProducto <= 0)
                throw new ArgumentException("La cantidad del producto debe ser mayor que cero.", nameof(ordenDeVentaProductoDTO.CantidadProducto));

            var existente = await _ordenDeVentaProductoRepositorio.ObtenerOrdenDeVentaProductoPorId(ordenDeVentaProductoDTO.Id);
            if (existente == null)
                throw new KeyNotFoundException($"No se encontró un registro con ID {ordenDeVentaProductoDTO.Id}.");

            existente.ProductoId = ordenDeVentaProductoDTO.ProductoId;
            existente.CantidadProducto = ordenDeVentaProductoDTO.CantidadProducto;
            existente.OrdenVentaId = ordenDeVentaProductoDTO.OrdenVentaId;

            await _ordenDeVentaProductoRepositorio.ActualizarOrdenDeVentaProducto(existente);
        }

        public async Task EliminarOrdenDeVentaProducto(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));

            var existente = await _ordenDeVentaProductoRepositorio.ObtenerOrdenDeVentaProductoPorId(id);
            if (existente == null)
                throw new KeyNotFoundException($"No se encontró un registro con ID {id}.");

            await _ordenDeVentaProductoRepositorio.EliminarOrdenDeVentaProducto(id);
        }
    }
}
