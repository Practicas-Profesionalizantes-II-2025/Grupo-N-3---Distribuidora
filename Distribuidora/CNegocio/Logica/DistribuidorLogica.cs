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
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            var distribuidoresDTO = new List<DistribuidorDTO>();

            foreach (var p in distribuidores)
            {
                string nombreCiudad = string.Empty;

                if (p.CiudadId > 0)
                {
                    var ciudad = await _ciudadRepositorio.ObtenerCiudadPorId(p.CiudadId);
                    if (ciudad != null)
                    {
                        nombreCiudad = ciudad.Nombre;
                    }
                }

                distribuidoresDTO.Add(new DistribuidorDTO
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    CuilCuit = p.CuilCuit,
                    Direccion = p.Direccion,
                    Telefono = p.Telefono,
                    CiudadId = p.CiudadId,
                    NombreCiudad = nombreCiudad
                });
            }

            return distribuidoresDTO;
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
            try
            {
                ValidarDistrbuidorDTO(DistrbuidorDTO, true);
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
            catch (Exception ex)
            {
                throw new Exception("Error al crear el distribuidor: " + ex.Message);
            }
        }
        public async Task<DistribuidorDTO> ActualizarDistribuidor(DistribuidorDTO DistrbuidorDTO)
        {

            try
            {
                ValidarDistrbuidorDTO(DistrbuidorDTO, true);
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
                DistrbuidorDTO.Id = distribuidor.Id;
                return DistrbuidorDTO;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el distribuidor: " + ex.Message);
            }
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
                throw new ArgumentException("El Nombre del distribuidor es obligatorio.");

            if (string.IsNullOrWhiteSpace(DistrbuidorDTO.CuilCuit)  || !IsValidCuit(DistrbuidorDTO.CuilCuit))
                throw new ArgumentException("El Cuit/Cuil del distribuidor es obligatorio.");

            if (string.IsNullOrWhiteSpace(DistrbuidorDTO.Direccion))
                throw new ArgumentException("La direccion del distribuidor es obligatorio.");

            if (string.IsNullOrWhiteSpace(DistrbuidorDTO.Telefono) || !IsValidTelefono(DistrbuidorDTO.Telefono))
                throw new ArgumentException("El teléfono del distribuidor es obligatorio.");
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
        private bool IsValidCuit(string cuit)
        {
            return cuit.Length > 10 && cuit.Length < 12 && !ContainsInvalidCharacter(cuit);
        }
        private bool IsValidTelefono(string telefono)
        {
            return telefono.Length > 9 && telefono.Length <= 10 && telefono.All(char.IsDigit);
        }
        #endregion Validaciones
    }
}
