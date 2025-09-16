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
                return View("Error");

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
        public async Task<IActionResult> crearCliente([Bind("Id,PersonaId,EstadoId")] ClienteDTO cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            var url = $"{_settings.BaseUrl}/{_settings.ClientesPost}";
            var jsonData = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaClientes));

            ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());
            return View(cliente);
        }

        // DELETE: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.ProductoDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaClientes));
   
            ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());

            var listaJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.ClientesGet}");
            var cliente = JsonConvert.DeserializeObject<List<ClienteDTO>>(listaJson);
            return View("listaCliente", cliente);
        }

        // GET: Modificar cliente
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