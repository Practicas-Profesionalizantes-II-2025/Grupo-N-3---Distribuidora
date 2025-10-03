using CDatos.Repositorios;
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
        private readonly IPersonaRepositorio _personaRepositorio;
        private readonly ICiudadRepositorio _ciudadRepositorio;

        public EmpleadoLogica(IEmpleadoRepositorio empleadoRepositorio, IPersonaRepositorio personaRepositorio, ICiudadRepositorio ciudadRepositorio)
        {
            _empleadoRepositorio = empleadoRepositorio;
            _personaRepositorio = personaRepositorio;
            _ciudadRepositorio = ciudadRepositorio;
        }
        public async Task<List<EmpleadoDTO>> ObtenerEmpleados()
        {
            var empleados = await _empleadoRepositorio.ObtenerEmpleados();
            var empleadosDto = empleados.Select(c => new EmpleadoDTO
            {
                Id = c.Id,
                EstadoId = c.EstadoId,
                Foto = c.Foto,
                Persona = new PersonaDTO
                {
                    Id = c.Persona.Id,
                    Nombre = c.Persona.Nombre,
                    Apellido = c.Persona.Apellido,
                    Nro_Doc = c.Persona.Nro_Doc,
                    Telefono = c.Persona.Telefono,
                    Email = c.Persona.Email,
                    Direccion = c.Persona.Direccion,
                    CiudadId = c.Persona.CiudadId,
                    EstadoId = c.Persona.EstadoId,
                },
            }).ToList();

            return empleadosDto;
        }
        public async Task<EmpleadoDTO> ObtenerEmpleadoPorId(int id)
        {
            if (id <= 0) throw new ArgumentException("El ID del empleado debe ser mayor que cero.");

            var empleado = await _empleadoRepositorio.ObtenerEmpleadoPorId(id);
            if (empleado == null) return null;

            return new EmpleadoDTO
            {
                Id = empleado.Id,
                EstadoId = empleado.EstadoId,
                PersonaId = empleado.PersonaId,
                Foto = empleado.Foto,
                Persona = new PersonaDTO
                {
                    Id = empleado.Persona.Id,
                    Nombre = empleado.Persona.Nombre,
                    Apellido = empleado.Persona.Apellido,
                    Nro_Doc = empleado.Persona.Nro_Doc,
                    Telefono = empleado.Persona.Telefono,
                    Email = empleado.Persona.Email,
                    Direccion = empleado.Persona.Direccion,
                }
            };
        }
        public async Task<EmpleadoDTO> CrearEmpleado(EmpleadoDTO empleadoDTO)
        {
            List<string> camposErroneos = new List<string>();
            if (empleadoDTO.PersonaId <= 0)
                camposErroneos.Add("PersonaId");
            if (empleadoDTO.EstadoId <= 0)
                camposErroneos.Add("EstadoId");
            //if (string.IsNullOrWhiteSpace(empleadoDTO.Foto))
            //    camposErroneos.Add("Foto");


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

            var persona = await _personaRepositorio.ObtenerPersonaPorId(empleadoDTO.PersonaId);
            var ciudad = await _ciudadRepositorio.ObtenerCiudadPorId(persona.CiudadId);
            return new EmpleadoDTO
            {
                Id = nuevoEmpleado.Id,
                PersonaId = nuevoEmpleado.PersonaId,
                EstadoId = nuevoEmpleado.EstadoId,
                Foto = nuevoEmpleado.Foto,
                Persona = new PersonaDTO
                {
                    Id = persona.Id,
                    Nombre = persona.Nombre,
                    Apellido = persona.Apellido,
                    Tipo_DocId = persona.Tipo_DocId,
                    Nro_Doc = persona.Nro_Doc,
                    CiudadId = persona.CiudadId,
                    NombreCiudad = ciudad.Nombre,
                    Email = persona.Email,
                    Direccion = persona.Direccion,
                    Telefono = persona.Telefono,
                    EstadoId = persona.EstadoId,
                }
            };
        }
        public async Task ActualizarEmpleado(EmpleadoDTO empleadoDTO)
        {
            var persona = await _personaRepositorio.ObtenerPersonaPorId(empleadoDTO.Persona.Id);
            if (persona == null)
                throw new Exception("Persona no encontrada.");

            persona.Nombre = empleadoDTO.Persona.Nombre;
            persona.Apellido = empleadoDTO.Persona.Apellido;
            persona.Nro_Doc = empleadoDTO.Persona.Nro_Doc;
            persona.Telefono = empleadoDTO.Persona.Telefono;
            persona.Email = empleadoDTO.Persona.Email;
            persona.Direccion = empleadoDTO.Persona.Direccion;
            persona.CiudadId = empleadoDTO.Persona.CiudadId;

            await _personaRepositorio.ActualizarPersona(persona);

            var empleadoExistente = await _empleadoRepositorio.ObtenerEmpleadoPorId(empleadoDTO.Id);
            if (empleadoExistente == null)
                throw new Exception("Empleado no encontrado.");

            empleadoExistente.EstadoId = empleadoDTO.EstadoId;
            await _empleadoRepositorio.ActualizarEmpleado(empleadoExistente);
        }
        public async Task EliminarEmpleado(int id)
        {    
            _empleadoRepositorio.EliminarEmpleado(id);
        }
        public async Task<List<EmpleadoDTO>> ObtenerEmpleadosPorDni(string dni)
        {
            var empleado = await _empleadoRepositorio.ObtenerEmpleadosPorDni(dni);

            return empleado.Select(c => new EmpleadoDTO
            {
                Id = c.Id,
                EstadoId = c.EstadoId,
                PersonaId = c.PersonaId
            }).ToList();
        }

        public async Task<PersonaDTO> ObtenerPersonaPorEmpleadoId(int empleadoId)
        {
            var persona = await _empleadoRepositorio.ObtenerPersonaPorEmpleadoId(empleadoId);
            if (persona == null) return null;

            return new PersonaDTO
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Nro_Doc = persona.Nro_Doc,
                Telefono = persona.Telefono,
                Email = persona.Email,
                Direccion = persona.Direccion,
                CiudadId = persona.CiudadId
            };
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
