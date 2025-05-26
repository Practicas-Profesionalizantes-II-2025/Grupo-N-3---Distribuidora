using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.Repositorios.IRepositorios
{
    public interface IProductoRepositorio
    {
        Task<List<Producto>> ObtenerProductos();
        Task<Producto> ObtenerProductoPorId(int id);
        Task CrearProducto(Producto producto);
        Task ActualizarProducto(Producto producto);
        Task EliminarProducto(int id);
        Task<List<Producto>> ObtenerProductosPorProveedorId(int proveedorId);
        Task<List<Producto>> ObtenerProductosPorNombre(string nombre);
        Task<List<Producto>> ObtenerProductosPorCategoriaId(int categoriaId);
    }
}
