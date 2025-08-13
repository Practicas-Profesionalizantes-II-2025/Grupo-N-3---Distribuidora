using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNegocio.Logica
{
    public class EstadoLogica : IEstadoLogica
    {
        private readonly IEstadoRepositorio _estadoRepositorio;

        public EstadoLogica(IEstadoRepositorio estadoRepositorio)
        {
            _estadoRepositorio = estadoRepositorio ?? throw new ArgumentNullException(nameof(estadoRepositorio));
        }

        public async Task<List<EstadoDTO>> ObtenerEstados()
        {
            var estados = await _estadoRepositorio.ObtenerEstados();
            return estados?.Select(e => new EstadoDTO
            {
                Id = e.Id,
                Descripcion = e.Descripcion
            }).ToList() ?? new List<EstadoDTO>();
        }

        public async Task<EstadoDTO> ObtenerEstadoPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));

            var estado = await _estadoRepositorio.ObtenerEstadoPorId(id);
            if (estado == null)
                throw new KeyNotFoundException($"No se encontró un estado con ID {id}.");

            return new EstadoDTO
            {
                Id = estado.Id,
                Descripcion = estado.Descripcion
            };
        }

        public async Task CrearEstado(EstadoDTO estadoDTO)
        {
            if (estadoDTO == null)
                throw new ArgumentNullException(nameof(estadoDTO));

            if (string.IsNullOrWhiteSpace(estadoDTO.Descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.", nameof(estadoDTO.Descripcion));

            // Validación opcional de duplicados
            var existentes = await _estadoRepositorio.ObtenerEstados();
            if (existentes.Any(e => e.Descripcion.Equals(estadoDTO.Descripcion, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException($"Ya existe un estado con la descripción '{estadoDTO.Descripcion}'.");

            var estado = new Estado
            {
                Descripcion = estadoDTO.Descripcion
            };

            await _estadoRepositorio.CrearEstado(estado);
        }

        public async Task ActualizarEstado(EstadoDTO estadoDTO)
        {
            if (estadoDTO == null)
                throw new ArgumentNullException(nameof(estadoDTO));

            if (estadoDTO.Id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(estadoDTO.Id));

            if (string.IsNullOrWhiteSpace(estadoDTO.Descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.", nameof(estadoDTO.Descripcion));

            var existente = await _estadoRepositorio.ObtenerEstadoPorId(estadoDTO.Id);
            if (existente == null)
                throw new KeyNotFoundException($"No se encontró un estado con ID {estadoDTO.Id}.");

            existente.Descripcion = estadoDTO.Descripcion;
            _estadoRepositorio.ActualizarEstado(existente);
        }

        public async Task EliminarEstado(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));

            var existente = await _estadoRepositorio.ObtenerEstadoPorId(id);
            if (existente == null)
                throw new KeyNotFoundException($"No se encontró un estado con ID {id}.");

            _estadoRepositorio.EliminarEstado(id);
        }
    }
}
