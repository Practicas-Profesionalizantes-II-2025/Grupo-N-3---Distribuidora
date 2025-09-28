using CDatos.Repositorios;
using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CNegocio.Logica
{
    public class DistribuidorLogica : IDistribuidorLogica
    {
        private readonly IDistribuidorRepositorio _distribuidorRepositorio;
        private readonly ICiudadRepositorio _ciudadRepositorio;
        public DistribuidorLogica(IDistribuidorRepositorio distribuidorRepositorio, ICiudadRepositorio ciudadRepositorio)
        {
            _distribuidorRepositorio = distribuidorRepositorio;
            _ciudadRepositorio = ciudadRepositorio;
        }

        public async Task<List<DistribuidorDTO>> ObtenerDistribuidores()
        {
            var distribuidores = await _distribuidorRepositorio.ObtenerDistribuidores();
            return distribuidores.Select(p => new DistribuidorDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                CuilCuit = p.CuilCuit,
                Direccion = p.Direccion,
                Telefono = p.Telefono,
                CiudadId = p.CiudadId
            }).ToList();
        }
        public async Task<DistribuidorDTO> ObtenerDistribuidorPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del distribuidor debe ser mayor que cero.");

            var distribuidor = await _distribuidorRepositorio.ObtenerDistribuidorPorId(id);
            if (distribuidor == null)
                throw new ArgumentException($"No se encontró un distribuidor con el ID {id}");

            return new DistribuidorDTO
            {
                Id = distribuidor.Id,
                CuilCuit = distribuidor.CuilCuit,
                Nombre = distribuidor.Nombre,
                Direccion = distribuidor.Direccion,
                Telefono = distribuidor.Telefono,
                CiudadId = distribuidor.CiudadId,
            };
        }
        public async Task<DistribuidorDTO> CrearDistribuidor(DistribuidorDTO DistrbuidorDTO)
        {
            List<string> camposErroneos = new List<string>();
            if (string.IsNullOrEmpty(DistrbuidorDTO.Nombre) || !IsValidName(DistrbuidorDTO.Nombre))
                camposErroneos.Add("Nombre");

            if (camposErroneos.Count > 0)
            {
                throw new ArgumentException("Los siguientes campos son inválidos: ", string.Join(", ", camposErroneos));
            }

            var distribuidor = new Distribuidor
            {
                Nombre = DistrbuidorDTO.Nombre,
                CuilCuit = DistrbuidorDTO.CuilCuit,
                Direccion = DistrbuidorDTO.Direccion,
                Telefono = DistrbuidorDTO.Telefono,
                CiudadId = DistrbuidorDTO.CiudadId,
                
            };

            var nuevoDistribuidor = await _distribuidorRepositorio.CrearDistribuidor(distribuidor);
            var ciudad = await _ciudadRepositorio.ObtenerCiudadPorId(distribuidor.CiudadId); 
            return new DistribuidorDTO
            {
                Id = nuevoDistribuidor.Id,
                CuilCuit = nuevoDistribuidor.CuilCuit,
                Nombre = nuevoDistribuidor.Nombre,
                Direccion = nuevoDistribuidor.Direccion,
                Telefono = nuevoDistribuidor.Telefono,
                CiudadId = nuevoDistribuidor.CiudadId,
                NombreCiudad = ciudad.Nombre
            };
        }
        public async Task ActualizarDistribuidor(DistribuidorDTO DistrbuidorDTO)
        {
            if (DistrbuidorDTO.Id <= 0)
                throw new ArgumentException("El Id del distribuidor no es válido.");

            var existente = await _distribuidorRepositorio.ObtenerDistribuidorPorId(DistrbuidorDTO.Id);
            if (existente == null)
                throw new InvalidOperationException("No se encontró el distribuidor a actualizar.");

            ValidarDistrbuidorDTO(DistrbuidorDTO, esNuevo: false);

            var distribuidor = new Distribuidor
            {
                Id = DistrbuidorDTO.Id,
                CuilCuit = DistrbuidorDTO.CuilCuit,
                Nombre = DistrbuidorDTO.Nombre,
                Direccion = DistrbuidorDTO.Direccion,
                Telefono = DistrbuidorDTO.Telefono,
                CiudadId = DistrbuidorDTO.CiudadId
            };
            _distribuidorRepositorio.ActualizarDistribuidor(distribuidor);
        }
        public async Task EliminarDistribuidor(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id del distribuidor no es válido.");

            var existente = await _distribuidorRepositorio.ObtenerDistribuidorPorId(id);
            if (existente == null)
                throw new InvalidOperationException("No se encontró el distribuidor a eliminar.");

            _distribuidorRepositorio.EliminarDistribuidor(id);
        }
        #region Validaciones
        private void ValidarDistrbuidorDTO(DistribuidorDTO DistrbuidorDTO, bool esNuevo)
        {

            if (DistrbuidorDTO == null)
                throw new ArgumentNullException(nameof(DistrbuidorDTO), "El distribuidor no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(DistrbuidorDTO.Nombre))
                throw new ArgumentException("El nombre del distribuidor es obligatorio.");

            if (string.IsNullOrWhiteSpace(DistrbuidorDTO.Direccion))
                throw new ArgumentException("La dirección del distribuidor es obligatoria.");

            if (string.IsNullOrWhiteSpace(DistrbuidorDTO.Telefono))
                throw new ArgumentException("El teléfono del distribuidor es obligatorio.");

            if (!Regex.IsMatch(DistrbuidorDTO.Telefono, @"^\+?\d{7,15}$"))
                throw new ArgumentException("El teléfono no tiene un formato válido.");
        }

        private bool ContainsInvalidCharacter(string text)
        {
            char[] caracteres = { '!', '"', '#', '$', '%', '/', '(', ')', '=', '.', ',' };
            return caracteres.Any(c => text.Contains(c));
        }
        private bool IsValidName(string nombre)
        {
            return nombre.Length < 15 && !ContainsInvalidCharacter(nombre);
        }
    }
    #endregion Validaciones
}
