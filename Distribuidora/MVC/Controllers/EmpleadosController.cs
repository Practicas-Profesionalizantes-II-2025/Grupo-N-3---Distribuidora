using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Data;
using MVC.Models.DTOs;
using MVC.Models.Entities;
using Newtonsoft.Json;
using Shared.DTOs;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleadoDTO = MVC.Models.DTOs.EmpleadoDTO;
using PersonaDTO = MVC.Models.DTOs.PersonaDTO;

namespace MVC.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public EmpleadosController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Empleados
        public async Task<IActionResult> listaEmpleados()
        {
            var url = $"{_settings.BaseUrl}/{_settings.EmpleadosGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new List<EmpleadoDTO>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista_empleados = JsonConvert.DeserializeObject<List<EmpleadoDTO>>(json);

            return View(lista_empleados);
        }

        // GET: Crear Empleado
        public IActionResult crearEmpleado()
        {
            var empleado = new EmpleadoDTO
            {
                Persona = new PersonaDTO()
            };
            return View(empleado);
        }

        // POST: Crear Empleado
        [HttpPost]
        public async Task<IActionResult> crearEmpleado(EmpleadoDTO empleado)
        {
            try
            {
                // Aseguramos que Persona no sea null
                if (empleado.Persona == null)
                {
                    empleado.Persona = new PersonaDTO();
                }

                // Forzamos estado de Persona en Alta
                empleado.Persona.EstadoId = 1;
                empleado.EstadoId = 1;


                var JsonData = JsonConvert.SerializeObject(empleado);
                var Content = new StringContent(JsonData, Encoding.UTF8, "application/json");

                // Llamada al endpoint de la API
                var Response = await _httpClient.PostAsync($"{_settings.BaseUrl}/{_settings.EmpleadosPost}", Content);

                if (!Response.IsSuccessStatusCode)
                {
                    var error = await Response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Error creando empleado: {error}");
                    return View(empleado);
                }

                // Si llegó hasta acá → se creó bien
                return RedirectToAction(nameof(listaEmpleados));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocurrió un error: {ex.Message}");
                return View(empleado);
            }
        }

        // DELETE: Empleado/Delete/5
        public async Task<IActionResult> eliminarEmpleado(int? id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.EmpleadosDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaEmpleados));

            ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());

            var listaJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.EmpleadosGet}");
            var empleado = JsonConvert.DeserializeObject<List<EmpleadoDTO>>(listaJson);
            return View("listaEmpleado", empleado);
        }

        // GET: Modificar empleado
        public async Task<IActionResult> modificarEmpleado(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.EmpleadosGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "No se pudo cargar el empleado");
                return RedirectToAction(nameof(listaEmpleados));
            }

            var json = await response.Content.ReadAsStringAsync();
            var empleados = JsonConvert.DeserializeObject<List<EmpleadoDTO>>(json);
            var empleado = empleados.FirstOrDefault(c => c.Id == id);

            if (empleado == null)
            {
                ModelState.AddModelError(string.Empty, "Empleado no encontrado");
                return RedirectToAction(nameof(listaEmpleados));
            }

            return View(empleado);
        }

        // POST: Modificar empleado
        [HttpPost]
        public async Task<IActionResult> modificarEmpleado(int id,EmpleadoDTO empleado)
        {
            if (id != empleado.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(empleado);

            if (empleado.Foto == null)
            {
                empleado.Foto = empleado.Foto; // conservar foto existente
            }
            try
            {
                empleado.EstadoId = 1;
                empleado.Persona.EstadoId = 1;
                empleado.Persona.Tipo_DocId = empleado.Persona.Tipo_DocId == 0 ? 1 : empleado.Persona.Tipo_DocId;

                var personaJson = JsonConvert.SerializeObject(empleado.Persona);
                var personaContent = new StringContent(personaJson, Encoding.UTF8, "application/json");
                var personaResponse = await _httpClient.PutAsync(
                    $"{_settings.BaseUrl}/{_settings.PersonaPut}/{empleado.Persona.Id}",
                    personaContent
                );

                if (!personaResponse.IsSuccessStatusCode)
                {
                    var error = await personaResponse.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Error actualizando persona: {error}");
                    return View(empleado);
                }

                var JsonData = JsonConvert.SerializeObject(empleado);
                var Content = new StringContent(JsonData, Encoding.UTF8, "application/json");
                var Response = await _httpClient.PutAsync(
                    $"{_settings.BaseUrl}/{_settings.EmpleadosPut}/{empleado.Id}",
                    Content
                );

                if (!Response.IsSuccessStatusCode)
                {
                    var error = await Response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Error actualizando empleado: {error}");
                    return View(empleado);
                }

                return RedirectToAction(nameof(listaEmpleados));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocurrió un error: {ex.Message}");
                return View(empleado);
            }
        }
        
    }
}
