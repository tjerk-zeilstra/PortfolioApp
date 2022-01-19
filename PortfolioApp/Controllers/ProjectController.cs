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
    public class ProjectController : Controller
    {
        private readonly ProjectManager _projectManager;
        private readonly int gebruikerID = 1;

        public ProjectController(ProjectManager projectManager)
        {
            _projectManager = projectManager;
        }

        // GET: ProjectController
        public ActionResult Index()
        {
            List<ProjectViewModel> models = new();
            foreach (var project in _projectManager.GetAllProjects())
            {
                models.Add(new(project));
            }
            return View(models);
        }

        // GET: ProjectController/Details/5
        public ActionResult Details(int id)
        {
            Project project = _projectManager.GetProject(id);
            project.GetBestanden();

            ProjectViewModel viewModel = new(project);
            return View(viewModel);
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm]ProjectViewModel viewModel)
        {
            try
            {
                _projectManager.AddProject(viewModel.GebruikerID, viewModel.ProjectNaam, viewModel.ProjectBeschrijving, viewModel.ProjectDatum);
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
            ProjectViewModel viewModel = new(_projectManager.GetProject(id));
            return View(viewModel);
        }

        // POST: ProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm]ProjectViewModel viewModel)
        {
            try
            {
                Project project = _projectManager.GetProject(id);
                project.Update(viewModel.GebruikerID, viewModel.ProjectNaam, viewModel.ProjectBeschrijving, viewModel.ProjectDatum);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: ProjectController/Delete/5
        public ActionResult Delete(int id)
        {
            ProjectViewModel viewModel = new(_projectManager.GetProject(id));
            return View(viewModel);
        }

        // POST: ProjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [FromForm]ProjectViewModel viewModel)
        {
            try
            {
                _projectManager.DelteProject(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
