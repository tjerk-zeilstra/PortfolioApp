using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOInterface.Interface;
using DAOInterface.DTOs;

namespace PortfolioTest.FakeDAL
{
    public class FakeProjectDAO : IProjectDAO
    {

        public int ID { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public DateTime Datum { get; set; }

        public void AddBestand(BestandDTO bestand, int projectID)
        {
            throw new NotImplementedException();
        }

        public void AddExpertise(int expertiseID)
        {
            throw new NotImplementedException();
        }

        public void AddGebruiker(int gebruiker)
        {
            throw new NotImplementedException();
        }

        public void CreateProject(ProjectDTO Project)
        {
            throw new NotImplementedException();
        }

        public void DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public void EditProject(ProjectDTO Project)
        {
            ID = Project.ProjectID;
            Naam = Project.ProjectNaam;
            Beschrijving = Project.ProjectBeschrijving;
            Datum = Project.ProjectDatum;
        }

        public List<ProjectDTO> GetAllProjecten()
        {
            throw new NotImplementedException();
        }

        public List<BestandDTO> GetBestanden(int projectID)
        {
            throw new NotImplementedException();
        }

        public List<ExpertiseDTO> GetExpertises(int projectID)
        {
            throw new NotImplementedException();
        }

        public ProjectDTO GetProject(int projectID)
        {
            throw new NotImplementedException();
        }

        public List<GebruikerDTO> GetProjectGebruikers(int projectID)
        {
            throw new NotImplementedException();
        }

        public List<ProjectDTO> GetProjectsFromUser(int userID)
        {
            throw new NotImplementedException();
        }

        public void RemoveBestanden(int bestandsID, int projectID)
        {
            throw new NotImplementedException();
        }

        public void RemoveExpertise(int expertiseID, int projectID)
        {
            throw new NotImplementedException();
        }

        public void RemoveGebruiker(int gebruikerID, int projectID)
        {
            throw new NotImplementedException();
        }
    }
}
