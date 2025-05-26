using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.Repositorios;
using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using Shared.Entities;

namespace CNegocio.Logica
{
    public class OrdenDeVentaProductoLogica : IOrdenDeVentaProductoLogica
    {
        private readonly IOrdenDeVentaProductoRepositorio _IordenDeVentaProductoRepositorio;
        public OrdenDeVentaProductoLogica(IOrdenDeVentaProductoRepositorio _IordenDeVentaProductoRepositorio)
        {
            _IordenDeVentaProductoRepositorio = _IordenDeVentaProductoRepositorio;
        }
        public async Task<List<OrdenDeVentaProductoDTO>> ObtenerOrdenesDeVentaProductos()
        {
            var ordenesDeVentaProductos = await _IordenDeVentaProductoRepositorio.ObtenerOrdenesDeVentaProductos();
            return ordenesDeVentaProductos.Select(ovp => new OrdenDeVentaProductoDTO
            {
                Id = ovp.Id,
                ProductoId = ovp.ProductoId,
                CantidadProducto = ovp.CantidadProducto,
                OrdenVentaId = ovp.OrdenVentaId
            }).ToList();
        }
        public async Task<OrdenDeVentaProductoDTO> ObtenerOrdenDeVentaProductoPorId(int id)
        {
            var ordenDeVentaProducto = await _IordenDeVentaProductoRepositorio.ObtenerOrdenDeVentaProductoPorId(id);
            if (ordenDeVentaProducto == null)
            {
                return null;
            }
            return new OrdenDeVentaProductoDTO
            {
                Id = ordenDeVentaProducto.Id,
                ProductoId = ordenDeVentaProducto.ProductoId,
                CantidadProducto = ordenDeVentaProducto.CantidadProducto,
                OrdenVentaId = ordenDeVentaProducto.OrdenVentaId
            };
        }
        //  Obtener lista a travez de claves foraneas
        public async Task<List<OrdenDeVentaProductoDTO>> ObtenerOrdenesDeVentaProductosPorOrdenDeVentaId(int ordenDeVentaId)
        {
            var ordenesDeVentaProducto = await _IordenDeVentaProductoRepositorio.ObtenerOrdenesDeVentaProductosPorOrdenDeVentaId(ordenDeVentaId);
            return ordenesDeVentaProducto.Select(o => new OrdenDeVentaProductoDTO
            {
                Id = o.Id,
                ProductoId = o.ProductoId,
                CantidadProducto = o.CantidadProducto,
                OrdenVentaId = o.OrdenVentaId
            }).ToList();
        }
        public async Task CrearOrdenDeVentaProducto(OrdenDeVentaProductoDTO ordenDeVentaProducto)
        {
            var nuevoOrdenDeVentaProducto = new OrdenDeVentaProducto
            {
                ProductoId = ordenDeVentaProducto.ProductoId,
                CantidadProducto = ordenDeVentaProducto.CantidadProducto,
                OrdenVentaId = ordenDeVentaProducto.OrdenVentaId
            };
            await _IordenDeVentaProductoRepositorio.CrearOrdenDeVentaProducto(nuevoOrdenDeVentaProducto);
        }
        public async Task ActualizarOrdenDeVentaProducto(OrdenDeVentaProductoDTO ordenDeVentaProductoDTO)
        {
            var ordenDeVentaProducto = new OrdenDeVentaProducto
            {
                Id = ordenDeVentaProductoDTO.Id,
                ProductoId = ordenDeVentaProductoDTO.ProductoId,
                CantidadProducto = ordenDeVentaProductoDTO.CantidadProducto,
                OrdenVentaId = ordenDeVentaProductoDTO.OrdenVentaId
            };
            await _IordenDeVentaProductoRepositorio.ActualizarOrdenDeVentaProducto(ordenDeVentaProducto);
        }
        public async Task EliminarOrdenDeVentaProducto(int id)
        {
            await _IordenDeVentaProductoRepositorio.EliminarOrdenDeVentaProducto(id);
        }
    }
}
