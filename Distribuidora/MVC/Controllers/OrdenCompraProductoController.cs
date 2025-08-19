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
    public class OrdenCompraProductoController : Controller
    {
        private readonly MVCContext _context;

        //public OrdenCompraProductoController(MVCContext context)
        //{
        //    _context = context;
        //}

        // GET: OrdenCompraProducto
        public async Task<IActionResult> PagPrincipalCompraProd()
        {
            return View();
        }

        //// GET: OrdenCompraProducto/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ordenDeCompraProducto = await _context.OrdenDeCompraProducto
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ordenDeCompraProducto == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ordenDeCompraProducto);
        //}

        //// GET: OrdenCompraProducto/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: OrdenCompraProducto/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,OrdenDeCompraId,ProductoId,CantidadProducto")] OrdenDeCompraProducto ordenDeCompraProducto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(ordenDeCompraProducto);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(ordenDeCompraProducto);
        //}

        //// GET: OrdenCompraProducto/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ordenDeCompraProducto = await _context.OrdenDeCompraProducto.FindAsync(id);
        //    if (ordenDeCompraProducto == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(ordenDeCompraProducto);
        //}

        //// POST: OrdenCompraProducto/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,OrdenDeCompraId,ProductoId,CantidadProducto")] OrdenDeCompraProducto ordenDeCompraProducto)
        //{
        //    if (id != ordenDeCompraProducto.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(ordenDeCompraProducto);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OrdenDeCompraProductoExists(ordenDeCompraProducto.Id))
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
        //    return View(ordenDeCompraProducto);
        //}

        //// GET: OrdenCompraProducto/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ordenDeCompraProducto = await _context.OrdenDeCompraProducto
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ordenDeCompraProducto == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ordenDeCompraProducto);
        //}

        //// POST: OrdenCompraProducto/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var ordenDeCompraProducto = await _context.OrdenDeCompraProducto.FindAsync(id);
        //    if (ordenDeCompraProducto != null)
        //    {
        //        _context.OrdenDeCompraProducto.Remove(ordenDeCompraProducto);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool OrdenDeCompraProductoExists(int id)
        //{
        //    return _context.OrdenDeCompraProducto.Any(e => e.Id == id);
        //}
    }
}
