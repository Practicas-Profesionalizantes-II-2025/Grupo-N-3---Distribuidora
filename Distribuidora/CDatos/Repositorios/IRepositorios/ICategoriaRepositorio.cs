using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace CDatos.Repositorios.IRepositorios
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> ObtenerCategorias();
        Task<Categoria> ObtenerCategoriaPorId(int id);
        Task<Categoria> CrearCategoria(Categoria categoria);
        void ActualizarCategoria(Categoria Categoria);
        void EliminarCategoria(int id);
    }
}
