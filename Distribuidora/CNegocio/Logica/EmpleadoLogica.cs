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
    public class EmpleadoLogica : IEmpleadoLogica
    {
        private readonly IEmpleadoRepositorio _empleadoRepositorio;
        public EmpleadoLogica(IEmpleadoRepositorio empleadoRepositorio)
        {
            _empleadoRepositorio = empleadoRepositorio;
        }
        public async Task<List<EmpleadoDTO>> ObtenerEmpleados()
        {
            var empleados = await _empleadoRepositorio.ObtenerEmpleados();
            return empleados.Select(e => new EmpleadoDTO
            {
                Id = e.Id,
                PersonaId = e.PersonaId,
                Foto = e.Foto,
                EstadoId = e.EstadoId,
            }).ToList();
        }
        public async Task<EmpleadoDTO> ObtenerEmpleadoPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del empleado debe ser mayor que cero.");

            var empleado = await _empleadoRepositorio.ObtenerEmpleadoPorId(id);
            if (empleado == null)
                throw new ArgumentException($"No se encontró un empleado con el ID {id}");

            return new EmpleadoDTO
            {
                Id = empleado.Id,
                PersonaId = empleado.PersonaId,
                Foto = empleado.Foto,
                EstadoId = empleado.EstadoId,
            };
        }
        public async Task CrearEmpleado(EmpleadoDTO empleadoDTO)
        {
            List<string> camposErroneos = new List<string>();
            if (empleadoDTO.PersonaId <= 0)
                camposErroneos.Add("PersonaId");
            if (empleadoDTO.EstadoId <= 0)
                camposErroneos.Add("EstadoId");
            if (string.IsNullOrWhiteSpace(empleadoDTO.Foto))
                camposErroneos.Add("Foto");


            if (camposErroneos.Count > 0)
            {
                throw new ArgumentException("Los siguientes campos son inválidos: ", string.Join(", ", camposErroneos));
            }

            var empleado = new Empleado
            {
                PersonaId = empleadoDTO.PersonaId,
                Foto = empleadoDTO.Foto,
                EstadoId = empleadoDTO.EstadoId,
            };
            var nuevoEmpleado = await _empleadoRepositorio.CrearEmpleado(empleado);
        }
        public async Task ActualizarEmpleado(EmpleadoDTO empleadoDTO)
        {
            List<string> camposErroneos = new List<string>();
            if (empleadoDTO.PersonaId <= 0)
                camposErroneos.Add("PersonaId");
            if (empleadoDTO.EstadoId <= 0)
                camposErroneos.Add("EstadoId");
            if (string.IsNullOrWhiteSpace(empleadoDTO.Foto))
                camposErroneos.Add("Foto");


            if (camposErroneos.Count > 0)
            {
                throw new ArgumentException("Los siguientes campos son inválidos: ", string.Join(", ", camposErroneos));
            }
            var empleado = new Empleado
            {
                Id = empleadoDTO.Id,
                PersonaId = empleadoDTO.PersonaId,
                Foto = empleadoDTO.Foto,
                EstadoId = empleadoDTO.EstadoId,
            };
            _empleadoRepositorio.ActualizarEmpleado(empleado);
        }
        public async Task EliminarEmpleado(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor a 0.");
            
            _empleadoRepositorio.EliminarEmpleado(id);
        }
        public async Task<List<EmpleadoDTO>> ObtenerEmpleadosPorDni(string dni)
        {
            var empleados = await _empleadoRepositorio.ObtenerEmpleadosPorDni(dni);
            return empleados.Select(e => new EmpleadoDTO
            {
                Id = e.Id,
                PersonaId = e.PersonaId,
                Foto = e.Foto,
                EstadoId = e.EstadoId,
            }).ToList();
        }
        #region Validaciones
        private bool ContainsInvalidCharacter(string text)
        {
            char[] caracteres = { '!', '"', '#', '$', '%', '/', '(', ')', '=', '.', ',' };
            return caracteres.Any(c => text.Contains(c));
        }
        private bool IsValidName(string nombre)
        {
            return nombre.Length < 15 && !ContainsInvalidCharacter(nombre);
        }
        #endregion Validaciones
    }
}
