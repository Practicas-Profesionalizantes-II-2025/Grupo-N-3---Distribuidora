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
    public class DistribuidorController : ControllerBase
    {
        private readonly IDistribuidorLogica _IDistribuidorLogica;
        public DistribuidorController(IDistribuidorLogica _IDistribuidorLogica)
        {
            this._IDistribuidorLogica = _IDistribuidorLogica;
        }

        // GET: api/Distribuidors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistribuidorDTO>>> GetDistribuidores()
        {
            return await _IDistribuidorLogica.ObtenerDistribuidores();
        }

        // GET: api/Distribuidors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DistribuidorDTO>> GetDistribuidor(int id)
        {
            var distribuidor = await _IDistribuidorLogica.ObtenerDistribuidorPorId(id);

            if (distribuidor == null)
            {
                return NotFound();
            }

            return distribuidor;
        }

        // PUT: api/Distribuidors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistribuidor(int id, DistribuidorDTO distribuidor)
        {
            _IDistribuidorLogica.ActualizarDistribuidor(distribuidor);

            return NoContent();
        }

        // POST: api/Distribuidors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Distribuidor>> PostDistribuidor(DistribuidorDTO distribuidor)
        {
            _IDistribuidorLogica.CrearDistribuidor(distribuidor);

            return CreatedAtAction("GetDistribuidor", new { id = distribuidor.Id }, distribuidor);
        }

        // DELETE: api/Distribuidors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistribuidor(int id)
        {
            _IDistribuidorLogica.EliminarDistribuidor(id);

            return NoContent();
        }
    }
}
