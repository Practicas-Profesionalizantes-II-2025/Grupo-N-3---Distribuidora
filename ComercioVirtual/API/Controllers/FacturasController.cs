using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.Facturas;
using Api.Data;
using Shared.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")] // Ruta agregada automaticamente
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly DataContext _context;

        public FacturasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Facturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facturas>>> GetFacturas()
        {
            return await _context.Facturas.ToListAsync();
        }

        // GET api/Facturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facturas>> GetFactura(int id)
        {
            var Factura = await _context.Facturas.FindAsync(id);

            if (Factura == null)
            {
                return NotFound();
            }

            return Factura;
        }

        // GET: api/Facturas/Luis
        //[HttpGet("nombre/{nombre}")]
        //public async Task<ActionResult<IEnumerable<Facturas>>> GetFactura(string nombre)
        //{
        //    var queryable = _context.Facturas.AsQueryable().Where(x => x.Nombre.Contains(nombre));

        //    var listaFacturas = await queryable.ToListAsync();

        //    if (listaFacturas == null || listaFacturas.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return listaFacturas;
        //}

        // POST: api/Facturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Facturas>> PostFactura(CrearDTOFacturas Factura)
        {
            Facturas FacturaEntity = new Facturas { numeroFactura = Factura.numeroFactura, };

            _context.Facturas.Add(FacturaEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactura", new { id = FacturaEntity.Id }, FacturaEntity);
        }

        // PUT: api/Facturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Facturas>> PutFactura(int id, ModificarDTOFacturas Factura)
        {
            Facturas FacturaEntity = new Facturas { Id = id, numeroFactura = Factura.numeroFactura, };

            _context.Entry(FacturaEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return FacturaEntity;
        }

        // DELETE: api/Facturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            var Factura = await _context.Facturas.FindAsync(id);
            if (Factura == null)
            {
                return NotFound();
            }

            _context.Facturas.Remove(Factura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturasExists(int id)
        {
            return _context.Facturas.Any(e => e.Id == id);
        }
    }
}
