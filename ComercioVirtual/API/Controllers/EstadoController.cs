using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Shared.Entities;
using Shared.Dtos.Estados;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")] // Ruta agregada automaticamente
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly DataContext _context;

        public EstadosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Estados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estados>>> GetEstados()
        {
            return await _context.Estados.ToListAsync();
        }

        // GET api/Estados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estados>> GetEstado(int id)
        {
            var Estado = await _context.Estados.FindAsync(id);

            if (Estado == null)
            {
                return NotFound();
            }

            return Estado;
        }

        // GET: api/Estados/Luis
        [HttpGet("Descripcion/{Descripcion}")]
        public async Task<ActionResult<IEnumerable<Estados>>> GetEstado(string Descripcion)
        {
            var queryable = _context.Estados.AsQueryable().Where(x => x.Descripcion.Contains(Descripcion));

            var listaEstados = await queryable.ToListAsync();

            if (listaEstados == null || listaEstados.Count == 0)
            {
                return NotFound();
            }

            return listaEstados;
        }

        // POST: api/Estados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estados>> PostEstado(CrearDTOEstados Estado)
        {
            Estados EstadoEntity = new Estados { Descripcion = Estado.Descripcion, };

            _context.Estados.Add(EstadoEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstado", new { id = EstadoEntity.Id }, EstadoEntity);
        }

        // PUT: api/Estados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Estados>> PutEstado(int id, ModificarDTOEstados Estado)
        {
            Estados EstadoEntity = new Estados { Id = id, Descripcion = Estado.Descripcion, };

            _context.Entry(EstadoEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return EstadoEntity;
        }

        // DELETE: api/Estados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            var Estado = await _context.Estados.FindAsync(id);
            if (Estado == null)
            {
                return NotFound();
            }

            _context.Estados.Remove(Estado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadosExists(int id)
        {
            return _context.Estados.Any(e => e.Id == id);
        }
    }
}
