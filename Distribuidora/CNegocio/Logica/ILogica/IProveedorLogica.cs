using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica.ILogica
{
    public interface IProveedorLogica
    {
        Task<List<ProveedorDTO>> ObtenerProveedores();
        Task<ProveedorDTO> ObtenerProveedorPorId(int id);
        Task<ProveedorDTO> CrearProveedor(ProveedorDTO proveedorDTO);
        Task<ProveedorDTO> ActualizarProveedor(ProveedorDTO proveedorDTO);
        Task EliminarProveedor(int id);
    }
}
