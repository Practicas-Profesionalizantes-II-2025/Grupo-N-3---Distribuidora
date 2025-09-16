using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Data;
using MVC.Models.DTOs;
using MVC.Models.Entities;
using Newtonsoft.Json;
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

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("listaClientes");
        }

        // DELETE: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.ClientesDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            // Volver a traer la lista después de eliminar
            var url2 = $"{_settings.BaseUrl}/{_settings.ClientesGet}";
            var response2 = await _httpClient.GetAsync(url2);

            if (!response2.IsSuccessStatusCode)
                return View("Error");

            var json = await response2.Content.ReadAsStringAsync();
            var lista_clientes = JsonConvert.DeserializeObject<List<ClienteDTO>>(json);

            return View("listaClientes", lista_clientes);
        }

        //// PUT: Cliente/Edit/5
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,PersonaId,EstadoId")] ClienteDTO cliente)
        //{
        //    if (id != cliente.Id)
        //        return NotFound();
        //
        //    if (!ModelState.IsValid)
        //        return View(cliente);
        //
        //    var url = $"{_settings.BaseUrl}/{_settings.ClientesPut}/{id}";
        //    var jsonData = JsonConvert.SerializeObject(cliente);
        //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //
        //    var response = await _httpClient.PutAsync(url, content);
        //
        //    if (!response.IsSuccessStatusCode)
        //        return View("Error");
        //
        //    return RedirectToAction("listaClientes");
        //}
    }
}