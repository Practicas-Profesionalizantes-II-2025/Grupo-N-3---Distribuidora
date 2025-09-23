using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Models.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class DistribuidorController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public DistribuidorController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Distribuidor/Lista
        public async Task<IActionResult> listaDistribuidores()
        {
            var url = $"{_settings.BaseUrl}/{_settings.DistribuidorGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new List<DistribuidorDTO>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista_distribuidores = JsonConvert.DeserializeObject<List<DistribuidorDTO>>(json);

            return View(lista_distribuidores);
        }

        // GET: Distribuidor/Crear
        public IActionResult crearDistribuidor()
        {
            return View();
        }

        // POST: Distribuidor/Crear
        [HttpPost]
        public async Task<IActionResult> crearDistribuidor([Bind("Id,Nombre,CuilCuit,Telefono,Direccion,CiudadId")] DistribuidorDTO distribuidor)
        {
            if (!ModelState.IsValid)
                return View(distribuidor);

            var url = $"{_settings.BaseUrl}/{_settings.DistribuidorPost}";
            var jsonData = JsonConvert.SerializeObject(distribuidor);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaDistribuidores));

            ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());
            return RedirectToAction("listaDistribuidores");
        }

        // POST: Distribuidor/Eliminar
        [HttpPost]
        public async Task<IActionResult> eliminarDistribuidor(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.DistribuidorDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaDistribuidores));

            ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());

            var listaJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.DistribuidorGet}");
            var distribuidores = JsonConvert.DeserializeObject<List<DistribuidorDTO>>(listaJson);
            return View("listaDistribuidores", distribuidores);
        }

        // GET: Distribuidor/Modificar
        [HttpGet]
        public async Task<IActionResult> modificarDistribuidor(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.DistribuidorGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al buscar distribuidor: {errorMsg}");
                return RedirectToAction(nameof(listaDistribuidores));
            }

            var json = await response.Content.ReadAsStringAsync();
            var distribuidor = JsonConvert.DeserializeObject<DistribuidorDTO>(json);

            return View(distribuidor);
        }

        // PUT: Distribuidor/Modificar
        [HttpPost]
        public async Task<IActionResult> modificarDistribuidor(int id, [Bind("Id,Nombre,CuilCuit,Telefono,Direccion,Ciudad,Provincia,CodigoPostal")] DistribuidorDTO distribuidor)
        {
            if (id != distribuidor.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(distribuidor);

            var url = $"{_settings.BaseUrl}/{_settings.DistribuidorPut}/{id}";
            var jsonData = JsonConvert.SerializeObject(distribuidor);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al modificar distribuidor: {errorMsg}");
                return View(distribuidor);
            }

            return RedirectToAction(nameof(listaDistribuidores));
        }
    }
}
