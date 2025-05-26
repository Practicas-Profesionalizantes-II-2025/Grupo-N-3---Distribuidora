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
        Task CrearProveedor(Proveedor proveedor);
        Task ActualizarProveedor(Proveedor proveedor);
        Task EliminarProveedor(int id);
    }
}
