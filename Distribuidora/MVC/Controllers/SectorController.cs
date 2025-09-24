using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Models.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace MVC.Controllers
{
    public class SectorController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public SectorController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Sector
        public async Task<IActionResult> listaSectores()
        {
            var url = $"{_settings.BaseUrl}/{_settings.SectorGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_sectores = JsonConvert.DeserializeObject<List<SectorDTO>>(json);

            return View(lista_sectores);
        }

        // GET: Sector/Create
        public IActionResult crearSector()
        {
            return View();
        }

        // POST: Sector/Create
        [HttpPost]
        public async Task<IActionResult> crearSector([Bind("Id,Nombre,EstadoId")] SectorDTO sector)
        {
            if (!ModelState.IsValid)
            {
                return View(sector);
            }

            var url = $"{_settings.BaseUrl}/{_settings.SectorPost}";
            var jsonData = JsonConvert.SerializeObject(sector);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("listaSectores");
        }

        // GET: Sector/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.SectorDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error al eliminar el sector");

            // Volver a obtener la lista actualizada
            var url2 = $"{_settings.BaseUrl}/{_settings.SectorGet}";
            var response2 = await _httpClient.GetAsync(url2);

            if (!response2.IsSuccessStatusCode)
                return View("Error");

            var json = await response2.Content.ReadAsStringAsync();
            var lista_sectores = JsonConvert.DeserializeObject<List<SectorDTO>>(json);

            return View("listaSectores", lista_sectores);
        }

        //// PUT: Sector/Edit/5 (opcional)
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,EstadoId")] SectorDTO sector)
        //{
        //    if (id != sector.Id)
        //        return NotFound();
        //
        //    if (!ModelState.IsValid)
        //        return View(sector);
        //
        //    var url = $"{_settings.BaseUrl}/{_settings.SectorPut}/{id}";
        //    var jsonData = JsonConvert.SerializeObject(sector);
        //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //
        //    var response = await _httpClient.PutAsync(url, content);
        //
        //    if (!response.IsSuccessStatusCode)
        //        return View("Error");
        //
        //    return RedirectToAction("listaSectores");
        //}
    }
}
