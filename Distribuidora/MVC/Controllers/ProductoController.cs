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
    public class ProductoController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public ProductoController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Productos
        public async Task<IActionResult> listaProductos()
        {
            var url = $"{_settings.BaseUrl}/{_settings.ProductoGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_productos = JsonConvert.DeserializeObject<List<ProductoDTO>>(json);

            return View(lista_productos);
        }

        // GET: Producto/Create
        public IActionResult crearProducto()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public async Task<IActionResult> crearProducto([Bind("Id,Nombre,ProveedorId,CategoriaId,UnidadesProducto,PrecioProducto,Stock")] ProductoDTO producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

            var url = $"{_settings.BaseUrl}/{_settings.ProductoPost}";
            var jsonData = JsonConvert.SerializeObject(producto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("listaProductos");
        }

        // GET: Producto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.ProductoDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error al eliminar el producto");

            // Volver a obtener la lista actualizada
            var url2 = $"{_settings.BaseUrl}/{_settings.ProductoGet}";
            var response2 = await _httpClient.GetAsync(url2);

            if (!response2.IsSuccessStatusCode)
                return View("Error");

            var json = await response2.Content.ReadAsStringAsync();
            var lista_productos = JsonConvert.DeserializeObject<List<ProductoDTO>>(json);

            return View("listaProductos", lista_productos);
        }

        //// PUT: Producto/Edit/5 (opcional)
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,ProveedorId,CategoriaId,UnidadesProducto,PrecioProducto,Stock")] ProductoDTO producto)
        //{
        //    if (id != producto.Id)
        //        return NotFound();
        //
        //    if (!ModelState.IsValid)
        //        return View(producto);
        //
        //    var url = $"{_settings.BaseUrl}/{_settings.ProductoPut}/{id}";
        //    var jsonData = JsonConvert.SerializeObject(producto);
        //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //
        //    var response = await _httpClient.PutAsync(url, content);
        //
        //    if (!response.IsSuccessStatusCode)
        //        return View("Error");
        //
        //    return RedirectToAction("listaProductos");
        //}
    }
}
