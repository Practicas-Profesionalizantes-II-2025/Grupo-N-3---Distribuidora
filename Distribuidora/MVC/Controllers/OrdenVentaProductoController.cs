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
    public class OrdenVentaProductoController : Controller
    {
        //private readonly MVCContext _context;

        //public OrdenVentaProductoController(MVCContext context)
        //{
        //    _context = context;
        //}

        // GET: OrdenVentaProducto
        public async Task<IActionResult> PagPrincipOrdenVentaProd()
        {
            return View();
        }

        //// GET: OrdenVentaProducto/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ordenDeVentaProducto = await _context.OrdenDeVentaProducto
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ordenDeVentaProducto == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ordenDeVentaProducto);
        //}

        //// GET: OrdenVentaProducto/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: OrdenVentaProducto/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,OrdenVentaId,ProductoId,CantidadProducto")] OrdenDeVentaProducto ordenDeVentaProducto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(ordenDeVentaProducto);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(ordenDeVentaProducto);
        //}

        //// GET: OrdenVentaProducto/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ordenDeVentaProducto = await _context.OrdenDeVentaProducto.FindAsync(id);
        //    if (ordenDeVentaProducto == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(ordenDeVentaProducto);
        //}

        //// POST: OrdenVentaProducto/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,OrdenVentaId,ProductoId,CantidadProducto")] OrdenDeVentaProducto ordenDeVentaProducto)
        //{
        //    if (id != ordenDeVentaProducto.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(ordenDeVentaProducto);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OrdenDeVentaProductoExists(ordenDeVentaProducto.Id))
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
        //    return View(ordenDeVentaProducto);
        //}

        //// GET: OrdenVentaProducto/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ordenDeVentaProducto = await _context.OrdenDeVentaProducto
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ordenDeVentaProducto == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ordenDeVentaProducto);
        //}

        //// POST: OrdenVentaProducto/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var ordenDeVentaProducto = await _context.OrdenDeVentaProducto.FindAsync(id);
        //    if (ordenDeVentaProducto != null)
        //    {
        //        _context.OrdenDeVentaProducto.Remove(ordenDeVentaProducto);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool OrdenDeVentaProductoExists(int id)
        //{
        //    return _context.OrdenDeVentaProducto.Any(e => e.Id == id);
        //}
    }
}
