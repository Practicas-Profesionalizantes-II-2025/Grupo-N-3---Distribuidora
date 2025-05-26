using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.Repositorios;
using Shared.Entities;

namespace CDatos.Repositorios.IRepositorios
{
    public interface IOrdenDeVentaProductoRepositorio
    {
        Task<List<OrdenDeVentaProducto>> ObtenerOrdenesDeVentaProductos();
        Task<OrdenDeVentaProducto> ObtenerOrdenDeVentaProductoPorId(int id);
        Task CrearOrdenDeVentaProducto(OrdenDeVentaProducto ordenDeVentaProducto);
        Task ActualizarOrdenDeVentaProducto(OrdenDeVentaProducto ordenDeVentaProducto);
        Task EliminarOrdenDeVentaProducto(int id);
        Task<List<OrdenDeVentaProducto>> ObtenerOrdenesDeVentaProductosPorOrdenDeVentaId(int ordenDeVentaId);
    }
}
//ObtenerOrdenDeVentaProductoPorId