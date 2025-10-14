using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Models.DTOs;
using Newtonsoft.Json;
using System.Text;

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
        public async Task<IActionResult> listaOrdenesProducto()
        {
            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeVentaProductoGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_ordenes = JsonConvert.DeserializeObject<List<OrdenDeVentaProductoDTO>>(json);

            return View(lista_ordenes);
        }

        // GET: Crear OrdenDeVentaProducto
        public IActionResult crearOrdenProducto()
        {
            return View();
        }

        // POST: Crear OrdenDeVentaProducto
        [HttpPost]
        public async Task<IActionResult> crearOrdenProducto([Bind("Id,OrdenVentaId,ProductoId,CantidadProducto")] OrdenDeVentaProductoDTO ordenProducto)
        {
            if (!ModelState.IsValid)
                return View(ordenProducto);

            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeVentaProductoPost}";
            var jsonData = JsonConvert.SerializeObject(ordenProducto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("listaOrdenesProducto");
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

            // Volver a traer la lista después de eliminar
            var url2 = $"{_settings.BaseUrl}/{_settings.OrdenDeVentaProductoGet}";
            var response2 = await _httpClient.GetAsync(url2);

            if (!response2.IsSuccessStatusCode)
                return View("Error");

            var json = await response2.Content.ReadAsStringAsync();
            var lista_ordenes = JsonConvert.DeserializeObject<List<OrdenDeVentaProductoDTO>>(json);

            return View("listaOrdenesProducto", lista_ordenes);
        }

        //// PUT: OrdenDeVentaProducto/Edit/5
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,OrdenVentaId,ProductoId,CantidadProducto")] OrdenDeVentaProductoDTO ordenProducto)
        //{
        //    if (id != ordenProducto.Id)
        //        return NotFound();
        //
        //    if (!ModelState.IsValid)
        //        return View(ordenProducto);
        //
        //    var url = $"{_settings.BaseUrl}/{_settings.OrdenDeVentaProductoPut}/{id}";
        //    var jsonData = JsonConvert.SerializeObject(ordenProducto);
        //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //
        //    var response = await _httpClient.PutAsync(url, content);
        //
        //    if (!response.IsSuccessStatusCode)
        //        return View("Error");
        //
        //    return RedirectToAction("listaOrdenesProducto");
        //}
    }
}
