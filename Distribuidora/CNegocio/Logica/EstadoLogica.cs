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
    public class EstadoLogica : IEstadoLogica
    {
        private readonly IEstadoRepositorio _estadoRepositorio;
        public EstadoLogica(IEstadoRepositorio estadoRepositorio)
        {
            _estadoRepositorio = estadoRepositorio;
        }
        public async Task<List<EstadoDTO>> ObtenerEstados()
        {
            var estados = await _estadoRepositorio.ObtenerEstados();
            return estados.Select(e => new EstadoDTO
            {
                Descripcion = e.Descripcion,
            }).ToList();
        }
        public async Task<EstadoDTO> ObtenerEstadoPorId(int id)
        {
            var estado = await _estadoRepositorio.ObtenerEstadoPorId(id);
            if (estado == null) return null;
            return new EstadoDTO
            {
                Id = estado.Id,
                Descripcion = estado.Descripcion,
            };
        }
        public async Task CrearEstado(EstadoDTO estadoDTO)
        {
            var estado = new Estado
            {
                Descripcion = estadoDTO.Descripcion,
            };
            var nuevoEstado = await _estadoRepositorio.CrearEstado(estado);
        }
        public async Task ActualizarEstado(EstadoDTO estadoDTO)
        {
            var estado = new Estado
            {
                Id = estadoDTO.Id,
                Descripcion = estadoDTO.Descripcion,
            };
            _estadoRepositorio.ActualizarEstado(estado);
        }
        public async Task EliminarEstado(int id)
        {
            _estadoRepositorio.EliminarEstado(id);
        }
    }
}
