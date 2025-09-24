using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Models.DTOs;
using Newtonsoft.Json;
using System.Text;

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
        public async Task<IActionResult> listaOrdenesCompra()
        {
            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeCompraGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_ordenes = JsonConvert.DeserializeObject<List<OrdenDeCompraDTO>>(json);

            return View(lista_ordenes);
        }

        // GET: Crear OrdenDeCompra
        public IActionResult crearOrdenCompra()
        {
            return View();
        }

        // POST: Crear OrdenDeCompra
        [HttpPost]
        public async Task<IActionResult> crearOrdenCompra([Bind("Id,EmpleadoId,DistribuidorId,FechaOrden")] OrdenDeCompraDTO orden)
        {
            if (!ModelState.IsValid)
                return View(orden);

            var url = $"{_settings.BaseUrl}/{_settings.OrdenDeCompraPost}";
            var jsonData = JsonConvert.SerializeObject(orden);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("listaOrdenesCompra");
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

            // Volver a traer la lista después de eliminar
            var url2 = $"{_settings.BaseUrl}/{_settings.OrdenDeCompraGet}";
            var response2 = await _httpClient.GetAsync(url2);

            if (!response2.IsSuccessStatusCode)
                return View("Error");

            var json = await response2.Content.ReadAsStringAsync();
            var lista_ordenes = JsonConvert.DeserializeObject<List<OrdenDeCompraDTO>>(json);

            return View("listaOrdenesCompra", lista_ordenes);
        }

        //// PUT: OrdenDeCompra/Edit/5
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,EmpleadoId,DistribuidorId,FechaOrden")] OrdenDeCompraDTO orden)
        //{
        //    if (id != orden.Id)
        //        return NotFound();
        //
        //    if (!ModelState.IsValid)
        //        return View(orden);
        //
        //    var url = $"{_settings.BaseUrl}/{_settings.OrdenDeCompraPut}/{id}";
        //    var jsonData = JsonConvert.SerializeObject(orden);
        //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //
        //    var response = await _httpClient.PutAsync(url, content);
        //
        //    if (!response.IsSuccessStatusCode)
        //        return View("Error");
        //
        //    return RedirectToAction("listaOrdenesCompra");
        //}
    }
}
