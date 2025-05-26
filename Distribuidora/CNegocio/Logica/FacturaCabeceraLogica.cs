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
    public class FacturaCabeceraLogica : IFacturaCabeceraLogica
    {
        private readonly IFacturaCabeceraRepositorio _facturaCabeceraRepositorio;
        public FacturaCabeceraLogica(IFacturaCabeceraRepositorio facturaCabeceraRepositorio)
        {
            _facturaCabeceraRepositorio = facturaCabeceraRepositorio;
        }
        public async Task<List<FacturaCabeceraDTO>> ObtenerFacturas()
        {
            var facturas = await _facturaCabeceraRepositorio.ObtenerFacturasCabecera();
            return facturas.Select(e => new FacturaCabeceraDTO
            {
                //Agregar propiedades necesarias
            }).ToList();
        }
        public async Task<FacturaCabeceraDTO> ObtenerFacturaPorId(int id)
        {
            var factura = await _facturaCabeceraRepositorio.ObtenerFacturaCabeceraPorId(id);
            if (factura == null) return null;
            return new FacturaCabeceraDTO
            {
                //Agregar propiedades necesarias
            };
        }
        public async Task CrearFactura(FacturaCabeceraDTO facturaDTO)
        {
            var factura = new FacturaCabecera
            {
                //Agregar propiedades necesarias
            };
            var nuevaFactura = await _facturaCabeceraRepositorio.CrearFacturaCabecera(factura);
        }
        public async Task ActualizarFactura(FacturaCabeceraDTO facturaDTO)
        {
            var factura = new FacturaCabecera
            {
                //Agregar propiedades necesarias
            };
            _facturaCabeceraRepositorio.ActualizarFacturaCabecera(factura);
        }
        public async Task EliminarFactura(int id)
        {
            _facturaCabeceraRepositorio.EliminarFacturaCabecera(id);
        }
    }
}
