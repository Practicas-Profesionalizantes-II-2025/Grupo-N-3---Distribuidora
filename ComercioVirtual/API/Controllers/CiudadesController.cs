using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.Ciudades;
using Api.Data;
using Shared.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")] // Ruta agregada automaticamente
    [ApiController]
    public class CiudadesController : ControllerBase
    {
        private readonly DataContext _context;

        public CiudadesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Ciudades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ciudades>>> GetCiudades()
        {
            return await _context.Ciudades.ToListAsync();
        }

        // GET api/Ciudades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ciudades>> GetCiudad(int id)
        {
            var Ciudad = await _context.Ciudades.FindAsync(id);

            if (Ciudad == null)
            {
                return NotFound();
            }

            return Ciudad;
        }

        // GET: api/Ciudades/Luis
        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<Ciudades>>> GetCiudad(string nombre)
        {
            var queryable = _context.Ciudades.AsQueryable().Where(x => x.Nombre.Contains(nombre));

            var listaCiudades = await queryable.ToListAsync();

            if (listaCiudades == null || listaCiudades.Count == 0)
            {
                return NotFound();
            }

            return listaCiudades;
        }

        // POST: api/Ciudades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ciudades>> PostCiudad(CrearDTOCiudades Ciudad)
        {
            Ciudades CiudadEntity = new Ciudades { Nombre = Ciudad.Nombre, };

            _context.Ciudades.Add(CiudadEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCiudad", new { id = CiudadEntity.Id }, CiudadEntity);
        }

        // PUT: api/Ciudades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Ciudades>> PutCiudad(int id, ModificarDTOCiudades Ciudad)
        {
            Ciudades CiudadEntity = new Ciudades { Id = id, Nombre = Ciudad.Nombre, };

            _context.Entry(CiudadEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CiudadesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CiudadEntity;
        }

        // DELETE: api/Ciudades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCiudad(int id)
        {
            var Ciudad = await _context.Ciudades.FindAsync(id);
            if (Ciudad == null)
            {
                return NotFound();
            }

            _context.Ciudades.Remove(Ciudad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CiudadesExists(int id)
        {
            return _context.Ciudades.Any(e => e.Id == id);
        }
    }
}
