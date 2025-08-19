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
    public class OrdenCompraController : Controller
    {
        //private readonly MVCContext _context;

        //public OrdenCompraController(MVCContext context)
        //{
        //    _context = context;
        //}

        // GET: OrdenCompra
        public async Task<IActionResult> IndexCompra()
        {
            return View();
        }

        //// GET: OrdenCompra/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ordenDeCompra = await _context.OrdenDeCompra
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ordenDeCompra == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ordenDeCompra);
        //}

        //// GET: OrdenCompra/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: OrdenCompra/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,EmpleadoId,DistribuidorId,FechaOrden")] OrdenDeCompra ordenDeCompra)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(ordenDeCompra);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(ordenDeCompra);
        //}

        //// GET: OrdenCompra/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ordenDeCompra = await _context.OrdenDeCompra.FindAsync(id);
        //    if (ordenDeCompra == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(ordenDeCompra);
        //}

        //// POST: OrdenCompra/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,EmpleadoId,DistribuidorId,FechaOrden")] OrdenDeCompra ordenDeCompra)
        //{
        //    if (id != ordenDeCompra.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(ordenDeCompra);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OrdenDeCompraExists(ordenDeCompra.Id))
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
        //    return View(ordenDeCompra);
        //}

        //// GET: OrdenCompra/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ordenDeCompra = await _context.OrdenDeCompra
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ordenDeCompra == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ordenDeCompra);
        //}

        //// POST: OrdenCompra/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var ordenDeCompra = await _context.OrdenDeCompra.FindAsync(id);
        //    if (ordenDeCompra != null)
        //    {
        //        _context.OrdenDeCompra.Remove(ordenDeCompra);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool OrdenDeCompraExists(int id)
        //{
        //    return _context.OrdenDeCompra.Any(e => e.Id == id);
        //}
    }
}
