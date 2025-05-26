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
    public class OrdenDeVentasController : ControllerBase
    {
        private readonly IOrdenDeVentaLogica _ordenDeVentaLogica;

        public OrdenDeVentasController(DataContext context)
        {
            this._ordenDeVentaLogica = _ordenDeVentaLogica;
        }

        // GET: api/OrdenDeVentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenDeVentaDTO>>> GetOrdenesDeVenta()
        {
            return await _ordenDeVentaLogica.ObtenerOrdenesDeVenta();
        }

        // GET: api/OrdenDeVentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenDeVentaDTO>> GetOrdenDeVenta(int id)
        {
            var ordenDeVenta = await _ordenDeVentaLogica.ObtenerOrdenDeVentaPorId(id);

            return ordenDeVenta;
        }

        // PUT: api/OrdenDeVentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenDeVenta(int id, OrdenDeVentaDTO ordenDeVenta)
        {
            _ordenDeVentaLogica.ActualizarOrdenDeVenta(ordenDeVenta);

            return NoContent();
        }

        // POST: api/OrdenDeVentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenDeVentaDTO>> PostOrdenDeVenta(OrdenDeVentaDTO ordenDeVenta)
        {
            _ordenDeVentaLogica.CrearOrdenDeVenta(ordenDeVenta);

            return CreatedAtAction("GetOrdenDeVenta", new { id = ordenDeVenta.Id }, ordenDeVenta);
        }

        // DELETE: api/OrdenDeVentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenDeVenta(int id)
        {
            _ordenDeVentaLogica.EliminarOrdenDeVenta(id);

            return NoContent();
        }
    }
}
