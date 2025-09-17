using CDatos.Data;
using CNegocio.Logica;
using CNegocio.Logica.ILogica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteLogica _clienteLogica;
        public ClientesController(IClienteLogica clienteLogica)
        {
            _clienteLogica = clienteLogica;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetCliente()
        {
            return await _clienteLogica.ObtenerClientes();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetCliente(int id)
        {
            var cliente = await _clienteLogica.ObtenerClientePorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // GET: api/Cliente/dni/
        [HttpGet("dni/{dni}")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientesPorDni(string dni)
        {
            var clientes = await _clienteLogica.ObtenerClientesPorDni(dni);
            if (clientes == null || !clientes.Any())
                return NotFound($"No hay clientes con DNI {dni}.");

            return Ok(clientes);
        }


        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteDTO cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }
            await _clienteLogica.ActualizarCliente(cliente);

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> PostCliente(ClienteDTO cliente)
        {
            var clienteDto = new ClienteDTO
            {
                PersonaId = cliente.PersonaId,
                EstadoId = cliente.EstadoId
            };

            var nuevoCliente = await _clienteLogica.CrearCliente(clienteDto);

            return CreatedAtAction("ClientesGet", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _clienteLogica.EliminarCliente(id);

            return NoContent();
        }

        // Plantear los get para
        //Task<List<ClienteDTO>> ObtenerClientesPorDni(string dni);
        //Task<PersonaDTO> ObtenerPersonaPorClienteId(int clienteId);
    }
}
