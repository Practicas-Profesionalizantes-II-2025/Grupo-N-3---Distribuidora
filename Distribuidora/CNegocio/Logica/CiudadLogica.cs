using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.Data;
using CDatos.Repositorios;
using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;
using Shared.Entities;

namespace CNegocio.Logica
{
    public class CiudadLogica : ICiudadLogica
    {
        private readonly ICiudadRepositorio _ciudadRepositorio;
        public CiudadLogica(ICiudadRepositorio _ciudadRepositorio)
        {
            this._ciudadRepositorio = _ciudadRepositorio;
        }
        public async Task<List<CiudadDTO>> ObtenerCiudades()
        {
            var ciudades = await _ciudadRepositorio.ObtenerCiudades();
            return ciudades.Select(c => new CiudadDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Cp = c.Cp,
                Acp = c.Acp,
            }).ToList();
        }

        public async Task<CiudadDTO> ObtenerCiudadPorId(int id)
        {
            var ciudad = await _ciudadRepositorio.ObtenerCiudadPorId(id);
            if (ciudad == null) return null;
            return new CiudadDTO
            {
                Id = ciudad.Id,
                Nombre = ciudad.Nombre,
                Cp = ciudad.Cp,
                Acp = ciudad.Acp,
            };
        }
        public async Task CrearCiudad(CiudadDTO CiudadDTO)
        {
            var ciudad = new Ciudad
            {
                Nombre = CiudadDTO.Nombre,
                Cp = CiudadDTO.Cp,
                Acp = CiudadDTO.Acp,
            };
            var nuevaCiudad = await _ciudadRepositorio.CrearCiudad(ciudad);
        }
        public async Task ActualizarCiudad(CiudadDTO CiudadDTO)
        {
            var ciudad = new Ciudad
            {
                Id = CiudadDTO.Id,
                Nombre = CiudadDTO.Nombre,
                Cp = CiudadDTO.Cp,
                Acp = CiudadDTO.Acp,
            };
            _ciudadRepositorio.ActualizarCiudad(ciudad);
        }
        public async Task EliminarCiudad(int id)
        {
            _ciudadRepositorio.EliminarCiudad(id);
        }
    }
}
