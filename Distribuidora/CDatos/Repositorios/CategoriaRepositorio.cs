using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.Data;
using CDatos.Repositorios.IRepositorios;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace CDatos.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly DataContext _context;
        public CategoriaRepositorio(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Categoria>> ObtenerCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }
        public async Task<Categoria> ObtenerCategoriaPorId(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }
        public async Task<Categoria> CrearCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }
        public void ActualizarCategoria(Categoria Categoria)
        {
            var categoriaExistente = _context.Categorias.Find(Categoria.Id);
            if (categoriaExistente == null)
            {
                throw new Exception("Categoría no encontrada.");
            }
            categoriaExistente.Nombre = Categoria.Nombre;
            categoriaExistente.EstadoId = Categoria.EstadoId;

            _context.SaveChanges();
        }
        public void EliminarCategoria(int id)
        {
            var Categoria = _context.Categorias.FirstOrDefault(x => x.Id == id);
            if (Categoria != null)
            {
                _context.Categorias.Remove(Categoria);
                _context.SaveChanges();
            }
        }
    }
}
