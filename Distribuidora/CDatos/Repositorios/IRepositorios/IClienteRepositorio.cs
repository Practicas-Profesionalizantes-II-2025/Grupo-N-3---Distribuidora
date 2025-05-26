using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace CDatos.Repositorios.IRepositorios
{
    public interface IClienteRepositorio
    {
        Task<List<Cliente>> ObtenerClientes();
        Task<Cliente> ObtenerClientePorId(int id);
        Task<Cliente> CrearCliente(Cliente cliente);
        void ActualizarCliente(Cliente cliente);
        void EliminarCliente(int id);
        Task<List<Cliente>> ObtenerClientesPorDni(string dni);
        Task<Persona> ObtenerPersonaPorClienteId(int clienteId);
    }
}
