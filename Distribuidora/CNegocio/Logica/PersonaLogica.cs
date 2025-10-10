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
    public class PersonaLogica : IPersonaLogica
    {
        private readonly IPersonaRepositorio _personaRepositorio;
        private readonly ICiudadRepositorio _ciudadRepositorio;
        public PersonaLogica(IPersonaRepositorio personaRepositorio, ICiudadRepositorio ciudadRepositorio)
        {
            _personaRepositorio = personaRepositorio;
            _ciudadRepositorio = ciudadRepositorio;
        }
        public async Task<List<PersonaDTO>> ObtenerPersonas()
        {
            var personas = await _personaRepositorio.ObtenerPersonas();
            var personasDTO = new List<PersonaDTO>();

            foreach (var p in personas)
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

                personasDTO.Add(new PersonaDTO
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    Tipo_DocId = p.Tipo_DocId,
                    Nro_Doc = p.Nro_Doc,
                    CiudadId = p.CiudadId,
                    NombreCiudad = nombreCiudad,
                    Email = p.Email,
                    Direccion = p.Direccion,
                    Telefono = p.Telefono,
                });
            }

            return personasDTO;
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
            };
        }
        public async Task<PersonaDTO> CrearPersona(PersonaDTO personaDTO)
        {
            try
            {
                var errores = ValidarPersona(personaDTO, true);
                if (errores.Any())
                {
                    string mensaje = "Los siguientes campos son inválidos: " + string.Join(", ", errores);
                    throw new ArgumentException(mensaje);
                }
                var persona = new Persona
                {
                Nombre = personaDTO.Nombre,
                Apellido = personaDTO.Apellido,
                Tipo_DocId = personaDTO.Tipo_DocId,
                Nro_Doc = personaDTO.Nro_Doc,
                CiudadId = personaDTO.CiudadId,
                Email = personaDTO.Email,
                Direccion = personaDTO.Direccion,
                Telefono = personaDTO.Telefono,
                };

                var nuevaPersona = await _personaRepositorio.CrearPersona(persona);

                personaDTO.Id = nuevaPersona.Id;

                return personaDTO;
            }
            catch (ArgumentException ex)
            {

                throw new ArgumentException(ex.Message);
            }

        }
        public async Task<PersonaDTO> ActualizarPersona(PersonaDTO personaDTO)
        {
            try
            {
                var errores = ValidarPersona(personaDTO, true);
                if (errores.Any())
                {
                    string mensaje = "Los siguientes campos son inválidos: " + string.Join(", ", errores);
                    throw new ArgumentException(mensaje);
                }
                var persona = new Persona
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
                };
                _personaRepositorio.ActualizarPersona(persona);
                personaDTO.Id = persona.Id;
                return personaDTO;
            }
            catch (ArgumentException ex)
            {

                throw new ArgumentException(ex.Message);
            }
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

            return errores;
        }

        private bool ContainsInvalidCharacter(string text)
        {
            char[] caracteres = { '!', '"', '#', '$', '%', '/', '(', ')', '=', ',' };
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
