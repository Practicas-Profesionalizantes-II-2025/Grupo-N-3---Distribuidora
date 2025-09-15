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
        public async Task<IActionResult> Index()
        {
            var url = $"{_settings.BaseUrl}/{_settings.ClientesGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_clientes = JsonConvert.DeserializeObject<List<ClienteDTO>>(json);

            return View(lista_clientes);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,PersonaId,EstadoId")] ClienteDTO cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            var url = $"{_settings.BaseUrl}/{_settings.ClientesPost}";
            var jsonData = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.ClientesGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var cliente = JsonConvert.DeserializeObject<ClienteDTO>(json);

            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        // PUT: Clientes/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonaId,EstadoId")] ClienteDTO cliente)
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
                return View("Error");

            return RedirectToAction("Index");
        }

        // DELETE: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.ClientesDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }
    }
}