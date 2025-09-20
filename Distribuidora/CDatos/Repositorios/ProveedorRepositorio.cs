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
            return await _context.Proveedor.ToListAsync();
        }
        public async Task<Proveedor> ObtenerProveedorPorId(int id)
        {
            return await _context.Proveedor.FindAsync(id);
        }
        public async Task<Proveedor> CrearProveedor(Proveedor proveedor)
        {
            _context.Proveedor.Add(proveedor);
            await _context.SaveChangesAsync();
            return proveedor;
        }
        public void ActualizarProveedor(Proveedor proveedor)
        {
            var proveedorExistente = _context.Proveedor.Find(proveedor.Id);
            if (proveedorExistente == null)
            {
                throw new Exception("Proveedor no encontrado.");
            }
            proveedorExistente.Nombre = proveedor.Nombre;
            proveedorExistente.Telefono = proveedor.Telefono;
            proveedorExistente.Direccion = proveedor.Direccion;
            proveedorExistente.Email = proveedor.Email;

            _context.SaveChangesAsync();
        }
        public void EliminarProveedor(int id)
        {
            var Proveedor = _context.Proveedor.FirstOrDefault(x => x.Id == id);
            if (Proveedor != null)
            {
                _context.Proveedor.Remove(Proveedor);
                _context.SaveChanges();
            }
        }
    }
}
