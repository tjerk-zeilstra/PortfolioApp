using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApp.Controllers
{
    public class GebruikerController : Controller
    {
        // GET: GebruikerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GebruikerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GebruikerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GebruikerController/Create
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

        // GET: GebruikerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GebruikerController/Edit/5
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

        // GET: GebruikerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GebruikerController/Delete/5
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
