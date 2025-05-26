using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace CNegocio.Logica.ILogica
{
    public interface ICategoriaLogica
    {
        Task<List<CategoriaDTO>> ObtenerCategorias();
        Task<CategoriaDTO> ObtenerCategoriaPorId(int id);
        Task CrearCategoria(CategoriaDTO categoriaDTO);
        Task ActualizarCategoria(CategoriaDTO categoriaDTO);
        Task EliminarCategoria(int id);
    }
}
