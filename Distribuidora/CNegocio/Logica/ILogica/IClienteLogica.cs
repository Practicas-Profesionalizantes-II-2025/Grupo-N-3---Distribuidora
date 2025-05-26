using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace CNegocio.Logica.ILogica
{
    public interface IClienteLogica
    {
        Task<List<ClienteDTO>> ObtenerClientes();
        Task<ClienteDTO> ObtenerClientePorId(int id);
        Task<ClienteDTO> CrearCliente(ClienteDTO clienteDTO);
        Task ActualizarCliente(ClienteDTO clienteDTO);
        Task EliminarCliente(int id);
        Task<List<ClienteDTO>> ObtenerClientesPorDni(string dni);
        Task<PersonaDTO> ObtenerPersonaPorClienteId(int clienteId);
    }
}
