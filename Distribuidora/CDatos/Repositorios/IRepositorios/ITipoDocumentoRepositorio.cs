using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.Repositorios.IRepositorios
{
    public interface ITipoDocumentoRepositorio
    {
        Task<List<TipoDocumento>> ObtenerTiposDocumento();
        Task<TipoDocumento> ObtenerTipoDocumentoPorId(int id);
        Task<TipoDocumento> CrearTipoDocumento(TipoDocumento tipoDocumento);
        void ActualizarTipoDocumento(TipoDocumento tipoDocumento);
        void EliminarTipoDocumento(int id);
    }
}
