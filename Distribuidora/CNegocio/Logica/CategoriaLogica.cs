using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            if (id <= 0)
                throw new ArgumentException("El ID de la categoría debe ser mayor que cero.");

            var categoria = await _categoriaRepositorio.ObtenerCategoriaPorId(id);
            if (categoria == null)
                throw new ArgumentException($"No se encontró una categoría con el ID {id}");

            return new CategoriaDTO
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                EstadoId = categoria.EstadoId
            };
        }
        public async Task CrearCategoria(CategoriaDTO categoriaDTO)
        {
            List<string> camposErroneos = new List<string>();
            if (string.IsNullOrEmpty(categoriaDTO.Nombre) || !IsValidName(categoriaDTO.Nombre))
                camposErroneos.Add("Nombre");

            if (camposErroneos.Count > 0)
            {
                throw new ArgumentException("Los siguientes campos son inválidos: ", string.Join(", ", camposErroneos));
            }

            var categoria = new Categoria
            {
                Nombre = categoriaDTO.Nombre,
                EstadoId = categoriaDTO.EstadoId
            };
            var nuevaCategoria = await _categoriaRepositorio.CrearCategoria(categoria);
        }
        public async Task ActualizarCategoria(CategoriaDTO categoriaDTO)
        {
            List<string> camposErroneos = new List<string>();
            if (string.IsNullOrEmpty(categoriaDTO.Nombre) || !IsValidName(categoriaDTO.Nombre))
                camposErroneos.Add("Nombre");

            if (camposErroneos.Count > 0)
            {
                throw new ArgumentException("Los siguientes campos son inválidos: ", string.Join(", ", camposErroneos));
            }

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
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor a 0.");

            _categoriaRepositorio.EliminarCategoria(id);
        }

        #region Validaciones
        private bool ContainsInvalidCharacter(string text)
        {
            char[] caracteres = { '!', '"', '#', '$', '%', '/', '(', ')', '=', '.', ',' };
            return caracteres.Any(c => text.Contains(c));
        }
        private bool IsValidName(string nombre)
        {
            return nombre.Length < 15 && !ContainsInvalidCharacter(nombre);
        }
        #endregion Validaciones
    }
}
