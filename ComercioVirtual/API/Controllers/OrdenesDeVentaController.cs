using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.OrdenesDeVenta;
using Api.Data;
using Shared.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")] // Ruta agregada automaticamente
    [ApiController]
    public class OrdenesDeVentaController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdenesDeVentaController(DataContext context)
        {
            _context = context;
        }

        // GET: api/OrdenesDeVenta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenesDeVenta>>> GetOrdenesDeVenta()
        {
            return await _context.OrdenesDeVenta.ToListAsync();
        }

        // GET api/OrdenesDeVenta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenesDeVenta>> GetOrdenDeVenta(int id)
        {
            var OrdenDeVenta = await _context.OrdenesDeVenta.FindAsync(id);

            if (OrdenDeVenta == null)
            {
                return NotFound();
            }

            return OrdenDeVenta;
        }

        // GET: api/OrdenesDeVenta/Luis
        //[HttpGet("nombre/{nombre}")]
        //public async Task<ActionResult<IEnumerable<OrdenesDeVenta>>> GetOrdenDeVenta(string nombre)
        //{
        //    var queryable = _context.OrdenesDeVenta.AsQueryable().Where(x => x.Nombre.Contains(nombre));

        //    var listaOrdenesDeVenta = await queryable.ToListAsync();

        //    if (listaOrdenesDeVenta == null || listaOrdenesDeVenta.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return listaOrdenesDeVenta;
        //}

        // POST: api/OrdenesDeVenta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenesDeVenta>> PostOrdenDeVenta(CrearDTOOrdenesDeVenta OrdenDeVenta)
        {
            OrdenesDeVenta OrdenDeVentaEntity = new OrdenesDeVenta { Factura = OrdenDeVenta.Factura, Empleado = OrdenDeVenta.Empleado, Cliente = OrdenDeVenta.Cliente, Distribuidor = OrdenDeVenta.Distribuidor };

            _context.OrdenesDeVenta.Add(OrdenDeVentaEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenDeVenta", new { id = OrdenDeVentaEntity.Id }, OrdenDeVentaEntity);
        }

        // PUT: api/OrdenesDeVenta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<OrdenesDeVenta>> PutOrdenDeVenta(int id, ModificarDTOOrdenesDeVenta OrdenDeVenta)
        {
            OrdenesDeVenta OrdenDeVentaEntity = new OrdenesDeVenta { Id = id, Factura = OrdenDeVenta.Factura, Empleado = OrdenDeVenta.Empleado, Cliente = OrdenDeVenta.Cliente, Distribuidor = OrdenDeVenta.Distribuidor };

            _context.Entry(OrdenDeVentaEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenesDeVentaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return OrdenDeVentaEntity;
        }

        // DELETE: api/OrdenesDeVenta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenDeVenta(int id)
        {
            var OrdenDeVenta = await _context.OrdenesDeVenta.FindAsync(id);
            if (OrdenDeVenta == null)
            {
                return NotFound();
            }

            _context.OrdenesDeVenta.Remove(OrdenDeVenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenesDeVentaExists(int id)
        {
            return _context.OrdenesDeVenta.Any(e => e.Id == id);
        }
    }
}
