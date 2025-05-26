using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using Shared.Entities;

namespace CNegocio.Logica
{
    public class ClienteLogica : IClienteLogica
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteLogica(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        public async Task<List<ClienteDTO>> ObtenerClientes()
        {
            var clientes = await _clienteRepositorio.ObtenerClientes();
            return clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                PersonaId = c.PersonaId,
                EstadoId = c.EstadoId,
            }).ToList();
        }
        public async Task<ClienteDTO> ObtenerClientePorId(int id)
        {
            var cliente = await _clienteRepositorio.ObtenerClientePorId(id);
            if (cliente == null) return null;
            return new ClienteDTO
            {
                Id = cliente.Id,
                PersonaId = cliente.PersonaId,
                EstadoId = cliente.EstadoId,
            };
        }
        public async Task<ClienteDTO> CrearCliente(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente
            {
                PersonaId = clienteDTO.PersonaId,
                EstadoId = clienteDTO.EstadoId,
            };
            var nuevoCliente = await _clienteRepositorio.CrearCliente(cliente);
            return new ClienteDTO
            {
                Id = nuevoCliente.Id,
                PersonaId = nuevoCliente.PersonaId,
                EstadoId = nuevoCliente.EstadoId,
            };
        }
        public async Task ActualizarCliente(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente
            {
                Id = clienteDTO.Id,
                PersonaId = clienteDTO.PersonaId,
                EstadoId = clienteDTO.EstadoId,
            };
            _clienteRepositorio.ActualizarCliente(cliente);
        }
        public async Task EliminarCliente(int id)
        {
            _clienteRepositorio.EliminarCliente(id);
        }
        public async Task<List<ClienteDTO>> ObtenerClientesPorDni(string dni)
        {
            var clientes = await _clienteRepositorio.ObtenerClientesPorDni(dni);
            return clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                PersonaId = c.PersonaId,
                EstadoId = c.EstadoId,
            }).ToList();
        }
        public async Task<PersonaDTO> ObtenerPersonaPorClienteId(int clienteId)
        {
            var persona = await _clienteRepositorio.ObtenerPersonaPorClienteId(clienteId);
            if (persona == null) return null;
            return new PersonaDTO
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Nro_Doc = persona.Nro_Doc,
                Telefono = persona.Telefono,
                Email = persona.Email,
                Direccion = persona.Direccion,
            };
        }
    }
}
