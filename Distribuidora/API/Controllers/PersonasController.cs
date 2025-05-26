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
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaLogica _IPersonaLogica;

        public PersonasController(IPersonaLogica _IPersonaLogica)
        {
            this._IPersonaLogica = _IPersonaLogica;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaDTO>>> GetPersonas()
        {
            return await _IPersonaLogica.ObtenerPersonas();
        }
        // Implemetar Get por DNI
        //[HttpGet("dni/{dni}")]



        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaDTO>> GetPersona(int id)
        {
            var persona = await _IPersonaLogica.ObtenerPersonaPorId(id);

            return persona;
        }

        // PUT: api/Personas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, PersonaDTO persona)
        {
            _IPersonaLogica.ActualizarPersona(persona);

            return NoContent();
        }

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(PersonaDTO persona)
        {
            _IPersonaLogica.CrearPersona(persona);

            return CreatedAtAction("GetPersona", new { id = persona.Id }, persona);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            _IPersonaLogica.EliminarPersona(id);

            return NoContent();
        }
    }
}
