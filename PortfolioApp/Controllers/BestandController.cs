using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioApp.Models;
using Logic.Managers;
using Logic.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace PortfolioApp.Controllers
{
    public class BestandController : Controller
    {
        private readonly ProjectManager _projectManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly int gebruikerID = 1;

        public BestandController(ProjectManager projectManager, IWebHostEnvironment hostingEnvironment)
        {
            _projectManager = projectManager;
            _webHostEnvironment = hostingEnvironment;
        }

        public ActionResult Create(int id)
        {
            Project project = _projectManager.GetProject(id);
            ProjectViewModel projectViewModel = new(project);
            BestandViewModel bestandViewModel = new();
            bestandViewModel.Project = projectViewModel;

            return View(bestandViewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        //IFormCollection collection
        public ActionResult Create(int id, IFormFile Bestand)
        {
            Project project = _projectManager.GetProject(id);
            if (Bestand != null)
            {
                string bestandsnaam = GenerateUniqueFileName(Bestand.FileName);
                string folder = Path.Combine(_webHostEnvironment.WebRootPath, "bestanden\\" + project.GebruikerID + "\\" + project.ProjectNaam);
                string path = Path.Combine(folder, bestandsnaam);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                Bestand.CopyTo(new FileStream(path, FileMode.Create));
                project.AddBestand(new Bestand()
                {
                    BestandsLocatie = bestandsnaam
                });
            }

            return RedirectToAction("Details", "Project", new { id});
        }

        private static string GenerateUniqueFileName(string filename)
        {
            string NoExtension = Path.GetFileNameWithoutExtension(filename);
            string returnName = NoExtension + DateTime.Now.Ticks + Path.GetExtension(filename);
            return returnName;
        }

        public ActionResult Delete(int projectID, int bestandID)
        {
            Project project = _projectManager.GetProject(projectID);
            project.RemoveBestanden(bestandID);
            return RedirectToAction("Details", "Project", new { id = projectID });
        }
    }
}
