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
            Bestanden = new();

            ProjectID = project.ProjectID;
            GebruikerID = project.GebruikerID;
            ProjectNaam = project.ProjectNaam;
            ProjectBeschrijving = project.ProjectBeschrijving;
            ProjectDatum = project.ProjectDatum;

            if (project.Bestanden != null)
            {
                foreach (var bes in project.Bestanden)
                {
                    Bestanden.Add(new BestandenViewModel()
                    {
                        ID = bes.ID,
                        BestandsLocatie = bes.BestandsLocatie
                    });
                }
            }
            

            //foreach (var geb in project.Gebruikers)
            //{
            //    Gebruikers.Add(new(geb));
            //}

            //foreach (var exp in project.Expertises)
            //{
            //    Expertises.Add(new(exp));
            //}
        }

        public List<GebruikerViewModel> Gebruikers { get; private set; }
        public List<ExpertiseViewModel> Expertises { get; private set; }
        public List<BestandenViewModel> Bestanden { get; set; }

        public int ProjectID { get; private set; }
        public int GebruikerID { get; set; }
        public string ProjectNaam { get; set; }
        public string ProjectBeschrijving { get; set; }
        public DateTime ProjectDatum { get; set; }
    }
}
