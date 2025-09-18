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
            await _IPersonaLogica.ActualizarPersona(persona);

            return NoContent();
        }

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persona>> PersonaPost(PersonaDTO persona)
        {
            var personaCreada = await _IPersonaLogica.CrearPersona(persona);

            // Retornar persona con todos sus datos
            return CreatedAtAction(nameof(GetPersona), new { id = personaCreada.Id }, personaCreada);
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
