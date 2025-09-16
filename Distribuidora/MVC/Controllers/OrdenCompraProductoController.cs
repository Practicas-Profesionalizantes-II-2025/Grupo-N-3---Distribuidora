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
    public class OrdenCompraProductoController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public OrdenCompraProductoController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: OrdenDeCompraProducto
        public async Task<IActionResult> listaOrdenesCompraProducto()
        {
            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeCompraProductoGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_ordenes = JsonConvert.DeserializeObject<List<OrdenDeCompraProductoDTO>>(json);

            return View(lista_ordenes);
        }

        // GET: Crear OrdenDeCompraProducto
        public IActionResult crearOrdenCompraProducto()
        {
            return View();
        }

        // POST: Crear OrdenDeCompraProducto
        [HttpPost]
        public async Task<IActionResult> crearOrdenCompraProducto([Bind("Id,OrdenDeCompraId,ProductoId,CantidadProducto")] OrdenDeCompraProductoDTO ordenProducto)
        {
            if (!ModelState.IsValid)
                return View(ordenProducto);

            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeCompraProductoPost}";
            var jsonData = JsonConvert.SerializeObject(ordenProducto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("listaOrdenesCompraProducto");
        }

        // DELETE: OrdenDeCompraProducto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeCompraProductoDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            // Volver a traer la lista después de eliminar
            var url2 = $"{_settings.BaseUrl}/{_settings.OrdenDeCompraProductoGet}";
            var response2 = await _httpClient.GetAsync(url2);

            if (!response2.IsSuccessStatusCode)
                return View("Error");

            var json = await response2.Content.ReadAsStringAsync();
            var lista_ordenes = JsonConvert.DeserializeObject<List<OrdenDeCompraProductoDTO>>(json);

            return View("listaOrdenesCompraProducto", lista_ordenes);
        }

        //// PUT: OrdenDeCompraProducto/Edit/5
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,OrdenDeCompraId,ProductoId,CantidadProducto")] OrdenDeCompraProductoDTO ordenProducto)
        //{
        //    if (id != ordenProducto.Id)
        //        return NotFound();
        //
        //    if (!ModelState.IsValid)
        //        return View(ordenProducto);
        //
        //    var url = $"{_settings.BaseUrl}/{_settings.OrdenDeCompraProductoPut}/{id}";
        //    var jsonData = JsonConvert.SerializeObject(ordenProducto);
        //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //
        //    var response = await _httpClient.PutAsync(url, content);
        //
        //    if (!response.IsSuccessStatusCode)
        //        return View("Error");
        //
        //    return RedirectToAction("listaOrdenesCompraProducto");
        //}
    }
}
