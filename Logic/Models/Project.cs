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

        public List<Gebruiker> Gebruikers { get; private set; }
        public List<Expertise> Expertises { get; private set; }
        public List<ToDoItem> ToDoItems { get; private set; }
        public int ProjectID { get; set; }
        public int GebruikerID { get; set; }
        public string ProjectNaam { get; set; }
        public string ProjectBeschrijving { get; set; }
        public DateTime ProjectDatum { get; set; }

        public void Update()
        {
            _projectDAO.EditProject(new ProjectDTO()
            {
                ProjectID = this.ProjectID,
                GebruikerID = this.GebruikerID,
                ProjectNaam = this.ProjectNaam,
                ProjectBeschrijving = this.ProjectBeschrijving,
                ProjectDatum = this.ProjectDatum
            });
        }

        //Project
        private void GetProjectGebruikers()
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
        private void AddGebruiker(Gebruiker gebruiker)
        {
            _projectDAO.AddGebruiker(gebruiker.GebruikerID);
            Gebruikers.Add(gebruiker);
        }

        private void RemoveGebruiker(Gebruiker gebruiker)
        {
            _projectDAO.RemoveGebruiker(gebruiker.GebruikerID, ProjectID);
            Gebruikers.Remove(gebruiker);
        }

        //Expertises
        private void GetProjectExpertise(Expertise expertise)
        {
            List<ExpertiseDTO> expertiseDTOs = _projectDAO.GetExpertises(ProjectID);
            foreach (var expDTO in expertiseDTOs)
            {
                expertiseDTOs.Add(new()
                {

                });
            }
        }

        private void GetProjectToDo()
        {
            
        }


    }
}
