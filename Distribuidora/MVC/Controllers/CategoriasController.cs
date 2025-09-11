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
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public CategoriasController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Categorias
        public async Task<IActionResult> listaCategorias()
        {
            var url = $"{_settings.BaseUrl}/{_settings.CategoriasGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_categorias = JsonConvert.DeserializeObject<List<CategoriaDTO>>(json);

            return View(lista_categorias);
        }

        // POST: Categorias
        public IActionResult crearCategoria()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> crearCategoria([Bind("Id,Nombre")] CategoriaDTO categoria)
        {
            if (!ModelState.IsValid)
            {
                return View(categoria);
            }

            var url = $"{_settings.BaseUrl}/{_settings.CategoriasPost}";
            var jsonData = JsonConvert.SerializeObject(categoria);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            // Redirigir a la lista de categorías después de guardar
            return RedirectToAction("listaCategorias");
        }

        //// GET: Categorias/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.CategoriasDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error al eliminar la categoria");

            var url2 = $"{_settings.BaseUrl}/{_settings.CategoriasGet}";
            var response2 = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_categorias = JsonConvert.DeserializeObject<List<CategoriaDTO>>(json);

            return View("listaCategorias", lista_categorias);
        }

        //// PUT: Categorias/Edit/5
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] CategoriaDTO categoria)
        //{
        //    if (id != categoria.Id)
        //        return NotFound();

        //    if (!ModelState.IsValid)
        //        return View(categoria);

        //    var url = $"{_settings.BaseUrl}/{_settings.CategoriasPut}/{id}";
        //    var jsonData = JsonConvert.SerializeObject(categoria);
        //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        //    var response = await _httpClient.PutAsync(url, content);

        //    if (!response.IsSuccessStatusCode)
        //        return View("Error");

        //    return RedirectToAction("listaCategorias");
        //}
    }
}
