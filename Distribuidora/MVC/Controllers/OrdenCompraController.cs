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
        public async Task<IActionResult> listaOrdenCompras()
        {
            var url = $"{_settings.BaseUrl}/{_settings.OrdenCompraGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new List<OrdenDeCompraDTO>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista_OrdenCompras = JsonConvert.DeserializeObject<List<OrdenDeCompraDTO>>(json);

            return View(lista_OrdenCompras);
        }

        // GET: Crear OrdenDeCompra
        public async Task<IActionResult> crearOrdenCompra()
        {
            var url = $"{_settings.BaseUrl}/{_settings.ProductoGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new OrdenDeCompraDTO());
            }

            var json = await response.Content.ReadAsStringAsync();
            var productos = JsonConvert.DeserializeObject<List<ProductoDTO>>(json,
                new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });


            var model = new OrdenDeCompraDTO
            {
                FechaOrden = DateTime.Now,
                Productos = productos
            };

            return View(model);
        }

        // POST: Crear OrdenDeCompra
        [HttpPost]
        public async Task<IActionResult> crearOrdenCompra(OrdenDeCompraDTO orden)
        {
            if (!ModelState.IsValid)
                return View(orden);

            var url = $"{_settings.BaseUrl}/{_settings.OrdenCompraPost}";
            var jsonData = JsonConvert.SerializeObject(orden);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaOrdenCompras));

            return RedirectToAction("listaOrdenesCompra");
        }

        // PUT: OrdenDeCompra/Edit/5
        [HttpPost]
        public async Task<IActionResult> modificarOrdenCompra(int id, [Bind("Id,EmpleadoId,DistribuidorId,FechaOrden")] OrdenDeCompraDTO orden)
        {
            if (id != orden.Id)
                return NotFound();
        
            if (!ModelState.IsValid)
                return View(orden);
            var url = $"{_settings.BaseUrl}/{_settings.OrdenCompraPut}/{id}";
            var jsonData = JsonConvert.SerializeObject(orden);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        
            var response = await _httpClient.PutAsync(url, content);
        
            if (!response.IsSuccessStatusCode)
                return View("Error");
        
            return RedirectToAction("listaOrdenesCompra");
        }
        // DELETE: OrdenDeCompra/Delete/5
        public async Task<IActionResult> eliminarOrdenCompra(int? id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.OrdenCompraDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaOrdenCompras));

            ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());

            var listaJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.ClientesGet}");
            var lista_OrdenCompras = JsonConvert.DeserializeObject<List<OrdenDeCompraDTO>>(listaJson);
            return View("lista_OrdenCompras", lista_OrdenCompras);
        }
    }
}
