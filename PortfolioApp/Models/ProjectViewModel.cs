using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Models;

namespace PortfolioApp.Models
{
    public class ProjectViewModel
    {
        public ProjectViewModel()
        {

        }

        public ProjectViewModel(Project project)
        {
            LogicProject = project;

            ProjectID = project.ProjectID;
            GebruikerID = project.GebruikerID;
            ProjectNaam = project.ProjectNaam;
            ProjectBeschrijving = project.ProjectBeschrijving;
            ProjectDatum = project.ProjectDatum;

            foreach (var geb in project.Gebruikers)
            {
                Gebruikers.Add(new(geb));
            }

            foreach (var exp in project.Expertises)
            {
                Expertises.Add(new(exp));
            }
        }

        public Project LogicProject { get; set; }
        public List<GebruikerViewModel> Gebruikers { get; private set; }
        public List<ExpertiseViewModel> Expertises { get; private set; }
        //public List<ToDoItem> ToDoItems { get; private set; }

        public int ProjectID { get; private set; }
        public int GebruikerID { get; set; }
        public string ProjectNaam { get; set; }
        public string ProjectBeschrijving { get; set; }
        public DateTime ProjectDatum { get; set; }
    }
}
