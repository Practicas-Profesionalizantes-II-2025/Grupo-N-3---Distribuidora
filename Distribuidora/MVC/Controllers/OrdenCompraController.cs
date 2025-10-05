using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Models.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace MVC.Controllers
{
    public class OrdenCompraController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public OrdenCompraController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: OrdenDeCompra
        public async Task<IActionResult> listaOrdenCompras()
        {
            var url = $"{_settings.BaseUrl}/{_settings.OrdenCompraGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new List<OrdenDeCompraDTO>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var listaApi = JsonConvert.DeserializeObject<List<OrdenDeCompraDTO>>(json);

            var listaMvc = listaApi.Select(o => new OrdenDeCompraDTO
            {
                Id = o.Id,
                FechaOrden = o.FechaOrden,
                EmpleadoId = o.EmpleadoId,
                NombreEmpleado = $"Empleado {o.EmpleadoId}",
                ProveedorId = o.ProveedorId,
                ProveedorNombre = $"Proveedor {o.ProveedorId}",
                ProductosSeleccionados = o.ProductosSeleccionados,
            }).ToList();

            return View(listaMvc);
        }

        // GET: Crear OrdenDeCompra
        public async Task<IActionResult> crearOrdenCompra()
        {
            var url = $"{_settings.BaseUrl}/{_settings.ProductoGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new OrdenDeCompraDTO());
            }

            var json = await response.Content.ReadAsStringAsync();
            var productos = JsonConvert.DeserializeObject<List<ProductoDTO>>(json,
            new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });


            var model = new OrdenDeCompraDTO
            {
                EmpleadoId = 1, // Cambiarlo por el empleado que inicie sesion
                ProveedorId = 1,
                ProveedorNombre = "Proveedor 4",
                NombreEmpleado = "Juan Pérez",
                Estado = "Pendiente",
                FechaOrden = DateTime.Now,
                Productos = productos
            };

            return View(model);
        }

        // POST: Crear OrdenDeCompra
        [HttpPost]
        public async Task<IActionResult> crearOrdenCompra(OrdenDeCompraDTO orden)
        {
            if (orden.ProductosSeleccionados == null || !orden.ProductosSeleccionados.Any())
            {
                ModelState.AddModelError("", "Debe agregar al menos un producto a la orden.");
                return View(orden);
            }

            // Mapear al objeto que la API espera
            var model = new
            {
                EmpleadoId = orden.EmpleadoId,
                ProveedorId = orden.ProveedorId,
                FechaOrden = DateTime.Now,
                Productos = orden.ProductosSeleccionados.Select(p => new
                {
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto
                }).ToList()
            };

            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var url = $"{_settings.BaseUrl}/{_settings.OrdenCompraPost}";
            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", $"Error al crear la orden: {error}");
                return View(orden);
            }

            return RedirectToAction(nameof(listaOrdenCompras));
        }


        // GET: OrdenDeCompra/Edit/5
        public async Task<IActionResult> modificarOrdenCompra(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.OrdenCompraGet}/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaOrdenCompras));

            var json = await response.Content.ReadAsStringAsync();
            var ordenApi = JsonConvert.DeserializeObject<Shared.DTOs.OrdenDeCompraDTO>(json);

            var ordenMvc = new OrdenDeCompraDTO
            {
                Id = ordenApi.Id,
                FechaOrden = ordenApi.FechaOrden,
                EmpleadoId = ordenApi.EmpleadoId,
                Estado = ordenApi.Estado,
                NombreEmpleado = $"Empleado {ordenApi.EmpleadoId}",
                ProveedorId = ordenApi.ProveedorId,
                ProveedorNombre = $"Proveedor {ordenApi.ProveedorId}",
                ProductosSeleccionados = ordenApi.Productos.Select(p => new OrdenDeCompraProductoDTO
                {
                    ProductoId = p.ProductoId,
                    NombreProducto = p.NombreProducto,
                    PrecioUnitario = p.PrecioUnitario,
                    CantidadProducto = p.CantidadProducto
                }).ToList()
            };

            // Aquí definimos el ViewBag por separado
            ViewBag.Estados = new SelectList(
                new List<string> { "Pendiente", "Realizado", "Entregado" },
                ordenApi.Estado // valor seleccionado
            );

            return View(ordenMvc);
        }


        // POST: OrdenDeCompra/Edit/5
        [HttpPost]
        public async Task<IActionResult> modificarOrdenCompra(int id, OrdenDeCompraDTO orden)
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
                FechaOrden = orden.FechaOrden,
                Estado = orden.Estado,
                EmpleadoId = orden.EmpleadoId,
                ProveedorId = orden.ProveedorId,
                Productos = orden.ProductosSeleccionados.Select(p => new
                {
                    ProductoId = p.ProductoId,
                    CantidadProducto = p.CantidadProducto,
                    PrecioUnitario = p.PrecioUnitario
                }).ToList()
            };

            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var url = $"{_settings.BaseUrl}/{_settings.OrdenCompraPut}/{id}";
            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", $"Error actualizando la orden: {error}");
                return View(orden);
            }

            return RedirectToAction(nameof(listaOrdenCompras));
        }
        
        // DELETE: OrdenDeCompra/Delete/5
        public async Task<IActionResult> eliminarOrdenCompra(int? id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.OrdenCompraDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(listaOrdenCompras));
            }
            return RedirectToAction(nameof(listaOrdenCompras));
        }

        // GET: OrdenDeCompra/Detalle/5
        public async Task<IActionResult> detalleOrdenCompra(int id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.OrdenCompraGet}/{id}";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return RedirectToAction(nameof(listaOrdenCompras));

            var json = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<DetalleOrdenCompraDTO>(json);
            if (content == null)
                return RedirectToAction(nameof(listaOrdenCompras));

            var urlProductos = $"{_settings.BaseUrl}/{_settings.ProductoGet}";
            var responseProductos = await _httpClient.GetAsync(urlProductos);
            var jsonProductos = await responseProductos.Content.ReadAsStringAsync();
            var catalogoProductos = JsonConvert.DeserializeObject<List<ProductoDTOvista>>(jsonProductos);

            var productosSeleccionados = content.Productos.Select(p =>
            {
                var prodCatalogo = catalogoProductos.FirstOrDefault(x => x.Id == p.ProductoId);
                return new OrdenDeCompraProductoDTO
                {
                    Id = p.Id,
                    OrdenDeCompraId = p.OrdenDeCompraId,
                    ProductoId = p.ProductoId,
                    NombreProducto = p.NombreProducto,
                    CantidadProducto = p.CantidadProducto,
                    PrecioUnitario = p.PrecioUnitario,
                    ProveedorNombre = prodCatalogo?.ProveedorNombre ?? $"Proveedor {prodCatalogo?.ProveedorId ?? 0}"
                };
            }).ToList();

            var ordenParaVista = new OrdenDeCompraDTO
            {
                Id = content.Id,
                FechaOrden = content.FechaOrden,
                Estado = content.Estado,
                EmpleadoId = content.EmpleadoId,
                NombreEmpleado = $"Empleado {content.EmpleadoId}",
                ProveedorId = content.ProveedorId,
                ProveedorNombre = $"Proveedor {content.ProveedorId}",
                ProductosSeleccionados = productosSeleccionados
            };

            return View(ordenParaVista);
        }
    }
}
