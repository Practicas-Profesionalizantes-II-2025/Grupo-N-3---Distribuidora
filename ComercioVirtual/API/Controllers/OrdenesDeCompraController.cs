using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.OrdenesDeCompra;
using Api.Data;
using Shared.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")] // Ruta agregada automaticamente
    [ApiController]
    public class OrdenesDeCompraController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdenesDeCompraController(DataContext context)
        {
            _context = context;
        }

        // GET: api/OrdenesDeCompra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenesDeCompra>>> GetOrdenesDeCompra()
        {
            return await _context.OrdenesDeCompra.ToListAsync();
        }

        // GET api/OrdenesDeCompra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenesDeCompra>> GetOrdenDeCompra(int id)
        {
            var OrdenDeCompra = await _context.OrdenesDeCompra.FindAsync(id);

            if (OrdenDeCompra == null)
            {
                return NotFound();
            }

            return OrdenDeCompra;
        }

        // GET: api/OrdenesDeCompra/Luis
        //[HttpGet("nombre/{nombre}")]
        //public async Task<ActionResult<IEnumerable<OrdenesDeCompra>>> GetOrdenDeCompra(string nombre)
        //{
        //    var queryable = _context.OrdenesDeCompra.AsQueryable().Where(x => x.Nombre.Contains(nombre));

        //    var listaOrdenesDeCompra = await queryable.ToListAsync();

        //    if (listaOrdenesDeCompra == null || listaOrdenesDeCompra.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return listaOrdenesDeCompra;
        //}

        // POST: api/OrdenesDeCompra
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenesDeCompra>> PostOrdenDeCompra(CrearDTOOrdenesDeCompra OrdenDeCompra)
        {
            OrdenesDeCompra OrdenDeCompraEntity = new OrdenesDeCompra { Empleado = OrdenDeCompra.Empleado, Distribuidor = OrdenDeCompra.Distribuidor };

            _context.OrdenesDeCompra.Add(OrdenDeCompraEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenDeCompra", new { id = OrdenDeCompraEntity.Id }, OrdenDeCompraEntity);
        }

        // PUT: api/OrdenesDeCompra/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<OrdenesDeCompra>> PutOrdenDeCompra(int id, ModificarDTOOrdenesDeCompra OrdenDeCompra)
        {
            OrdenesDeCompra OrdenDeCompraEntity = new OrdenesDeCompra { Id = id, Empleado = OrdenDeCompra.Empleado, Distribuidor = OrdenDeCompra.Distribuidor };

            _context.Entry(OrdenDeCompraEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenesDeCompraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return OrdenDeCompraEntity;
        }

        // DELETE: api/OrdenesDeCompra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenDeCompra(int id)
        {
            var OrdenDeCompra = await _context.OrdenesDeCompra.FindAsync(id);
            if (OrdenDeCompra == null)
            {
                return NotFound();
            }

            _context.OrdenesDeCompra.Remove(OrdenDeCompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenesDeCompraExists(int id)
        {
            return _context.OrdenesDeCompra.Any(e => e.Id == id);
        }
    }
}
