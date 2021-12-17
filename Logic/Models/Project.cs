using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOInterface.Interface;
using DAOInterface.DTOs;

namespace Logic.Models
{
    public class Project
    {
        private readonly IProjectDAO _projectDAO;

        public Project(IProjectDAO projectDAO)
        {
            _projectDAO = projectDAO;
        }

        public Project(IProjectDAO projectDAO, ProjectDTO projectDTO)
        {
            _projectDAO = projectDAO;

            ProjectID = projectDTO.ProjectID;
            GebruikerID = projectDTO.GebruikerID;
            ProjectNaam = projectDTO.ProjectNaam;
            ProjectBeschrijving = projectDTO.ProjectBeschrijving;
            ProjectDatum = projectDTO.ProjectDatum;
        }

        public List<Gebruiker> Gebruikers { get; private set; }
        public List<Expertise> Expertises { get; private set; }
        public List<ToDoItem> ToDoItems { get; private set; }

        public int ProjectID { get; private set; }
        public int GebruikerID { get; set; }
        public string ProjectNaam { get; set; }
        public string ProjectBeschrijving { get; set; }
        public DateTime ProjectDatum { get; set; }

        public void Update()
        {
            _projectDAO.EditProject(new ProjectDTO()
            {
                ProjectID = ProjectID,
                GebruikerID = GebruikerID,
                ProjectNaam = ProjectNaam,
                ProjectBeschrijving = ProjectBeschrijving,
                ProjectDatum = ProjectDatum
            });
        }

        //Project
        public void GetProjectGebruikers()
        {
            List<GebruikerDTO> gebruikerDTOs = _projectDAO.GetProjectGebruikers(ProjectID);
            Gebruikers.Clear();
            foreach (var gebDTO in gebruikerDTOs)
            {
                Gebruikers.Add(new()
                {
                    GebruikerID = gebDTO.GebruikerID,
                    Beschrijving = gebDTO.Beschrijving,
                    Email = gebDTO.Email,
                    Naam = gebDTO.Naam,
                    ProfielFoto = gebDTO.ProfielFoto
                });
            }
        }

        //Gebruikers
        public void AddGebruiker(Gebruiker gebruiker)
        {
            _projectDAO.AddGebruiker(gebruiker.GebruikerID);
            Gebruikers.Add(gebruiker);
        }

        public void RemoveGebruiker(Gebruiker gebruiker)
        {
            _projectDAO.RemoveGebruiker(gebruiker.GebruikerID, ProjectID);
            Gebruikers.Remove(gebruiker);
        }

        //Expertises
        public List<ExpertiseDTO> GetProjectExpertise(Expertise expertise)
        {
            List<ExpertiseDTO> expertiseDTOs = _projectDAO.GetExpertises(expertise.ID);
            foreach (var expDTO in expertiseDTOs)
            {
                expertiseDTOs.Add(new()
                {
                    ID = expDTO.ID,
                    Beschrijving = expDTO.Beschrijving,
                    Name = expDTO.Name
                });
            }
            return expertiseDTOs;
        }

        public void AddExpertise(Expertise expertise)
        {
            _projectDAO.AddExpertise(expertise.ID);
            Expertises.Add(expertise);
        }

        public void RemoveExpertise(Expertise expertise)
        {
            _projectDAO.RemoveExpertise(expertise.ID, ProjectID);
            Expertises.Remove(expertise);
        }
    }
}
