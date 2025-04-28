using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.Distribuidores;
using Api.Data;
using Shared.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")] // Ruta agregada automaticamente
    [ApiController]
    public class DistribuidoresController : ControllerBase
    {
        private readonly DataContext _context;

        public DistribuidoresController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Distribuidores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distribuidores>>> GetDistribuidores()
        {
            return await _context.Distribuidores.ToListAsync();
        }

        // GET api/Distribuidores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Distribuidores>> GetDistribuidor(int id)
        {
            var Distribuidor = await _context.Distribuidores.FindAsync(id);

            if (Distribuidor == null)
            {
                return NotFound();
            }

            return Distribuidor;
        }

        // GET: api/Distribuidores/Luis
        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<Distribuidores>>> GetDistribuidor(string nombre)
        {
            var queryable = _context.Distribuidores.AsQueryable().Where(x => x.Nombre.Contains(nombre));

            var listaDistribuidores = await queryable.ToListAsync();

            if (listaDistribuidores == null || listaDistribuidores.Count == 0)
            {
                return NotFound();
            }

            return listaDistribuidores;
        }

        // POST: api/Distribuidores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Distribuidores>> PostDistribuidor(CrearDTODistribuidores Distribuidor)
        {
            Distribuidores DistribuidorEntity = new Distribuidores { Nombre = Distribuidor.Nombre, };

            _context.Distribuidores.Add(DistribuidorEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistribuidor", new { id = DistribuidorEntity.Id }, DistribuidorEntity);
        }

        // PUT: api/Distribuidores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Distribuidores>> PutDistribuidor(int id, ModificarDTODistribuidores Distribuidor)
        {
            Distribuidores DistribuidorEntity = new Distribuidores { Id = id, Nombre = Distribuidor.Nombre, };

            _context.Entry(DistribuidorEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistribuidoresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return DistribuidorEntity;
        }

        // DELETE: api/Distribuidores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistribuidor(int id)
        {
            var Distribuidor = await _context.Distribuidores.FindAsync(id);
            if (Distribuidor == null)
            {
                return NotFound();
            }

            _context.Distribuidores.Remove(Distribuidor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DistribuidoresExists(int id)
        {
            return _context.Distribuidores.Any(e => e.Id == id);
        }
    }
}
