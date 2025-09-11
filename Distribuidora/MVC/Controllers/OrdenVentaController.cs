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
    public class OrdenVentaController : Controller
    {
        public class OrdenDeVentaController : Controller
        {
            private readonly HttpClient _httpClient;
            private readonly ApiSettings _settings;

            public OrdenDeVentaController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
            {
                _httpClient = httpClientFactory.CreateClient("API");
                _settings = settings.Value;
            }

            // GET: OrdenDeVenta
            public async Task<IActionResult> Index()
            {
                var url = $"{_settings.BaseUrl}/{_settings.OrdenDeVentaGet}";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return View("Error");

                var json = await response.Content.ReadAsStringAsync();
                var lista_ordenes = JsonConvert.DeserializeObject<List<OrdenDeVentaDTO>>(json);

                return View(lista_ordenes);
            }

            // GET: OrdenDeVenta/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: OrdenDeVenta/Create
            [HttpPost]
            public async Task<IActionResult> Create([Bind("Id,Fecha,FacturaId,EmpleadoId,ClienteId,DistribuidorId")] OrdenDeVentaDTO orden)
            {
                if (!ModelState.IsValid)
                    return View(orden);

                var url = $"{_settings.BaseUrl}/{_settings.OrdenDeVentaPost}";
                var jsonData = JsonConvert.SerializeObject(orden);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                    return View("Error");

                return RedirectToAction("Index");
            }

            // GET: OrdenDeVenta/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                    return NotFound();

                var url = $"{_settings.BaseUrl}/{_settings.OrdenDeVentaGet}/{id}";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return View("Error");

                var json = await response.Content.ReadAsStringAsync();
                var orden = JsonConvert.DeserializeObject<OrdenDeVentaDTO>(json);

                if (orden == null)
                    return NotFound();

                return View(orden);
            }

            // PUT: OrdenDeVenta/Edit/5
            [HttpPost]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,FacturaId,EmpleadoId,ClienteId,DistribuidorId")] OrdenDeVentaDTO orden)
            {
                if (id != orden.Id)
                    return NotFound();

                if (!ModelState.IsValid)
                    return View(orden);

                var url = $"{_settings.BaseUrl}/{_settings.OrdenDeVentaPut}/{id}";
                var jsonData = JsonConvert.SerializeObject(orden);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(url, content);

                if (!response.IsSuccessStatusCode)
                    return View("Error");

                return RedirectToAction("Index");
            }

            // DELETE: OrdenDeVenta/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                    return NotFound();

                var url = $"{_settings.BaseUrl}/{_settings.OrdenDeVentaDelete}/{id}";
                var response = await _httpClient.DeleteAsync(url);

                if (!response.IsSuccessStatusCode)
                    return View("Error");

                return RedirectToAction("Index");
            }
        }
    }
}
