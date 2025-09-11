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
    public class EmpleadoController : Controller
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
            public async Task<IActionResult> Index()
            {
                var url = $"{_settings.BaseUrl}/{_settings.EmpleadosGet}";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return View("Error");

                var json = await response.Content.ReadAsStringAsync();
                var lista_empleados = JsonConvert.DeserializeObject<List<EmpleadoDTO>>(json);

                return View(lista_empleados);
            }

            // GET: Empleados/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Empleados/Create
            [HttpPost]
            public async Task<IActionResult> Create([Bind("Id,PersonaId,Foto,EstadoId")] EmpleadoDTO empleado)
            {
                if (!ModelState.IsValid)
                    return View(empleado);

                var url = $"{_settings.BaseUrl}/{_settings.EmpleadosPost}";
                var jsonData = JsonConvert.SerializeObject(empleado);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                    return View("Error");

                return RedirectToAction("Index");
            }

            // GET: Empleados/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                    return NotFound();

                var url = $"{_settings.BaseUrl}/{_settings.EmpleadosGet}/{id}";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return View("Error");

                var json = await response.Content.ReadAsStringAsync();
                var empleado = JsonConvert.DeserializeObject<EmpleadoDTO>(json);

                if (empleado == null)
                    return NotFound();

                return View(empleado);
            }

            // PUT: Empleados/Edit/5
            [HttpPost]
            public async Task<IActionResult> Edit(int id, [Bind("Id,PersonaId,Foto,EstadoId")] EmpleadoDTO empleado)
            {
                if (id != empleado.Id)
                    return NotFound();

                if (!ModelState.IsValid)
                    return View(empleado);

                var url = $"{_settings.BaseUrl}/{_settings.EmpleadosPut}/{id}";
                var jsonData = JsonConvert.SerializeObject(empleado);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(url, content);

                if (!response.IsSuccessStatusCode)
                    return View("Error");

                return RedirectToAction("Index");
            }

            // DELETE: Empleados/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                    return NotFound();

                var url = $"{_settings.BaseUrl}/{_settings.EmpleadosDelete}/{id}";
                var response = await _httpClient.DeleteAsync(url);

                if (!response.IsSuccessStatusCode)
                    return View("Error");

                return RedirectToAction("Index");
            }
        }
    }
}
