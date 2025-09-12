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
    public class OrdenVentaProductoController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public OrdenVentaProductoController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: OrdenDeVentaProducto
        public async Task<IActionResult> Index()
        {
            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeVentaProductoGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_productos = JsonConvert.DeserializeObject<List<OrdenDeVentaProductoDTO>>(json);

            return View(lista_productos);
        }

        // GET: OrdenDeVentaProducto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrdenDeVentaProducto/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,OrdenVentaId,ProductoId,CantidadProducto")] OrdenDeVentaProductoDTO producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeVentaProductoPost}";
            var jsonData = JsonConvert.SerializeObject(producto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }

        // GET: OrdenDeVentaProducto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeVentaProductoGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var producto = JsonConvert.DeserializeObject<OrdenDeVentaProductoDTO>(json);

            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // PUT: OrdenDeVentaProducto/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrdenVentaId,ProductoId,CantidadProducto")] OrdenDeVentaProductoDTO producto)
        {
            if (id != producto.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(producto);

            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeVentaProductoPut}/{id}";
            var jsonData = JsonConvert.SerializeObject(producto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }

        // DELETE: OrdenDeVentaProducto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeVentaProductoDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }
    }
}
