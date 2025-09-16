using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Data;
using MVC.Models.DTOs;
using MVC.Models.Entities;
using Newtonsoft.Json;
using Shared.Entities;
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
            {
                // Podés pasar una lista vacía o un ViewBag con el error
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new List<CategoriaDTO>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista_categorias = JsonConvert.DeserializeObject<List<CategoriaDTO>>(json);

            return View(lista_categorias);
        }

        // POST: Categorias
        public IActionResult crearCategoria()
        {
            return View();
        }
        // POST: Categorias
        [HttpPost]
        public async Task<IActionResult> crearCategoria([Bind("Id,Nombre")] CategoriaDTO categoria)
        {
            if (!ModelState.IsValid)
                return View(categoria);

            var url = $"{_settings.BaseUrl}/{_settings.CategoriasPost}";
            var jsonData = JsonConvert.SerializeObject(categoria);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaCategorias));

            ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());
            return RedirectToAction("listaCategorias");
        }

        // GET: Categorias/EliminarCategoria
        [HttpGet]
        public async Task<IActionResult> eliminarCategoria()
        {
            var url = $"{_settings.BaseUrl}/{_settings.CategoriasGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_categorias = JsonConvert.DeserializeObject<List<CategoriaDTO>>(json);

            return View(lista_categorias); // muestra la vista con el select
        }

        // POST: Categorias/EliminarCategoria
        [HttpPost]
        public async Task<IActionResult> eliminarCategoria(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.CategoriasDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaCategorias));

            ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());

            var listaJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.CategoriasGet}");
            var categoria = JsonConvert.DeserializeObject<List<CategoriaDTO>>(listaJson);
            return View("listaCategorias", categoria);
        }

        // GET: Modificar categoria
        [HttpPost]
        public async Task<IActionResult> modificarCategoria(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.CategoriasGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al buscar categoria: {errorMsg}");
                return View(listaCategorias);
            }

            var json = await response.Content.ReadAsStringAsync();
            var categoria = JsonConvert.DeserializeObject<CategoriaDTO>(json);

            return View(categoria);
        }
        // PUT: Categorias/Edit/5
        [HttpPost]
        public async Task<IActionResult> modificarCategoria(int id, [Bind("Id,Nombre")] CategoriaDTO categoria)
        {
            if (id != categoria.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(categoria);

            var url = $"{_settings.BaseUrl}/{_settings.CategoriasPut}/{id}";
            var jsonData = JsonConvert.SerializeObject(categoria);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al modificar categoria: {errorMsg}");
                return View(categoria);
            }

            return RedirectToAction("listaCategorias");
        }
    }
}
