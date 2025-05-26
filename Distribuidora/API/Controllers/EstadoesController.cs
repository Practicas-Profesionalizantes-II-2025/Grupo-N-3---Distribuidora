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
    public class EstadoesController : ControllerBase
    {
        private readonly IEstadoLogica _estadoLogic;
        public EstadoesController(IEstadoLogica estadoLogic)
        {
            _estadoLogic = estadoLogic;
        }

        // GET: api/Estadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoDTO>>> GetEstados()
        {
            return await _estadoLogic.ObtenerEstados();
        }

        // GET: api/Estadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoDTO>> GetEstado(int id)
        {
            var estado = await _estadoLogic.ObtenerEstadoPorId(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        // PUT: api/Estadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstado(int id, EstadoDTO estado)
        {
            if (id != estado.Id)
            {
                return BadRequest();
            }

            _estadoLogic.ActualizarEstado(estado);

            return NoContent();
        }

        // POST: api/Estadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estado>> PostEstado(EstadoDTO estado)
        {
            _estadoLogic.CrearEstado(estado);

            return CreatedAtAction("GetEstado", new { id = estado.Id }, estado);
        }

        // DELETE: api/Estadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            _estadoLogic.EliminarEstado(id);

            return NoContent();
        }
    }
}
