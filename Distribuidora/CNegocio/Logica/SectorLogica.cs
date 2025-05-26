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
    public class SectorLogica : ISectorLogica
    {
        private readonly ISectorRepositorio _IsectorRepositorio;
        public SectorLogica(ISectorRepositorio sectorRepositorio)
        {
            _IsectorRepositorio = sectorRepositorio;
        }
        public async Task<List<SectorDTO>> ObtenerSectores()
        {
            var sectores = await _IsectorRepositorio.ObtenerSectores();
            return sectores.Select(s => new SectorDTO
            {
                Id = s.Id,
                Nombre = s.Nombre,
                EstadoId = s.EstadoId
            }).ToList();
        }
        public async Task<SectorDTO> ObtenerSectorPorId(int id)
        {
            var sector = await _IsectorRepositorio.ObtenerSectorPorId(id);
            if (sector == null) return null;
            return new SectorDTO
            {
                Id = sector.Id,
                Nombre = sector.Nombre,
                EstadoId = sector.EstadoId
            };
        }
        public async Task CrearSector(SectorDTO sectorDTO)
        {
            var sector = new Sector
            {
                Nombre = sectorDTO.Nombre,
                EstadoId = sectorDTO.EstadoId
            };
            await _IsectorRepositorio.CrearSector(sector);
        }
        public async Task ActualizarSector(SectorDTO sectorDTO)
        {
            var sector = new Sector
            {
                Id = sectorDTO.Id,
                Nombre = sectorDTO.Nombre,
                EstadoId = sectorDTO.EstadoId
            };
            await _IsectorRepositorio.ActualizarSector(sector);
        }
        public async Task EliminarSector(int id)
        {
            await _IsectorRepositorio.EliminarSectorAsync(id);
        }
    }
}
