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
            if (id <= 0)
                throw new ArgumentException("El ID del sector debe ser mayor a cero.");

            var sector = await _IsectorRepositorio.ObtenerSectorPorId(id);
            if (sector == null)
                throw new ArgumentException($"No se encontró un sector con el ID {id}");
            return new SectorDTO
            {
                Id = sector.Id,
                Nombre = sector.Nombre,
                EstadoId = sector.EstadoId
            };
        }
        public async Task CrearSector(SectorDTO sectorDTO)
        {
            List<string> camposErroneos = ValidarSector(sectorDTO, esNueva: true);

            if (camposErroneos.Count > 0)
                throw new ArgumentException("Los siguientes campos son inválidos: " + string.Join(", ", camposErroneos));

            var sector = new Sector
            {
                Nombre = sectorDTO.Nombre,
                EstadoId = sectorDTO.EstadoId
            };
            await _IsectorRepositorio.CrearSector(sector);
        }
        public async Task ActualizarSector(SectorDTO sectorDTO)
        {
            List<string> camposErroneos = ValidarSector(sectorDTO, esNueva: false);

            if (camposErroneos.Count > 0)
                throw new ArgumentException("Los siguientes campos son inválidos: " + string.Join(", ", camposErroneos));

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
            if (id <= 0)
                throw new ArgumentException("El ID del sector debe ser mayor a 0.");

            await _IsectorRepositorio.EliminarSectorAsync(id);
        }

        #region Validaciones
        private List<string> ValidarSector(SectorDTO sector, bool esNueva)
        {
            List<string> errores = new List<string>();

            if (!esNueva && sector.Id <= 0)
                errores.Add("Id");

            if (string.IsNullOrWhiteSpace(sector.Nombre) || !IsValidName(sector.Nombre))
                errores.Add("Nombre");

            if (sector.EstadoId <= 0)
                errores.Add("EstadoId");

            return errores;
        }

        private bool ContainsInvalidCharacter(string text)
        {
            char[] caracteres = { '!', '"', '#', '$', '%', '/', '(', ')', '=', '.', ',' };
            return caracteres.Any(c => text.Contains(c));
        }

        private bool IsValidName(string nombre)
        {
            return nombre.Length <= 50 && !ContainsInvalidCharacter(nombre);
        }
        #endregion Validaciones
    }
}
