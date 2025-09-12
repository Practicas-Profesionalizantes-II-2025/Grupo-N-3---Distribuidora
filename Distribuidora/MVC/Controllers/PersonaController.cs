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
    public class PersonaController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public PersonaController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Persona
        public async Task<IActionResult> Index()
        {
            var url = $"{_settings.BaseUrl}/{_settings.PersonaGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_personas = JsonConvert.DeserializeObject<List<PersonaDTO>>(json);

            return View(lista_personas);
        }

        // GET: Persona/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Tipo_DocId,Nro_Doc,CiudadId,Email,Direccion,Telefono,EstadoId")] PersonaDTO persona)
        {
            if (!ModelState.IsValid)
                return View(persona);

            var url = $"{_settings.BaseUrl}/{_settings.PersonaPost}";
            var jsonData = JsonConvert.SerializeObject(persona);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }

        // GET: Persona/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.PersonaGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var persona = JsonConvert.DeserializeObject<PersonaDTO>(json);

            if (persona == null)
                return NotFound();

            return View(persona);
        }

        // PUT: Persona/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Tipo_DocId,Nro_Doc,CiudadId,Email,Direccion,Telefono,EstadoId")] PersonaDTO persona)
        {
            if (id != persona.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(persona);

            var url = $"{_settings.BaseUrl}/{_settings.PersonaPut}/{id}";
            var jsonData = JsonConvert.SerializeObject(persona);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }

        // DELETE: Persona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.PersonaDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }
    }
}
