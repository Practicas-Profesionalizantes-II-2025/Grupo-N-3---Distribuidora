using CDatos.Data;
using CNegocio.Logica;
using CNegocio.Logica.ILogica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenDeVentasController : ControllerBase
    {
        private readonly IOrdenDeVentaLogica _ordenDeVentaLogica;

        public OrdenDeVentasController(IOrdenDeVentaLogica ordenDeVentaLogica)
        {
            _ordenDeVentaLogica = ordenDeVentaLogica;
        }

        // GET: api/OrdenDeVentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenDeVentaDTO>>> GetOrdenesDeVenta()
        {
            var ordenes = await _ordenDeVentaLogica.ObtenerOrdenesDeVenta();
            return Ok(ordenes);
        }

        // GET: api/OrdenDeVentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenDeVentaDTO>> GetOrdenDeVentaPorId(int id)
        {
            var ordenDeVenta = await _ordenDeVentaLogica.ObtenerOrdenDeVentaPorId(id);

            if (ordenDeVenta == null)
            {
                return NotFound();
            }

            return ordenDeVenta;
        }

        // PUT: api/OrdenDeVentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenDeVenta(int id, OrdenDeVentaDTO ordenDeVenta)
        {
            if (id != ordenDeVenta.Id)
            {
                return BadRequest();
            }
            await _ordenDeVentaLogica.ActualizarOrdenDeVenta(ordenDeVenta);

            return NoContent();
        }

        // POST: api/OrdenDeVentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenDeVentaDTO>> PostOrdenDeVenta(OrdenDeVentaDTO ordenDeVenta)
        {
            try
            {
                await _ordenDeVentaLogica.CrearOrdenDeVenta(ordenDeVenta);
                return CreatedAtAction("GetOrdenDeVentaPorId", new { id = ordenDeVenta.Id }, ordenDeVenta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/OrdenDeVentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenDeVenta(int id)
        {
            await _ordenDeVentaLogica.EliminarOrdenDeVenta(id);

            return NoContent();
        }
    }
}
