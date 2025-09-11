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
    public class CiudadController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public CiudadController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Ciudades
        public async Task<IActionResult> Index()
        {
            var url = $"{_settings.BaseUrl}/{_settings.CiudadesGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_ciudades = JsonConvert.DeserializeObject<List<CiudadDTO>>(json);

            return View(lista_ciudades);
        }

        // GET: Ciudades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ciudades/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Cp,Acp")] CiudadDTO ciudad)
        {
            if (!ModelState.IsValid)
                return View(ciudad);

            var url = $"{_settings.BaseUrl}/{_settings.CiudadesPost}";
            var jsonData = JsonConvert.SerializeObject(ciudad);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }

        // GET: Ciudades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.CiudadesGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var ciudad = JsonConvert.DeserializeObject<CiudadDTO>(json);

            if (ciudad == null)
                return NotFound();

            return View(ciudad);
        }

        // PUT: Ciudades/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Cp,Acp")] CiudadDTO ciudad)
        {
            if (id != ciudad.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(ciudad);

            var url = $"{_settings.BaseUrl}/{_settings.CiudadesPut}/{id}";
            var jsonData = JsonConvert.SerializeObject(ciudad);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }

        // DELETE: Ciudades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.CiudadesDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }
    }
}
