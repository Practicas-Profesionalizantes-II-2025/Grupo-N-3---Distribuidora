using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica.ILogica
{
    public interface IOrdenDeCompraLogica
    {
        Task<List<OrdenDeCompraDTO>> ObtenerOrdenesDeCompra();
        Task<OrdenDeCompraDTO> ObtenerOrdenDeCompraPorId(int id);
        Task<List<OrdenDeCompraDTO>> ObtenerOrdenesDeCompraPorDistribuidorId(int distribuidorId);
        Task<List<OrdenDeCompraDTO>> ObtenerOrdenesDeCompraPorEmpleadoId(int empleadoId);
        Task CrearOrdenDeCompra(OrdenDeCompraDTO ordenDeCompraDTO);
        Task ActualizarOrdenDeCompra(OrdenDeCompraDTO ordenDeCompraDTO);
        Task EliminarOrdenDeCompra(int id);
    }
}
