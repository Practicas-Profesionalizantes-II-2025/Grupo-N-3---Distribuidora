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
        Task<OrdenDeVenta> CrearOrdenDeVenta(OrdenDeVenta ordenDeVenta);
        void ActualizarOrdenDeVenta(OrdenDeVenta ordenDeVenta);
        void EliminarOrdenDeVenta(int id);
        Task<List<OrdenDeVenta>> ObtenerOrdenesDeVentaPorEmpleadoId(int empleadoId);
        Task<List<OrdenDeVenta>> ObtenerOrdenesDeVentaPorClienteId(int clienteId);
        Task<List<OrdenDeVenta>> ObtenerOrdenesDeVentaPorDistribuidoraId(int distribuidoraId);
    }
}
