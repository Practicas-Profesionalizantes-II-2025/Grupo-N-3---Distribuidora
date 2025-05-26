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
    public class ProveedorRepositorio : IProveedorRepositorio
    {
        private readonly DataContext _context;
        public ProveedorRepositorio(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Proveedor>> ObtenerProveedores()
        {
            return await _context.Proveedores.ToListAsync();
        }
        public async Task<Proveedor> ObtenerProveedorPorId(int id)
        {
            return await _context.Proveedores.FindAsync(id);
        }
        public async Task CrearProveedor(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
        }
        public async Task ActualizarProveedor(Proveedor proveedor)
        {
            var proveedorExistente = _context.Proveedores.Find(proveedor.Id);
            if (proveedorExistente == null)
            {
                throw new Exception("Proveedor no encontrado.");
            }
            proveedorExistente.Telefono = proveedor.Telefono;
            proveedorExistente.Direccion = proveedor.Direccion;
            proveedorExistente.Email = proveedor.Email;

            await _context.SaveChangesAsync();
        }
        public async Task EliminarProveedor(int id)
        {
            var proveedor = await ObtenerProveedorPorId(id);
            if (proveedor != null)
            {
                _context.Proveedores.Remove(proveedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
