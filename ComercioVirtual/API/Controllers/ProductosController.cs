using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.Productos;
using Api.Data;
using Shared.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")] // Ruta agregada automaticamente
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        // GET api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetProducto(int id)
        {
            var Producto = await _context.Productos.FindAsync(id);

            if (Producto == null)
            {
                return NotFound();
            }

            return Producto;
        }

        // GET: api/Productos/Luis
        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<Productos>>> GetProducto(string nombre)
        {
            var queryable = _context.Productos.AsQueryable().Where(x => x.Nombre.Contains(nombre));

            var listaProductos = await queryable.ToListAsync();

            if (listaProductos == null || listaProductos.Count == 0)
            {
                return NotFound();
            }

            return listaProductos;
        }

        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Productos>> PostProducto(CrearDTOProductos Producto)
        {
            Productos ProductoEntity = new Productos { Nombre = Producto.Nombre, };

            _context.Productos.Add(ProductoEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducto", new { id = ProductoEntity.Id }, ProductoEntity);
        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Productos>> PutProducto(int id, ModificarDTOProductos Producto)
        {
            Productos ProductoEntity = new Productos { Id = id, Nombre = Producto.Nombre, };

            _context.Entry(ProductoEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return ProductoEntity;
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var Producto = await _context.Productos.FindAsync(id);
            if (Producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(Producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductosExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
