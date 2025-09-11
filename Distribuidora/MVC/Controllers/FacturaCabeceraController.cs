using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Data;
using MVC.Models.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class FacturaCabeceraController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public FacturaCabeceraController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: FacturaCabecera
        public async Task<IActionResult> Index()
        {
            var url = $"{_settings.BaseUrl}/{_settings.FacturaCabeceraGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_facturas = JsonConvert.DeserializeObject<List<FacturaCabeceraDTO>>(json);

            return View(lista_facturas);
        }

        // GET: FacturaCabecera/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FacturaCabecera/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id")] FacturaCabeceraDTO factura)
        {
            if (!ModelState.IsValid)
                return View(factura);

            var url = $"{_settings.BaseUrl}/{_settings.FacturaCabeceraPost}";
            var jsonData = JsonConvert.SerializeObject(factura);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }

        // GET: FacturaCabecera/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.FacturaCabeceraGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var factura = JsonConvert.DeserializeObject<FacturaCabeceraDTO>(json);

            if (factura == null)
                return NotFound();

            return View(factura);
        }

        // PUT: FacturaCabecera/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] FacturaCabeceraDTO factura)
        {
            if (id != factura.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(factura);

            var url = $"{_settings.BaseUrl}/{_settings.FacturaCabeceraPut}/{id}";
            var jsonData = JsonConvert.SerializeObject(factura);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }

        // DELETE: FacturaCabecera/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.FacturaCabeceraDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }
    }
}
