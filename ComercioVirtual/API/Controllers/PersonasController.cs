using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.Personas;
using Api.Data;
using Shared.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")] // Ruta agregada automaticamente
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personas>>> GetPersonas()
        {
            var tipoDocumento = await _context.Empleados.Include(e => e.Persona.Tipo_Doc).ToListAsync();
            return await _context.Personas.ToListAsync();
        }

        // GET api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personas>> GetPersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // GET: api/Personas/Luis
        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<Personas>>> GetPersona(string nombre)
        {
            var queryable = _context.Personas.AsQueryable().Where(x => x.Nombre.Contains(nombre));

            var listaPersonas = await queryable.ToListAsync();

            if (listaPersonas == null || listaPersonas.Count == 0)
            {
                return NotFound();
            }

            return listaPersonas;
        }

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Personas>> PostPersona(CrearDTOPersonas persona)
        {
            Personas personaEntity = new Personas { Nombre = persona.Nombre, 
                                                    Apellido = persona.Apellido, 
                                                    Tipo_Doc = persona.Tipo_Doc, 
                                                    Nro_Doc = persona.Nro_Doc,
                                                    Ciudad = persona.Ciudad,
                                                    Email = persona.Email, 
                                                    Direccion = persona.Direccion, 
                                                    Telefono = persona.Telefono };

        _context.Personas.Add(personaEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = personaEntity.Id }, personaEntity);
        }

        // PUT: api/Personas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Personas>> PutPersona(int id, ModificarDTOPersonas Persona)
        {
            Personas PersonaEntity = new Personas { Id = id, Nombre = Persona.Nombre, };

            _context.Entry(PersonaEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return PersonaEntity;
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonasExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }
    }
}
