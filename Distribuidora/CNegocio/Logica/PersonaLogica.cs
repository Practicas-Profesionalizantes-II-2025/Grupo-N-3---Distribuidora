using CDatos.Repositorios.IRepositorios;
using CNegocio.Logica.ILogica;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNegocio.Logica
{
    public class PersonaLogica : IPersonaLogica
    {
        private readonly IPersonaRepositorio _personaRepositorio;
        public PersonaLogica(IPersonaRepositorio personaRepositorio)
        {
            _personaRepositorio = personaRepositorio;
        }
        public async Task<List<PersonaDTO>> ObtenerPersonas()
        {
            var personas = await _personaRepositorio.ObtenerPersonas();
            return personas.Select(p => new PersonaDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Tipo_DocId = p.Tipo_DocId,
                Nro_Doc = p.Nro_Doc,
                CiudadId = p.CiudadId,
                Email = p.Email,
                Direccion = p.Direccion,
                Telefono = p.Telefono,
                EstadoId = p.EstadoId
            }).ToList();
        }
        public async Task<PersonaDTO> ObtenerPersonaPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la persona debe ser mayor que cero.");

            var persona = await _personaRepositorio.ObtenerPersonaPorId(id);
            if (persona == null) 
                throw new ArgumentException($"No se encontró una persona con el ID {id}");

            return new PersonaDTO
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Tipo_DocId = persona.Tipo_DocId,
                Nro_Doc = persona.Nro_Doc,
                CiudadId = persona.CiudadId,
                Email = persona.Email,
                Direccion = persona.Direccion,
                Telefono = persona.Telefono,
                EstadoId = persona.EstadoId
            };
        }
        public async Task CrearPersona(PersonaDTO personaDTO)
        {
            List<string> camposErroneos = ValidarPersona(personaDTO, esNueva: false);

            if (camposErroneos.Count > 0)
                throw new ArgumentException("Los siguientes campos son inválidos: " + string.Join(", ", camposErroneos));

            var persona = new Shared.Entities.Persona
            {
                Nombre = personaDTO.Nombre,
                Apellido = personaDTO.Apellido,
                Tipo_DocId = personaDTO.Tipo_DocId,
                Nro_Doc = personaDTO.Nro_Doc,
                CiudadId = personaDTO.CiudadId,
                Email = personaDTO.Email,
                Direccion = personaDTO.Direccion,
                Telefono = personaDTO.Telefono,
                EstadoId = personaDTO.EstadoId
            };
            await _personaRepositorio.CrearPersona(persona);
        }
        public async Task ActualizarPersona(PersonaDTO personaDTO)
        {
            List<string> camposErroneos = ValidarPersona(personaDTO, esNueva: false);

            if (camposErroneos.Count > 0)
                throw new ArgumentException("Los siguientes campos son inválidos: " + string.Join(", ", camposErroneos));

            var persona = new Shared.Entities.Persona
            {
                Id = personaDTO.Id,
                Nombre = personaDTO.Nombre,
                Apellido = personaDTO.Apellido,
                Tipo_DocId = personaDTO.Tipo_DocId,
                Nro_Doc = personaDTO.Nro_Doc,
                CiudadId = personaDTO.CiudadId,
                Email = personaDTO.Email,
                Direccion = personaDTO.Direccion,
                Telefono = personaDTO.Telefono,
                EstadoId = personaDTO.EstadoId
            };
            await _personaRepositorio.ActualizarPersona(persona);
        }
        public async Task EliminarPersona(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor a 0.");

            await _personaRepositorio.EliminarPersona(id);
        }
        public async Task<List<PersonaDTO>> ObtenerPersonasPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni) || !IsValidDocumento(dni))
                throw new ArgumentException("El número de documento es inválido.");

            var personas = await _personaRepositorio.ObtenerPersonasPorDni(dni);
            return personas.Select(p => new PersonaDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Tipo_DocId = p.Tipo_DocId,
                Nro_Doc = p.Nro_Doc,
                CiudadId = p.CiudadId,
                Email = p.Email,
                Direccion = p.Direccion,
                Telefono = p.Telefono,
                EstadoId = p.EstadoId
            }).ToList();
        }

        #region Validaciones
        private List<string> ValidarPersona(PersonaDTO persona, bool esNueva)
        {
            List<string> errores = new List<string>();

            if (!esNueva && persona.Id <= 0)
                errores.Add("Id");

            if (string.IsNullOrWhiteSpace(persona.Nombre) || !IsValidName(persona.Nombre))
                errores.Add("Nombre");

            if (string.IsNullOrWhiteSpace(persona.Apellido) || !IsValidName(persona.Apellido))
                errores.Add("Apellido");

            if (persona.Tipo_DocId <= 0)
                errores.Add("Tipo_DocId");

            if (string.IsNullOrWhiteSpace(persona.Nro_Doc) || !IsValidDocumento(persona.Nro_Doc))
                errores.Add("Nro_Doc");

            if (persona.CiudadId <= 0)
                errores.Add("CiudadId");

            if (string.IsNullOrWhiteSpace(persona.Email) || !IsValidEmail(persona.Email))
                errores.Add("Email");

            if (string.IsNullOrWhiteSpace(persona.Direccion))
                errores.Add("Direccion");

            if (string.IsNullOrWhiteSpace(persona.Telefono) || !IsValidTelefono(persona.Telefono))
                errores.Add("Telefono");

            if (persona.EstadoId <= 0)
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

        private bool IsValidDocumento(string nroDoc)
        {
            return nroDoc.Length == 8 && nroDoc.All(char.IsDigit);
        }

        private bool IsValidTelefono(string telefono)
        {
            return telefono.Length == 10 && telefono.All(char.IsDigit);
        }

        private bool IsValidEmail(string email)
        {
            return email.Contains("@") && !ContainsInvalidCharacter(email);
        }
        #endregion Validaciones
    }
}
