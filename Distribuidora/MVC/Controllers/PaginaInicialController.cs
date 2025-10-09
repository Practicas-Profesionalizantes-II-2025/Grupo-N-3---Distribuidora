using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class PaginaInicialController : Controller
    {
        // GET: PaginaInicial
        public ActionResult PaginaInicial()
        {
            return View();
        }

        // GET: PaginaInicial/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaginaInicial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaginaInicial/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaginaInicial/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaginaInicial/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaginaInicial/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaginaInicial/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
