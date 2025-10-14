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

        // Ir a vista Lista con todos los productos
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
            var ulrProveedores = $"{_settings.BaseUrl}/{_settings.ProveedorGet}";
            var urlCategorias = $"{_settings.BaseUrl}/{_settings.CategoriasGet}";
            var proveedoresJson = await _httpClient.GetStringAsync(ulrProveedores);
            var categoriasJson = await _httpClient.GetStringAsync(urlCategorias);

            var proveedores = JsonConvert.DeserializeObject<List<ProveedorDTO>>(proveedoresJson);
            var categorias = JsonConvert.DeserializeObject<List<CategoriaDTO>>(categoriasJson);

            List< ProductoDTOvista> productosParaVista = new List< ProductoDTOvista>();

            foreach (var p in productos)
            {
                ProductoDTOvista productoDTOvista = new ProductoDTOvista
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    ProveedorNombre = proveedores.FirstOrDefault(x => x.Id == p.ProveedorId)?.Nombre ?? "N/A",
                    CategoriaNombre = categorias.FirstOrDefault(x => x.Id == p.CategoriaId)?.Nombre ?? "N/A",
                    PrecioProducto = p.PrecioProducto,
                    Stock = p.Stock
                };
                productosParaVista.Add(productoDTOvista);

            }

            return View(productosParaVista);
        }

        // Ir a vista Lista con los productos filstrados
        public async Task<IActionResult> bucarProductos(string nombre)
        {

            if (nombre == null)
            {
                return RedirectToAction(nameof(listaProductos));
            }
            var url = $"{_settings.BaseUrl}/{_settings.ProductoGetNombre}/{nombre}";
            var response = await _httpClient.GetAsync(url);


            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new List<ProductoDTO>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var productos = JsonConvert.DeserializeObject<List<ProductoDTO>>(json);

            // Obtener proveedores y categorías para mostrar nombres
            var ulrProveedores = $"{_settings.BaseUrl}/{_settings.ProveedorGet}";
            var urlCategorias = $"{_settings.BaseUrl}/{_settings.CategoriasGet}";
            var proveedoresJson = await _httpClient.GetStringAsync(ulrProveedores);
            var categoriasJson = await _httpClient.GetStringAsync(urlCategorias);

            var proveedores = JsonConvert.DeserializeObject<List<ProveedorDTO>>(proveedoresJson);
            var categorias = JsonConvert.DeserializeObject<List<CategoriaDTO>>(categoriasJson);

            List<ProductoDTOvista> productosParaVista = new List<ProductoDTOvista>();

            foreach (var p in productos)
            {
                ProductoDTOvista productoDTOvista = new ProductoDTOvista
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    ProveedorNombre = proveedores.FirstOrDefault(x => x.Id == p.ProveedorId)?.Nombre ?? "N/A",
                    CategoriaNombre = categorias.FirstOrDefault(x => x.Id == p.CategoriaId)?.Nombre ?? "N/A",
                    PrecioProducto = p.PrecioProducto,
                    Stock = p.Stock
                };
                productosParaVista.Add(productoDTOvista);

            }
            return View("listaProductos", productosParaVista);
        }

        // Ir a Vista crear producto
        public async Task<IActionResult> crearProducto()
        {
            // Obtener proveedores y categorías para mostrar nombres
            var ulrProveedores = $"{_settings.BaseUrl}/{_settings.ProveedorGet}";
            var urlCategorias = $"{_settings.BaseUrl}/{_settings.CategoriasGet}";
            var proveedoresJson = await _httpClient.GetStringAsync(ulrProveedores);
            var categoriasJson = await _httpClient.GetStringAsync(urlCategorias);

            var proveedores = JsonConvert.DeserializeObject<List<ProveedorDTO>>(proveedoresJson);
            var categorias = JsonConvert.DeserializeObject<List<CategoriaDTO>>(categoriasJson);

            ProductoCrearModel model = new ProductoCrearModel
            {
                Proveedores = proveedores,
                Categorias = categorias
            };
            return View(model);
        }

        // Accion crear producto

        [HttpPost]
        public async Task<IActionResult> AccioncrearProducto([Bind("Nombre, PrecioProducto, Stock, CategoriaId, ProveedorId")] ProductoDTO producto)
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


        // PUT: Modificar producto
        public async Task<IActionResult> modificarProducto(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.ProductoGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            var urlCategorias = $"{_settings.BaseUrl}/{_settings.CategoriasGet}";
            var responseUrlCategorias = await _httpClient.GetAsync(urlCategorias);

            var urlProveedores = $"{_settings.BaseUrl}/{_settings.ProveedorGet}";
            var responseUrlProveedores = await _httpClient.GetAsync(urlProveedores);

            if (!response.IsSuccessStatusCode)
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al buscar producto: {errorMsg}");
                return View(listaProductos);
            }

            var json = await response.Content.ReadAsStringAsync();
            var producto = JsonConvert.DeserializeObject<ProductoDTO>(json);

            var jsonCategorias = await responseUrlCategorias.Content.ReadAsStringAsync();
            var jsonProveedores = await responseUrlProveedores.Content.ReadAsStringAsync();

            var categorias = JsonConvert.DeserializeObject<List<CategoriaDTO>>(jsonCategorias);
            var proveedores = JsonConvert.DeserializeObject<List<ProveedorDTO>>(jsonProveedores);


            ProductoEditarModel modelo = new ProductoEditarModel
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                PrecioProducto = producto.PrecioProducto,
                Stock = producto.Stock,
                ProveedorId = producto.ProveedorId,
                CategoriaId = producto.CategoriaId,
                Proveedores = proveedores,
                Categorias = categorias
            };
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> AccionModificarProducto([Bind("Id, Nombre, PrecioProducto, Stock, CategoriaId, ProveedorId")] ProductoDTO producto)
        {
            // Si ModelState no es válido, volver a la vista de edición con el modelo que espera la vista
            if (!ModelState.IsValid)
            {
                var categoriasJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.CategoriasGet}");
                var proveedoresJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.ProveedorGet}");

                var categorias = JsonConvert.DeserializeObject<List<CategoriaDTO>>(categoriasJson);
                var proveedores = JsonConvert.DeserializeObject<List<ProveedorDTO>>(proveedoresJson);

                var modelo = new ProductoEditarModel
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    PrecioProducto = producto.PrecioProducto,
                    Stock = producto.Stock,
                    CategoriaId = producto.CategoriaId,
                    ProveedorId = producto.ProveedorId,
                    Categorias = categorias,
                    Proveedores = proveedores
                };

                return View("modificarProducto", modelo);
            }

            var url = $"{_settings.BaseUrl}/{_settings.ProductoPut}/{producto.Id}";
            var jsonData = JsonConvert.SerializeObject(producto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);


            // si algo falla
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaProductos));

            // Si falla el PUT, agrego el error y vuelvo a cargar la vista de edición con las listas
            var errorMsg = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, $"Error al modificar: {errorMsg}");

            var categoriasJson2 = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.CategoriasGet}");
            var proveedoresJson2 = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.ProveedorGet}");

            var categorias2 = JsonConvert.DeserializeObject<List<CategoriaDTO>>(categoriasJson2);
            var proveedores2 = JsonConvert.DeserializeObject<List<ProveedorDTO>>(proveedoresJson2);

            var modelo2 = new ProductoEditarModel
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                PrecioProducto = producto.PrecioProducto,
                Stock = producto.Stock,
                CategoriaId = producto.CategoriaId,
                ProveedorId = producto.ProveedorId,
                Categorias = categorias2,
                Proveedores = proveedores2
            };

            return View("modificarProducto", modelo2);
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

        // DELETE: Eliminar producto
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
            return RedirectToAction(nameof(listaProductos));
        }
    }
}
