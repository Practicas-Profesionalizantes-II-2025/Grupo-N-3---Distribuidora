using CNegocio.Logica;
using CNegocio.Logica.ILogica;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
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
        public async Task<ActionResult<IEnumerable<ProveedorDTO>>> GetProveedor()
        {
            return await _proveedorLogica.ObtenerProveedores();
        }

        // GET: api/Proveedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProveedorDTO>> GetProveedor(int id)
        {
            var proveedor = await _proveedorLogica.ObtenerProveedorPorId(id);
            if (proveedor == null)
                return NotFound($"No se encontró un proveedor con Id {id}");

            return proveedor;
        }

        // PUT: api/Proveedor
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedor(int id,ProveedorDTO proveedor)
        {
            try
            {
                await _proveedorLogica.ActualizarProveedor(proveedor);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message }); 
            }
        }

        // POST: api/Proveedor/5
        [HttpPost]
        public async Task<ActionResult<ProveedorDTO>> PostProveedor(ProveedorDTO proveedor)
        {
            try
            {
                var proveedorCreado = await _proveedorLogica.CrearProveedor(proveedor);

                return CreatedAtAction(nameof(GetProveedor), new { id = proveedorCreado.Id }, proveedorCreado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message }); 
            }
        }

        // DELETE: api/Proveedor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            await _proveedorLogica.EliminarProveedor(id);

            return NoContent();
        }
    }
}
