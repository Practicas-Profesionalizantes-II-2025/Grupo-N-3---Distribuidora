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
            return await _context.TipoDocumento.ToListAsync();
        }
        public async Task<TipoDocumento> ObtenerTipoDocumentoPorId(int id)
        {
            return await _context.TipoDocumento.FindAsync(id);
        }
        public async Task<TipoDocumento> CrearTipoDocumento(TipoDocumento tipoDocumento)
        {
            _context.TipoDocumento.Add(tipoDocumento);
            await _context.SaveChangesAsync();
            return tipoDocumento;
        }
        public void ActualizarTipoDocumento(TipoDocumento tipoDocumento)
        {
            var tipoDocumentoExistente = _context.TipoDocumento.Find(tipoDocumento.Id);
            if (tipoDocumentoExistente == null)
            {
                throw new Exception("Tipo Documento no encontrado.");
            }
            tipoDocumentoExistente.NombreTipoDocumento = tipoDocumento.NombreTipoDocumento;

            _context.SaveChangesAsync();
        }
        public void EliminarTipoDocumento(int id)
        {
            var TipoDocumento = _context.TipoDocumento.FirstOrDefault(x => x.Id == id);
            if (TipoDocumento != null)
            {
                _context.TipoDocumento.Remove(TipoDocumento);
                _context.SaveChanges();
            }
        }
    }
}
