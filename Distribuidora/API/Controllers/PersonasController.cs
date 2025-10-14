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
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaLogica _IPersonaLogica;

        public PersonasController(IPersonaLogica IPersonaLogica)
        {
            _IPersonaLogica = IPersonaLogica;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaDTO>>> PersonasGet()
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
        public async Task<IActionResult> PersonaPut(int id, PersonaDTO persona)
        {
            try
            {
                await _IPersonaLogica.ActualizarPersona(persona);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persona>> PersonaPost(PersonaDTO persona)
        {
            try
            {
                var personaCreada = await _IPersonaLogica.CrearPersona(persona);
                return CreatedAtAction(nameof(GetPersona), new { id = personaCreada.Id }, personaCreada);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> PersonaDelete(int id)
        {
            await _IPersonaLogica.EliminarPersona(id);

            return NoContent();
        }
    }
}
