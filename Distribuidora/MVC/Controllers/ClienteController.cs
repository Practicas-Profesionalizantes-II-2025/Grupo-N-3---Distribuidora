using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Data;
using MVC.Models.DTOs;
using MVC.Models.Entities;
using Newtonsoft.Json;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return View();
        }

        // POST: Crear Cliente
        [HttpPost]
        public async Task<IActionResult> crearCliente(ClienteDTO cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            // 1️⃣ Crear la persona primero
            var personaDto = new PersonaDTO
            {
                Nombre = Request.Form["Nombre"],
                Apellido = Request.Form["Apellido"],
                Tipo_DocId = int.Parse(Request.Form["Tipo_DocId"]),
                Nro_Doc = Request.Form["Nro_Doc"],
                CiudadId = int.Parse(Request.Form["CiudadId"]),
                Email = Request.Form["Email"],
                Direccion = Request.Form["Direccion"],
                Telefono = Request.Form["Telefono"],
                EstadoId = 1
            };

            var personaJson = JsonConvert.SerializeObject(personaDto);
            var personaContent = new StringContent(personaJson, Encoding.UTF8, "application/json");

            var personaResponse = await _httpClient.PostAsync($"{_settings.BaseUrl}/{_settings.PersonaPost}", personaContent);

            if (!personaResponse.IsSuccessStatusCode)
            {
                var error = await personaResponse.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, "Error creando persona: " + error);
                return View(cliente);
            }

            var personaCreadaJson = await personaResponse.Content.ReadAsStringAsync();
            var personaCreada = JsonConvert.DeserializeObject<PersonaDTO>(personaCreadaJson);

            // 2️⃣ Crear el cliente usando solo PersonaId y EstadoId
            cliente.PersonaId = personaCreada.Id;

            var clienteJson = JsonConvert.SerializeObject(cliente);
            var clienteContent = new StringContent(clienteJson, Encoding.UTF8, "application/json");
            var clienteResponse = await _httpClient.PostAsync($"{_settings.BaseUrl}/{_settings.ClientesPost}", clienteContent);

            if (!clienteResponse.IsSuccessStatusCode)
            {
                var error = await clienteResponse.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, "Error creando cliente: " + error);
                return View(cliente);
            }

            return RedirectToAction("listaClientes");
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
        [HttpGet]
        public async Task<IActionResult> modificarCliente(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.ClientesGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al buscar cliente: {errorMsg}");
                return View(listaClientes);
            }

            var json = await response.Content.ReadAsStringAsync();
            var cliente = JsonConvert.DeserializeObject<ClienteDTO>(json);

            return View(cliente);
        }

        // POST: Modificar cliente
        [HttpPost]
        public async Task<IActionResult> modificarCliente(int id, ClienteDTO cliente)
        {
            if (id != cliente.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(cliente);

            var url = $"{_settings.BaseUrl}/{_settings.ClientesPut}/{id}";
            var jsonData = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al modificar cliente: {errorMsg}");
                return View(cliente);
            }

            return RedirectToAction("listaClientes");
        }
    }
}