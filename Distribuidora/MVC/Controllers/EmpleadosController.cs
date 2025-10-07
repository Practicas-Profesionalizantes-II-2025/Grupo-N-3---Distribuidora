using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Models.DTOs;
using Newtonsoft.Json;
using System.Text;
using EmpleadoDTO = MVC.Models.DTOs.EmpleadoDTO;
using PersonaDTO = MVC.Models.DTOs.PersonaDTO;

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
        // Loggin

        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> LoginAccion(DatosInicioSesionDTO datos)
        {
            // Construir la URL del endpoint
            string urlValidacion = $"{_settings.BaseUrl}/{_settings.ValidacionEmpleado}/{datos.dni}/{datos.Contrasenia}";
            var response = await _httpClient.GetAsync(urlValidacion);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Error al conectar con el servidor.";
                return View("Login");
            }

            bool confirmacionLoggin = await response.Content.ReadFromJsonAsync<bool>();

            if (!confirmacionLoggin)
            {
                ViewBag.Error = "DNI o contraseña incorrectos.";
                return View("Login");
            }

            string empleadoUrl = $"{_settings.BaseUrl.TrimEnd('/')}/Empleados/dni/{datos.dni}";
            Console.WriteLine(empleadoUrl); // o Debug.WriteLine
            var empleadoResponse = await _httpClient.GetAsync(empleadoUrl);

            if (!empleadoResponse.IsSuccessStatusCode)
            {
                ViewBag.Error = $"No se pudo obtener el empleado desde la API. Status: {empleadoResponse.StatusCode}";
                return View("Login");
            }

            var empleado = await empleadoResponse.Content.ReadFromJsonAsync<EmpleadoDTO>();

            if (empleado == null)
            {
                ViewBag.Error = "Empleado no encontrado";
                return View("Login");
            }

            HttpContext.Session.SetInt32("EmpleadoId", empleado.Id);
            HttpContext.Session.SetString("EmpleadoNombre", $"{empleado.Persona.Nombre ?? "Sin nombre"} {empleado.Persona.Apellido ?? ""}");

            return RedirectToAction("PaginaInicial", "PaginaInicial");
        }

        // GET: Empleados
        public async Task<IActionResult> listaEmpleados()
        {
            var url = $"{_settings.BaseUrl}/{_settings.EmpleadosGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new List<EmpleadoDTO>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista_empleados = JsonConvert.DeserializeObject<List<EmpleadoDTO>>(json);
            
            // Obtener proveedores y categorías para mostrar nombres
            var ulrCiudad = $"{_settings.BaseUrl}/{_settings.CiudadesGet}";
            var urlDoc = $"{_settings.BaseUrl}/{_settings.TipoDocumentoGet}";
            var CiudadJson = await _httpClient.GetStringAsync(ulrCiudad);
            var DocJson = await _httpClient.GetStringAsync(urlDoc);

            var Ciudad = JsonConvert.DeserializeObject<List<CiudadDTO>>(CiudadJson);
            var Doc = JsonConvert.DeserializeObject<List<TipoDocumentoDTO>>(DocJson);

            List<EmpleadoDTO> empleado = new List<EmpleadoDTO>();

            foreach (var p in lista_empleados)
            {
                p.Persona.NombreCiudad = Ciudad.FirstOrDefault(x => x.Id == p.Persona.CiudadId)?.Nombre ?? "N/A";
                p.Persona.Tipo_DocNombre = Doc.FirstOrDefault(x => x.Id == p.Persona.Tipo_DocId)?.NombreTipoDocumento ?? "N/A";

                p.Persona.Ciudades = Ciudad;
                p.Persona.TiposDocumentos = Doc;

            }

            return View(lista_empleados);
        }

        // GET: Crear Empleado
        public async Task<IActionResult> crearEmpleado()
        {
            var ciudadesJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.CiudadesGet}");
            var ciudades = JsonConvert.DeserializeObject<List<CiudadDTO>>(ciudadesJson);

            var tiposDocJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.TipoDocumentoGet}");
            var tiposDoc = JsonConvert.DeserializeObject<List<TipoDocumentoDTO>>(tiposDocJson);

            EmpleadoVista_CargarEmpleadoDTO empleadoVista_CargarEmpleado = new EmpleadoVista_CargarEmpleadoDTO
            {
                ciudades = ciudades,
                tiposDocumentos = tiposDoc,
                empleado = new EmpleadoDTO
                {
                    Persona = new PersonaDTO()
                }
            };
            return View(empleadoVista_CargarEmpleado);
        }

        // POST: Crear Empleado
        [HttpPost]
        public async Task<IActionResult> crearEmpleado(EmpleadoVista_CargarEmpleadoDTO modelo)
        {
            try
            {
                var empleado = modelo.empleado;

                // Forzar estado
                empleado.EstadoId = 1;

                // Validación: contraseñas iguales
                if (empleado.Contrasenia != empleado.ContraseniaConfimarcion)
                {
                    ModelState.AddModelError("empleado.ContraseniaConfimarcion", "Las contraseñas no coinciden.");

                    // Recargar selects para que no se pierdan al volver a la vista
                    var ciudadesJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.CiudadesGet}");
                    var tiposDocJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.TipoDocumentoGet}");

                    modelo.ciudades = JsonConvert.DeserializeObject<List<CiudadDTO>>(ciudadesJson);
                    modelo.tiposDocumentos = JsonConvert.DeserializeObject<List<TipoDocumentoDTO>>(tiposDocJson);

                    return View(modelo);
                }
                if (!ModelState.IsValid)
                {
                    var ciudadesJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.CiudadesGet}");
                    var tiposDocJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.TipoDocumentoGet}");

                    modelo.ciudades = JsonConvert.DeserializeObject<List<CiudadDTO>>(ciudadesJson);
                    modelo.tiposDocumentos = JsonConvert.DeserializeObject<List<TipoDocumentoDTO>>(tiposDocJson);

                    return View(modelo);
                }

                var jsonData = JsonConvert.SerializeObject(empleado);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{_settings.BaseUrl}/{_settings.EmpleadosPost}", content);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Error creando empleado: {error}");
                    return View(modelo);
                }

                return RedirectToAction(nameof(listaEmpleados));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocurrió un error: {ex.Message}");
                return View(modelo);
            }
        }
        //public async Task<IActionResult> crearEmpleado(EmpleadoDTO empleado)
        //{
        //    try
        //    {
        //        // Aseguramos que Persona no sea null
        //        if (empleado.Persona == null)
        //        {
        //            empleado.Persona = new PersonaDTO();
        //        }
        //        var CiudadJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.CiudadesGet}");
        //        var DocJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.TipoDocumentoGet}");

        //        empleado.Persona.Ciudades = JsonConvert.DeserializeObject<List<CiudadDTO>>(CiudadJson);
        //        empleado.Persona.TiposDocumentos = JsonConvert.DeserializeObject<List<TipoDocumentoDTO>>(DocJson);

        //        // Forzamos estado de Persona en Alta
        //        empleado.Persona.EstadoId = 1;
        //        empleado.EstadoId = 1;
        //        if (!ModelState.IsValid)
        //        {
        //            return View(empleado);
        //        }
        //        var JsonData = JsonConvert.SerializeObject(empleado);
        //        var Content = new StringContent(JsonData, Encoding.UTF8, "application/json");
        //        var Response = await _httpClient.PostAsync($"{_settings.BaseUrl}/{_settings.EmpleadosPost}", Content);

        //        if (!Response.IsSuccessStatusCode)
        //        {
        //            var error = await Response.Content.ReadAsStringAsync();
        //            ModelState.AddModelError(string.Empty, $"Error creando empleado: {error}");
        //            return View(empleado);
        //        }

        //        return RedirectToAction(nameof(listaEmpleados));
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, $"Ocurrió un error: {ex.Message}");
        //        return View(empleado);
        //    }
        //}

        // GET: Modificar empleado
        public async Task<IActionResult> modificarEmpleado(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.EmpleadosGet}/{id}";
            var response = await _httpClient.GetAsync(url);
           
            var urlCiudad = $"{_settings.BaseUrl}/{_settings.CiudadesGet}";
            var responseUrlCiudad = await _httpClient.GetAsync(urlCiudad);

            var urlDocumentos = $"{_settings.BaseUrl}/{_settings.TipoDocumentoGet}";
            var responseUrlDocumentos = await _httpClient.GetAsync(urlDocumentos);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "No se pudo cargar el empleado");
                return RedirectToAction(nameof(listaEmpleados));
            }
            ModelState.Remove("Foto");
            var json = await response.Content.ReadAsStringAsync();
            var empleados = JsonConvert.DeserializeObject<EmpleadoDTO>(json);
            
            var jsonCiudad = await responseUrlCiudad.Content.ReadAsStringAsync();
            var jsonDocumentos = await responseUrlDocumentos.Content.ReadAsStringAsync();

            var ciudades = JsonConvert.DeserializeObject<List<CiudadDTO>>(jsonCiudad);
            var Documentos = JsonConvert.DeserializeObject<List<TipoDocumentoDTO>>(jsonDocumentos);

            EmpleadoDTO model = new EmpleadoDTO
            {
                Id = empleados.Id,
                PersonaId = empleados.PersonaId,
                Persona = new PersonaDTO
                {
                    Id = empleados.Persona.Id,
                    Nombre = empleados.Persona.Nombre,
                    Apellido = empleados.Persona.Apellido,
                    Tipo_DocId = empleados.Persona.Tipo_DocId,
                    Nro_Doc = empleados.Persona.Nro_Doc,
                    CiudadId = empleados.Persona.CiudadId,
                    Email = empleados.Persona.Email,
                    Direccion = empleados.Persona.Direccion,
                    Telefono = empleados.Persona.Telefono,
                    EstadoId = empleados.Persona.EstadoId,
                    Ciudades = ciudades,
                    TiposDocumentos = Documentos
                },
            };
            return View(model);
        }

        // POST: Modificar empleado
        [HttpPost]
        public async Task<IActionResult> modificarEmpleado(EmpleadoDTO empleado)
        {
            if (!ModelState.IsValid)
                return View(empleado);

            try
            {
                empleado.EstadoId = 1;
                empleado.Persona.EstadoId = 1;
                empleado.Persona.Tipo_DocId = empleado.Persona.Tipo_DocId == 0 ? 1 : empleado.Persona.Tipo_DocId;

                var personaJson = JsonConvert.SerializeObject(empleado.Persona);
                var personaContent = new StringContent(personaJson, Encoding.UTF8, "application/json");
                var personaResponse = await _httpClient.PutAsync($"{_settings.BaseUrl}/{_settings.PersonaPut}/{empleado.Persona.Id}",personaContent);

                if (!personaResponse.IsSuccessStatusCode)
                {
                    var error = await personaResponse.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Error actualizando persona: {error}");
                    return View(empleado);
                }

                var JsonData = JsonConvert.SerializeObject(empleado);
                var Content = new StringContent(JsonData, Encoding.UTF8, "application/json");
                var Response = await _httpClient.PutAsync($"{_settings.BaseUrl}/{_settings.EmpleadosPut}/{empleado.Id}",Content);

                if (!Response.IsSuccessStatusCode)
                {
                    var error = await Response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Error actualizando empleado: {error}");
                    return View(empleado);
                }

                return RedirectToAction(nameof(listaEmpleados));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocurrió un error: {ex.Message}");
                return View(empleado);
            }
        }

        // DELETE: Empleado/Delete/5
        [HttpPost]
        public async Task<IActionResult> eliminarEmpleado(int? id)
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


    }
}
