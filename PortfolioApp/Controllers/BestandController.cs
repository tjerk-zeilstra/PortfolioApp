using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioApp.Models;
using Logic.Managers;
using DAOInterface.Interface;

namespace PortfolioApp.Controllers
{
    public class BestandController : Controller
    {
        private readonly ProjectManager _projectManager;
        private readonly int gebruikerID = 1;

        public BestandController(ProjectManager projectManager)
        {
            _projectManager = projectManager;
        }

        public ActionResult Create(int id)
        {
            ProjectViewModel project = new(_projectManager.GetProject(id));
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, [FromForm]BestandViewModel viewModel)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
