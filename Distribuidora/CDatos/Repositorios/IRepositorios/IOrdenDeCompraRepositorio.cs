using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace CDatos.Repositorios.IRepositorios
{
    public interface IOrdenDeCompraRepositorio
    {
        Task<List<OrdenDeCompra>> ObtenerOrdenesDeCompra();
        Task<OrdenDeCompra> ObtenerOrdenDeCompraPorId(int id);
        Task<OrdenDeCompra> CrearOrdenDeCompra(OrdenDeCompra ordenDeCompra);
        void ActualizarOrdenDeCompra(OrdenDeCompra ordenDeCompra);
        void EliminarOrdenDeCompra(int id);
        // Obtener lista de Ordenes de Compra segun el atributo de clave foranea (EmpleadoId, ClienteId, DistribuidorId)
        Task<List<OrdenDeCompra>> ObtenerOrdenesDeCompraPorDistribuidorId(int distribuidorId);
        Task<List<OrdenDeCompra>> ObtenerOrdenesDeCompraPorEmpleadoId(int empleadoId);
    }
}
