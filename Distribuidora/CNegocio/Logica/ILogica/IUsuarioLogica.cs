using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica.ILogica
{
    public interface IUsuarioLogica
    {
        Task<List<UsuarioDTO>> ObtenerUsuarios();
        Task<UsuarioDTO> ObtenerUsuarioPorId(int id);
        Task<bool> VerificarUsuario(UsuarioDTO usuario);
        Task CrearUsuario(UsuarioDTO usuarioDTO);
        Task ActualizarUsuario(UsuarioDTO usuarioDTO);
        Task EliminarUsuario(int id);

    }
}
