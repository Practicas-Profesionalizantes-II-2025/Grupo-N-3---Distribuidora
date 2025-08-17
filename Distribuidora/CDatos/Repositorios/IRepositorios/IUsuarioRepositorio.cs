using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace CDatos.Repositorios.IRepositorios
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> ObtenerUsuarios();
        Task<Usuario> ObtenerUsuarioPorId(int id);
        Task<Usuario> ObtenerUsuarioPorNombreUsuario(string nombreUsuario);
        Task<Usuario> CrearUsuario(Usuario usuario);
        void ActualizarUsuario(Usuario usuario);
        void EliminarUsuario(int id);
    }
}
