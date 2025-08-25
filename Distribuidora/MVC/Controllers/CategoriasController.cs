using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC.ConfigAPI;
using MVC.Data;
using MVC.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MVC.Models.DTOs;

namespace MVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _settings;

        public CategoriasController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> settings)
        {
            _httpClient = httpClientFactory.CreateClient("API");
            _settings = settings.Value;
        }

        // GET: Categorias
        public async Task<IActionResult> listaCategorias()
        {
            var url = $"{_settings.BaseUrl}/{_settings.CategoriasGet}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_categorias = JsonConvert.DeserializeObject<List<CategoriaDTO>>(json);

            return View(lista_categorias);
        }

        //// GET: Categorias/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var categoria = await _context.Categoria
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (categoria == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(categoria);
        //}

        //// GET: Categorias/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Categorias/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nombre,EstadoId")] Categoria categoria)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(categoria);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(categoria);
        //}

        //// GET: Categorias/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var categoria = await _context.Categoria.FindAsync(id);
        //    if (categoria == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(categoria);
        //}

        //// POST: Categorias/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,EstadoId")] Categoria categoria)
        //{
        //    if (id != categoria.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(categoria);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CategoriaExists(categoria.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(categoria);
        //}

        //// GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var url = $"{_settings.BaseUrl}/{_settings.CategoriasDelete}/{id}";
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error al eliminar la categoria");

            var url2 = $"{_settings.BaseUrl}/{_settings.CategoriasGet}";
            var response2 = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var lista_categorias = JsonConvert.DeserializeObject<List<CategoriaDTO>>(json);

            return View("listaCategorias", lista_categorias);

        }

        //// POST: Categorias/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var categoria = await _context.Categoria.FindAsync(id);
        //    if (categoria != null)
        //    {
        //        _context.Categoria.Remove(categoria);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CategoriaExists(int id)
        //{
        //    return _context.Categoria.Any(e => e.Id == id);
        //}
    }
}
