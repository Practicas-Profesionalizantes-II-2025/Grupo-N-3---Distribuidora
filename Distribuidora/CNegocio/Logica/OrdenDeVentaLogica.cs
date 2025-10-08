using CDatos.Repositorios;
using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica
{
    public class OrdenDeVentaLogica : IOrdenDeVentaLogica
    {
        private readonly IOrdenDeVentaRepositorio _ordenDeVentaRepositorio;
        private readonly IProductoRepositorio _productoRepositorio;
        public OrdenDeVentaLogica(IOrdenDeVentaRepositorio ordenDeVentaRepositorio, IProductoRepositorio productoRepositorio)
        {
            _ordenDeVentaRepositorio = ordenDeVentaRepositorio;
            _productoRepositorio = productoRepositorio;
        }
        #region obtener ordenes
        public async Task<List<OrdenDeVentaDTO>> ObtenerOrdenesDeVenta()
        {
            var ordenes = await _ordenDeVentaRepositorio.ObtenerOrdenesDeVenta();
            return ordenes.Select(o => new OrdenDeVentaDTO
            {
                Id = o.Id,
                Fecha = o.Fecha,
                EmpleadoId = o.EmpleadoId,
                ClienteId = o.ClienteId,
                Estado = o.Estado,
                DistribuidorId = o.DistribuidorId,
                ProductosSeleccionados = o.Productos.Select(p => new OrdenDeVentaProductoDTO
                {
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto,
                    NombreProducto = p.Producto.Nombre,
                    PrecioUnitario = p.Producto.PrecioProducto,
                }).ToList()
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
                EmpleadoId = o.EmpleadoId,
                ClienteId = o.ClienteId,
            }).ToList();
        }
        public async Task<List<OrdenDeVentaDTO>> ObtenerOrdenesDeVentaPorClienteId(int clienteId)
        {
            var ordenesDeVenta = await _ordenDeVentaRepositorio.ObtenerOrdenesDeVentaPorClienteId(clienteId);
            return ordenesDeVenta.Select(o => new OrdenDeVentaDTO
            {
                Id = o.Id,
                Fecha = o.Fecha,
                EmpleadoId = o.EmpleadoId,
                ClienteId = o.ClienteId,
            }).ToList();
        }
        public async Task<List<OrdenDeVentaDTO>> ObtenerOrdenesDeVentaPorDistribuidoraId(int distribuidorId)
        {
            var ordenesDeVenta = await _ordenDeVentaRepositorio.ObtenerOrdenesDeVentaPorDistribuidoraId(distribuidorId);
            return ordenesDeVenta.Select(o => new OrdenDeVentaDTO
            {
                Id = o.Id,
                Fecha = o.Fecha,
                EmpleadoId = o.EmpleadoId,
                ClienteId = o.ClienteId,
            }).ToList();
        }

        //------------------------------------------------------------------------------------------------//
        public async Task<OrdenDeVentaDTO> ObtenerOrdenDeVentaPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la orden debe ser mayor que cero.");

            var ordenDeCompra = await _ordenDeVentaRepositorio.ObtenerOrdenDeVentaPorId(id);
            if (ordenDeCompra == null)
                throw new ArgumentException($"No se encontró una orden con el ID {id}");

            return new OrdenDeVentaDTO
            {
                Id = ordenDeCompra.Id,
                Fecha = ordenDeCompra.Fecha,
                EmpleadoId = ordenDeCompra.EmpleadoId,
                ClienteId = ordenDeCompra.ClienteId,
                Estado = ordenDeCompra.Estado,
                DistribuidorId = ordenDeCompra.DistribuidorId,
                ProductosSeleccionados = ordenDeCompra.Productos.Select(p => new OrdenDeVentaProductoDTO
                {
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto,
                    NombreProducto = p.Producto.Nombre,
                    PrecioUnitario = p.Producto.PrecioProducto,
                }).ToList()
            };
        }
        #endregion obtener ordenes
        public async Task CrearOrdenDeVenta(OrdenDeVentaDTO ordenDeVentaDTO)
        {
            if (ordenDeVentaDTO == null)
                throw new ArgumentNullException(nameof(ordenDeVentaDTO));

            if (ordenDeVentaDTO.EmpleadoId <= 0)
                throw new ArgumentException("El ID del empleado debe ser mayor que cero.", nameof(ordenDeVentaDTO.EmpleadoId));

            if (ordenDeVentaDTO.DistribuidorId <= 0)
                throw new ArgumentException("El ID del proveedor debe ser mayor que cero.", nameof(ordenDeVentaDTO.DistribuidorId));

            if (ordenDeVentaDTO.Fecha == default)
                throw new ArgumentException("La fecha de la orden no es válida.", nameof(ordenDeVentaDTO.Fecha));
            List<string> camposErroneos = new List<string>();

            if (ordenDeVentaDTO.EmpleadoId <= 0)
                camposErroneos.Add("EmpleadoId");

            if (ordenDeVentaDTO.DistribuidorId <= 0)
                camposErroneos.Add("DistribuidorId");

            if (ordenDeVentaDTO.Fecha == default)
                camposErroneos.Add("FechaOrden");

            if (camposErroneos.Count > 0)
                throw new ArgumentException("Los siguientes campos son inválidos: " + string.Join(", ", camposErroneos));

            var orden = new OrdenDeVenta
            {
                EmpleadoId = ordenDeVentaDTO.EmpleadoId,
                DistribuidorId = ordenDeVentaDTO.DistribuidorId,
                ClienteId = ordenDeVentaDTO.ClienteId,
                Fecha = ordenDeVentaDTO.Fecha,
                Estado = ordenDeVentaDTO.Estado = "Pendiente",
                Productos = ordenDeVentaDTO.ProductosSeleccionados.Select(p => new OrdenDeVentaProducto
                {
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto
                }).ToList()
            };

            await _ordenDeVentaRepositorio.CrearOrdenDeVenta(orden);
        }
        public async Task ActualizarOrdenDeVenta(OrdenDeVentaDTO ordenDeVentaDTO)
        {
            if (ordenDeVentaDTO == null)
                throw new ArgumentNullException(nameof(ordenDeVentaDTO));

            var ordenExistente = await _ordenDeVentaRepositorio.ObtenerOrdenDeVentaPorId(ordenDeVentaDTO.Id);
            if (ordenExistente == null)
                throw new Exception("Orden de Compra no encontrada.");

            bool cambioAEntregado = ordenExistente.Estado != "Entregado" && ordenDeVentaDTO.Estado == "Entregado";

            var orden = new OrdenDeVenta
            {
                Id = ordenDeVentaDTO.Id,
                EmpleadoId = ordenDeVentaDTO.EmpleadoId,
                DistribuidorId = ordenDeVentaDTO.DistribuidorId,
                Fecha = ordenDeVentaDTO.Fecha,
                ClienteId = ordenDeVentaDTO.ClienteId,
                Estado = ordenDeVentaDTO.Estado,
                Productos = ordenDeVentaDTO.ProductosSeleccionados.Select(p => new OrdenDeVentaProducto
                {
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto
                }).ToList()
            };

            _ordenDeVentaRepositorio.ActualizarOrdenDeVenta(orden);

            if (cambioAEntregado)
            {
                foreach (var prod in orden.Productos)
                {
                    var producto = await _productoRepositorio.ObtenerProductoPorId(prod.ProductoId);
                    if (producto != null)
                    {
                        producto.Stock += prod.CantidadProducto;
                        await _productoRepositorio.ActualizarProducto(producto);
                    }
                }
            }
        }
        public async Task EliminarOrdenDeVenta(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));

            var existente = await _ordenDeVentaRepositorio.ObtenerOrdenDeVentaPorId(id);
            if (existente == null)
                throw new KeyNotFoundException($"No se encontró una orden de compra con ID {id}.");

            _ordenDeVentaRepositorio.EliminarOrdenDeVenta(id);
        }
    }
}