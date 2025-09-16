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
                return View("Error");

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

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("listaEmpleados");
        }

        // DELETE: Empleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.EmpleadosDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            // Volver a traer la lista después de eliminar
            var url2 = $"{_settings.BaseUrl}/{_settings.EmpleadosGet}";
            var response2 = await _httpClient.GetAsync(url2);

            if (!response2.IsSuccessStatusCode)
                return View("Error");

            var json = await response2.Content.ReadAsStringAsync();
            var lista_empleados = JsonConvert.DeserializeObject<List<EmpleadoDTO>>(json);

            return View("listaEmpleados", lista_empleados);
        }

        //// PUT: Empleado/Edit/5
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,PersonaId,Foto,EstadoId")] EmpleadoDTO empleado)
        //{
        //    if (id != empleado.Id)
        //        return NotFound();
        //
        //    if (!ModelState.IsValid)
        //        return View(empleado);
        //
        //    var url = $"{_settings.BaseUrl}/{_settings.EmpleadosPut}/{id}";
        //    var jsonData = JsonConvert.SerializeObject(empleado);
        //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //
        //    var response = await _httpClient.PutAsync(url, content);
        //
        //    if (!response.IsSuccessStatusCode)
        //        return View("Error");
        //
        //    return RedirectToAction("listaEmpleados");
        //}
    }
}
