using CDatos.Data;
using CDatos.Repositorios.IRepositorios;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.Repositorios
{
    public class TipoDocumentoRepositorio : ITipoDocumentoRepositorio
    {
        private readonly DataContext _context;
        public TipoDocumentoRepositorio(DataContext context)
        {
            _context = context;
        }
        public async Task<List<TipoDocumento>> ObtenerTiposDocumento()
        {
            return await _context.TiposDocumento.ToListAsync();
        }
        public async Task<TipoDocumento> ObtenerTipoDocumentoPorId(int id)
        {
            return await _context.TiposDocumento.FindAsync(id);
        }
        public async Task CrearTipoDocumento(TipoDocumento tipoDocumento)
        {
            _context.TiposDocumento.Add(tipoDocumento);
            await _context.SaveChangesAsync();
        }
        public async Task ActualizarTipoDocumento(TipoDocumento tipoDocumento)
        {
            var tipoDocumentoExistente = _context.TiposDocumento.Find(tipoDocumento.Id);
            if (tipoDocumentoExistente == null)
            {
                throw new Exception("Tipo Documento no encontrado.");
            }
            tipoDocumentoExistente.NombreTipoDocumento = tipoDocumento.NombreTipoDocumento;

            await _context.SaveChangesAsync();
        }
        public async Task EliminarTipoDocumentoAsync(int id)
        {
            var tipoDocumento = await ObtenerTipoDocumentoPorId(id);
            if (tipoDocumento != null)
            {
                _context.TiposDocumento.Remove(tipoDocumento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
