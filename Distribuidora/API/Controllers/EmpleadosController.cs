using API.Metricas;
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

        // GET: api/Empleados/dni/12345678/contrasenia
        [HttpGet("dni/{dni}/{contrasenia}")]
        public async Task<bool> ValidacionEmpleado(string dni, string contrasenia)
        {
            var valido = await _empleadoLogic.ValidacionEmpleado(dni, contrasenia);

            if (!valido)
            {
                LoginMetrics.LoginFallidos.Inc(); // 👈 incrementa el contador
            }

            return valido;
        }

        // PUT: api/Empleados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, EmpleadoDTO empleado)
        {
            try
            {
                await _empleadoLogic.ActualizarEmpleado(empleado);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
           
        }

        // POST: api/Empleados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(EmpleadoDTO empleado)
        {
            try
            {
                var personaCreada = await _personaLogica.CrearPersona(empleado.Persona);

                var empleadoDto = new EmpleadoDTO
                {
                    PersonaId = personaCreada.Id,
                    Persona = personaCreada,
                    EstadoId = empleado.EstadoId,
                    Contrasenia = empleado.Contrasenia,
                    Admin = empleado.Admin
                };

                var nuevoEmpleado = await _empleadoLogic.CrearEmpleado(empleadoDto);
                LoginMetrics.EmpleadosCreados.Inc(); // Incrementa el contador cuando se crea un empleado
                nuevoEmpleado.Persona = personaCreada;
                return CreatedAtAction(nameof(GetEmpleado), new { id = nuevoEmpleado.Id }, nuevoEmpleado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }    
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            await _empleadoLogic.EliminarEmpleado(id);

            return NoContent();
        }

        [HttpGet("dni/{dni}")]
        public async Task<ActionResult<EmpleadoDTO>> GetEmpleadoPorDni(string dni)
        {
            var empleados = await _empleadoLogic.ObtenerEmpleadosPorDni(dni);
            var empleado = empleados.FirstOrDefault();

            if (empleado == null)
                return NotFound();

            return Ok(empleado);
        }
    }
}
