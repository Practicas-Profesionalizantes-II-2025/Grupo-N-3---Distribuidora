using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.Empleados;
using Api.Data;
using Shared.Entities;


namespace API.Controllers
{
    [Route("api/[controller]")] // Ruta agregada automaticamente
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly DataContext _context;

        public EmpleadosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleados>>> GetEmpleados()
        {
            var empleados = await _context.Empleados.Include(e => e.Persona).ToListAsync();
            var tipoDocumento = await _context.Empleados.Include(e => e.Persona.Tipo_Doc).ToListAsync();
            var estado = await _context.Empleados.Include(e => e.EstadoEmpleado).ToListAsync();
            var ciudad = await _context.Empleados.Include(e => e.Persona.Ciudad).ToListAsync();

            return await _context.Empleados.ToListAsync();
        }

        // GET api/Empleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleados>> GetEmpleado(int id)
        {
            var Empleado = await _context.Empleados.FindAsync(id);

            if (Empleado == null)
            {
                return NotFound();
            }

            return Empleado;
        }

        // GET: api/Empleados/Luis
        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<Empleados>>> GetEmpleado(string nombre)
        {
            var queryable = _context.Empleados.AsQueryable().Where(x => x.Persona.Nombre.Contains(nombre));

            var listaEmpleados = await queryable.ToListAsync();

            if (listaEmpleados == null || listaEmpleados.Count == 0)
            {
                return NotFound();
            }

            return listaEmpleados;
        }

        // POST: api/Empleados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empleados>> PostEmpleado(CrearDTOEmpleados Empleado)
        {
            Empleados EmpleadoEntity = new Empleados
            {
                Persona = Empleado.Persona,
                EstadoEmpleado = Empleado.EstadoEmpleado,
                Foto = Empleado.Foto,
                CreatedDate = DateTime.Now
            };

            _context.Empleados.Add(EmpleadoEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleado", new { id = EmpleadoEntity.Id }, EmpleadoEntity);
        }

        // PUT: api/Empleados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Empleados>> PutEmpleado(int id, ModificarDTOEmpleados Empleado)
        {
            Empleados EmpleadoEntity = new Empleados { Id = id, Persona = Empleado.Persona, };

            _context.Entry(EmpleadoEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return EmpleadoEntity;
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var Empleado = await _context.Empleados.FindAsync(id);
            if (Empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(Empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadosExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
