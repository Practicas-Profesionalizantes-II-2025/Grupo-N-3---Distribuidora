using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace CDatos.Repositorios.IRepositorios
{
    public interface IOrdenDeVentaRepositorio
    {   Task<List<OrdenDeVenta>> ObtenerOrdenesDeVenta();
        Task<OrdenDeVenta> ObtenerOrdenDeVentaPorId(int id);
        Task CrearOrdenDeVenta(OrdenDeVenta ordenDeVenta);
        Task ActualizarOrdenDeVenta(OrdenDeVenta ordenDeVenta);
        Task EliminarOrdenDeVentaAsync(int id);
        Task<List<OrdenDeVenta>> ObtenerOrdenesDeVentaPorEmpleadoId(int empleadoId);
        Task<List<OrdenDeVenta>> ObtenerOrdenesDeVentaPorClienteId(int clienteId);
        Task<List<OrdenDeVenta>> ObtenerOrdenesDeVentaPorDistribuidoraId(int distribuidoraId);
    }
}
