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
        private readonly IExpertiseDOA _expertiseDOA;

        public Project(IProjectDAO projectDAO, IExpertiseDOA expertiseDOA)
        {
            _projectDAO = projectDAO;
            _expertiseDOA = expertiseDOA;
        }

        public List<Gebruiker> gebruikers;
        public List<Expertise> expertises;
        public List<ToDoItem> toDoItems;

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

        private void GetProjectGebruikers()
        {
            List<GebruikerDTO> gebruikerDTOs = _projectDAO.GetProjectGebruikers(GebruikerID);
            gebruikers.Clear();
            foreach (var gebDTO in gebruikerDTOs)
            {
                gebruikers.Add(new()
                {
                    GebruikerID = gebDTO.GebruikerID,
                    Beschrijving = gebDTO.Beschrijving,
                    Email = gebDTO.Email,
                    Naam = gebDTO.Naam,
                    ProfielFoto = gebDTO.ProfielFoto
                });
            }
        }

        private void AddGebruiker(Gebruiker gebruiker)
        {
            _projectDAO.AddGebruiker(new()
            {
                GebruikerID = gebruiker.GebruikerID,
                Beschrijving = gebruiker.Beschrijving,
                Email = gebruiker.Email,
                Naam = gebruiker.Naam,
                ProfielFoto = gebruiker.ProfielFoto
            });

            gebruikers.Add(gebruiker);
        }

        private void RemoveGebruiker(Gebruiker gebruiker)
        {
            _projectDAO.RemoveGebruiker(gebruiker.GebruikerID, ProjectID);
            gebruikers.Remove(gebruiker);
        }

        private void GetProjectExpertise()
        {

        }

        private void GetProjectToDo()
        {
            
        }


    }
}
