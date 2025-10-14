using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica.ILogica
{
    public interface ITipoDocLogica
    {
        Task<List<TipoDocumentoDTO>> ObtenerTiposDocumento();
        Task<TipoDocumentoDTO> ObtenerTipoDocumentoPorId(int id);
        Task CrearTipoDocumento(TipoDocumentoDTO TipoDoc);
        Task ActualizarTipoDocumento(TipoDocumentoDTO TipoDoc);
        Task EliminarTipoDocumento(int id);
    }
}
