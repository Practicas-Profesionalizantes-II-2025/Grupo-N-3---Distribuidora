using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Models.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class ProductoController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public ProductoController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Lista de productos
        public async Task<IActionResult> listaProductos()
        {
            var url = $"{_settings.BaseUrl}/{_settings.ProductoGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new List<ProductoDTO>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var productos = JsonConvert.DeserializeObject<List<ProductoDTO>>(json);

            // Obtener proveedores y categorías para mostrar nombres
            var proveedoresJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.ProveedorGet}");
            var categoriasJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.CategoriasGet}");

            var proveedores = JsonConvert.DeserializeObject<List<dynamic>>(proveedoresJson);
            var categorias = JsonConvert.DeserializeObject<List<dynamic>>(categoriasJson);

            foreach (var p in productos)
            {
                p.ProveedorNombre = proveedores.FirstOrDefault(x => x.Id == p.ProveedorId)?.Nombre ?? "N/A";
                p.CategoriaNombre = categorias.FirstOrDefault(x => x.Id == p.CategoriaId)?.Nombre ?? "N/A";
            }

            return View(productos);
        }

        // GET: Crear producto
        public IActionResult crearProducto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> crearProducto(ProductoDTO producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

            var url = $"{_settings.BaseUrl}/{_settings.ProductoPost}";
            var jsonData = JsonConvert.SerializeObject(producto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaProductos));

            // Si falla, agrego el mensaje al ModelState y vuelvo a la vista
            ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());
            return View(producto);
        }


        // GET: Modificar producto
        public async Task<IActionResult> modificarProducto(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.ProductoGet}/{id}";
            var response = await _httpClient.GetAsync(url);
            
            if (!response.IsSuccessStatusCode)
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al buscar producto: {errorMsg}");
                return View(listaProductos);
            }

            var json = await response.Content.ReadAsStringAsync();
            var producto = JsonConvert.DeserializeObject<ProductoDTO>(json);

            return View(producto);
        }

        // POST: Modificar producto
        [HttpPost]
        public async Task<IActionResult> modificarProducto(int id, ProductoDTO producto)
        {
            if (id != producto.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(producto);

            var url = $"{_settings.BaseUrl}/{_settings.ProductoPut}/{id}";
            var jsonData = JsonConvert.SerializeObject(producto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al modificar producto: {errorMsg}");
                return View(producto);
            }

            return RedirectToAction("listaProductos");
        }

        // GET: Eliminar producto
        public async Task<IActionResult> eliminarProducto(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.ProductoDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaProductos));

            // Si falla, podrías pasar un mensaje de error a la vista de lista o crear una vista específica
            ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());

            // Aquí podés devolver la lista con los productos para que no rompa
            var listaJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.ProductoGet}");
            var productos = JsonConvert.DeserializeObject<List<ProductoDTO>>(listaJson);
            return View("listaProductos", productos);
        }
    }
}
