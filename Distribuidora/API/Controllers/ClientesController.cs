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
        public ClientesController(IClienteLogica IClienteLogica)
        {
            _IClienteLogica = IClienteLogica;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> ClientesGet()
        {
            return await _IClienteLogica.ObtenerClientes();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> ClientesGet(int id)
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
        public async Task<IActionResult> ClientesPut(int id, ClienteDTO cliente)
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
        public async Task<ActionResult<ClienteDTO>> ClientesPost(ClienteDTO cliente)
        {
            _IClienteLogica.CrearCliente(cliente);

            return CreatedAtAction("ClienteGet", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> ClienteDelete(int id)
        {
            _IClienteLogica.EliminarCliente(id);

            return NoContent();
        }

        // Plantear los get para
        //Task<List<ClienteDTO>> ObtenerClientesPorDni(string dni);
        //Task<PersonaDTO> ObtenerPersonaPorClienteId(int clienteId);
    }
}
