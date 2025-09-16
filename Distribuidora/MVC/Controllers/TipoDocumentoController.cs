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
    public class TipoDocumentoController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public TipoDocumentoController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: TipoDocumento
        public async Task<IActionResult> listaTipoDocumentos()
        {
            var url = $"{_settings.BaseUrl}/{_settings.TipoDocumentoGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_tipoDocumentos = JsonConvert.DeserializeObject<List<TipoDocumentoDTO>>(json);

            return View(lista_tipoDocumentos);
        }

        // GET: TipoDocumento/Create
        public IActionResult crearTipoDocumento()
        {
            return View();
        }

        // POST: TipoDocumento/Create
        [HttpPost]
        public async Task<IActionResult> crearTipoDocumento([Bind("Id,NombreTipoDocumento")] TipoDocumentoDTO tipoDocumento)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoDocumento);
            }

            var url = $"{_settings.BaseUrl}/{_settings.TipoDocumentoPost}";
            var jsonData = JsonConvert.SerializeObject(tipoDocumento);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            return RedirectToAction("listaTipoDocumentos");
        }

        // GET: TipoDocumento/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.TipoDocumentoDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error al eliminar el tipo de documento");

            // Volver a obtener la lista actualizada
            var url2 = $"{_settings.BaseUrl}/{_settings.TipoDocumentoGet}";
            var response2 = await _httpClient.GetAsync(url2);

            if (!response2.IsSuccessStatusCode)
                return View("Error");

            var json = await response2.Content.ReadAsStringAsync();
            var lista_tipoDocumentos = JsonConvert.DeserializeObject<List<TipoDocumentoDTO>>(json);

            return View("listaTipoDocumentos", lista_tipoDocumentos);
        }

        //// PUT: TipoDocumento/Edit/5 (opcional)
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,NombreTipoDocumento")] TipoDocumentoDTO tipoDocumento)
        //{
        //    if (id != tipoDocumento.Id)
        //        return NotFound();
        //
        //    if (!ModelState.IsValid)
        //        return View(tipoDocumento);
        //
        //    var url = $"{_settings.BaseUrl}/{_settings.TipoDocumentoPut}/{id}";
        //    var jsonData = JsonConvert.SerializeObject(tipoDocumento);
        //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //
        //    var response = await _httpClient.PutAsync(url, content);
        //
        //    if (!response.IsSuccessStatusCode)
        //        return View("Error");
        //
        //    return RedirectToAction("listaTipoDocumentos");
        //}
    }
}
