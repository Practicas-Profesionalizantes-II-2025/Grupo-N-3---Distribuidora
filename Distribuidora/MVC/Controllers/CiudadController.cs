using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
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
    public class CiudadController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public CiudadController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Ciudad
        public async Task<IActionResult> listaCiudades()
        {
            var url = $"{_settings.BaseUrl}/{_settings.CiudadesGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_ciudades = JsonConvert.DeserializeObject<List<CiudadDTO>>(json);

            return View(lista_ciudades);
        }

        // GET: Ciudad/Create
        public IActionResult crearCiudad()
        {
            return View();
        }

        // POST: Ciudad/Create
        [HttpPost]
        public async Task<IActionResult> crearCiudad([Bind("Id,Nombre,Cp,Acp")] CiudadDTO ciudad)
        {
            if (!ModelState.IsValid)
            {
                return View(ciudad);
            }

            var url = $"{_settings.BaseUrl}/{_settings.CiudadesPost}";
            var jsonData = JsonConvert.SerializeObject(ciudad);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            return RedirectToAction("listaCiudades");
        }

        // GET: Ciudad/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.CiudadesDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error al eliminar la ciudad");

            // Volver a obtener la lista actualizada
            var url2 = $"{_settings.BaseUrl}/{_settings.CiudadesGet}";
            var response2 = await _httpClient.GetAsync(url2);

            if (!response2.IsSuccessStatusCode)
                return View("Error");

            var json = await response2.Content.ReadAsStringAsync();
            var lista_ciudades = JsonConvert.DeserializeObject<List<CiudadDTO>>(json);

            return View("listaCiudades", lista_ciudades);
        }

        //// PUT: Ciudad/Edit/5 (opcional)
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Cp,Acp")] CiudadDTO ciudad)
        //{
        //    if (id != ciudad.Id)
        //        return NotFound();
        //
        //    if (!ModelState.IsValid)
        //        return View(ciudad);
        //
        //    var url = $"{_settings.BaseUrl}/{_settings.CiudadPut}/{id}";
        //    var jsonData = JsonConvert.SerializeObject(ciudad);
        //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //
        //    var response = await _httpClient.PutAsync(url, content);
        //
        //    if (!response.IsSuccessStatusCode)
        //        return View("Error");
        //
        //    return RedirectToAction("listaCiudades");
        //}
    }
}
