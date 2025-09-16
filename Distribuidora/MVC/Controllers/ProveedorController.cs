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
    public class ProveedorController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public ProveedorController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Proveedor
        public async Task<IActionResult> listaProveedores()
        {
            var url = $"{_settings.BaseUrl}/{_settings.ProveedorGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_proveedores = JsonConvert.DeserializeObject<List<ProveedorDTO>>(json);

            return View(lista_proveedores);
        }

        // GET: Proveedor/Create
        public IActionResult crearProveedor()
        {
            return View();
        }

        // POST: Proveedor/Create
        [HttpPost]
        public async Task<IActionResult> crearProveedor([Bind("Id,Nombre,Direccion,Telefono,Email")] ProveedorDTO proveedor)
        {
            if (!ModelState.IsValid)
            {
                return View(proveedor);
            }

            var url = $"{_settings.BaseUrl}/{_settings.ProveedorPost}";
            var jsonData = JsonConvert.SerializeObject(proveedor);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            // Redirigir a la lista de proveedores después de guardar
            return RedirectToAction("listaProveedores");
        }

        // GET: Proveedor/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.ProveedorDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error al eliminar el proveedor");

            // Volver a obtener la lista actualizada
            var url2 = $"{_settings.BaseUrl}/{_settings.ProveedorGet}";
            var response2 = await _httpClient.GetAsync(url2);

            if (!response2.IsSuccessStatusCode)
                return View("Error");

            var json = await response2.Content.ReadAsStringAsync();
            var lista_proveedores = JsonConvert.DeserializeObject<List<ProveedorDTO>>(json);

            return View("listaProveedores", lista_proveedores);
        }

        //// PUT: Proveedor/Edit/5 (opcional)
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,Telefono,Email")] ProveedorDTO proveedor)
        //{
        //    if (id != proveedor.Id)
        //        return NotFound();
        //
        //    if (!ModelState.IsValid)
        //        return View(proveedor);
        //
        //    var url = $"{_settings.BaseUrl}/{_settings.ProveedorPut}/{id}";
        //    var jsonData = JsonConvert.SerializeObject(proveedor);
        //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //
        //    var response = await _httpClient.PutAsync(url, content);
        //
        //    if (!response.IsSuccessStatusCode)
        //        return View("Error");
        //
        //    return RedirectToAction("listaProveedores");
        //}
    }
}
