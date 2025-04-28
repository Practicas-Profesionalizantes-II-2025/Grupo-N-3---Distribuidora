using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.TipoDocumento;
using Api.Data;
using Shared.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")] // Ruta agregada automaticamente
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly DataContext _context;

        public TipoDocumentoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TipoDocumento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDocumento>>> GetTipoDocumento()
        {
            return await _context.TipoDocumento.ToListAsync();
        }

        // GET api/TipoDocumento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDocumento>> GetTipoDocumento(int id)
        {
            var TipoDocumento = await _context.TipoDocumento.FindAsync(id);

            if (TipoDocumento == null)
            {
                return NotFound();
            }

            return TipoDocumento;
        }

        // GET: api/TipoDocumento/Luis
        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<TipoDocumento>>> GetTipoDocumento(string nombre)
        {
            var queryable = _context.TipoDocumento.AsQueryable().Where(x => x.NombreTipoDocumento.Contains(nombre));

            var listaTipoDocumento = await queryable.ToListAsync();

            if (listaTipoDocumento == null || listaTipoDocumento.Count == 0)
            {
                return NotFound();
            }

            return listaTipoDocumento;
        }

        // POST: api/TipoDocumento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoDocumento>> PostTipoDocumento(CrearDTOTipoDocumento TipoDocumento)
        {
            TipoDocumento TipoDocumentoEntity = new TipoDocumento { NombreTipoDocumento = TipoDocumento.NombreTipoDocumento, };

            _context.TipoDocumento.Add(TipoDocumentoEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoDocumento", new { id = TipoDocumentoEntity.Id }, TipoDocumentoEntity);
        }

        // PUT: api/TipoDocumento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<TipoDocumento>> PutTipoDocumento(int id, ModificarDTOTipoDocumento TipoDocumento)
        {
            TipoDocumento TipoDocumentoEntity = new TipoDocumento { Id = id, NombreTipoDocumento = TipoDocumento.NombreTipoDocumento, };

            _context.Entry(TipoDocumentoEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDocumentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return TipoDocumentoEntity;
        }

        // DELETE: api/TipoDocumento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDocumento(int id)
        {
            var TipoDocumento = await _context.TipoDocumento.FindAsync(id);
            if (TipoDocumento == null)
            {
                return NotFound();
            }

            _context.TipoDocumento.Remove(TipoDocumento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoDocumentoExists(int id)
        {
            return _context.TipoDocumento.Any(e => e.Id == id);
        }
    }
}
