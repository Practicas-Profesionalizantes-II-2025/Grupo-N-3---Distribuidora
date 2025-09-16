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
        public async Task<IActionResult> listaFacturas()
        {
            var url = $"{_settings.BaseUrl}/{_settings.FacturaCabeceraGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_facturas = JsonConvert.DeserializeObject<List<FacturaCabeceraDTO>>(json);

            return View(lista_facturas);
        }

        // GET: Crear FacturaCabecera
        public IActionResult crearFactura()
        {
            return View();
        }

        // POST: Crear FacturaCabecera
        [HttpPost]
        public async Task<IActionResult> crearFactura([Bind("Id")] FacturaCabeceraDTO factura)
        {
            if (!ModelState.IsValid)
                return View(factura);

            var url = $"{_settings.BaseUrl}/{_settings.FacturaCabeceraPost}";
            var jsonData = JsonConvert.SerializeObject(factura);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("listaFacturas");
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

            // Volver a traer la lista después de eliminar
            var url2 = $"{_settings.BaseUrl}/{_settings.FacturaCabeceraGet}";
            var response2 = await _httpClient.GetAsync(url2);

            if (!response2.IsSuccessStatusCode)
                return View("Error");

            var json = await response2.Content.ReadAsStringAsync();
            var lista_facturas = JsonConvert.DeserializeObject<List<FacturaCabeceraDTO>>(json);

            return View("listaFacturas", lista_facturas);
        }

        //// PUT: FacturaCabecera/Edit/5
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id")] FacturaCabeceraDTO factura)
        //{
        //    if (id != factura.Id)
        //        return NotFound();
        //
        //    if (!ModelState.IsValid)
        //        return View(factura);
        //
        //    var url = $"{_settings.BaseUrl}/{_settings.FacturaCabeceraPut}/{id}";
        //    var jsonData = JsonConvert.SerializeObject(factura);
        //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //
        //    var response = await _httpClient.PutAsync(url, content);
        //
        //    if (!response.IsSuccessStatusCode)
        //        return View("Error");
        //
        //    return RedirectToAction("listaFacturas");
        //}
    }
}
