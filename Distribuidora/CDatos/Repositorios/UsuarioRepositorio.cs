using CDatos.Data;
using CDatos.Repositorios.IRepositorios;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDatos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DataContext _context;

        public UsuarioRepositorio(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            return await _context.Set<Usuario>().ToListAsync();
        }

        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            return await _context.Set<Usuario>().FindAsync(id);
        }
        public async Task<Usuario> ObtenerUsuarioPorNombreUsuario(string nombreUsuario)
        {
            return await _context.Set<Usuario>().FindAsync(nombreUsuario);
        }

        public async Task<Usuario> CrearUsuario(Usuario usuario)
        {
            _context.Set<Usuario>().Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            var usuarioExistente = _context.Set<Usuario>().Find(usuario.Id);
            if (usuarioExistente == null)
                throw new System.Exception("Usuario no encontrado.");

            usuarioExistente.Contrasenia = usuario.Contrasenia;
            usuarioExistente.PersonaId = usuario.PersonaId;
            usuarioExistente.Activo = usuario.Activo;

            _context.SaveChanges();
        }

        public void EliminarUsuario(int id)
        {
            var usuario = _context.Set<Usuario>().FirstOrDefault(x => x.Id == id);
            if (usuario != null)
            {
                _context.Set<Usuario>().Remove(usuario);
                _context.SaveChanges();
            }
        }
    }
}
