using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using Shared.Entities;

namespace CNegocio.Logica
{
    public class DistribuidorLogica : IDistribuidorLogica
    {
        private readonly IDistribuidorRepositorio _distribuidorRepositorio;
        public DistribuidorLogica(IDistribuidorRepositorio distribuidorRepositorio)
        {
            _distribuidorRepositorio = distribuidorRepositorio;
        }
        public async Task<List<DistribuidorDTO>> ObtenerDistribuidores()
        {
            var distribuidores = await _distribuidorRepositorio.ObtenerDistribuidores();
            return distribuidores.Select(d => new DistribuidorDTO
            {
                Id = d.Id,
                Nombre = d.Nombre,
                Telefono = d.Telefono,
                Email = d.Email,
            }).ToList();
        }
        public async Task<DistribuidorDTO> ObtenerDistribuidorPorId(int id)
        {
            var distribuidor = await _distribuidorRepositorio.ObtenerDistribuidorPorId(id);
            if (distribuidor == null) return null;
            return new DistribuidorDTO
            {
                Id = distribuidor.Id,
                Nombre = distribuidor.Nombre,
                Telefono = distribuidor.Telefono,
                Email = distribuidor.Email,
            };
        }
        public async Task CrearDistribuidor(DistribuidorDTO distribuidorDTO)
        {
            var distribuidor = new Distribuidor
            {
                Nombre = distribuidorDTO.Nombre,
                Telefono = distribuidorDTO.Telefono,
                Email = distribuidorDTO.Email,
            };

            var nuevoDistribuidor = await _distribuidorRepositorio.CrearDistribuidor(distribuidor);
        }
        public async Task ActualizarDistribuidor(DistribuidorDTO distribuidorDTO)
        {
            var distribuidor = new Distribuidor
            {
                Id = distribuidorDTO.Id,
                Nombre = distribuidorDTO.Nombre,
                Telefono = distribuidorDTO.Telefono,
                Email = distribuidorDTO.Email,
            };
            _distribuidorRepositorio.ActualizarDistribuidor(distribuidor);
        }
        public async Task EliminarDistribuidor(int id)
        {
            _distribuidorRepositorio.EliminarDistribuidor(id);
        }
    }
}
