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
    public class TipoDocumentoController : Controller
    {
        //private readonly MVCContext _context;

        //public TipoDocumentoController(MVCContext context)
        //{
        //    _context = context;
        //}

        // GET: TipoDocumento
        public async Task<IActionResult> TipoDocIndex()
        {
            return View();
        }

        //// GET: TipoDocumento/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tipoDocumento = await _context.TipoDocumento
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (tipoDocumento == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tipoDocumento);
        //}

        //// GET: TipoDocumento/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TipoDocumento/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,NombreTipoDocumento")] TipoDocumento tipoDocumento)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(tipoDocumento);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tipoDocumento);
        //}

        //// GET: TipoDocumento/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tipoDocumento = await _context.TipoDocumento.FindAsync(id);
        //    if (tipoDocumento == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(tipoDocumento);
        //}

        //// POST: TipoDocumento/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,NombreTipoDocumento")] TipoDocumento tipoDocumento)
        //{
        //    if (id != tipoDocumento.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(tipoDocumento);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TipoDocumentoExists(tipoDocumento.Id))
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
        //    return View(tipoDocumento);
        //}

        //// GET: TipoDocumento/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tipoDocumento = await _context.TipoDocumento
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (tipoDocumento == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tipoDocumento);
        //}

        //// POST: TipoDocumento/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var tipoDocumento = await _context.TipoDocumento.FindAsync(id);
        //    if (tipoDocumento != null)
        //    {
        //        _context.TipoDocumento.Remove(tipoDocumento);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool TipoDocumentoExists(int id)
        //{
        //    return _context.TipoDocumento.Any(e => e.Id == id);
        //}
    }
}
