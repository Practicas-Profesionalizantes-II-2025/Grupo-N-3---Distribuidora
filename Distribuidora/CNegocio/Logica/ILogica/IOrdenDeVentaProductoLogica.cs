using Shared.DTOs;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica.ILogica
{
    public interface IOrdenDeVentaProductoLogica
    {
        Task<List<OrdenDeVentaProductoDTO>> ObtenerOrdenesDeVentaProductos();
        Task<OrdenDeVentaProductoDTO> ObtenerOrdenDeVentaProductoPorId(int id);
        Task CrearOrdenDeVentaProducto(OrdenDeVentaProductoDTO ordenDeVentaProducto);
        Task ActualizarOrdenDeVentaProducto(OrdenDeVentaProductoDTO ordenDeVentaProducto);
        Task EliminarOrdenDeVentaProducto(int id);
        Task<List<OrdenDeVentaProductoDTO>> ObtenerOrdenesDeVentaProductosPorOrdenDeVentaId(int ordenDeVentaId);
    }
}
