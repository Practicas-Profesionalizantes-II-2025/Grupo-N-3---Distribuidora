using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CDatos.Data;
using Shared.Entities;
using Shared.DTOs;
using CNegocio.Logica.ILogica;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoLogica _IProductoLogicaa;

        public ProductoController(IProductoLogica context)
        {
            _IProductoLogicaa = context;
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> ProductoGet()
        {
            return await _IProductoLogicaa.ObtenerProductos();
        }

        // GET: api/Producto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> ProductoGet(int id)
        {
            var producto = await _IProductoLogicaa.ObtenerProductoPorId(id);

            return producto;
        }

        // GET: api/Producto/nombre/nombreProdcuto
        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> ProductoGetPorNombre(string nombre)
        {
            var producto = await _IProductoLogicaa.ObtenerProductosPorNombre(nombre);
            return producto;
        }

        // PUT: api/Producto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> ProductoPut(int id, ProductoDTO producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            _IProductoLogicaa.ActualizarProducto(producto);

            return NoContent();
        }

        // POST: api/Producto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producto>> ProductoPost(ProductoDTO producto)
        {
            _IProductoLogicaa.CrearProducto(producto);

            return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
        }

        // DELETE: api/Producto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> ProductoDelete(int id)
        {
            await _IProductoLogicaa.EliminarProducto(id);

            return NoContent();
        }
    }
}
