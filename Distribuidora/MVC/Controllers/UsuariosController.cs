using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Models.Entities;
using Newtonsoft.Json;
using System.Text;

namespace MVC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public UsuariosController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Usuario
        public async Task<IActionResult> Login()
        {
            var url = $"{_settings.BaseUrl}/{_settings.UsuarioGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);

            return View(lista_usuarios);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Contrasenia,PersonaId,Activo")] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return View(usuario);

            var url = $"{_settings.BaseUrl}/{_settings.UsuarioPost}";
            var jsonData = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Login(string Usuario, string Contrasenia)
        {
            // 🔹 Acá validás usuario y contraseña
            if (Usuario == "admin" && Contrasenia == "1234") // ejemplo
            {
                // Redirige a la página de inicio
                return RedirectToAction("PaginaInicial", "Usuarios");
                // o a otra acción/vista que quieras
            }

            // Si falla, devolvés el mismo login con error
            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }

        public IActionResult PaginaInicial()
        {
            return View();
        }



        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.UsuarioGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var usuario = JsonConvert.DeserializeObject<Usuario>(json);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        // PUT: Usuario/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Contrasenia,PersonaId,Activo")] Usuario usuario)
        {
            if (id != usuario.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(usuario);

            var url = $"{_settings.BaseUrl}/{_settings.UsuarioPut}/{id}";
            var jsonData = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }

        // DELETE: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var url = $"{_settings.BaseUrl}/{_settings.UsuarioDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction("Index");
        }
    }
}
