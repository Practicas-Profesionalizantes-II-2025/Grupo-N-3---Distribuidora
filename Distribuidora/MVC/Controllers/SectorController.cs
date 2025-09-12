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
    public class SectorController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public SectorController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Sector
        public async Task<IActionResult> Index()
        {
            var url = $"{_settings.BaseUrl}/{_settings.SectorGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_sectores = JsonConvert.DeserializeObject<List<SectorDTO>>(json);

            return View(lista_sectores);
        }

        // GET: Sector/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sector/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Nombre,EstadoId")] SectorDTO sector)
        {
            if (!ModelState.IsValid)
                return View(sector);

            var url = $"{_settings.BaseUrl}/{_settings.SectorPost}";
            var jsonData = JsonConvert.SerializeObject(sector);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }

        // GET: Sector/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.SectorGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var sector = JsonConvert.DeserializeObject<SectorDTO>(json);

            if (sector == null)
                return NotFound();

            return View(sector);
        }

        // PUT: Sector/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,EstadoId")] SectorDTO sector)
        {
            if (id != sector.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(sector);

            var url = $"{_settings.BaseUrl}/{_settings.SectorPut}/{id}";
            var jsonData = JsonConvert.SerializeObject(sector);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }

        // DELETE: Sector/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.SectorDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }
    }
}
