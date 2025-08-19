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
    public class OrdenVentaController : Controller
    {
        //private readonly MVCContext _context;

        //public OrdenVentaController(MVCContext context)
        //{
        //    _context = context;
        //}

        // GET: OrdenVenta
        public async Task<IActionResult> PagPrincOrdenVenta()
        {
            return View();
        }

        //// GET: OrdenVenta/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ordenDeVenta = await _context.OrdenDeVenta
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ordenDeVenta == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ordenDeVenta);
        //}

        //// GET: OrdenVenta/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: OrdenVenta/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Fecha,FacturaId,EmpleadoId,ClienteId,DistribuidorId,EstadoId")] OrdenDeVenta ordenDeVenta)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(ordenDeVenta);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(ordenDeVenta);
        //}

        //// GET: OrdenVenta/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ordenDeVenta = await _context.OrdenDeVenta.FindAsync(id);
        //    if (ordenDeVenta == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(ordenDeVenta);
        //}

        //// POST: OrdenVenta/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,FacturaId,EmpleadoId,ClienteId,DistribuidorId,EstadoId")] OrdenDeVenta ordenDeVenta)
        //{
        //    if (id != ordenDeVenta.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(ordenDeVenta);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OrdenDeVentaExists(ordenDeVenta.Id))
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
        //    return View(ordenDeVenta);
        //}

        //// GET: OrdenVenta/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ordenDeVenta = await _context.OrdenDeVenta
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ordenDeVenta == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ordenDeVenta);
        //}

        //// POST: OrdenVenta/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var ordenDeVenta = await _context.OrdenDeVenta.FindAsync(id);
        //    if (ordenDeVenta != null)
        //    {
        //        _context.OrdenDeVenta.Remove(ordenDeVenta);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool OrdenDeVentaExists(int id)
        //{
        //    return _context.OrdenDeVenta.Any(e => e.Id == id);
        //}
    }
}
