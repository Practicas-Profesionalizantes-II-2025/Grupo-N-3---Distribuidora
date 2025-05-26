using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica.ILogica
{
    public interface IProductoLogica
    {
        Task<List<ProductoDTO>> ObtenerProductos();
        Task<ProductoDTO> ObtenerProductoPorId(int id);
        Task CrearProducto(ProductoDTO productoDTO);
        Task ActualizarProducto(ProductoDTO productoDTO);
        Task EliminarProducto(int id);
        Task<List<ProductoDTO>> ObtenerProductosPorProveedorId(int proveedorId);
        Task<List<ProductoDTO>> ObtenerProductosPorNombre(string nombre);
        Task<List<ProductoDTO>> ObtenerProductosPorCategoriaId(int categoriaId);
    }
}
