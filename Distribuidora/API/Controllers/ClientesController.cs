using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CDatos.Data;
using Shared.Entities;
using CNegocio.Logica.ILogica;
using Shared.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteLogica _IClienteLogica;
        public ClientesController(IClienteLogica _IClienteLogica)
        {
            this._IClienteLogica = _IClienteLogica;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes()
        {
            return await _IClienteLogica.ObtenerClientes();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetCliente(int id)
        {
            var cliente = await _IClienteLogica.ObtenerClientePorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
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
            _IClienteLogica.ActualizarCliente(cliente);

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> PostCliente(ClienteDTO cliente)
        {
            _IClienteLogica.CrearCliente(cliente);

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            _IClienteLogica.EliminarCliente(id);

            return NoContent();
        }

        // Plantear los get para
        //Task<List<ClienteDTO>> ObtenerClientesPorDni(string dni);
        //Task<PersonaDTO> ObtenerPersonaPorClienteId(int clienteId);
    }
}
