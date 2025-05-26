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

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenDeVentaProductoesController : ControllerBase
    {
        private readonly IOrdenDeVentaProductoLogica _IOrdenDeVentaProductoLogica;

        public OrdenDeVentaProductoesController(DataContext context)
        {
            this._IOrdenDeVentaProductoLogica = _IOrdenDeVentaProductoLogica;
        }

        // GET: api/OrdenDeVentaProductoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenDeVentaProductoDTO>>> GetOrdenesDeVentaProducto()
        {
            return await _IOrdenDeVentaProductoLogica.ObtenerOrdenesDeVentaProductos();
        }

        // GET: api/OrdenDeVentaProductoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenDeVentaProductoDTO>> GetOrdenDeVentaProductoPorId(int id)
        {
            var ordenDeVentaProducto = await _IOrdenDeVentaProductoLogica.ObtenerOrdenDeVentaProductoPorId(id);
            return ordenDeVentaProducto;
        }

        // PUT: api/OrdenDeVentaProductoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenDeVentaProducto(int id, OrdenDeVentaProductoDTO ordenDeVentaProducto)
        {
            _IOrdenDeVentaProductoLogica.ActualizarOrdenDeVentaProducto(ordenDeVentaProducto);

            return NoContent();
        }

        // POST: api/OrdenDeVentaProductoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenDeVentaProducto>> PostOrdenDeVentaProducto(OrdenDeVentaProductoDTO ordenDeVentaProducto)
        {
            _IOrdenDeVentaProductoLogica.CrearOrdenDeVentaProducto(ordenDeVentaProducto);

            return CreatedAtAction("GetOrdenDeVentaProducto", new { id = ordenDeVentaProducto.Id }, ordenDeVentaProducto);
        }

        // DELETE: api/OrdenDeVentaProductoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenDeVentaProducto(int id)
        {
            _IOrdenDeVentaProductoLogica.EliminarOrdenDeVentaProducto(id);

            return NoContent();
        }
    }
}
