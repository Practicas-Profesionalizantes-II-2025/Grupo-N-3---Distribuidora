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

        public ProveedorController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        // GET: Proveedor/Lista
        public async Task<IActionResult> listaProveedores()
        {
            var proveedores = await _httpClient.GetFromJsonAsync<List<ProveedorDTO>>("Proveedor");
            return View(proveedores);
        }

        // GET: Proveedor/Crear
        public IActionResult CrearProveedor() => View();

        // POST: Proveedor/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearProveedor(ProveedorDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _httpClient.PostAsJsonAsync("Proveedor", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaProveedores));

            ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
            return View(dto);
        }

        // GET: Proveedor/Editar/5
        public async Task<IActionResult> EditarProveedor(int id)
        {
            var proveedor = await _httpClient.GetFromJsonAsync<ProveedorDTO>($"Proveedor/{id}");
            if (proveedor == null) return NotFound();
            return View(proveedor);
        }

        // POST: Proveedor/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarProveedor(int id, ProveedorDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _httpClient.PutAsJsonAsync($"Proveedor/{id}", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaProveedores));

            ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
            return View(dto);
        }

        // GET: Proveedor/Eliminar/5
        public async Task<IActionResult> EliminarProveedor(int id)
        {
            var proveedor = await _httpClient.GetFromJsonAsync<ProveedorDTO>($"Proveedor/{id}");
            if (proveedor == null) return NotFound();
            return View(proveedor);
        }

        // POST: Proveedor/Eliminar/5
        [HttpPost, ActionName("EliminarProveedor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            await _httpClient.DeleteAsync($"Proveedor/{id}");
            return RedirectToAction(nameof(listaProveedores));
        }
    }
}
