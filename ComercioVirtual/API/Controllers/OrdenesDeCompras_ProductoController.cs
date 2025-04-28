using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.OrdenesDeCompra_Producto;
using Api.Data;
using Shared.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")] // Ruta agregada automaticamente
    [ApiController]
    public class OrdenesDeCompra_ProductoController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdenesDeCompra_ProductoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/OrdenesDeCompra_Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenesDeCompra_Producto>>> GetOrdenesDeCompra_Producto()
        {
            return await _context.OrdenesDeCompra_Producto.ToListAsync();
        }

        // GET api/OrdenesDeCompra_Producto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenesDeCompra_Producto>> GetOrdenDeCompra_Producto(int id)
        {
            var OrdenDeCompra_Producto = await _context.OrdenesDeCompra_Producto.FindAsync(id);

            if (OrdenDeCompra_Producto == null)
            {
                return NotFound();
            }

            return OrdenDeCompra_Producto;
        }

        // GET: api/OrdenesDeCompra_Producto/Luis
        //[HttpGet("nombre/{nombre}")]
        //public async Task<ActionResult<IEnumerable<OrdenesDeCompra_Producto>>> GetOrdenDeCompra_Producto(string nombre)
        //{
        //    var queryable = _context.OrdenesDeCompra_Producto.AsQueryable().Where(x => x.Nombre.Contains(nombre));

        //    var listaOrdenesDeCompra_Producto = await queryable.ToListAsync();

        //    if (listaOrdenesDeCompra_Producto == null || listaOrdenesDeCompra_Producto.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return listaOrdenesDeCompra_Producto;
        //}

        // POST: api/OrdenesDeCompra_Producto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenesDeCompra_Producto>> PostOrdenDeCompra_Producto(CrearDTOOrdenesDeCompra_Producto OrdenDeCompra_Producto)
        {
            OrdenesDeCompra_Producto OrdenDeCompra_ProductoEntity = new OrdenesDeCompra_Producto { Producto = OrdenDeCompra_Producto.Producto, OrdenDeCompra = OrdenDeCompra_Producto.OrdenDeCompra };

            _context.OrdenesDeCompra_Producto.Add(OrdenDeCompra_ProductoEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenDeCompra_Producto", new { id = OrdenDeCompra_ProductoEntity.Id }, OrdenDeCompra_ProductoEntity);
        }

        // PUT: api/OrdenesDeCompra_Producto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<OrdenesDeCompra_Producto>> PutOrdenDeCompra_Producto(int id, ModificarDTOOrdenesDeCompra_Producto OrdenDeCompra_Producto)
        {
            OrdenesDeCompra_Producto OrdenDeCompra_ProductoEntity = new OrdenesDeCompra_Producto { Id = id, Producto = OrdenDeCompra_Producto.Producto, OrdenDeCompra = OrdenDeCompra_Producto.OrdenDeCompra };

            _context.Entry(OrdenDeCompra_ProductoEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenesDeCompra_ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return OrdenDeCompra_ProductoEntity;
        }

        // DELETE: api/OrdenesDeCompra_Producto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenDeCompra_Producto(int id)
        {
            var OrdenDeCompra_Producto = await _context.OrdenesDeCompra_Producto.FindAsync(id);
            if (OrdenDeCompra_Producto == null)
            {
                return NotFound();
            }

            _context.OrdenesDeCompra_Producto.Remove(OrdenDeCompra_Producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenesDeCompra_ProductoExists(int id)
        {
            return _context.OrdenesDeCompra_Producto.Any(e => e.Id == id);
        }
    }
}
