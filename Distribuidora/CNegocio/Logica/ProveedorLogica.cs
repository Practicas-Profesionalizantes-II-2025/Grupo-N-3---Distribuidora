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
                throw new ArgumentException("El Id del proveedor debe ser mayor a cero.");

            var proveedor = await _proveedorRepositorio.ObtenerProveedorPorId(id);
            if (proveedor == null)
                return null;

            return new ProveedorDTO
            {
                Id = proveedor.Id,
                Nombre = proveedor.Nombre,
                Direccion = proveedor.Direccion,
                Telefono = proveedor.Telefono,
                Email = proveedor.Email
            };
        }

        public async Task CrearProveedor(ProveedorDTO proveedorDTO)
        {
            ValidarProveedorDTO(proveedorDTO, esNuevo: true);

            // Evitar duplicados por Email
            var existentes = await _proveedorRepositorio.ObtenerProveedores();
            if (existentes.Any(p => p.Email.Equals(proveedorDTO.Email, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Ya existe un proveedor con el mismo email.");

            var proveedor = new Proveedor
            {
                Nombre = proveedorDTO.Nombre,
                Direccion = proveedorDTO.Direccion,
                Telefono = proveedorDTO.Telefono,
                Email = proveedorDTO.Email
            };

            await _proveedorRepositorio.CrearProveedor(proveedor);
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

            await _proveedorRepositorio.ActualizarProveedor(proveedor);
        }

        public async Task EliminarProveedor(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id del proveedor no es válido.");

            var existente = await _proveedorRepositorio.ObtenerProveedorPorId(id);
            if (existente == null)
                throw new InvalidOperationException("No se encontró el proveedor a eliminar.");

            await _proveedorRepositorio.EliminarProveedor(id);
        }

        private void ValidarProveedorDTO(ProveedorDTO dto, bool esNuevo)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "El proveedor no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(dto.Nombre))
                throw new ArgumentException("El nombre del proveedor es obligatorio.");

            if (string.IsNullOrWhiteSpace(dto.Direccion))
                throw new ArgumentException("La dirección del proveedor es obligatoria.");

            if (string.IsNullOrWhiteSpace(dto.Telefono))
                throw new ArgumentException("El teléfono del proveedor es obligatorio.");

            if (!Regex.IsMatch(dto.Telefono, @"^\+?\d{7,15}$"))
                throw new ArgumentException("El teléfono no tiene un formato válido.");

            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new ArgumentException("El email del proveedor es obligatorio.");

            if (!Regex.IsMatch(dto.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("El email del proveedor no tiene un formato válido.");
        }
    }
}
