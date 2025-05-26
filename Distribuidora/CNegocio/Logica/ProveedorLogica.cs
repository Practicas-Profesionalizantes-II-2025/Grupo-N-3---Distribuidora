using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var proveedor = await _proveedorRepositorio.ObtenerProveedorPorId(id);
            if (proveedor == null)
            {
                return null;
            }
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
            await _proveedorRepositorio.EliminarProveedor(id);
        }
    }
}
