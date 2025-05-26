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
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaLogica _IcategoriaLogica;
        public CategoriasController(ICategoriaLogica _IcategoriaLogica)
        {
            this._IcategoriaLogica = _IcategoriaLogica;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategorias()
        {
            return await _IcategoriaLogica.ObtenerCategorias();
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDTO>> GetCategoria(int id)
        {
            var categoria = await _IcategoriaLogica.ObtenerCategoriaPorId(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, CategoriaDTO categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            _IcategoriaLogica.ActualizarCategoria(categoria);

            return NoContent();
        }

        // POST: api/Categorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriaDTO>> PostCategoria(CategoriaDTO categoria)
        {
            _IcategoriaLogica.CrearCategoria(categoria);

            return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            _IcategoriaLogica.EliminarCategoria(id);

            return NoContent();
        }

    }
}
