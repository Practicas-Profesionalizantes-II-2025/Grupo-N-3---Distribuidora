using CDatos.Repositorios;
using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CNegocio.Logica
{
    public class ProveedorLogica : IProveedorLogica
    {
        private readonly IProveedorRepositorio _proveedorRepositorio;
        public ProveedorLogica(IProveedorRepositorio proveedorRepositorio)
        {
            _proveedorRepositorio = proveedorRepositorio;
        }

        public async Task<List<ProveedorDTO>> ObtenerProveedores()
        {
            var proveedores = await _proveedorRepositorio.ObtenerProveedores();
            return proveedores.Select(p => new ProveedorDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Direccion = p.Direccion,
                Telefono = p.Telefono,
                Email = p.Email
            }).ToList();
        }
        public async Task<ProveedorDTO> ObtenerProveedorPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del proveedor debe ser mayor que cero.");

            var proveedor = await _proveedorRepositorio.ObtenerProveedorPorId(id);
            if (proveedor == null)
                throw new ArgumentException($"No se encontró un proveedor con el ID {id}");

            return new ProveedorDTO
            {
                Id = proveedor.Id,
                Nombre = proveedor.Nombre,
                Direccion = proveedor.Direccion,
                Telefono = proveedor.Telefono,
                Email = proveedor.Email
            };
        }
        public async Task<ProveedorDTO> CrearProveedor(ProveedorDTO proveedorDTO)
        {
            List<string> camposErroneos = new List<string>();
            if (string.IsNullOrEmpty(proveedorDTO.Nombre) || !IsValidName(proveedorDTO.Nombre))
                camposErroneos.Add("Nombre");

            if (camposErroneos.Count > 0)
            {
                throw new ArgumentException("Los siguientes campos son inválidos: ", string.Join(", ", camposErroneos));
            }

            var proveedor = new Proveedor
            {
                Nombre = proveedorDTO.Nombre,
                Direccion = proveedorDTO.Direccion,
                Telefono = proveedorDTO.Telefono,
                Email = proveedorDTO.Email
            };

            var nuevoProveedor = await _proveedorRepositorio.CrearProveedor(proveedor);

            proveedorDTO.Id = nuevoProveedor.Id;

            return proveedorDTO;
        }
        public async Task ActualizarProveedor(ProveedorDTO proveedorDTO)
        {
            if (proveedorDTO.Id <= 0)
                throw new ArgumentException("El Id del proveedor no es válido.");

            var existente = await _proveedorRepositorio.ObtenerProveedorPorId(proveedorDTO.Id);
            if (existente == null)
                throw new InvalidOperationException("No se encontró el proveedor a actualizar.");

            ValidarProveedorDTO(proveedorDTO, esNuevo: false);

            var proveedor = new Proveedor
            {
                Id = proveedorDTO.Id,
                Nombre = proveedorDTO.Nombre,
                Direccion = proveedorDTO.Direccion,
                Telefono = proveedorDTO.Telefono,
                Email = proveedorDTO.Email
            };
            _proveedorRepositorio.ActualizarProveedor(proveedor);
        }
        public async Task EliminarProveedor(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id del proveedor no es válido.");

            var existente = await _proveedorRepositorio.ObtenerProveedorPorId(id);
            if (existente == null)
                throw new InvalidOperationException("No se encontró el proveedor a eliminar.");

            _proveedorRepositorio.EliminarProveedor(id);
        }
        #region Validaciones
        private void ValidarProveedorDTO(ProveedorDTO proveedorDTO, bool esNuevo)
        {

            if (proveedorDTO == null)
                throw new ArgumentNullException(nameof(proveedorDTO), "El proveedor no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(proveedorDTO.Nombre))
                throw new ArgumentException("El nombre del proveedor es obligatorio.");

            if (string.IsNullOrWhiteSpace(proveedorDTO.Direccion))
                throw new ArgumentException("La dirección del proveedor es obligatoria.");

            if (string.IsNullOrWhiteSpace(proveedorDTO.Telefono))
                throw new ArgumentException("El teléfono del proveedor es obligatorio.");

            if (!Regex.IsMatch(proveedorDTO.Telefono, @"^\+?\d{7,15}$"))
                throw new ArgumentException("El teléfono no tiene un formato válido.");

            if (string.IsNullOrWhiteSpace(proveedorDTO.Email))
                throw new ArgumentException("El email del proveedor es obligatorio.");

            if (!Regex.IsMatch(proveedorDTO.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("El email del proveedor no tiene un formato válido.");
        }

        private bool ContainsInvalidCharacter(string text)
        {
            char[] caracteres = { '!', '"', '#', '$', '%', '/', '(', ')', '=', '.', ',' };
            return caracteres.Any(c => text.Contains(c));
        }
        private bool IsValidName(string nombre)
        {
            return nombre.Length < 15 && !ContainsInvalidCharacter(nombre);
        }
    }
        #endregion Validaciones
}
