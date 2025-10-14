using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.Repositorios.IRepositorios
{
    public interface IProveedorRepositorio
    {
        Task<List<Proveedor>> ObtenerProveedores();
        Task<Proveedor> ObtenerProveedorPorId(int id);
        Task<Proveedor> CrearProveedor(Proveedor proveedor);
        void ActualizarProveedor(Proveedor proveedor);
        void EliminarProveedor(int id);
    }
}
