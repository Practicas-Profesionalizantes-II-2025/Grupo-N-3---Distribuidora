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
    public class OrdenDeVentaLogica : IOrdenDeVentaLogica
    {
        private readonly IOrdenDeVentaRepositorio _ordenDeVentaRepositorio;
        public OrdenDeVentaLogica(IOrdenDeVentaRepositorio ordenDeVentaRepositorio)
        {
            _ordenDeVentaRepositorio = ordenDeVentaRepositorio;
        }
        public async Task<List<OrdenDeVentaDTO>> ObtenerOrdenesDeVenta()
        {
            var ordenesDeVenta = await _ordenDeVentaRepositorio.ObtenerOrdenesDeVenta();
            return ordenesDeVenta.Select(o => new OrdenDeVentaDTO
            {
                Id = o.Id,
                Fecha = o.Fecha,
                FacturaId = o.FacturaId,
                EmpleadoId = o.EmpleadoId,
                ClienteId = o.ClienteId,
                DistribuidorId = o.DistribuidorId
            }).ToList();
        }

        //  Obtener lista a travez de claves foraneas
        public async Task<List<OrdenDeVentaDTO>> ObtenerOrdenesDeVentaPorEmpleadoId(int empleadoId)
        {
            var ordenesDeVenta = await _ordenDeVentaRepositorio.ObtenerOrdenesDeVentaPorEmpleadoId(empleadoId);
            return ordenesDeVenta.Select(o => new OrdenDeVentaDTO
            {
                Id = o.Id,
                Fecha = o.Fecha,
                FacturaId = o.FacturaId,
                EmpleadoId = o.EmpleadoId,
                ClienteId = o.ClienteId,
                DistribuidorId = o.DistribuidorId
            }).ToList();
        }
        public async Task<List<OrdenDeVentaDTO>> ObtenerOrdenesDeVentaPorClienteId(int clienteId)
        {
            var ordenesDeVenta = await _ordenDeVentaRepositorio.ObtenerOrdenesDeVentaPorClienteId(clienteId);
            return ordenesDeVenta.Select(o => new OrdenDeVentaDTO
            {
                Id = o.Id,
                Fecha = o.Fecha,
                FacturaId = o.FacturaId,
                EmpleadoId = o.EmpleadoId,
                ClienteId = o.ClienteId,
                DistribuidorId = o.DistribuidorId
            }).ToList();
        }
        public async Task<List<OrdenDeVentaDTO>> ObtenerOrdenesDeVentaPorDistribuidoraId(int distribuidorId)
        {
            var ordenesDeVenta = await _ordenDeVentaRepositorio.ObtenerOrdenesDeVentaPorDistribuidoraId(distribuidorId);
            return ordenesDeVenta.Select(o => new OrdenDeVentaDTO
            {
                Id = o.Id,
                Fecha = o.Fecha,
                FacturaId = o.FacturaId,
                EmpleadoId = o.EmpleadoId,
                ClienteId = o.ClienteId,
                DistribuidorId = o.DistribuidorId
            }).ToList();
        }

        //------------------------------------------------------------------------------------------------//
        public async Task<OrdenDeVentaDTO> ObtenerOrdenDeVentaPorId(int id)
        {
            var ordenDeVenta = await _ordenDeVentaRepositorio.ObtenerOrdenDeVentaPorId(id);
            if (ordenDeVenta == null) return null;
            return new OrdenDeVentaDTO
            {
                Id = ordenDeVenta.Id,
                Fecha = ordenDeVenta.Fecha,
                FacturaId = ordenDeVenta.FacturaId,
                EmpleadoId = ordenDeVenta.EmpleadoId,
                ClienteId = ordenDeVenta.ClienteId,
                DistribuidorId = ordenDeVenta.DistribuidorId
            };
        }
        public async Task CrearOrdenDeVenta(OrdenDeVentaDTO ordenDeVentaDTO)
        {
            var ordenDeVenta = new OrdenDeVenta
            {
                Fecha = ordenDeVentaDTO.Fecha,
                FacturaId = ordenDeVentaDTO.FacturaId,
                EmpleadoId = ordenDeVentaDTO.EmpleadoId,
                ClienteId = ordenDeVentaDTO.ClienteId,
                DistribuidorId = ordenDeVentaDTO.DistribuidorId
            };
            await _ordenDeVentaRepositorio.CrearOrdenDeVenta(ordenDeVenta);
        }
        public async Task ActualizarOrdenDeVenta(OrdenDeVentaDTO ordenDeVentaDTO)
        {
            var ordenDeVenta = new OrdenDeVenta
            {
                Id = ordenDeVentaDTO.Id,
                Fecha = ordenDeVentaDTO.Fecha,
                FacturaId = ordenDeVentaDTO.FacturaId,
                EmpleadoId = ordenDeVentaDTO.EmpleadoId,
                ClienteId = ordenDeVentaDTO.ClienteId,
                DistribuidorId = ordenDeVentaDTO.DistribuidorId
            };
            await _ordenDeVentaRepositorio.ActualizarOrdenDeVenta(ordenDeVenta);
        }
        public async Task EliminarOrdenDeVenta(int id)
        {
            await _ordenDeVentaRepositorio.EliminarOrdenDeVentaAsync(id);
        }
    }
}