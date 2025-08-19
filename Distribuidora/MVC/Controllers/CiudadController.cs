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
    public class CiudadController : Controller
    {
        //private readonly MVCContext _context;

        //public Ciudads1Controller(MVCContext context)
        //{
        //    _context = context;
        //}

        // GET: Ciudads1
        public async Task<IActionResult> Index()
        {
            return View();
        }

        //// GET: Ciudads1/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ciudad = await _context.Ciudad
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ciudad == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ciudad);
        //}

        //// GET: Ciudads1/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Ciudads1/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nombre,Cp,Acp")] Ciudad ciudad)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(ciudad);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(ciudad);
        //}

        //// GET: Ciudads1/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ciudad = await _context.Ciudad.FindAsync(id);
        //    if (ciudad == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(ciudad);
        //}

        //// POST: Ciudads1/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Cp,Acp")] Ciudad ciudad)
        //{
        //    if (id != ciudad.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(ciudad);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CiudadExists(ciudad.Id))
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
        //    return View(ciudad);
        //}

        //// GET: Ciudads1/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ciudad = await _context.Ciudad
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ciudad == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ciudad);
        //}

        //// POST: Ciudads1/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var ciudad = await _context.Ciudad.FindAsync(id);
        //    if (ciudad != null)
        //    {
        //        _context.Ciudad.Remove(ciudad);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CiudadExists(int id)
        //{
        //    return _context.Ciudad.Any(e => e.Id == id);
        //}
    }
}
