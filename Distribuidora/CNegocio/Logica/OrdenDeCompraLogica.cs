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
    public class OrdenDeCompraLogica : IOrdenDeCompraLogica
    {
        private readonly IOrdenDeCompraRepositorio _ordenDeCompraRepositorio;
        private readonly IProductoRepositorio _productoRepositorio;

        public OrdenDeCompraLogica(IOrdenDeCompraRepositorio ordenDeCompraRepositorio, IProductoRepositorio productoRepositorio)
        {
            _ordenDeCompraRepositorio = ordenDeCompraRepositorio ?? throw new ArgumentNullException(nameof(ordenDeCompraRepositorio));
            _productoRepositorio = productoRepositorio ?? throw new ArgumentNullException(nameof(productoRepositorio));
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
                Estado = o.Estado,
                ProveedorId = o.ProveedorId,
                ProductosSeleccionados = o.Productos.Select(p => new OrdenDeCompraProductoDTO
                {
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto,
                    NombreProducto = p.Producto.Nombre,
                    PrecioUnitario = p.Producto.PrecioProducto,
                }).ToList()
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
                Estado = ordenDeCompra.Estado,
                ProveedorId = ordenDeCompra.ProveedorId,
                ProductosSeleccionados = ordenDeCompra.Productos.Select(p => new OrdenDeCompraProductoDTO
                {
                    Id = p.Id,                           // ID del registro de la relación
                    OrdenDeCompraId = ordenDeCompra.Id,  // ID de la orden
                    ProductoId = p.ProductoId,           // ID del producto
                    CantidadProducto = p.CantidadProducto,
                    NombreProducto = p.Producto.Nombre,
                    PrecioUnitario = p.Producto.PrecioProducto,
                }).ToList()
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
                ProveedorId = o.ProveedorId,
                ProductosSeleccionados = o.Productos.Select(p => new OrdenDeCompraProductoDTO
                {
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto,
                    NombreProducto = p.Producto.Nombre,
                    PrecioUnitario = p.Producto.PrecioProducto
                }).ToList()
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
                ProveedorId = o.ProveedorId,
                ProductosSeleccionados = o.Productos.Select(p => new OrdenDeCompraProductoDTO
                {
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto,
                    NombreProducto = p.Producto.Nombre,
                    PrecioUnitario = p.Producto.PrecioProducto
                }).ToList()
            }).ToList();
        }
        #endregion obtener ordenes
        public async Task CrearOrdenDeCompra(OrdenDeCompraDTO ordenDeCompraDTO)
        {
            if (ordenDeCompraDTO == null)
                throw new ArgumentNullException(nameof(ordenDeCompraDTO));

            if (ordenDeCompraDTO.EmpleadoId <= 0)
                throw new ArgumentException("El ID del empleado debe ser mayor que cero.", nameof(ordenDeCompraDTO.EmpleadoId));

            if (ordenDeCompraDTO.ProveedorId <= 0)
                throw new ArgumentException("El ID del proveedor debe ser mayor que cero.", nameof(ordenDeCompraDTO.ProveedorId));

            if (ordenDeCompraDTO.FechaOrden == default)
                throw new ArgumentException("La fecha de la orden no es válida.", nameof(ordenDeCompraDTO.FechaOrden));
            List<string> camposErroneos = new List<string>();

            if (ordenDeCompraDTO.EmpleadoId <= 0)
                camposErroneos.Add("EmpleadoId");

            if (ordenDeCompraDTO.ProveedorId <= 0)
                camposErroneos.Add("DistribuidorId");

            if (ordenDeCompraDTO.FechaOrden == default)
                camposErroneos.Add("FechaOrden");

            if (camposErroneos.Count > 0)
                throw new ArgumentException("Los siguientes campos son inválidos: " + string.Join(", ", camposErroneos));

            var orden = new OrdenDeCompra
            {
                EmpleadoId = ordenDeCompraDTO.EmpleadoId,
                ProveedorId = ordenDeCompraDTO.ProveedorId,
                FechaOrden = ordenDeCompraDTO.FechaOrden,
                Estado = ordenDeCompraDTO.Estado = "Pendiente",
                Productos = ordenDeCompraDTO.ProductosSeleccionados.Select(p => new OrdenDeCompraProducto
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

            var ordenExistente = await _ordenDeCompraRepositorio.ObtenerOrdenDeCompraPorId(ordenDeCompraDTO.Id);
            if (ordenExistente == null)
                throw new Exception("Orden de Compra no encontrada.");

            bool cambioAEntregado = ordenExistente.Estado != "Entregado" && ordenDeCompraDTO.Estado == "Entregado";
            var orden = new OrdenDeCompra
            {
                Id = ordenDeCompraDTO.Id,
                EmpleadoId = ordenDeCompraDTO.EmpleadoId,
                ProveedorId = ordenDeCompraDTO.ProveedorId,
                FechaOrden = ordenDeCompraDTO.FechaOrden,
                Estado = ordenDeCompraDTO.Estado,
                Productos = ordenDeCompraDTO.ProductosSeleccionados.Select(p => new OrdenDeCompraProducto
                {
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto
                }).ToList()
            };

            _ordenDeCompraRepositorio.ActualizarOrdenDeCompra(orden);

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
