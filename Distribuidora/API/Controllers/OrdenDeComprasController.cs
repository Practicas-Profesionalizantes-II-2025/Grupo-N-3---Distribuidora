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
    public class OrdenDeComprasController : ControllerBase
    {
        private readonly IOrdenDeCompraLogica _ordenDeCompraLogic;

        public OrdenDeComprasController(IOrdenDeCompraLogica _ordenDeCompraLogic)
        {
            this._ordenDeCompraLogic = _ordenDeCompraLogic;
        }

        // GET: api/OrdenDeCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenDeCompraDTO>>> GetOrdenesDeCompra()
        {
            return await _ordenDeCompraLogic.ObtenerOrdenesDeCompra();
        }

        // GET: api/OrdenDeCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenDeCompraDTO>> GetOrdenDeCompraPorId(int id)
        {
            var ordenDeCompra = await _ordenDeCompraLogic.ObtenerOrdenDeCompraPorId(id);

            if (ordenDeCompra == null)
            {
                return NotFound();
            }

            return ordenDeCompra;
        }

        // PUT: api/OrdenDeCompras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenDeCompra(int id, OrdenDeCompraDTO ordenDeCompra)
        {
            if (id != ordenDeCompra.Id)
            {
                return BadRequest();
            }

            _ordenDeCompraLogic.ActualizarOrdenDeCompra(ordenDeCompra);

            return NoContent();
        }

        // POST: api/OrdenDeCompras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenDeCompra>> PostOrdenDeCompra(OrdenDeCompraDTO ordenDeCompra)
        {
            _ordenDeCompraLogic.CrearOrdenDeCompra(ordenDeCompra);

            return CreatedAtAction("GetOrdenDeCompra", new { id = ordenDeCompra.Id }, ordenDeCompra);
        }

        // DELETE: api/OrdenDeCompras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenDeCompra(int id)
        {
            _ordenDeCompraLogic.EliminarOrdenDeCompra(id);

            return NoContent();
        }
    }
}
