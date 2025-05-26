using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace CNegocio.Logica
{
    public class OrdenDeCompraProductoLogica : IOrdenDeCompraProductoLogica
    {
        private readonly IOrdenDeCompraProductoRepositorio _ordenDeCompraProductoRepositorio;
        public OrdenDeCompraProductoLogica(IOrdenDeCompraProductoRepositorio ordenDeCompraProductoRepositorio)
        {
            _ordenDeCompraProductoRepositorio = ordenDeCompraProductoRepositorio;
        }
        public async Task<List<OrdenDeCompraProductoDTO>> ObtenerOrdenCompraProductos()
        {
            var ordenCompraProductos = await _ordenDeCompraProductoRepositorio.ObtenerOrdenesDeCompraProducto();
            return ordenCompraProductos.Select(o => new OrdenDeCompraProductoDTO
            {
                Id = o.Id,
                OrdenDeCompraId = o.OrdenDeCompraId,
                ProductoId = o.ProductoId,
                CantidadProducto = o.CantidadProducto
            }).ToList();
        }
        public async Task<OrdenDeCompraProductoDTO> ObtenerOrdenCompraProductoPorId(int id)
        {
            var ordenCompraProducto = await _ordenDeCompraProductoRepositorio.ObtenerOrdenDeCompraProductoPorId(id);
            if (ordenCompraProducto == null) return null;
            return new OrdenDeCompraProductoDTO
            {
                Id = ordenCompraProducto.Id,
                OrdenDeCompraId = ordenCompraProducto.OrdenDeCompraId,
                ProductoId = ordenCompraProducto.ProductoId,
                CantidadProducto = ordenCompraProducto.CantidadProducto
            };
        }
        public async Task CrearOrdenCompraProducto(OrdenDeCompraProductoDTO OrdenDeCompraProductoDTO)
        {
            var ordenCompraProducto = new OrdenDeCompraProducto
            {
                OrdenDeCompraId = OrdenDeCompraProductoDTO.OrdenDeCompraId,
                ProductoId = OrdenDeCompraProductoDTO.ProductoId,
                CantidadProducto = OrdenDeCompraProductoDTO.CantidadProducto
            };
            await _ordenDeCompraProductoRepositorio.CrearOrdenDeCompraProducto(ordenCompraProducto);
        }
        public async Task ActualizarOrdenCompraProducto(OrdenDeCompraProductoDTO OrdenDeCompraProductoDTO)
        {
            var ordenCompraProducto = new OrdenDeCompraProducto
            {
                Id = OrdenDeCompraProductoDTO.Id,
                OrdenDeCompraId = OrdenDeCompraProductoDTO.OrdenDeCompraId,
                ProductoId = OrdenDeCompraProductoDTO.ProductoId,
                CantidadProducto = OrdenDeCompraProductoDTO.CantidadProducto
            };
            _ordenDeCompraProductoRepositorio.ActualizarOrdenDeCompraProducto(ordenCompraProducto);
        }
        public async Task EliminarOrdenCompraProducto(int id)
        {
            _ordenDeCompraProductoRepositorio.EliminarOrdenDeCompraProducto(id);
        }
        public async Task<List<OrdenDeCompraProductoDTO>> ObtenerOrdenesDeCompraProductoPorOrdenDeCompraId(int ordenDeCompraId)
        {
            var ordenesDeCompraProducto = await _ordenDeCompraProductoRepositorio.ObtenerOrdenesDeCompraProductoPorOrdenDeCompraId(ordenDeCompraId);
            return ordenesDeCompraProducto.Select(o => new OrdenDeCompraProductoDTO
            {
                Id = o.Id,
                OrdenDeCompraId = o.OrdenDeCompraId,
                ProductoId = o.ProductoId,
                CantidadProducto = o.CantidadProducto
            }).ToList();
        }
    }
}
