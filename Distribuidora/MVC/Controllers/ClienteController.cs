using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Models.DTOs;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Text;
using Ciudad = MVC.Models.Entities.Ciudad;
using Estado = MVC.Models.Entities.Estado;

namespace MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public ClientesController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Clientes
        public async Task<IActionResult> listaClientes()
        {
            var url = $"{_settings.BaseUrl}/{_settings.ClientesGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new List<ClienteDTO>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var lista_clientes = JsonConvert.DeserializeObject<List<ClienteDTO>>(json);
            
            // Obtener proveedores y categorías para mostrar nombres
            var ulrCiudad = $"{_settings.BaseUrl}/{_settings.CiudadesGet}";
            var urlDoc = $"{_settings.BaseUrl}/{_settings.TipoDocumentoGet}";
            var CiudadJson = await _httpClient.GetStringAsync(ulrCiudad);
            var DocJson = await _httpClient.GetStringAsync(urlDoc);

            var Ciudad = JsonConvert.DeserializeObject<List<CiudadDTO>>(CiudadJson);
            var Doc = JsonConvert.DeserializeObject<List<TipoDocumentoDTO>>(DocJson);
            
            List<ClienteDTO> cliente = new List<ClienteDTO>();

            foreach (var p in lista_clientes)
            {
                p.Persona.NombreCiudad = Ciudad.FirstOrDefault(x => x.Id == p.Persona.CiudadId)?.Nombre ?? "N/A";
                p.Persona.Tipo_DocNombre = Doc.FirstOrDefault(x => x.Id == p.Persona.Tipo_DocId)?.NombreTipoDocumento ?? "N/A";

                // si querés que nunca sean null
                p.Persona.Ciudades = Ciudad;
                p.Persona.TiposDocumentos = Doc;

            }

            return View(lista_clientes);
        }

        // GET: Crear Cliente
        public async Task<IActionResult> crearCliente()
        {
            var ciudadesJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.CiudadesGet}");
            var ciudades = JsonConvert.DeserializeObject<List<CiudadDTO>>(ciudadesJson);

            // Obtener tipos de documentos desde la API
            var tiposDocJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.TipoDocumentoGet}");
            var tiposDoc = JsonConvert.DeserializeObject<List<TipoDocumentoDTO>>(tiposDocJson);

            var cliente = new ClienteDTO
            {
                Persona = new PersonaDTO
                {
                    Ciudades = ciudades,
                    TiposDocumentos = tiposDoc

                }
            };
            return View(cliente);
        }

        // POST: Crear Cliente
        [HttpPost]
        public async Task<IActionResult> crearCliente(ClienteDTO cliente)
        {
            try
            {
                if (cliente.Persona == null)
                    cliente.Persona = new PersonaDTO();

                // Cargar dropdowns siempre antes de validar ModelState
                var CiudadJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.CiudadesGet}");
                var DocJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.TipoDocumentoGet}");

                cliente.Persona.Ciudades = JsonConvert.DeserializeObject<List<CiudadDTO>>(CiudadJson);
                cliente.Persona.TiposDocumentos = JsonConvert.DeserializeObject<List<TipoDocumentoDTO>>(DocJson);

                // Forzamos estado de Persona en Alta
                cliente.Persona.EstadoId = 1;

                // Validación del ModelState
                if (!ModelState.IsValid)
                {
                    var errores = ModelState
                        .Where(ms => ms.Value.Errors.Count > 0)
                        .Select(ms => new {
                            Campo = ms.Key,
                            Errores = ms.Value.Errors.Select(e => e.ErrorMessage).ToList()
                        });

                    // Log o breakpoint para ver los errores
                    foreach (var error in errores)
                    {
                        Console.WriteLine($"Campo: {error.Campo}, Errores: {string.Join(", ", error.Errores)}");
                    }

                    return View(cliente);
                }

                // Serializamos y enviamos a la API
                var clienteJson = JsonConvert.SerializeObject(cliente);
                var clienteContent = new StringContent(clienteJson, Encoding.UTF8, "application/json");

                var clienteResponse = await _httpClient.PostAsync($"{_settings.BaseUrl}/{_settings.ClientesPost}", clienteContent);

                if (!clienteResponse.IsSuccessStatusCode)
                {
                    var error = await clienteResponse.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Error creando cliente: {error}");
                    return View(cliente);
                }

                return RedirectToAction(nameof(listaClientes));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocurrió un error: {ex.Message}");
                return View(cliente);
            }
        }


        // GET: Modificar cliente
        public async Task<IActionResult> modificarCliente(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.ClientesGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            var urlCiudad = $"{_settings.BaseUrl}/{_settings.CiudadesGet}";
            var responseUrlCiudad = await _httpClient.GetAsync(urlCiudad);

            var urlDocumentos = $"{_settings.BaseUrl}/{_settings.TipoDocumentoGet}";
            var responseUrlDocumentos = await _httpClient.GetAsync(urlDocumentos);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "No se pudo cargar el cliente");
                return RedirectToAction(nameof(listaClientes));
            }

            var json = await response.Content.ReadAsStringAsync();
            var clientes = JsonConvert.DeserializeObject<ClienteDTO>(json);

            var jsonCiudad = await responseUrlCiudad.Content.ReadAsStringAsync();
            var jsonDocumentos = await responseUrlDocumentos.Content.ReadAsStringAsync();

            var ciudades = JsonConvert.DeserializeObject<List<CiudadDTO>>(jsonCiudad);
            var Documentos = JsonConvert.DeserializeObject<List<TipoDocumentoDTO>>(jsonDocumentos);

            ClienteDTO modelo = new ClienteDTO
            {
                Id = clientes.Id,
                PersonaId = clientes.PersonaId,
                Persona = new PersonaDTO
                {
                    Id = clientes.Persona.Id,
                    Nombre = clientes.Persona.Nombre,
                    Apellido = clientes.Persona.Apellido,
                    Tipo_DocId = clientes.Persona.Tipo_DocId,
                    Nro_Doc = clientes.Persona.Nro_Doc,
                    CiudadId = clientes.Persona.CiudadId,
                    Email = clientes.Persona.Email,
                    Direccion = clientes.Persona.Direccion,
                    Telefono = clientes.Persona.Telefono,
                    EstadoId = clientes.Persona.EstadoId,
                    Ciudades = ciudades,
                    TiposDocumentos = Documentos
                },
            };
            return View(modelo);
        }

        // POST: Modificar cliente
        [HttpPost]
        public async Task<IActionResult> modificarCliente(ClienteDTO cliente)
        {

            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            try
            { 
                cliente.EstadoId = 1;
                cliente.Persona.EstadoId = 1;
                cliente.Persona.Tipo_DocId = cliente.Persona.Tipo_DocId == 0 ? 1 : cliente.Persona.Tipo_DocId;

                var personaJson = JsonConvert.SerializeObject(cliente.Persona);
                var personaContent = new StringContent(personaJson, Encoding.UTF8, "application/json");
                var personaResponse = await _httpClient.PutAsync(
                    $"{_settings.BaseUrl}/{_settings.PersonaPut}/{cliente.Persona.Id}",
                    personaContent
                );

                if (!personaResponse.IsSuccessStatusCode)
                {
                    var error = await personaResponse.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Error actualizando persona: {error}");
                    return View(cliente);
                }

                var clienteJson = JsonConvert.SerializeObject(cliente);
                var clienteContent = new StringContent(clienteJson, Encoding.UTF8, "application/json");
                var clienteResponse = await _httpClient.PutAsync(
                    $"{_settings.BaseUrl}/{_settings.ClientesPut}/{cliente.Id}",
                    clienteContent
                );

                if (!clienteResponse.IsSuccessStatusCode)
                {
                    var error = await clienteResponse.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Error actualizando cliente: {error}");
                    return View(cliente);
                }

                return RedirectToAction(nameof(listaClientes));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocurrió un error: {ex.Message}");
                return View(cliente);
            }
        }

        // DELETE: Cliente/Delete/5
        [HttpPost]
        public async Task<IActionResult> eliminarCliente(int? id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.ClientesDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaClientes));

            ModelState.AddModelError(string.Empty, await response.Content.ReadAsStringAsync());

            var listaJson = await _httpClient.GetStringAsync($"{_settings.BaseUrl}/{_settings.ClientesGet}");
            var cliente = JsonConvert.DeserializeObject<List<ClienteDTO>>(listaJson);
            return View("listaClientes", cliente);
        }
    }
}