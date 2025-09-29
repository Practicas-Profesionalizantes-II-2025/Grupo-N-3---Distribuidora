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
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoLogica _empleadoLogic;
        private readonly IPersonaLogica _personaLogica;
        public EmpleadosController(IEmpleadoLogica empleadoLogic, IPersonaLogica personaLogica)
        {
            _empleadoLogic = empleadoLogic;
            _personaLogica = personaLogica;
        }

        // GET: api/Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoDTO>>> GetEmpleado()
        {
            return await _empleadoLogic.ObtenerEmpleados();
        }

        // GET: api/Empleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoDTO>> GetEmpleado(int id)
        {
            var empleado = await _empleadoLogic.ObtenerEmpleadoPorId(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        // PUT: api/Empleados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, EmpleadoDTO empleado)
        {
            if (id != empleado.Id)
            {
                return BadRequest();
            }
            await _empleadoLogic.ActualizarEmpleado(empleado);
            return NoContent();
        }

        // POST: api/Empleados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(EmpleadoDTO empleado)
        {
            var personaCreada = await _personaLogica.CrearPersona(empleado.Persona);

            var empleadoDto = new EmpleadoDTO
            {
                PersonaId = personaCreada.Id,
                Persona = personaCreada, 
                Foto = empleado.Foto,
                EstadoId = empleado.EstadoId
            };

            var nuevoEmpleado = await _empleadoLogic.CrearEmpleado(empleadoDto);
            nuevoEmpleado.Persona = personaCreada;
            return CreatedAtAction(nameof(GetEmpleado), new { id = nuevoEmpleado.Id }, nuevoEmpleado);
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            await _empleadoLogic.EliminarEmpleado(id);

            return NoContent();
        }
    }
}
