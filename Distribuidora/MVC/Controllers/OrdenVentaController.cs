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
            var urlOrdenes = $"{_settings.BaseUrl}/{_settings.OrdenVentaGet}";
            var responseOrdenes = await _httpClient.GetAsync(urlOrdenes);

            if (!responseOrdenes.IsSuccessStatusCode)
            {
                ViewBag.Error = await responseOrdenes.Content.ReadAsStringAsync();
                return View(new List<OrdenDeVentaDTO>());
            }

            var jsonOrdenes = await responseOrdenes.Content.ReadAsStringAsync();
            var listaOrdenes = JsonConvert.DeserializeObject<List<OrdenDeVentaDTO>>(jsonOrdenes);

            if (listaOrdenes == null || !listaOrdenes.Any())
                return View(new List<OrdenDeVentaDTO>());

            // Traer todos los empleados de la API
            var urlEmpleados = $"{_settings.BaseUrl}/Empleados";
            var jsonEmpleados = await _httpClient.GetStringAsync(urlEmpleados);
            var empleados = JsonConvert.DeserializeObject<List<EmpleadoDTO>>(jsonEmpleados);

            // Traer todos los clientes de la API
            var urlClientes = $"{_settings.BaseUrl}/Clientes";
            var jsonClientes = await _httpClient.GetStringAsync(urlClientes);
            var clientes = JsonConvert.DeserializeObject<List<ClienteDTO>>(jsonClientes);

            // Traer todos los distribuidores
            var urlDistribuidores = $"{_settings.BaseUrl}/Distribuidor";
            var jsonDistribuidores = await _httpClient.GetStringAsync(urlDistribuidores);
            var distribuidores = JsonConvert.DeserializeObject<List<DistribuidorDTO>>(jsonDistribuidores);

            foreach (var orden in listaOrdenes)
            {
                var empleado = empleados.FirstOrDefault(e => e.Id == orden.EmpleadoId);
                orden.NombreEmpleado = empleado != null? $"{empleado.Persona.Nombre} {empleado.Persona.Apellido}": $"Empleado {orden.EmpleadoId}";

                var cliente = clientes.FirstOrDefault(c => c.Id == orden.ClienteId);
                orden.ClienteNombre = cliente != null? $"{cliente.Persona.Nombre} {cliente.Persona.Apellido}": $"Cliente {orden.ClienteId}";

                var distribuidor = distribuidores.FirstOrDefault(d => d.Id == orden.DistribuidorId);
                orden.DistribuidorNombre = distribuidor != null? distribuidor.Nombre: $"Distribuidor {orden.DistribuidorId}";

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
                        DistribuidorNombre = orden.DistribuidorNombre,
                        ClienteId = orden.ClienteId,
                        ClienteNombre = orden.ClienteNombre,
                        EmpleadoId = orden.EmpleadoId,
                        EmpleadoNombre = orden.NombreEmpleado,
                    }).ToList();
                }
            }
            return View(listaOrdenes);
        }

        // GET: OrdenDeVenta/Create
        public async Task<IActionResult> crearOrdenVenta()
        {
            var empleadoId = HttpContext.Session.GetInt32("EmpleadoId");
            if (empleadoId == null || empleadoId == 0)
                return RedirectToAction("Login", "Empleados");

            var empleadoNombre = HttpContext.Session.GetString("EmpleadoNombre") ?? "Empleado";

            // Traer productos
            var urlProductos = $"{_settings.BaseUrl}/{_settings.ProductoGet}";
            var responseProductos = await _httpClient.GetAsync(urlProductos);
            if (!responseProductos.IsSuccessStatusCode)
            {
                ViewBag.Error = await responseProductos.Content.ReadAsStringAsync();
                return View(new OrdenDeVentaDTO());
            }
            var jsonProductos = await responseProductos.Content.ReadAsStringAsync();
            var productos = JsonConvert.DeserializeObject<List<ProductoDTO>>(jsonProductos,
                new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });

            // Traer clientes
            var urlClientes = $"{_settings.BaseUrl}/{_settings.ClientesGet}";
            var responseClientes = await _httpClient.GetAsync(urlClientes);
            List<SelectListItem> clientesList = new List<SelectListItem>();
            if (responseClientes.IsSuccessStatusCode)
            {
                var jsonClientes = await responseClientes.Content.ReadAsStringAsync();
                var clientes = JsonConvert.DeserializeObject<List<ClienteDTO>>(jsonClientes);

                clientesList = clientes.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.Persona.Nombre} {c.Persona.Apellido}"
                }).ToList();
            }

            // Traer distribuidores
            var urlDistribuidores = $"{_settings.BaseUrl}/{_settings.DistribuidorGet}";
            var responseDistribuidores = await _httpClient.GetAsync(urlDistribuidores);
            List<SelectListItem> distribuidoresList = new List<SelectListItem>();
            if (responseDistribuidores.IsSuccessStatusCode)
            {
                var jsonDistribuidores = await responseDistribuidores.Content.ReadAsStringAsync();
                var distribuidores = JsonConvert.DeserializeObject<List<DistribuidorDTO>>(jsonDistribuidores);

                distribuidoresList = distribuidores.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Nombre
                }).ToList();
            }

            // Pasar al ViewBag
            ViewBag.Clientes = clientesList;
            ViewBag.Distribuidores = distribuidoresList;

            // Armar modelo
            var model = new OrdenDeVentaDTO
            {
                EmpleadoId = empleadoId.Value,
                NombreEmpleado = empleadoNombre,
                Estado = "Pendiente",
                FechaOrden = DateTime.Now,
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
                await CargarListasParaVista();
                return View(orden);
            }

            orden.EmpleadoId = HttpContext.Session.GetInt32("EmpleadoId") ?? 0;

            if (orden.ProductosSeleccionados == null || !orden.ProductosSeleccionados.Any())
            {
                ModelState.AddModelError("", "Debe agregar al menos un producto a la orden.");
                await CargarListasParaVista();
                return View(orden);
            }

            var model = new
            {
                EmpleadoId = orden.EmpleadoId, // ahora seguro es el logueado
                DistribuidorId = orden.DistribuidorId,
                ClienteId = orden.ClienteId,
                FechaOrden = DateTime.Now,
                Estado = "Pendiente",
                ProductosSeleccionados = orden.ProductosSeleccionados.Select(p => new OrdenDeVentaProductoDTO
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

                try
                {
                    var apiError = JsonConvert.DeserializeObject<dynamic>(error);
                    string mensaje = apiError?.mensaje ?? error;
                    ModelState.AddModelError("", mensaje);
                }
                catch
                {
                    ModelState.AddModelError("", $"Error al crear la orden: {error}");
                }

                await CargarListasParaVista();
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
                FechaOrden = ordenApi.FechaOrden,
                EmpleadoId = ordenApi.EmpleadoId,
                NombreEmpleado = $"Empleado {ordenApi.EmpleadoId}",
                ClienteId = ordenApi.ClienteId,
                ClienteNombre = $"Cliente {ordenApi.ClienteId}",
                Estado = ordenApi.Estado,
                DistribuidorId = ordenApi.DistribuidorId,
                DistribuidorNombre = $"Distribuidor {ordenApi.DistribuidorId}",
                ProductosSeleccionados = ordenApi.ProductosSeleccionados.Select(p => new OrdenDeVentaProductoDTO
                {
                    ProductoId = p.ProductoId,
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

            var model = new
            {
                Id = orden.Id,
                FechaOrden = orden.FechaOrden,
                Estado = orden.Estado,
                EmpleadoId = orden.EmpleadoId,
                DistribuidorId = orden.DistribuidorId,
                ClienteId = orden.ClienteId,
                ProductosSeleccionados = orden.ProductosSeleccionados.Select(p => new
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
                Console.WriteLine(error);
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

            var urlEmpleados = $"{_settings.BaseUrl}/Empleados";
            var empleados = JsonConvert.DeserializeObject<List<EmpleadoDTO>>(
                await _httpClient.GetStringAsync(urlEmpleados));

            var urlClientes = $"{_settings.BaseUrl}/Clientes";
            var clientes = JsonConvert.DeserializeObject<List<ClienteDTO>>(
                await _httpClient.GetStringAsync(urlClientes));

            var urlDistribuidores = $"{_settings.BaseUrl}/Distribuidor";
            var distribuidores = JsonConvert.DeserializeObject<List<DistribuidorDTO>>(
                await _httpClient.GetStringAsync(urlDistribuidores));

            var urlProductos = $"{_settings.BaseUrl}/{_settings.ProductoGet}";
            var catalogoProductos = JsonConvert.DeserializeObject<List<ProductoDTOvista>>(
                await _httpClient.GetStringAsync(urlProductos));

            var empleado = empleados.FirstOrDefault(e => e.Id == content.EmpleadoId);
            var empleadoNombre = empleado != null? $"{empleado.Persona.Nombre} {empleado.Persona.Apellido}": $"Empleado {content.EmpleadoId}";

            var cliente = clientes.FirstOrDefault(c => c.Id == content.ClienteId);
            var clienteNombre = cliente != null? $"{cliente.Persona.Nombre} {cliente.Persona.Apellido}": $"Cliente {content.ClienteId}";

            var distribuidor = distribuidores.FirstOrDefault(d => d.Id == content.DistribuidorId);
            var distribuidorNombre = distribuidor != null? distribuidor.Nombre: $"Distribuidor {content.DistribuidorId}";

            var productosSeleccionados = content.ProductosSeleccionados.Select(p =>
            {
                var prodCatalogo = catalogoProductos.FirstOrDefault(x => x.Id == p.ProductoId);
                return new OrdenDeVentaProductoDTO
                {
                    Id = p.Id,
                    OrdenDeVentaId = p.OrdenDeVentaId,
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto,
                    NombreProducto = prodCatalogo?.Nombre ?? $"Producto {p.ProductoId}",
                    PrecioUnitario = prodCatalogo?.PrecioProducto ?? 0,
                    EmpleadoId = content.EmpleadoId,
                    EmpleadoNombre = empleadoNombre,
                    DistribuidorId = content.DistribuidorId,
                    DistribuidorNombre = distribuidorNombre,
                    ClienteId = content.ClienteId,
                    ClienteNombre = clienteNombre
                };
            }).ToList();

            var ordenParaVista = new OrdenDeVentaDTO
            {
                Id = content.Id,
                FechaOrden = content.FechaOrden,
                Estado = content.Estado,
                EmpleadoId = content.EmpleadoId,
                NombreEmpleado = empleadoNombre,
                DistribuidorId = content.DistribuidorId,
                DistribuidorNombre = distribuidorNombre,
                ClienteId = content.ClienteId,
                ClienteNombre = clienteNombre,
                ProductosSeleccionados = productosSeleccionados
            };

            return View(ordenParaVista);
        }



        private async Task CargarListasParaVista()
        {
            // Traer clientes
            var urlClientes = $"{_settings.BaseUrl}/{_settings.ClientesGet}";
            var responseClientes = await _httpClient.GetAsync(urlClientes);
            if (responseClientes.IsSuccessStatusCode)
            {
                var jsonClientes = await responseClientes.Content.ReadAsStringAsync();
                var clientes = JsonConvert.DeserializeObject<List<ClienteDTO>>(jsonClientes);

                ViewBag.Clientes = clientes.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.Persona.Nombre} {c.Persona.Apellido}"
                }).ToList();
            }

            // Traer distribuidores
            var urlDistribuidores = $"{_settings.BaseUrl}/{_settings.DistribuidorGet}";
            var responseDistribuidores = await _httpClient.GetAsync(urlDistribuidores);
            if (responseDistribuidores.IsSuccessStatusCode)
            {
                var jsonDistribuidores = await responseDistribuidores.Content.ReadAsStringAsync();
                var distribuidores = JsonConvert.DeserializeObject<List<DistribuidorDTO>>(jsonDistribuidores);

                ViewBag.Distribuidores = distribuidores.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Nombre
                }).ToList();
            }

            // Traer productos
            var urlProductos = $"{_settings.BaseUrl}/{_settings.ProductoGet}";
            var responseProductos = await _httpClient.GetAsync(urlProductos);
            if (responseProductos.IsSuccessStatusCode)
            {
                var jsonProductos = await responseProductos.Content.ReadAsStringAsync();
                var productos = JsonConvert.DeserializeObject<List<ProductoDTO>>(jsonProductos);

                ViewBag.Productos = productos;
            }
        }

    }
}
