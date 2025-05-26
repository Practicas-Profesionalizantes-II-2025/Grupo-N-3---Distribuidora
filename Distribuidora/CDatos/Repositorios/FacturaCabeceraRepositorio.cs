using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.Data;
using CDatos.Repositorios.IRepositorios;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace CDatos.Repositorios
{
    public class FacturaCabeceraRepositorio : IFacturaCabeceraRepositorio
    {
        private readonly DataContext _context;
        public FacturaCabeceraRepositorio(DataContext context)
        {
            _context = context;
        }
        public async Task<List<FacturaCabecera>> ObtenerFacturasCabecera()
        {
            return await _context.FacturasCabeceras.ToListAsync();
        }
        public async Task<FacturaCabecera> ObtenerFacturaCabeceraPorId(int id)
        {
            return await _context.FacturasCabeceras.FindAsync(id);
        }
        public async Task<FacturaCabecera> CrearFacturaCabecera(FacturaCabecera facturaCabecera)
        {
            _context.FacturasCabeceras.Add(facturaCabecera);
            await _context.SaveChangesAsync();
            return facturaCabecera;
        }
        public void ActualizarFacturaCabecera(FacturaCabecera facturaCabecera)
        {
            var facturaCabeceraExistente = _context.FacturasCabeceras.Find(facturaCabecera.Id);
            if (facturaCabeceraExistente == null)
            {
                throw new Exception("Factura Cabecera no encontrada.");
            }
            //Poner facturaCabeceraExistente.atrituto = facturaCabecera.atrituto
            _context.SaveChanges();
        }
        public void EliminarFacturaCabecera(int id)
        {
            var facturaCabecera = _context.FacturasCabeceras.FirstOrDefault(x => x.Id == id);
            if (facturaCabecera != null)
            {
                _context.FacturasCabeceras.Remove(facturaCabecera);
                _context.SaveChanges();
            }
        }
    }
}
