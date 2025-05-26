using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CDatos.Data;
using Shared.Entities;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using CNegocio.Logica;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenDeCompraProductoesController : ControllerBase
    {
        private readonly IOrdenDeCompraProductoLogica _ordenCompraProductoLogic;
        public OrdenDeCompraProductoesController(IOrdenDeCompraProductoLogica ordenCompraProductoLogic)
        {
            _ordenCompraProductoLogic = ordenCompraProductoLogic;
        }

        // GET: api/OrdenDeCompraProductoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenDeCompraProductoDTO>>> GetOrdenesDeCompraProducto()
        {
            return await _ordenCompraProductoLogic.ObtenerOrdenCompraProductos();
        }

        // GET: api/OrdenDeCompraProductoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenDeCompraProductoDTO>> GetOrdenDeCompraProducto(int id)
        {
            var ordenDeCompraProducto = await _ordenCompraProductoLogic.ObtenerOrdenCompraProductoPorId(id);

            if (ordenDeCompraProducto == null)
            {
                return NotFound();
            }

            return ordenDeCompraProducto;
        }

        // PUT: api/OrdenDeCompraProductoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenDeCompraProducto(int id, OrdenDeCompraProductoDTO ordenDeCompraProducto)
        {
            if (id != ordenDeCompraProducto.Id)
            {
                return BadRequest();
            }
            _ordenCompraProductoLogic.ActualizarOrdenCompraProducto(ordenDeCompraProducto);

            return NoContent();
        }

        // POST: api/OrdenDeCompraProductoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenDeCompraProducto>> PostOrdenDeCompraProducto(OrdenDeCompraProductoDTO ordenDeCompraProducto)
        {
            _ordenCompraProductoLogic.CrearOrdenCompraProducto(ordenDeCompraProducto);

            return CreatedAtAction("GetOrdenDeCompraProducto", new { id = ordenDeCompraProducto.Id }, ordenDeCompraProducto);
        }

        // DELETE: api/OrdenDeCompraProductoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenDeCompraProducto(int id)
        {
            _ordenCompraProductoLogic.EliminarOrdenCompraProducto(id);

            return NoContent();
        }
    }
}
