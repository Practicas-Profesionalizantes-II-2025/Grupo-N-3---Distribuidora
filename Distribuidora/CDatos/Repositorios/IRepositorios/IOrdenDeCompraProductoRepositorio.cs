using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace CDatos.Repositorios.IRepositorios
{
    public interface IOrdenDeCompraProductoRepositorio
    {
        Task<List<OrdenDeCompraProducto>> ObtenerOrdenesDeCompraProducto();
        Task<OrdenDeCompraProducto> ObtenerOrdenDeCompraProductoPorId(int id);
        Task<OrdenDeCompraProducto> CrearOrdenDeCompraProducto(OrdenDeCompraProducto ordenDeCompraProducto);
        void ActualizarOrdenDeCompraProducto(OrdenDeCompraProducto ordenDeCompraProducto);
        void EliminarOrdenDeCompraProducto(int id);
        Task<List<OrdenDeCompraProducto>> ObtenerOrdenesDeCompraProductoPorOrdenDeCompraId(int ordenDeCompraId);
    }
}
