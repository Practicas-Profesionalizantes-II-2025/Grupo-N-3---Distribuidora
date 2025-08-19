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
    public class SectorController : Controller
    {
        //private readonly MVCContext _context;

        //public SectorController(MVCContext context)
        //{
        //    _context = context;
        //}

        // GET: Sector
        public async Task<IActionResult> SectorIndex()
        {
            return View();
        }

        //// GET: Sector/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var sector = await _context.Sector
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (sector == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(sector);
        //}

        //// GET: Sector/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Sector/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nombre,EstadoId")] Sector sector)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(sector);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(sector);
        //}

        //// GET: Sector/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var sector = await _context.Sector.FindAsync(id);
        //    if (sector == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(sector);
        //}

        //// POST: Sector/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,EstadoId")] Sector sector)
        //{
        //    if (id != sector.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(sector);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SectorExists(sector.Id))
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
        //    return View(sector);
        //}

        //// GET: Sector/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var sector = await _context.Sector
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (sector == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(sector);
        //}

        //// POST: Sector/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var sector = await _context.Sector.FindAsync(id);
        //    if (sector != null)
        //    {
        //        _context.Sector.Remove(sector);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SectorExists(int id)
        //{
        //    return _context.Sector.Any(e => e.Id == id);
        //}
    }
}
