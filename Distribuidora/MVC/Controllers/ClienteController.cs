using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Models.DTOs;
using Newtonsoft.Json;
using System.Text;
using Ciudad = MVC.Models.Entities.Ciudad;
using Estado = MVC.Models.Entities.Estado;

namespace MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public ClientesController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Clientes
        public async Task<IActionResult> listaClientes()
        {
            var url = $"{_settings.BaseUrl}/{_settings.ClientesGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new List<ClienteDTO>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista_clientes = JsonConvert.DeserializeObject<List<ClienteDTO>>(json);

            return View(lista_clientes);
        }

        // GET: Crear Cliente
        public IActionResult crearCliente()
        {
            var cliente = new ClienteDTO
            {
                Persona = new PersonaDTO()
            };
            return View(cliente);
        }

        // POST: Crear Cliente
        [HttpPost]
        public async Task<IActionResult> crearCliente(ClienteDTO cliente)
        {
            try
            {
                // Aseguramos que Persona no sea null
                if (cliente.Persona == null)
                {
                    ModelState.AddModelError(string.Empty, "Debe ingresar los datos de la Persona.");
                    return View(cliente);
                }

                // Forzamos estado de Persona en Alta
                cliente.Persona.EstadoId = 1;

                // Serializamos TODO el objeto ClienteDTO con Persona incluida
                var clienteJson = JsonConvert.SerializeObject(cliente);
                var clienteContent = new StringContent(clienteJson, Encoding.UTF8, "application/json");

                // Llamada al endpoint de la API
                var clienteResponse = await _httpClient.PostAsync($"{_settings.BaseUrl}/{_settings.ClientesPost}", clienteContent);

                if (!clienteResponse.IsSuccessStatusCode)
                {
                    var error = await clienteResponse.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Error creando cliente: {error}");
                    return View(cliente);
                }

                // Si llegó hasta acá → se creó bien
                return RedirectToAction(nameof(listaClientes));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocurrió un error: {ex.Message}");
                return View(cliente);
            }
        }

        // GET : Eliminar Cliente
        [HttpGet]
        public async Task<IActionResult> eliminarCliente()
        {
            var url = $"{_settings.BaseUrl}/{_settings.ClientesGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_clientes = JsonConvert.DeserializeObject<List<ClienteDTO>>(json);

            return View(lista_clientes);
        }
        // DELETE: Cliente/Delete/5
        [HttpPost]
        public async Task<IActionResult> eliminarCliente(int? id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.ClientesDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaClientes));
   
            ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());

            var listaJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.ClientesGet}");
            var cliente = JsonConvert.DeserializeObject<List<ClienteDTO>>(listaJson);
            return View("listaClientes", cliente);
        }

        // GET: Modificar cliente
        public async Task<IActionResult> modificarCliente(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.ClientesGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "No se pudo cargar el cliente");
                return RedirectToAction(nameof(listaClientes));
            }

            var json = await response.Content.ReadAsStringAsync();
            var clientes = JsonConvert.DeserializeObject<List<ClienteDTO>>(json);
            var cliente = clientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                ModelState.AddModelError(string.Empty, "Cliente no encontrado");
                return RedirectToAction(nameof(listaClientes));
            }
            var estados = new List<Estado>
            {
                new Estado { Id = 1, Descripcion = "Activo" },
                new Estado { Id = 2, Descripcion = "Inactivo" }
            };

            var ciudades = new List<Ciudad>
            {
                new Ciudad { Id = 1, Nombre = "Ciudad A" },
                new Ciudad { Id = 2, Nombre = "Ciudad B" }
            };

            // Pasamos las listas a la vista
            ViewBag.Estados = new SelectList(estados, "Id", "Descripcion", cliente.EstadoId);
            ViewBag.Ciudades = new SelectList(ciudades, "Id", "Nombre", cliente.Persona.CiudadId);

            return View(cliente);
        }

        // POST: Modificar cliente
        [HttpPost]
        public async Task<IActionResult> modificarCliente(int id, ClienteDTO cliente)
        {
            if (id != cliente.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                // Repopular combos si hay error de validación
                ViewBag.Estados = new SelectList(new[]
                {
                new Estado { Id = 1, Descripcion = "Activo" },
                new Estado { Id = 2, Descripcion = "Inactivo" }
                }, "Id", "Descripcion", cliente.EstadoId);

                ViewBag.Ciudades = new SelectList(new[]
                {
                new Ciudad { Id = 1, Nombre = "Ciudad A" },
                new Ciudad { Id = 2, Nombre = "Ciudad B" }
                }, "Id", "Nombre", cliente.Persona.CiudadId);

                return View(cliente);
            }

            try
            { 
                cliente.EstadoId = 1;
                cliente.Persona.EstadoId = 1;
                cliente.Persona.Tipo_DocId = cliente.Persona.Tipo_DocId == 0 ? 1 : cliente.Persona.Tipo_DocId;

                var personaJson = JsonConvert.SerializeObject(cliente.Persona);
                var personaContent = new StringContent(personaJson, Encoding.UTF8, "application/json");
                var personaResponse = await _httpClient.PutAsync(
                    $"{_settings.BaseUrl}/{_settings.PersonaPut}/{cliente.Persona.Id}",
                    personaContent
                );

                if (!personaResponse.IsSuccessStatusCode)
                {
                    var error = await personaResponse.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Error actualizando persona: {error}");
                    return View(cliente);
                }

                var clienteJson = JsonConvert.SerializeObject(cliente);
                var clienteContent = new StringContent(clienteJson, Encoding.UTF8, "application/json");
                var clienteResponse = await _httpClient.PutAsync(
                    $"{_settings.BaseUrl}/{_settings.ClientesPut}/{cliente.Id}",
                    clienteContent
                );

                if (!clienteResponse.IsSuccessStatusCode)
                {
                    var error = await clienteResponse.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Error actualizando cliente: {error}");
                    return View(cliente);
                }

                return RedirectToAction(nameof(listaClientes));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocurrió un error: {ex.Message}");
                return View(cliente);
            }
        }
    }
}