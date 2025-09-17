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
        public ClienteRepositorio(DataContext context, IPersonaRepositorio personaRepositorio)
        {
            _context = context;
            _personaRepositorio = personaRepositorio;
        }
        public async Task<List<Cliente>> ObtenerClientes()
        {
            return await _context.Cliente
                .Include(c => c.Persona)
                .ToListAsync();

        }
        public async Task<Cliente> ObtenerClientePorId(int id)
        {
            return await _context.Cliente
                .Include(c => c.Persona)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Cliente> CrearCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
        public void ActualizarCliente(Cliente cliente)
        {
            var clienteExistente = _context.Cliente.Find(cliente.Id);
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
            var cliente = _context.Cliente.FirstOrDefault(x => x.Id == id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
                _context.SaveChanges();
            }
        }
        public async Task<List<Cliente>> ObtenerClientesPorDni(string dni)
        {
            return await _context.Cliente
                .Include(c => c.Persona)
                .Where(c => c.Persona.Nro_Doc == dni)
                .ToListAsync();
        }
        // obtener persona por ClienteId
        public async Task<Persona> ObtenerPersonaPorClienteId(int clienteId)
        {
            var cliente = await _context.Cliente
                 .Include(c => c.Persona)
                 .FirstOrDefaultAsync(c => c.Id == clienteId);

            return cliente?.Persona;
        }
    }
}
