using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace CDatos.Repositorios.IRepositorios
{
    public interface IFacturaCabeceraRepositorio
    {
        Task<List<FacturaCabecera>> ObtenerFacturasCabecera();
        Task<FacturaCabecera> ObtenerFacturaCabeceraPorId(int id);
        Task<FacturaCabecera> CrearFacturaCabecera(FacturaCabecera facturaCabecera);
        void ActualizarFacturaCabecera(FacturaCabecera facturaCabecera);
        void EliminarFacturaCabecera(int id);
    }
}
