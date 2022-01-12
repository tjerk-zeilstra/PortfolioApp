using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Managers;
using Logic.Models;
using PortfolioApp.Models;
using DAOInterface.Interface;

namespace PortfolioApp.Controllers
{
    public class GebruikerController : Controller
    {
        private readonly GebruikerManager _gebruikerManager;
        private readonly int gebruikerID = 1;

        public GebruikerController(IGebruikerDAO gebruikerDAO)
        {
            _gebruikerManager = new(gebruikerDAO);
        }

        // GET: GebruikerController
        public ActionResult Index()
        {
            GebruikerViewModel gebruiker = new(_gebruikerManager.GetGebruiker(gebruikerID));
            
            return View(gebruiker);
        }

        // GET: GebruikerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GebruikerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm]GebruikerViewModel viewModel)
        {
            try
            {
                _gebruikerManager.AddGebruiker(viewModel.Beschrijving, viewModel.Naam, viewModel.Email, viewModel.ProfielFoto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: GebruikerController/Edit
        public ActionResult Edit()
        {
            GebruikerViewModel gebruiker = new(_gebruikerManager.GetGebruiker(gebruikerID));
            return View(gebruiker);
        }

        // POST: GebruikerController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm]GebruikerViewModel viewModel)
        {
            try
            {
                Gebruiker gebruiker = _gebruikerManager.GetGebruiker(gebruikerID);
                gebruiker.Update(viewModel.Naam, viewModel.Beschrijving, viewModel.Email, viewModel.ProfielFoto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: GebruikerController/Delete/5
        public ActionResult Delete(int id)
        {
            GebruikerViewModel gebruiker = new(_gebruikerManager.GetGebruiker(id));
            return View(gebruiker);
        }

        // POST: GebruikerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [FromForm] GebruikerViewModel viewModel)
        {
            try
            {
                _gebruikerManager.DeleteGebruiker(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }
    }
}
