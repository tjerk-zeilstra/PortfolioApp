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
        public void AddExpertise(int expertiseID)
        {
            
        }

        public void AddGebruiker(int gebruiker)
        {
            
        }

        public int CreateProject(ProjectDTO Project)
        {
            return 1;
        }

        public void DeleteProject(ProjectDTO Project)
        {
            
        }

        public void EditProject(ProjectDTO Project)
        {
            
        }

        public List<ProjectDTO> GetAllProjecten()
        {
            List<ProjectDTO> projectDTOs = new();
            for (int i = 0; i < 2; i++)
            {
                projectDTOs.Add(new()
                {
                    ProjectID = i,
                    GebruikerID = 1,
                    ProjectBeschrijving = "test " + i,
                    ProjectDatum = new DateTime(),
                    ProjectNaam = "test " + i
                });
            }
            return projectDTOs;
        }

        public List<ExpertiseDTO> GetExpertises(int projectID)
        {
            List<ExpertiseDTO> expertiseDTOs = new();
            for (int i = 0; i < 2; i++)
            {
                expertiseDTOs.Add(new()
                {
                    ID = i,
                    Beschrijving = "test " + 1,
                    Name = "test " + 1
                });
            }
            return expertiseDTOs;
        }

        public ProjectDTO GetProject(int projectID)
        {
            return new ProjectDTO()
            {
                ProjectID = projectID,
                GebruikerID = 1,
                ProjectBeschrijving = "test",
                ProjectDatum = new DateTime(),
                ProjectNaam = "test"
            };
        }

        public List<GebruikerDTO> GetProjectGebruikers(int projectID)
        {
            List<GebruikerDTO> gebruikerDTOs = new();
            for (int i = 0; i < 2; i++)
            {
                gebruikerDTOs.Add(new()
                {
                    GebruikerID = i,
                    Beschrijving = "test",
                    Email = "mail",
                    Naam = "naam",
                    ProfielFoto = "foto"
                });
            }
            return gebruikerDTOs;
        }

        public List<ProjectDTO> GetProjectsFromUser(int userID)
        {
            List<ProjectDTO> projectDTOs = new();
            for (int i = 0; i < 2; i++)
            {
                projectDTOs.Add(new()
                {
                    ProjectID = i,
                    GebruikerID = userID,
                    ProjectBeschrijving = "test " + i,
                    ProjectDatum = new DateTime(),
                    ProjectNaam = "test " + i
                });
            }
            return projectDTOs;
        }

        public void RemoveExpertise(int expertiseID, int projectID)
        {
            
        }

        public void RemoveGebruiker(int gebruikerID, int projectID)
        {
            
        }
    }
}
