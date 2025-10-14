using CNegocio.Logica;
using CNegocio.Logica.ILogica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistribuidorController : ControllerBase
    {
        private readonly IDistribuidorLogica _distribuidorLogica;

        public DistribuidorController(IDistribuidorLogica distribuidorLogica)
        {
            _distribuidorLogica = distribuidorLogica;
        }

        // GET: api/Distribuidor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistribuidorDTO>>> GetDistribuidor()
        {
            return await _distribuidorLogica.ObtenerDistribuidores();
        }

        // GET: api/Distribuidor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DistribuidorDTO>> GetDistribuidor(int id)
        {
            var distribuidor = await _distribuidorLogica.ObtenerDistribuidorPorId(id);
            if (distribuidor == null)
                return NotFound($"No se encontró un distribuidor con Id {id}");

            return distribuidor;
        }

        // PUT: api/Distribuidor
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistribuidor(int id, DistribuidorDTO distribuidor)
        {
            try
            {
                await _distribuidorLogica.ActualizarDistribuidor(distribuidor);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // POST: api/Distribuidor/5
        [HttpPost]
        public async Task<ActionResult<DistribuidorDTO>> PostDIstribuidor(DistribuidorDTO distribuidor)
        {
            try
            {
                var distribuidorCreado = await _distribuidorLogica.CrearDistribuidor(distribuidor);
                return CreatedAtAction(nameof(GetDistribuidor), new { id = distribuidorCreado.Id }, distribuidorCreado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            
        }

        // DELETE: api/Distribuidor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistribuidor(int id)
        {
            await _distribuidorLogica.EliminarDistribuidor(id);

            return NoContent();
        }
}
}
