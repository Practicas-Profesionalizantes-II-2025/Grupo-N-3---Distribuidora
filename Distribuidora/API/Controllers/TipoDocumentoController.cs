using CNegocio.Logica.ILogica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using System.Reflection.Metadata;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocLogica _tipodocLogica;
        public TipoDocumentoController(ITipoDocLogica tipodocLogica)
        {
            _tipodocLogica = tipodocLogica;
        }

        // GET: api/TipoDocumento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDocumentoDTO>>> TipoDocumentoGet()
        {
            return await _tipodocLogica.ObtenerTiposDocumento();
        }

        // GET: api/TipoDocumento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDocumentoDTO>> TipoDocumentoGet(int id)
        {
            var documentos = await _tipodocLogica.ObtenerTipoDocumentoPorId(id);

            if (documentos == null)
            {
                return NotFound();
            }

            return documentos;
        }

        // PUT: api/TipoDocumento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> TipoDocumentoPut(int id, TipoDocumentoDTO documentos)
        {
            if (id != documentos.Id)
            {
                return BadRequest();
            }

            await _tipodocLogica.ActualizarTipoDocumento(documentos);

            return NoContent();
        }

        // POST: api/TipoDocumento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoDocumentoDTO>> TipoDocumentoPost(TipoDocumentoDTO documentos)
        {
            await _tipodocLogica.CrearTipoDocumento(documentos);

            return CreatedAtAction("TipoDocumentoGet", new { id = documentos.Id }, documentos);
        }

        // DELETE: api/TipoDocumento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> TipoDocumentoDelete(int id)
        {
            await _tipodocLogica.EliminarTipoDocumento(id);

            return NoContent();
        }

    }
}
