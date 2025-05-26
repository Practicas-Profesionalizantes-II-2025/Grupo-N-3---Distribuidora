using CNegocio.Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNegocio.Logica.ILogica;
using Shared.DTOs;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        private readonly ISectorLogica _ISectorLogica;

        public SectorsController(ISectorLogica _ISectorLogica)
        {
            this._ISectorLogica = _ISectorLogica;
        }

        // GET: api/Sectors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SectorDTO>>> GetSectores()
        {
            return await _ISectorLogica.ObtenerSectores();
        }

        // GET: api/Sectors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SectorDTO>> GetSector(int id)
        {
            var sector = await _ISectorLogica.ObtenerSectorPorId(id);

            return sector;
        }

        // PUT: api/Sectors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSector(int id, SectorDTO sector)
        {
            _ISectorLogica.ActualizarSector(sector);

            return NoContent();
        }

        // POST: api/Sectors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sector>> PostSector(SectorDTO sector)
        {
            _ISectorLogica.CrearSector(sector);

            return CreatedAtAction("GetSector", new { id = sector.Id }, sector);
        }

        // DELETE: api/Sectors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSector(int id)
        {
            _ISectorLogica.EliminarSector(id);

            return NoContent();
        }
    }
}
