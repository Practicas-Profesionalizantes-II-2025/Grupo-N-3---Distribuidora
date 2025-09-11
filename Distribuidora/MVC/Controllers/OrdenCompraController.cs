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
    public class OrdenCompraController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public OrdenCompraController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: OrdenDeCompra
        public async Task<IActionResult> Index()
        {
            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeCompraGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_ordenes = JsonConvert.DeserializeObject<List<OrdenDeCompraDTO>>(json);

            return View(lista_ordenes);
        }

        // GET: OrdenDeCompra/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrdenDeCompra/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,EmpleadoId,DistribuidorId,FechaOrden")] OrdenDeCompraDTO orden)
        {
            if (!ModelState.IsValid)
                return View(orden);

            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeCompraPost}";
            var jsonData = JsonConvert.SerializeObject(orden);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }

        // GET: OrdenDeCompra/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeCompraGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var orden = JsonConvert.DeserializeObject<OrdenDeCompraDTO>(json);

            if (orden == null)
                return NotFound();

            return View(orden);
        }

        // PUT: OrdenDeCompra/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpleadoId,DistribuidorId,FechaOrden")] OrdenDeCompraDTO orden)
        {
            if (id != orden.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(orden);

            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeCompraPut}/{id}";
            var jsonData = JsonConvert.SerializeObject(orden);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }

        // DELETE: OrdenDeCompra/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeCompraDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }
    }
}
