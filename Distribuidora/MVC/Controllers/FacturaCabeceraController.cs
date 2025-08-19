using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models.DTOs;

namespace MVC.Controllers
{
    public class FacturaCabeceraController : Controller
    {
        //private readonly MVCContext _context;

        //public FacturaCabeceraController(MVCContext context)
        //{
        //    _context = context;
        //}

        // GET: FacturaCabecera
        public async Task<IActionResult> Index()
        {
            return View();
        }

        //// GET: FacturaCabecera/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var facturaCabeceraDTO = await _context.FacturaCabeceraDTO
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (facturaCabeceraDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(facturaCabeceraDTO);
        //}

        //// GET: FacturaCabecera/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: FacturaCabecera/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id")] FacturaCabeceraDTO facturaCabeceraDTO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(facturaCabeceraDTO);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(facturaCabeceraDTO);
        //}

        //// GET: FacturaCabecera/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var facturaCabeceraDTO = await _context.FacturaCabeceraDTO.FindAsync(id);
        //    if (facturaCabeceraDTO == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(facturaCabeceraDTO);
        //}

        //// POST: FacturaCabecera/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id")] FacturaCabeceraDTO facturaCabeceraDTO)
        //{
        //    if (id != facturaCabeceraDTO.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(facturaCabeceraDTO);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!FacturaCabeceraDTOExists(facturaCabeceraDTO.Id))
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
        //    return View(facturaCabeceraDTO);
        //}

        //// GET: FacturaCabecera/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var facturaCabeceraDTO = await _context.FacturaCabeceraDTO
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (facturaCabeceraDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(facturaCabeceraDTO);
        //}

        //// POST: FacturaCabecera/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var facturaCabeceraDTO = await _context.FacturaCabeceraDTO.FindAsync(id);
        //    if (facturaCabeceraDTO != null)
        //    {
        //        _context.FacturaCabeceraDTO.Remove(facturaCabeceraDTO);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool FacturaCabeceraDTOExists(int id)
        //{
        //    return _context.FacturaCabeceraDTO.Any(e => e.Id == id);
        //}
    }
}
