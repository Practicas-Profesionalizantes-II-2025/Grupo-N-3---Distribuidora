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
using System.Text;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public EmpleadosController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Empleados
        public async Task<IActionResult> listaEmpleados()
        {
            var url = $"{_settings.BaseUrl}/{_settings.EmpleadosGet}";
            var response = await _httpClient.GetAsync(url);


            if (!response.IsSuccessStatusCode)
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al buscar emokeadi: {errorMsg}");
                return View(listaEmpleados);
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista_empleados = JsonConvert.DeserializeObject<List<EmpleadoDTO>>(json);

            return View(lista_empleados);
        }

        // GET: Crear Empleado
        public IActionResult crearEmpleado()
        {
            return View();
        }

        // POST: Crear Empleado
        [HttpPost]
        public async Task<IActionResult> crearEmpleado([Bind("Id,PersonaId,Foto,EstadoId")] EmpleadoDTO empleado)
        {
            if (!ModelState.IsValid)
                return View(empleado);

            var url = $"{_settings.BaseUrl}/{_settings.EmpleadosPost}";
            var jsonData = JsonConvert.SerializeObject(empleado);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaEmpleados));

            ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());
            return RedirectToAction("listaEmpleados");
        }

        // DELETE: Empleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.EmpleadosDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaEmpleados));

            ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());

            var listaJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.EmpleadosGet}");
            var empleado = JsonConvert.DeserializeObject<List<EmpleadoDTO>>(listaJson);
            return View("listaEmpleado", empleado);
        }

        // GET: Modificar cliente
        public async Task<IActionResult> modificarEmpleado(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.EmpleadosGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al buscar empleado: {errorMsg}");
                return View(listaEmpleados);
            }

            var json = await response.Content.ReadAsStringAsync();
            var empleado = JsonConvert.DeserializeObject<EmpleadoDTO>(json);

            return View(empleado);
        }
        /*
        // POST: Modificar cliente
        [HttpPost]
        public async Task<IActionResult> modificarCliente(int id, ClienteDTO cliente)
        {
            if (id != cliente.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(cliente);

            var url = $"{_settings.BaseUrl}/{_settings.ClientesPut}/{id}";
            var jsonData = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error al modificar cliente: {errorMsg}");
                return View(cliente);
            }

            return RedirectToAction("listaClientes");
        }*/
        
    }
}
