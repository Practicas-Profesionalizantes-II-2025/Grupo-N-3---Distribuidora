using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Models.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace MVC.Controllers
{
    public class OrdenVentaController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public OrdenVentaController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: OrdenDeVentas
        public async Task<IActionResult> listaOrdenVentas()
        {
            var url = $"{_settings.BaseUrl}/{_settings.OrdenVentaGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new List<OrdenDeVentaDTO>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var listaApi = JsonConvert.DeserializeObject<List<OrdenDeVentaDTO>>(json);

            if (listaApi == null || !listaApi.Any())
                return View(new List<OrdenDeVentaDTO>());

            foreach (var orden in listaApi)
            {
                // Obtener el empleado de forma individual para esta orden
                var empleadoResponse = await _httpClient.GetAsync($"{_settings.BaseUrl}/Empleados/{orden.EmpleadoId}");
                if (empleadoResponse.IsSuccessStatusCode)
                {
                    var empleado = await empleadoResponse.Content.ReadFromJsonAsync<EmpleadoDTO>();
                    orden.NombreEmpleado = empleado != null
                        ? $"{empleado.Persona.Nombre} {empleado.Persona.Apellido}"
                        : $"Empleado {orden.EmpleadoId}";
                }
                else
                {
                    orden.NombreEmpleado = $"Empleado {orden.EmpleadoId}";
                }
                orden.DistribuidorNombre = $"Distribuidor {orden.DistribuidorId}";

                // Mapear productos si no hay detalles
                if (orden.ProductosSeleccionados == null || !orden.ProductosSeleccionados.Any())
                {
                    orden.ProductosSeleccionados = orden.Productos.Select(p => new OrdenDeVentaProductoDTO
                    {
                        ProductoId = p.Id,
                        NombreProducto = p.Nombre,
                        PrecioUnitario = p.PrecioProducto,
                        CantidadProducto = 0,
                        DistribuidorId = orden.DistribuidorId,
                        DistribuidorNombre = orden.DistribuidorNombre
                    }).ToList();
                }
            }

            return View(listaApi);
        }

        // GET: OrdenDeVenta/Create
        public async Task<IActionResult> crearOrdenVenta()
        {
            var empleadoId = HttpContext.Session.GetInt32("EmpleadoId");
            if (empleadoId == null || empleadoId == 0)
                return RedirectToAction("Login", "Empleados");

            var empleadoNombre = HttpContext.Session.GetString("EmpleadoNombre") ?? "Empleado";

            var url = $"{_settings.BaseUrl}/{_settings.ProductoGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new OrdenDeVentaDTO());
            }

            var json = await response.Content.ReadAsStringAsync();
            var productos = JsonConvert.DeserializeObject<List<ProductoDTO>>(json,
            new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });


            var model = new OrdenDeVentaDTO
            {
                EmpleadoId = empleadoId.Value,
                NombreEmpleado = empleadoNombre,
                DistribuidorId = 1,
                DistribuidorNombre = "Distribuidor 4",
                ClienteId = 1,
                ClienteNombre = "Cliente 1",
                Estado = "Pendiente",
                Fecha = DateTime.Now,
                Productos = productos
            };

            return View(model);
        }

        // POST: OrdenDeVenta/Create
        [HttpPost]
        public async Task<IActionResult> crearOrdenVenta(OrdenDeVentaDTO orden)
        {
            if (orden.ProductosSeleccionados == null || !orden.ProductosSeleccionados.Any())
            {
                ModelState.AddModelError("", "Debe agregar al menos un producto a la orden.");
                return View(orden);
            }

            orden.EmpleadoId = HttpContext.Session.GetInt32("EmpleadoId") ?? 0;

            if (orden.ProductosSeleccionados == null || !orden.ProductosSeleccionados.Any())
            {
                ModelState.AddModelError("", "Debe agregar al menos un producto a la orden.");
                return View(orden);
            }

            var model = new
            {
                EmpleadoId = orden.EmpleadoId, // ahora seguro es el logueado
                DistribuidorId = orden.DistribuidorId,
                ClienteId = orden.ClienteId,
                Fecha = DateTime.Now,
                Estado = "Pendiente",
                Productos = orden.ProductosSeleccionados.Select(p => new
                {
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto
                }).ToList()
            };

            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var url = $"{_settings.BaseUrl}/{_settings.OrdenVentaPost}";
            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", $"Error al crear la orden: {error}");
                return View(orden);
            }

            return RedirectToAction(nameof(listaOrdenVentas));
        }
        // GET: OrdenDeVenta/Edit/5
        public async Task<IActionResult> modificarOrdenventa(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.OrdenVentaGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaOrdenVentas));

            var json = await response.Content.ReadAsStringAsync();
            var ordenApi = JsonConvert.DeserializeObject<OrdenDeVentaDTO>(json);

            var ordenMvc = new OrdenDeVentaDTO
            {
                Id = ordenApi.Id,
                Fecha = ordenApi.Fecha,
                EmpleadoId = ordenApi.EmpleadoId,
                Estado = ordenApi.Estado,
                NombreEmpleado = $"Empleado {ordenApi.EmpleadoId}",
                DistribuidorId = ordenApi.DistribuidorId,
                DistribuidorNombre = $"Proveedor {ordenApi.DistribuidorId}",
                ProductosSeleccionados = ordenApi.ProductosSeleccionados.Select(p => new OrdenDeVentaProductoDTO
                {
                    ProductoId = p.Id,
                    NombreProducto = p.NombreProducto,
                    PrecioUnitario = p.PrecioUnitario,
                    CantidadProducto = p.CantidadProducto,
                }).ToList()
            };

            // Aquí definimos el ViewBag por separado
            ViewBag.Estados = new SelectList(
                new List<string> { "Pendiente", "Realizado", "Entregado" },
                ordenApi.Estado // valor seleccionado
            );

            return View(ordenMvc);
        }
        // POST: OrdenDeVenta/Edit/5
        [HttpPost]
        public async Task<IActionResult> modificarOrdenventa(int id, OrdenDeVentaDTO orden)
        {
            if (id != orden.Id)
                return NotFound();

            if (orden.ProductosSeleccionados == null || !orden.ProductosSeleccionados.Any())
            {
                ModelState.AddModelError("", "Debe agregar al menos un producto a la orden.");
                return View(orden);
            }

            // Mapear al objeto que la API espera
            var model = new
            {
                Id = orden.Id,
                Fecha = orden.Fecha,
                Estado = orden.Estado,
                EmpleadoId = orden.EmpleadoId,
                DistribuidorId = orden.DistribuidorId,
                Productos = orden.ProductosSeleccionados.Select(p => new
                {
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto,
                    PrecioUnitario = p.PrecioUnitario
                }).ToList()
            };

            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var url = $"{_settings.BaseUrl}/{_settings.OrdenVentaPut}/{id}";
            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", $"Error actualizando la orden: {error}");
                return View(orden);
            }

            return RedirectToAction(nameof(listaOrdenVentas));
        }

        // DELETE: OrdenDeVenta/Delete/5
        public async Task<IActionResult> eliminarOrdenventa(int? id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.OrdenVentaDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(listaOrdenVentas));
            }
            return RedirectToAction(nameof(listaOrdenVentas));
        }

        // GET: OrdenDeVenta/Detalle/5
        public async Task<IActionResult> detalleOrdenVenta(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.OrdenVentaGet}/{id}";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaOrdenVentas));

            var json = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<DetalleOrdenVentaDTO>(json);
            if (content == null)
                return RedirectToAction(nameof(listaOrdenVentas));

            var urlProductos = $"{_settings.BaseUrl}/{_settings.ProductoGet}";
            var responseProductos = await _httpClient.GetAsync(urlProductos);
            var jsonProductos = await responseProductos.Content.ReadAsStringAsync();
            var catalogoProductos = JsonConvert.DeserializeObject<List<ProductoDTOvista>>(jsonProductos);

            var productosSeleccionados = content.Productos.Select(p =>
            {
                var prodCatalogo = catalogoProductos.FirstOrDefault(x => x.Id == p.ProductoId);
                return new MVC.Models.DTOs.OrdenDeVentaProductoDTO
                {   Id = p.Id,
                    OrdenVentaId = p.OrdenVentaId,
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto,
                    DistribuidorId = content.DistribuidorId,
                    DistribuidorNombre = $"Distribuidor {content.DistribuidorId}",
                    NombreProducto = prodCatalogo != null ? prodCatalogo.Nombre : $"Producto {p.ProductoId}",
                    PrecioUnitario = prodCatalogo != null ? prodCatalogo.PrecioProducto : 0
                };
            }).ToList();

            var ordenParaVista = new OrdenDeVentaDTO
            {
                Id = content.Id,
                Fecha = content.Fecha,
                Estado = content.Estado,
                EmpleadoId = content.EmpleadoId,
                NombreEmpleado = $"Empleado {content.EmpleadoId}",
                DistribuidorId = content.DistribuidorId,
                DistribuidorNombre = $"Distribuidor {content.DistribuidorId}",
                ProductosSeleccionados = productosSeleccionados
            };

            return View(ordenParaVista);
        }
    }
}
