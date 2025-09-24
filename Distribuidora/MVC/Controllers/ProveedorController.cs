using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Models.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace MVC.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public ProveedorController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Proveedor/Lista
        public async Task<IActionResult> listaProveedores()
        {
            var url = $"{_settings.BaseUrl}/{_settings.ProveedorGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                // Podés pasar una lista vacía o un ViewBag con el error
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new List<ProveedorDTO>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista_proveedores = JsonConvert.DeserializeObject<List<ProveedorDTO>>(json);

            return View(lista_proveedores);
        }

        // GET: Proveedor/Crear
        public IActionResult crearProveedor()
        {
            return View();
        }

        // POST: Proveedor/Crear
        [HttpPost]
        public async Task<IActionResult> CrearProveedor([Bind("Id,Nombre,Telefono,Email,Direccion")] ProveedorDTO proveedor)
        {
            if (!ModelState.IsValid)
                return View(proveedor);

            var url = $"{_settings.BaseUrl}/{_settings.ProveedorPost}";
            var jsonData = JsonConvert.SerializeObject(proveedor);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaProveedores));

            ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());
            return RedirectToAction("listaProveedores");
        }
/*        // GET: Proveedores/EliminarProveedor
        [HttpGet]
        public async Task<IActionResult> eliminarProveedor()
        {
            var url = $"{_settings.BaseUrl}/{_settings.ProveedorGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var listaProveedores = JsonConvert.DeserializeObject<List<ProveedorDTO>>(json);

            return View(listaProveedores); 
        }*/

        // POST:Proveedores/EliminarProveedor
        [HttpPost]
        public async Task<IActionResult> eliminarProveedor(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.ProveedorDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaProveedores));

            ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());

            var listaJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.ProveedorGet}");
            var proveedor = JsonConvert.DeserializeObject<List<ProveedorDTO>>(listaJson);
            return View("listaProveedores", proveedor);
        }
        // GET: Modificar Proveedor
        [HttpGet]
        public async Task<IActionResult> modificarProveedor(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.ProveedorGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al buscar proveedor: {errorMsg}");
                return View(listaProveedores);
            }

            var json = await response.Content.ReadAsStringAsync();
            var proveedor = JsonConvert.DeserializeObject<ProveedorDTO>(json);

            return View(proveedor);
        }
        // PUT: Proveedor/Edit/5
        [HttpPost]
        public async Task<IActionResult> modificarProveedor(int id, [Bind("Id,Nombre,Telefono,Email,Direccion")] ProveedorDTO proveedor)
        {
            if (id != proveedor.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(proveedor);

            var url = $"{_settings.BaseUrl}/{_settings.ProveedorPut}/{id}";
            var jsonData = JsonConvert.SerializeObject(proveedor);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al modificar proveedor: {errorMsg}");
                return View(proveedor);
            }

            return RedirectToAction("listaProveedores");
        }
    }
}
