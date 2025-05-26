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
    public class OrdenDeCompraLogica : IOrdenDeCompraLogica
    {
        private readonly IOrdenDeCompraRepositorio  _ordenDeCompraRepositorio;
        public OrdenDeCompraLogica(IOrdenDeCompraRepositorio ordenDeCompraRepositorio)
        {
            _ordenDeCompraRepositorio = ordenDeCompraRepositorio;
        }
        public async Task<List<OrdenDeCompraDTO>> ObtenerOrdenesDeCompra()
        {
            var ordenesDeCompra = await _ordenDeCompraRepositorio.ObtenerOrdenesDeCompra();
            return ordenesDeCompra.Select(o => new OrdenDeCompraDTO
            {
                EmpleadoId = o.EmpleadoId,
                DistribuidorId = o.DistribuidorId,
                FechaOrden = o.FechaOrden
            }).ToList();
        }
        public async Task<OrdenDeCompraDTO> ObtenerOrdenDeCompraPorId(int id)
        {
            var ordenDeCompra = await _ordenDeCompraRepositorio.ObtenerOrdenDeCompraPorId(id);
            if (ordenDeCompra == null) return null;
            return new OrdenDeCompraDTO
            {
                EmpleadoId = ordenDeCompra.EmpleadoId,
                DistribuidorId = ordenDeCompra.DistribuidorId,
                FechaOrden = ordenDeCompra.FechaOrden
            };
        }
        public async Task<List<OrdenDeCompraDTO>> ObtenerOrdenesDeCompraPorDistribuidorId(int distribuidorId)
        {
            var ordenesDeCompra = await _ordenDeCompraRepositorio.ObtenerOrdenesDeCompraPorDistribuidorId(distribuidorId);
            return ordenesDeCompra.Select(o => new OrdenDeCompraDTO
            {
                EmpleadoId = o.EmpleadoId,
                DistribuidorId = o.DistribuidorId,
                FechaOrden = o.FechaOrden
            }).ToList();
        }
        public async Task<List<OrdenDeCompraDTO>> ObtenerOrdenesDeCompraPorEmpleadoId(int empleadoId)
        {
            var ordenesDeCompra = await _ordenDeCompraRepositorio.ObtenerOrdenesDeCompraPorEmpleadoId(empleadoId);
            return ordenesDeCompra.Select(o => new OrdenDeCompraDTO
            {
                EmpleadoId = o.EmpleadoId,
                DistribuidorId = o.DistribuidorId,
                FechaOrden = o.FechaOrden
            }).ToList();
        }
        public async Task CrearOrdenDeCompra(OrdenDeCompraDTO ordenDeCompraDTO)
        {
            var ordenDeCompra = new OrdenDeCompra
            {
                EmpleadoId = ordenDeCompraDTO.EmpleadoId,
                DistribuidorId = ordenDeCompraDTO.DistribuidorId,
                FechaOrden = ordenDeCompraDTO.FechaOrden
            };
            _ordenDeCompraRepositorio.CrearOrdenDeCompra(ordenDeCompra);
        }
        public async Task ActualizarOrdenDeCompra(OrdenDeCompraDTO ordenDeCompraDTO)
        {
            var ordenDeCompra = new OrdenDeCompra
            {
                Id = ordenDeCompraDTO.Id,
                EmpleadoId = ordenDeCompraDTO.EmpleadoId,
                DistribuidorId = ordenDeCompraDTO.DistribuidorId,
                FechaOrden = ordenDeCompraDTO.FechaOrden
            };
            _ordenDeCompraRepositorio.ActualizarOrdenDeCompra(ordenDeCompra);
        }
        public async Task EliminarOrdenDeCompra(int id)
        {
            _ordenDeCompraRepositorio.EliminarOrdenDeCompra(id);
        }
    }
}
