using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.Data;
using CDatos.Repositorios.IRepositorios;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace CDatos.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly DataContext _context;
        private readonly IPersonaRepositorio _personaRepositorio;
        public ClienteRepositorio(DataContext context)
        {
            _context = context;
            _personaRepositorio = _personaRepositorio;
        }
        public async Task<List<Cliente>> ObtenerClientes()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<Cliente> ObtenerClientePorId(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }
        public async Task<Cliente> CrearCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
        public void ActualizarCliente(Cliente cliente)
        {
            var clienteExistente = _context.Clientes.Find(cliente.Id);
            if (clienteExistente == null)
            {
                throw new Exception("Cliente no encontrado.");
            }
            clienteExistente.PersonaId = cliente.PersonaId;
            clienteExistente.EstadoId = cliente.EstadoId;

            _context.SaveChanges();
        }
        public void EliminarCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
        public async Task<List<Cliente>> ObtenerClientesPorDni(string dni)
        {
            var personaId = (_personaRepositorio.ObtenerPersonasPorDni(dni)).Id;
            return await _context.Clientes
                .Where(c => c.PersonaId == personaId)
                .ToListAsync();
        }
        // obtener persona por ClienteId
        public async Task<Persona> ObtenerPersonaPorClienteId(int clienteId)
        {
            var cliente = await _context.Clientes.FindAsync(clienteId);
            if (cliente == null)
            {
                return null;
            }
            return await _context.Personas.FindAsync(cliente.PersonaId);
        }
    }
}
