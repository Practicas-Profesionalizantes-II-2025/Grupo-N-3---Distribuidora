using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica.ILogica
{
    public interface IFacturaCabeceraLogica
    {
        Task<List<FacturaCabeceraDTO>> ObtenerFacturas();
        Task<FacturaCabeceraDTO> ObtenerFacturaPorId(int id);
        Task CrearFactura(FacturaCabeceraDTO facturaDTO);
        Task ActualizarFactura(FacturaCabeceraDTO facturaDTO);
        Task EliminarFactura(int id);
    }
}
