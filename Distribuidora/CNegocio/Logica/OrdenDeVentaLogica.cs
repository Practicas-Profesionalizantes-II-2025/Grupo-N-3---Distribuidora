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
            _ordenDeVentaRepositorio = ordenDeVentaRepositorio ?? throw new ArgumentNullException(nameof(ordenDeVentaRepositorio));
            _productoRepositorio = productoRepositorio ?? throw new ArgumentNullException(nameof(productoRepositorio));
        }
        #region obtener ordenes
        public async Task<List<OrdenDeVentaDTO>> ObtenerOrdenesDeVenta()
        {
            var ordenes = await _ordenDeVentaRepositorio.ObtenerOrdenesDeVenta();
            return ordenes.Select(o => new OrdenDeVentaDTO
            {
                Id = o.Id,
                FechaOrden = o.FechaOrden,
                EmpleadoId = o.EmpleadoId,
                Estado = o.Estado,
                DistribuidorId = o.DistribuidorId,
                ClienteId = o.ClienteId,
                ProductosSeleccionados = o.Productos.Select(p => new OrdenDeVentaProductoDTO
                {
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto,
                    NombreProducto = p.Producto.Nombre,
                    PrecioUnitario = p.Producto.PrecioProducto,
                }).ToList()
            }).ToList();
        }
        public async Task<OrdenDeVentaDTO> ObtenerOrdenDeVentaPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la orden debe ser mayor que cero.");

            var ordenDeVenta = await _ordenDeVentaRepositorio.ObtenerOrdenDeVentaPorId(id);
            if (ordenDeVenta == null)
                throw new ArgumentException($"No se encontró una orden con el ID {id}");

            return new OrdenDeVentaDTO
            {
                Id = ordenDeVenta.Id,
                FechaOrden = ordenDeVenta.FechaOrden,
                EmpleadoId = ordenDeVenta.EmpleadoId,
                Estado = ordenDeVenta.Estado,
                DistribuidorId = ordenDeVenta.DistribuidorId,
                ClienteId = ordenDeVenta.ClienteId,
                ProductosSeleccionados = ordenDeVenta.Productos.Select(p => new OrdenDeVentaProductoDTO
                {
                    Id = p.Id,
                    OrdenDeVentaId = ordenDeVenta.Id,
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto,
                    NombreProducto = p.Producto.Nombre,
                    PrecioUnitario = p.Producto.PrecioProducto,
                }).ToList()
            };
        }

        //  Obtener lista a travez de claves foraneas
        public async Task<List<OrdenDeVentaDTO>> ObtenerOrdenesDeVentaPorEmpleadoId(int empleadoId)
        {
            var ordenesDeVenta = await _ordenDeVentaRepositorio.ObtenerOrdenesDeVentaPorEmpleadoId(empleadoId);
            return ordenesDeVenta.Select(o => new OrdenDeVentaDTO
            {
                Id = o.Id,
                FechaOrden = o.FechaOrden,
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
                FechaOrden = o.FechaOrden,
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
                FechaOrden = o.FechaOrden,
                EmpleadoId = o.EmpleadoId,
                ClienteId = o.ClienteId,
            }).ToList();
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

            if (ordenDeVentaDTO.FechaOrden == default)
                throw new ArgumentException("La fecha de la orden no es válida.", nameof(ordenDeVentaDTO.FechaOrden));
            List<string> camposErroneos = new List<string>();

            if (ordenDeVentaDTO.EmpleadoId <= 0)
                camposErroneos.Add("EmpleadoId");

            if (ordenDeVentaDTO.DistribuidorId <= 0)
                camposErroneos.Add("DistribuidorId");

            if (ordenDeVentaDTO.FechaOrden == default)
                camposErroneos.Add("FechaOrden");

            if (camposErroneos.Count > 0)
                throw new ArgumentException("Los siguientes campos son inválidos: " + string.Join(", ", camposErroneos));

            foreach (var productoSeleccionado in ordenDeVentaDTO.ProductosSeleccionados)
            {
                var producto = await _productoRepositorio.ObtenerProductoPorId(productoSeleccionado.ProductoId);

                if (producto == null)
                    throw new ArgumentException($"El producto con ID {productoSeleccionado.ProductoId} no existe.");

                if (productoSeleccionado.CantidadProducto > producto.Stock)
                    throw new InvalidOperationException(
                        $"Stock insuficiente para '{producto.Nombre}'. Disponible: {producto.Stock}, solicitado: {productoSeleccionado.CantidadProducto}.");
            }

            var orden = new OrdenDeVenta
            {
                EmpleadoId = ordenDeVentaDTO.EmpleadoId,
                DistribuidorId = ordenDeVentaDTO.DistribuidorId,
                ClienteId = ordenDeVentaDTO.ClienteId,
                FechaOrden = ordenDeVentaDTO.FechaOrden,
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
                ClienteId = ordenDeVentaDTO.ClienteId,
                FechaOrden = ordenDeVentaDTO.FechaOrden,
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
                        producto.Stock -= prod.CantidadProducto;
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