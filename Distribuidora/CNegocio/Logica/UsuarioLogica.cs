using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CNegocio.Logica
{
    public class UsuarioLogica : IUsuarioLogica
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly PasswordHasher<Usuario> _passwordHasher;

        public UsuarioLogica(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _passwordHasher = new PasswordHasher<Usuario>();
        }

        public async Task<List<UsuarioDTO>> ObtenerUsuarios()
        {
            var usuarios = await _usuarioRepositorio.ObtenerUsuarios();
            return usuarios.Select(u => new UsuarioDTO
            {
                Id = u.Id,
                PersonaId = u.PersonaId,
                Activo = u.Activo
            }).ToList();
        }

        public async Task<bool> VerificarUsuario(UsuarioDTO usuarioDTO)
        {
            var usuarioEnDb = await _usuarioRepositorio.ObtenerUsuarioPorNombreUsuario(usuarioDTO.NombreUsuario);
            if (usuarioEnDb == null)
                return false;

            var resultado = _passwordHasher.VerifyHashedPassword(
                usuarioEnDb,
                usuarioEnDb.Contrasenia, // hash guardado
                usuarioDTO.Contrasenia   // password en texto plano que llega del cliente
            );

            return resultado == PasswordVerificationResult.Success;
        }


        public async Task<UsuarioDTO> ObtenerUsuarioPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del usuario debe ser mayor que cero.");

            var usuario = await _usuarioRepositorio.ObtenerUsuarioPorId(id);
            if (usuario == null)
                throw new ArgumentException($"No se encontró un usuario con el ID {id}");

            return new UsuarioDTO
            {
                Id = usuario.Id,
                PersonaId = usuario.PersonaId,
                Activo = usuario.Activo
                // Nunca mandes la contraseña al front
            };
        }

        public async Task CrearUsuario(UsuarioDTO usuarioDTO)
        {
            List<string> camposErroneos = new List<string>();
            if (string.IsNullOrEmpty(usuarioDTO.Contrasenia))
                camposErroneos.Add("Contrasenia");
            if (usuarioDTO.PersonaId <= 0)
                camposErroneos.Add("PersonaId");

            if (camposErroneos.Count > 0)
                throw new ArgumentException("Campos inválidos: " + string.Join(", ", camposErroneos));

            var usuario = new Usuario
            {
                PersonaId = usuarioDTO.PersonaId,
                Activo = usuarioDTO.Activo
            };

            // Hash de la contraseña
            usuario.Contrasenia = _passwordHasher.HashPassword(usuario, usuarioDTO.Contrasenia);

            await _usuarioRepositorio.CrearUsuario(usuario);
        }

        public async Task ActualizarUsuario(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO.Id <= 0)
                throw new ArgumentException("El ID debe ser mayor a 0.");

            var usuario = new Usuario
            {
                Id = usuarioDTO.Id,
                PersonaId = usuarioDTO.PersonaId,
                Activo = usuarioDTO.Activo
            };

            if (!string.IsNullOrEmpty(usuarioDTO.Contrasenia))
            {
                // Si se envía nueva contraseña, se hashea
                usuario.Contrasenia = _passwordHasher.HashPassword(usuario, usuarioDTO.Contrasenia);
            }

            _usuarioRepositorio.ActualizarUsuario(usuario);
        }

        public async Task EliminarUsuario(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor a 0.");

            _usuarioRepositorio.EliminarUsuario(id);
        }
    }
}
