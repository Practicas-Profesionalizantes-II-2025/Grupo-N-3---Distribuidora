using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CNegocio.Logica.ILogica;
using Shared.Entities;
using Shared.DTOs;
using CNegocio.Logica;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly ICiudadLogica _IciudadLogica;


        public CiudadController(ICiudadLogica IciudadLogica)
        {
            _IciudadLogica = IciudadLogica;
        }

        // GET: api/Ciudads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CiudadDTO>>> CiudadesGet()
        {
            return await _IciudadLogica.ObtenerCiudades();
        }

        // GET: api/Ciudads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CiudadDTO>> CiudadGet(int id)
        {
            var ciudad = await _IciudadLogica.ObtenerCiudadPorId(id);

            if (ciudad == null)
            {
                return NotFound();
            }

            return ciudad;
        }

        // PUT: api/Ciudads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> CiudadPut(int id, CiudadDTO ciudad)
        {
            if (id != ciudad.Id)
            {
                return BadRequest();
            }

            _IciudadLogica.ActualizarCiudad(ciudad);

            return NoContent();
        }

        // POST: api/Ciudads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ciudad>> CiudadPost(CiudadDTO ciudad)
        {
            _IciudadLogica.CrearCiudad(ciudad);

            return CreatedAtAction("GetCiudad", new { id = ciudad.Id }, ciudad);
        }

        // DELETE: api/Ciudads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> CiudadDelete(int id)
        {
            _IciudadLogica.EliminarCiudad(id);

            return NoContent();
        }
    }
}
