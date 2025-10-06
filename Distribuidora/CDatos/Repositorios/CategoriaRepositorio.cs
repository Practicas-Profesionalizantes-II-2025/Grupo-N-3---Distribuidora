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
            return await _context.Categoria.ToListAsync();
        }
        public async Task<Categoria> ObtenerCategoriaPorId(int id)
        {
            return await _context.Categoria.FindAsync(id);
        }
        public async Task<Categoria> CrearCategoria(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }
        public void ActualizarCategoria(Categoria Categoria)
        {
            var categoriaExistente = _context.Categoria.Find(Categoria.Id);
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
            var Categoria = _context.Categoria.FirstOrDefault(x => x.Id == id);
            if (Categoria != null)
            {
                _context.Categoria.Remove(Categoria);
                _context.SaveChanges();
            }
        }

        public async Task<List<Categoria>> BuscarCategoria(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro))
                return await _context.Categoria.ToListAsync();

            filtro = filtro.ToLower();

            return await _context.Categoria
                .Where(c => c.Nombre.ToLower().Contains(filtro)
                         || c.Id.ToString().Contains(filtro))
                .ToListAsync();
        }
    }
}
