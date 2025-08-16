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
            if (id <= 0)
                throw new ArgumentException("El Id de la orden debe ser mayor a 0");

            var ordenDeCompra = await _ordenDeCompraRepositorio.ObtenerOrdenDeCompraPorId(id);
            if (ordenDeCompra == null)
                throw new ArgumentException($"No se encontró una orden de compra con el ID {id}");

            return new OrdenDeCompraDTO
            {
                EmpleadoId = ordenDeCompra.EmpleadoId,
                DistribuidorId = ordenDeCompra.DistribuidorId,
                FechaOrden = ordenDeCompra.FechaOrden
            };
        }
        public async Task<List<OrdenDeCompraDTO>> ObtenerOrdenesDeCompraPorDistribuidorId(int distribuidorId)
        {
            if (distribuidorId <= 0)
                throw new ArgumentException("El ID del distribuidor debe ser mayor a 0.");

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
            if (empleadoId <= 0)
                throw new ArgumentException("El ID del empleado debe ser mayor a 0.");

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
            List<string> camposErroneos = new List<string>();

            if (ordenDeCompraDTO.EmpleadoId <= 0)
                camposErroneos.Add("EmpleadoId");

            if (ordenDeCompraDTO.DistribuidorId <= 0)
                camposErroneos.Add("DistribuidorId");

            if (ordenDeCompraDTO.FechaOrden == default)
                camposErroneos.Add("FechaOrden");

            if (camposErroneos.Count > 0)
                throw new ArgumentException("Los siguientes campos son inválidos: " + string.Join(", ", camposErroneos));

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
            List<string> camposErroneos = new List<string>();

            if (ordenDeCompraDTO.Id <= 0)
                camposErroneos.Add("Id");

            if (ordenDeCompraDTO.EmpleadoId <= 0)
                camposErroneos.Add("EmpleadoId");

            if (ordenDeCompraDTO.DistribuidorId <= 0)
                camposErroneos.Add("DistribuidorId");

            if (ordenDeCompraDTO.FechaOrden == default)
                camposErroneos.Add("FechaOrden");

            if (camposErroneos.Count > 0)
                throw new ArgumentException("Los siguientes campos son inválidos: " + string.Join(", ", camposErroneos));

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
            if (id <= 0)
                throw new ArgumentException("El ID de la orden debe ser mayor a 0.");

            _ordenDeCompraRepositorio.EliminarOrdenDeCompra(id);
        }
       
        #region Validaciones
        private bool FechaEsValida(DateTime fecha)
        {
            return fecha != default && fecha <= DateTime.Now;
        }
        #endregion Validaciones
    }
}
