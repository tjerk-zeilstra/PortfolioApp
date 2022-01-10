using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Managers;
using PortfolioApp.Models;
using DAOInterface.Interface;

namespace PortfolioApp.Controllers
{
    public class ProjectController : Controller
    {
        readonly ProjectManager projectManager;
        public ProjectController(IProjectDAO projectDAO)
        {
            projectManager = new(projectDAO);
        }

        // GET: ProjectController
        public ActionResult Index()
        {
            List<ProjectViewModel> models = new();
            foreach (var project in projectManager.GetAllProjects())
            {
                models.Add(new(project));
            }
            return View(models);
        }

        //GET: ProjectController TODO later
        //public ActionResult AccountPage()
        //{
        //    List<ProjectViewModel> models = new();
        //    return View();
        //}

        // GET: ProjectController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectController/Create
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

        // GET: ProjectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectController/Edit/5
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

        // GET: ProjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectController/Delete/5
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
