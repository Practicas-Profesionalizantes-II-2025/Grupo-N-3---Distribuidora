using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNegocio.Logica
{
    public class ClienteLogica : IClienteLogica
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IPersonaRepositorio _personaRepositorio;

        public ClienteLogica(IClienteRepositorio clienteRepositorio, IPersonaRepositorio personaRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _personaRepositorio = personaRepositorio;
        }

        public async Task<List<ClienteDTO>> ObtenerClientes()
        {
            var clientes = await _clienteRepositorio.ObtenerClientes();

            var clientesDTO = clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                EstadoId = c.EstadoId,
                Persona = new PersonaDTO
                {
                    Id = c.Persona.Id,
                    Nombre = c.Persona.Nombre,
                    Apellido = c.Persona.Apellido,
                    Nro_Doc = c.Persona.Nro_Doc,
                    Telefono = c.Persona.Telefono,
                    Email = c.Persona.Email,
                    Direccion = c.Persona.Direccion,
                    CiudadId = c.Persona.CiudadId,
                    EstadoId = c.Persona.EstadoId,
                },
            }).ToList();

            return clientesDTO;
        }

        public async Task<ClienteDTO> ObtenerClientePorId(int id)
        {
            var cliente = await _clienteRepositorio.ObtenerClientePorId(id);
            if (cliente == null) return null;

            return new ClienteDTO
            {
                Id = cliente.Id,
                EstadoId = cliente.EstadoId,
                PersonaId = cliente.PersonaId,
                Persona = new PersonaDTO
                {
                    Id = cliente.Persona.Id,
                    Nombre = cliente.Persona.Nombre,
                    Apellido = cliente.Persona.Apellido,
                    Nro_Doc = cliente.Persona.Nro_Doc,
                    Telefono = cliente.Persona.Telefono,
                    Email = cliente.Persona.Email,
                    Direccion = cliente.Persona.Direccion,
                    CiudadId = cliente.Persona.CiudadId,
                    EstadoId = cliente.Persona.EstadoId
                }
            };
        }

        public async Task<ClienteDTO> CrearCliente(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente
            {
                PersonaId = clienteDTO.PersonaId,
                EstadoId = clienteDTO.EstadoId
            };

            var nuevoCliente = await _clienteRepositorio.CrearCliente(cliente);

            return new ClienteDTO
            {
                Id = nuevoCliente.Id,
                PersonaId = nuevoCliente.PersonaId,
                EstadoId = nuevoCliente.EstadoId
            };
        }

        public async Task ActualizarCliente(ClienteDTO clienteDTO)
        {
            var persona = await _personaRepositorio.ObtenerPersonaPorId(clienteDTO.Persona.Id);
            if (persona == null)
                throw new Exception("Persona no encontrada.");

            persona.Nombre = clienteDTO.Persona.Nombre;
            persona.Apellido = clienteDTO.Persona.Apellido;
            persona.Nro_Doc = clienteDTO.Persona.Nro_Doc;
            persona.Telefono = clienteDTO.Persona.Telefono;
            persona.Email = clienteDTO.Persona.Email;
            persona.Direccion = clienteDTO.Persona.Direccion;
            persona.CiudadId = clienteDTO.Persona.CiudadId;

            await _personaRepositorio.ActualizarPersona(persona);

            var clienteExistente = await _clienteRepositorio.ObtenerClientePorId(clienteDTO.Id);
            if (clienteExistente == null)
                throw new Exception("Cliente no encontrado.");

            clienteExistente.EstadoId = clienteDTO.EstadoId;

            await _clienteRepositorio.ActualizarCliente(clienteExistente);
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
                EstadoId = c.EstadoId,
                PersonaId = c.PersonaId
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
                CiudadId = persona.CiudadId
            };
        }
    }
}
