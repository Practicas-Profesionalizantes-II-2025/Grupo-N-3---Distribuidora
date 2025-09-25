using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Models.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace MVC.Controllers
{
    public class PersonaController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public PersonaController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Personas
        public async Task<IActionResult> listaPersonas()
        {
            var url = $"{_settings.BaseUrl}/{_settings.PersonaGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_personas = JsonConvert.DeserializeObject<List<PersonaDTO>>(json);

            // Obtener para mostrar nombres
            var ulrCiudades = $"{_settings.BaseUrl}/{_settings.CiudadesGet}";
            var urlDoc = $"{_settings.BaseUrl}/{_settings.TipoDocumentoGet}";
            var CiudadJson = await _httpClient.GetStringAsync(ulrCiudades);
            var DocJson = await _httpClient.GetStringAsync(urlDoc);

            var ciudad = JsonConvert.DeserializeObject<List<CiudadDTO>>(CiudadJson);
            var doc = JsonConvert.DeserializeObject<List<TipoDocumentoDTO>>(DocJson);

            var personasConDatos = lista_personas.Select(p => new PersonaDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                NombreCiudad = ciudad.FirstOrDefault(x => x.Id == p.CiudadId)?.Nombre ?? "N/A",
                Tipo_DocNombre = doc.FirstOrDefault(x => x.Id == p.Tipo_DocId)?.NombreTipoDocumento ?? "N/A",
                Email = p.Email,
                Direccion = p.Direccion,
                Telefono = p.Telefono,
                Estado = p.EstadoId == 1 ? "Activo" : "Inactivo"
            }).ToList();

            return View(personasConDatos);
        }

        // GET: Persona/Create
        public async Task<IActionResult> crearPersona()
        {
            var ulrCiudades = $"{_settings.BaseUrl}/{_settings.CiudadesGet}";
            var urlDoc = $"{_settings.BaseUrl}/{_settings.TipoDocumentoGet}";
            var CiudadJson = await _httpClient.GetStringAsync(ulrCiudades);
            var DocJson = await _httpClient.GetStringAsync(urlDoc);

            var ciudad = JsonConvert.DeserializeObject<List<CiudadDTO>>(CiudadJson);
            var doc = JsonConvert.DeserializeObject<List<TipoDocumentoDTO>>(DocJson);
            PersonaDTO model = new PersonaDTO
            {
                Ciudades = ciudad,
                TiposDocumentos = doc
            };
            return View(model);
        }

        // POST: Persona/Create
        [HttpPost]
        public async Task<IActionResult> crearPersona([Bind("Id,Nombre,Apellido,Tipo_DocId,Nro_Doc,CiudadId,Email,Direccion,Telefono,EstadoId")] PersonaDTO persona)
        {
            if (!ModelState.IsValid)
                return View(persona);

            var url = $"{_settings.BaseUrl}/{_settings.PersonaPost}";
            var jsonData = JsonConvert.SerializeObject(persona);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Error creando persona: {error}");
                return View(persona);
            }

            return RedirectToAction("listaPersonas");
        }

        // GET: Persona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.PersonaDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error al eliminar la persona");

            var url2 = $"{_settings.BaseUrl}/{_settings.PersonaGet}";
            var response2 = await _httpClient.GetAsync(url2);

            if (!response2.IsSuccessStatusCode)
                return View("Error");

            var json = await response2.Content.ReadAsStringAsync();
            var lista_personas = JsonConvert.DeserializeObject<List<PersonaDTO>>(json);

            return View("listaPersonas", lista_personas);
        }

        //// PUT: Persona/Edit/5 (opcional)
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Tipo_DocId,Nro_Doc,CiudadId,Email,Direccion,Telefono,EstadoId")] PersonaDTO persona)
        //{
        //    if (id != persona.Id)
        //        return NotFound();
        //
        //    if (!ModelState.IsValid)
        //        return View(persona);
        //
        //    var url = $"{_settings.BaseUrl}/{_settings.PersonaPut}/{id}";
        //    var jsonData = JsonConvert.SerializeObject(persona);
        //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //
        //    var response = await _httpClient.PutAsync(url, content);
        //
        //    if (!response.IsSuccessStatusCode)
        //        return View("Error");
        //
        //    return RedirectToAction("listaPersonas");
        //}
    }
}
