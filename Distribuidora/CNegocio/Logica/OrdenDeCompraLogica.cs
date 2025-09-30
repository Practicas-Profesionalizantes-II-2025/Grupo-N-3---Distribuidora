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
    public class OrdenDeCompraLogica : IOrdenDeCompraLogica
    {
        private readonly IOrdenDeCompraRepositorio _ordenDeCompraRepositorio;

        public OrdenDeCompraLogica(IOrdenDeCompraRepositorio ordenDeCompraRepositorio)
        {
            _ordenDeCompraRepositorio = ordenDeCompraRepositorio ?? throw new ArgumentNullException(nameof(ordenDeCompraRepositorio));
        }

        #region obtener ordenes
        public async Task<List<OrdenDeCompraDTO>> ObtenerOrdenesDeCompra()
        {
            var ordenes = await _ordenDeCompraRepositorio.ObtenerOrdenesDeCompra();
            return ordenes.Select(o => new OrdenDeCompraDTO
            {
                Id = o.Id,
                FechaOrden = o.FechaOrden,
                EmpleadoId = o.EmpleadoId,
                Empleado = o.Empleado == null ? null : new EmpleadoDTO
                {
                    Id = o.Empleado.Id,
                    PersonaId = o.Empleado.PersonaId,
                    Foto = o.Empleado.Foto,
                    EstadoId = o.Empleado.EstadoId,
                    Persona = new PersonaDTO
                    {
                        Nombre = o.Empleado.Persona.Nombre,
                        Apellido = o.Empleado.Persona.Apellido,
                    }
                },
                DistribuidorId = o.DistribuidorId,
                Distribuidor = o.Distribuidor == null ? null : new ProveedorDTO
                {
                    Id = o.Distribuidor.Id,
                    Nombre = o.Distribuidor.Nombre
                }
            }).ToList();
        }

        public async Task<OrdenDeCompraDTO> ObtenerOrdenDeCompraPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la orden debe ser mayor que cero.");

            var ordenDeCompra = await _ordenDeCompraRepositorio.ObtenerOrdenDeCompraPorId(id);
            if (ordenDeCompra == null)
                throw new ArgumentException($"No se encontró una orden con el ID {id}");

            return new OrdenDeCompraDTO
            {
                Id = ordenDeCompra.Id,
                FechaOrden = ordenDeCompra.FechaOrden,
                EmpleadoId = ordenDeCompra.EmpleadoId,
                Empleado = ordenDeCompra.Empleado?.Persona == null ? null : new EmpleadoDTO
                {
                    Id = ordenDeCompra.Empleado.Id,
                    PersonaId = ordenDeCompra.Empleado.PersonaId,
                    Persona = new PersonaDTO
                    {
                        Nombre = ordenDeCompra.Empleado.Persona?.Nombre,
                        Apellido = ordenDeCompra.Empleado.Persona?.Apellido
                    }
                },
                DistribuidorId = ordenDeCompra.DistribuidorId,
                Distribuidor = ordenDeCompra.Distribuidor == null ? null : new ProveedorDTO
                {
                    Id = ordenDeCompra.Distribuidor.Id,
                    Nombre = ordenDeCompra.Distribuidor.Nombre
                }
            };
        }

        public async Task<List<OrdenDeCompraDTO>> ObtenerOrdenesDeCompraPorDistribuidorId(int distribuidorId)
        {
            if (distribuidorId <= 0)
                throw new ArgumentException("El ID del distribuidor debe ser mayor a 0.");

            var ordenesDeCompra = await _ordenDeCompraRepositorio.ObtenerOrdenesDeCompraPorDistribuidorId(distribuidorId);
            return ordenesDeCompra.Select(o => new OrdenDeCompraDTO
            {
                Id = o.Id,
                FechaOrden = o.FechaOrden,
                EmpleadoId = o.EmpleadoId,
                Empleado = o.Empleado?.Persona == null ? null : new EmpleadoDTO
                {
                    Id = o.Empleado.Id,
                    Persona = new PersonaDTO
                    {
                        Nombre = o.Empleado.Persona.Nombre,
                        Apellido = o.Empleado.Persona.Apellido
                    }
                },
                DistribuidorId = o.DistribuidorId,
                Distribuidor = o.Distribuidor == null ? null : new ProveedorDTO
                {
                    Id = o.Distribuidor.Id,
                    Nombre = o.Distribuidor.Nombre
                }
            }).ToList();
        }

        public async Task<List<OrdenDeCompraDTO>> ObtenerOrdenesDeCompraPorEmpleadoId(int empleadoId)
        {
            if (empleadoId <= 0)
                throw new ArgumentException("El ID del empleado debe ser mayor a 0.");

            var ordenesDeCompra = await _ordenDeCompraRepositorio.ObtenerOrdenesDeCompraPorEmpleadoId(empleadoId);
            return ordenesDeCompra.Select(o => new OrdenDeCompraDTO
            {
                Id = o.Id,
                FechaOrden = o.FechaOrden,
                EmpleadoId = o.EmpleadoId,
                Empleado = o.Empleado?.Persona == null ? null : new EmpleadoDTO
                {
                    Id = o.Empleado.Id,
                    PersonaId = o.Empleado.PersonaId,
                    Persona = new PersonaDTO
                    {
                        Nombre = o.Empleado.Persona?.Nombre,
                        Apellido = o.Empleado.Persona?.Apellido
                    }
                },
                DistribuidorId = o.DistribuidorId,
                Distribuidor = o.Distribuidor == null ? null : new ProveedorDTO
                {
                    Id = o.Distribuidor.Id,
                    Nombre = o.Distribuidor.Nombre
                }
            }).ToList();
        }
        #endregion obtener ordenes
        public async Task CrearOrdenDeCompra(OrdenDeCompraDTO ordenDeCompraDTO)
        {
            if (ordenDeCompraDTO == null)
                throw new ArgumentNullException(nameof(ordenDeCompraDTO));

            if (ordenDeCompraDTO.EmpleadoId <= 0)
                throw new ArgumentException("El ID del empleado debe ser mayor que cero.", nameof(ordenDeCompraDTO.EmpleadoId));

            if (ordenDeCompraDTO.DistribuidorId <= 0)
                throw new ArgumentException("El ID del distribuidor debe ser mayor que cero.", nameof(ordenDeCompraDTO.DistribuidorId));

            if (ordenDeCompraDTO.FechaOrden == default)
                throw new ArgumentException("La fecha de la orden no es válida.", nameof(ordenDeCompraDTO.FechaOrden));
            List<string> camposErroneos = new List<string>();

            if (ordenDeCompraDTO.EmpleadoId <= 0)
                camposErroneos.Add("EmpleadoId");

            if (ordenDeCompraDTO.DistribuidorId <= 0)
                camposErroneos.Add("DistribuidorId");

            if (ordenDeCompraDTO.FechaOrden == default)
                camposErroneos.Add("FechaOrden");

            if (camposErroneos.Count > 0)
                throw new ArgumentException("Los siguientes campos son inválidos: " + string.Join(", ", camposErroneos));

            var orden = new OrdenDeCompra
            {
                EmpleadoId = ordenDeCompraDTO.EmpleadoId,
                DistribuidorId = ordenDeCompraDTO.DistribuidorId,
                FechaOrden = ordenDeCompraDTO.FechaOrden,
                Productos = ordenDeCompraDTO.Productos.Select(p => new OrdenDeCompraProducto
                {
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto
                }).ToList()
            };

            await _ordenDeCompraRepositorio.CrearOrdenDeCompra(orden);
        }

        public async Task ActualizarOrdenDeCompra(OrdenDeCompraDTO ordenDeCompraDTO)
        {
            if (ordenDeCompraDTO == null)
                throw new ArgumentNullException(nameof(ordenDeCompraDTO));

            if (ordenDeCompraDTO.Id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(ordenDeCompraDTO.Id));

            if (ordenDeCompraDTO.EmpleadoId <= 0)
                throw new ArgumentException("El ID del empleado debe ser mayor que cero.", nameof(ordenDeCompraDTO.EmpleadoId));

            if (ordenDeCompraDTO.DistribuidorId <= 0)
                throw new ArgumentException("El ID del distribuidor debe ser mayor que cero.", nameof(ordenDeCompraDTO.DistribuidorId));

            if (ordenDeCompraDTO.FechaOrden == default)
                throw new ArgumentException("La fecha de la orden no es válida.", nameof(ordenDeCompraDTO.FechaOrden));

            var existente = await _ordenDeCompraRepositorio.ObtenerOrdenDeCompraPorId(ordenDeCompraDTO.Id);
            if (existente == null)
                throw new KeyNotFoundException($"No se encontró una orden de compra con ID {ordenDeCompraDTO.Id}.");

            existente.EmpleadoId = ordenDeCompraDTO.EmpleadoId;
            existente.DistribuidorId = ordenDeCompraDTO.DistribuidorId;
            existente.FechaOrden = ordenDeCompraDTO.FechaOrden;

            _ordenDeCompraRepositorio.ActualizarOrdenDeCompra(existente);
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

        }

        public async Task EliminarOrdenDeCompra(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));

            var existente = await _ordenDeCompraRepositorio.ObtenerOrdenDeCompraPorId(id);
            if (existente == null)
                throw new KeyNotFoundException($"No se encontró una orden de compra con ID {id}.");

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
