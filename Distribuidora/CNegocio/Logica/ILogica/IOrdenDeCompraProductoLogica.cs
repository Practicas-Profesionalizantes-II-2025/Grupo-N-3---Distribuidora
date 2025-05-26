using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace CNegocio.Logica.ILogica
{
    public interface IOrdenDeCompraProductoLogica
    {
        Task<List<OrdenDeCompraProductoDTO>> ObtenerOrdenCompraProductos();
        Task<OrdenDeCompraProductoDTO> ObtenerOrdenCompraProductoPorId(int id);
        Task CrearOrdenCompraProducto(OrdenDeCompraProductoDTO OrdenDeCompraProductoDTO);
        Task ActualizarOrdenCompraProducto(OrdenDeCompraProductoDTO OrdenDeCompraProductoDTO);
        Task EliminarOrdenCompraProducto(int id);
        Task<List<OrdenDeCompraProductoDTO>> ObtenerOrdenesDeCompraProductoPorOrdenDeCompraId(int ordenDeCompraId);
    }
}
