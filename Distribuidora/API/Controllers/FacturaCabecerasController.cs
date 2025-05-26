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
    public class FacturaCabecerasController : ControllerBase
    {
        private readonly IFacturaCabeceraLogica _facturaCabeceraLogic;
        public FacturaCabecerasController(IFacturaCabeceraLogica facturaCabeceraLogic)
        {
            _facturaCabeceraLogic = facturaCabeceraLogic;
        }

        // GET: api/FacturaCabeceras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaCabeceraDTO>>> GetFacturasCabeceras()
        {
            return await _facturaCabeceraLogic.ObtenerFacturas();
        }

        // GET: api/FacturaCabeceras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaCabeceraDTO>> GetFacturaCabecera(int id)
        {
            return await _facturaCabeceraLogic.ObtenerFacturaPorId(id); ;
        }

        // PUT: api/FacturaCabeceras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaCabecera(int id, FacturaCabeceraDTO facturaCabecera)
        {
            _facturaCabeceraLogic.ActualizarFactura(facturaCabecera);
            return NoContent();
        }

        // POST: api/FacturaCabeceras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FacturaCabecera>> PostFacturaCabecera(FacturaCabeceraDTO facturaCabecera)
        {
            _facturaCabeceraLogic.CrearFactura(facturaCabecera);
            return CreatedAtAction("GetFacturaCabecera", new { id = facturaCabecera.Id }, facturaCabecera);
        }

        // DELETE: api/FacturaCabeceras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturaCabecera(int id)
        {
            _facturaCabeceraLogic.EliminarFactura(id);
            return NoContent();
        }
    }
}
