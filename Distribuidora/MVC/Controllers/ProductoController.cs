using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models.Entities;

namespace MVC.Controllers
{
    public class ProductoController : Controller
    {
        //private readonly MVCContext _context;

        //public ProductoController(MVCContext context)
        //{
        //    _context = context;
        //}

        // GET: Producto
        public async Task<IActionResult> ProductoIndex()
        {
            return View();
        }

        //// GET: Producto/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var producto = await _context.Producto
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (producto == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(producto);
        //}

        //// GET: Producto/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Producto/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nombre,ProveedorId,CategoriaId,PrecioProducto")] Producto producto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(producto);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(producto);
        //}

        //// GET: Producto/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var producto = await _context.Producto.FindAsync(id);
        //    if (producto == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(producto);
        //}

        //// POST: Producto/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,ProveedorId,CategoriaId,PrecioProducto")] Producto producto)
        //{
        //    if (id != producto.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(producto);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductoExists(producto.Id))
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
        //    return View(producto);
        //}

        //// GET: Producto/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var producto = await _context.Producto
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (producto == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(producto);
        //}

        //// POST: Producto/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var producto = await _context.Producto.FindAsync(id);
        //    if (producto != null)
        //    {
        //        _context.Producto.Remove(producto);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProductoExists(int id)
        //{
        //    return _context.Producto.Any(e => e.Id == id);
        //}
    }
}
