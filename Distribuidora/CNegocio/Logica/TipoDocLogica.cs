using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica
{
    public class TipoDocLogica : ITipoDocLogica
    {
        private readonly ITipoDocumentoRepositorio _documentoRepositorio;
        public TipoDocLogica(ITipoDocumentoRepositorio documentoRepositorio)
        {
            _documentoRepositorio = documentoRepositorio;
        }

        public async Task<List<TipoDocumentoDTO>> ObtenerTiposDocumento()
        {
            var documentos = await _documentoRepositorio.ObtenerTiposDocumento();
            return documentos.Select(c => new TipoDocumentoDTO
            {
                Id = c.Id,
                NombreTipoDocumento = c.NombreTipoDocumento,
            }).ToList();
        }
        public async Task<TipoDocumentoDTO> ObtenerTipoDocumentoPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del documento debe ser mayor que cero.");

            var Tipodoc = await _documentoRepositorio.ObtenerTipoDocumentoPorId(id);
            if (Tipodoc == null)
                throw new ArgumentException($"No se encontró un documento con el ID {id}");

            return new TipoDocumentoDTO
            {
                Id = Tipodoc.Id,
                NombreTipoDocumento = Tipodoc.NombreTipoDocumento,
            };
        }
        public async Task CrearTipoDocumento(TipoDocumentoDTO TipoDoc)
        {
            List<string> camposErroneos = new List<string>();
            if (string.IsNullOrEmpty(TipoDoc.NombreTipoDocumento) || !IsValidName(TipoDoc.NombreTipoDocumento))
                camposErroneos.Add("Nombre");

            if (camposErroneos.Count > 0)
            {
                throw new ArgumentException("Los siguientes campos son inválidos: ", string.Join(", ", camposErroneos));
            }

            var tipodoc = new TipoDocumento
            {
                NombreTipoDocumento = TipoDoc.NombreTipoDocumento,
            };
            var nuevoDoc = await _documentoRepositorio.CrearTipoDocumento(tipodoc);
        }
        public async Task ActualizarTipoDocumento(TipoDocumentoDTO TipoDoc)
        {
            List<string> camposErroneos = new List<string>();
            if (string.IsNullOrEmpty(TipoDoc.NombreTipoDocumento) || !IsValidName(TipoDoc.NombreTipoDocumento))
                camposErroneos.Add("Nombre");

            if (camposErroneos.Count > 0)
            {
                throw new ArgumentException("Los siguientes campos son inválidos: ", string.Join(", ", camposErroneos));
            }

            var tipodoc = new TipoDocumento
            {
                Id = TipoDoc.Id,
                NombreTipoDocumento = TipoDoc.NombreTipoDocumento,
            };
            _documentoRepositorio.ActualizarTipoDocumento(tipodoc);
        }
        public async Task EliminarTipoDocumento(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor a 0.");

            _documentoRepositorio.EliminarTipoDocumento(id);
        }

        #region Validaciones
        private bool ContainsInvalidCharacter(string text)
        {
            char[] caracteres = { '!', '"', '#', '$', '%', '/', '(', ')', '=', '.', ',' };
            return caracteres.Any(c => text.Contains(c));
        }
        private bool IsValidName(string nombre)
        {
            return nombre.Length < 15 && !ContainsInvalidCharacter(nombre);
        }
        #endregion Validaciones
    }
}
