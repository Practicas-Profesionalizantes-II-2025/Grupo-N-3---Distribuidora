using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica.ILogica
{
    public interface IOrdenDeVentaLogica
    {
        Task<List<OrdenDeVentaDTO>> ObtenerOrdenesDeVenta();
        Task<List<OrdenDeVentaDTO>> ObtenerOrdenesDeVentaPorEmpleadoId(int empleadoId);
        Task<List<OrdenDeVentaDTO>> ObtenerOrdenesDeVentaPorClienteId(int clienteId);
        Task<List<OrdenDeVentaDTO>> ObtenerOrdenesDeVentaPorDistribuidoraId(int distribuidorId);        Task<OrdenDeVentaDTO> ObtenerOrdenDeVentaPorId(int id);
        Task CrearOrdenDeVenta(OrdenDeVentaDTO ordenDeVenta);
        Task ActualizarOrdenDeVenta(OrdenDeVentaDTO ordenDeVenta);
        Task EliminarOrdenDeVenta(int id);
    }
}
