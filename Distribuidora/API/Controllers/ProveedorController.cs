using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using CNegocio.Logica.ILogica;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorLogica _proveedorLogica;

        public ProveedorController(IProveedorLogica proveedorLogica)
        {
            _proveedorLogica = proveedorLogica;
        }

        // GET: api/Proveedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProveedorDTO>>> ObtenerProveedores()
        {
            var proveedores = await _proveedorLogica.ObtenerProveedores();
            return Ok(proveedores);
        }

        // GET: api/Proveedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProveedorDTO>> ObtenerProveedor(int id)
        {
            var proveedor = await _proveedorLogica.ObtenerProveedorPorId(id);
            if (proveedor == null)
                return NotFound($"No se encontró un proveedor con Id {id}");

            return Ok(proveedor);
        }

        // POST: api/Proveedor
        [HttpPost]
        public async Task<ActionResult<ProveedorDTO>> CrearProveedor(ProveedorDTO proveedor)
        {
            try
            {
                await _proveedorLogica.CrearProveedor(proveedor);
                return CreatedAtAction(nameof(ObtenerProveedor), new { id = proveedor.Id }, proveedor);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Proveedor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProveedor(int id, ProveedorDTO proveedor)
        {
            if (id != proveedor.Id)
                return BadRequest("El Id del proveedor no coincide.");

            try
            {
                await _proveedorLogica.ActualizarProveedor(proveedor);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Proveedor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProveedor(int id)
        {
            try
            {
                await _proveedorLogica.EliminarProveedor(id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
