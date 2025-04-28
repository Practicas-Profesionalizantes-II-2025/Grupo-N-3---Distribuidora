using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.Personas;
using Api.Data;
using Shared.Entities;
using Shared.Dtos.Clientes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")] // Ruta agregada automaticamente
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DataContext _context;

        public ClientesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetCliente(int id)
        {
            var Cliente = await _context.Clientes.FindAsync(id);

            if (Cliente == null)
            {
                return NotFound();
            }

            return Cliente;
        }

        // GET: api/Clientes/Luis
        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetCliente(string nombre)
        {
            var queryable = _context.Personas.AsQueryable().Where(x => x.Nombre.Contains(nombre));

            var queryable2 = _context.Clientes.AsQueryable().Where(x => x.Persona == queryable);

            var listaClientes = await queryable2.ToListAsync();

            if (listaClientes == null || listaClientes.Count == 0)
            {
                return NotFound();
            }

            return listaClientes;
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clientes>> PostCliente(CrearDTOClientes cliente)
        {
            Clientes clienteEntity = new Clientes { Persona = cliente.Persona };

            _context.Clientes.Add(clienteEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = clienteEntity.Id }, clienteEntity);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Clientes>> PutCliente(int id, ModificarDTOClientes cliente)
        {
            Clientes clienteEntity = new Clientes { Id = id, Persona = cliente.Persona, };

            _context.Entry(clienteEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return clienteEntity;
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await _context.Clientes.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientesExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
