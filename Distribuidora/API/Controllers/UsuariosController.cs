using Microsoft.AspNetCore.Mvc;
using Shared.Entities;
using Shared.DTOs;
using CNegocio.Logica.ILogica;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioLogica _IusuarioLogica;

        public UsuariosController(IUsuarioLogica IusuarioLogica)
        {
            _IusuarioLogica = IusuarioLogica;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            return await _IusuarioLogica.ObtenerUsuarios();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            var usuario = await _IusuarioLogica.ObtenerUsuarioPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioDTO usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _IusuarioLogica.ActualizarUsuario(usuario);

            return NoContent();
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> PostUsuario(UsuarioDTO usuario)
        {
            _IusuarioLogica.CrearUsuario(usuario);

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            _IusuarioLogica.EliminarUsuario(id);

            return NoContent();
        }
    }
}
