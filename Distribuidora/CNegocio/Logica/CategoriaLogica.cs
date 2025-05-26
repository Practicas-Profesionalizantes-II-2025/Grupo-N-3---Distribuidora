using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using Shared.Entities;

namespace CNegocio.Logica
{
    public class CategoriaLogica : ICategoriaLogica
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaLogica(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<List<CategoriaDTO>> ObtenerCategorias()
        {
            var categorias = await _categoriaRepositorio.ObtenerCategorias();
            return categorias.Select(c => new CategoriaDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                EstadoId = c.EstadoId
            }).ToList();
        }
        public async Task<CategoriaDTO> ObtenerCategoriaPorId(int id)
        {
            var categoria = await _categoriaRepositorio.ObtenerCategoriaPorId(id);
            if (categoria == null) return null;
            return new CategoriaDTO
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                EstadoId = categoria.EstadoId
            };
        }
        public async Task CrearCategoria(CategoriaDTO categoriaDTO)
        {
            var categoria = new Categoria
            {
                Nombre = categoriaDTO.Nombre,
                EstadoId = categoriaDTO.EstadoId
            };
            var nuevaCategoria = await _categoriaRepositorio.CrearCategoria(categoria);
        }
        public async Task ActualizarCategoria(CategoriaDTO categoriaDTO)
        {
            var categoria = new Categoria
            {
                Id = categoriaDTO.Id,
                Nombre = categoriaDTO.Nombre,
                EstadoId = categoriaDTO.EstadoId
            };
            _categoriaRepositorio.ActualizarCategoria(categoria);
        }
        public async Task EliminarCategoria(int id)
        {
            _categoriaRepositorio.EliminarCategoria(id);
        }

    }
}
