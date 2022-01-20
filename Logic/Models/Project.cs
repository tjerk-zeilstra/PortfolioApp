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
        private readonly IGebruikerDAO _gebruikerDAO;

        public Project(IProjectDAO projectDAO, IGebruikerDAO gebruikerDAO)
        {
            _projectDAO = projectDAO;
            _gebruikerDAO = gebruikerDAO;
        }

        public Project(IProjectDAO projectDAO, IGebruikerDAO gebruikerDAO, ProjectDTO projectDTO)
        {
            _projectDAO = projectDAO;
            _gebruikerDAO = gebruikerDAO;

            ProjectID = projectDTO.ProjectID;
            GebruikerID = projectDTO.GebruikerID;
            ProjectNaam = projectDTO.ProjectNaam;
            ProjectBeschrijving = projectDTO.ProjectBeschrijving;
            ProjectDatum = projectDTO.ProjectDatum;
        }

        public List<Gebruiker> Gebruikers { get; private set; }
        public List<Expertise> Expertises { get; private set; }
        public List<ToDoItem> ToDoItems { get; private set; }
        public List<Bestand> Bestanden { get; private set; }

        public int ProjectID { get; set; }
        public int GebruikerID { get; set; }
        public string ProjectNaam { get; set; }
        public string ProjectBeschrijving { get; set; }
        public DateTime ProjectDatum { get; set; }

        public void Update(int gebruiker, string naam, string beschrijving, DateTime datum)
        {
            GebruikerID = gebruiker;
            ProjectNaam = naam;
            ProjectBeschrijving = beschrijving;
            ProjectDatum = datum;
            _projectDAO.EditProject(new(){
                ProjectID = ProjectID,
                GebruikerID = gebruiker,
                ProjectNaam = naam,
                ProjectBeschrijving = beschrijving,
                ProjectDatum = datum
            });
        }

        //Project
        public void GetProjectGebruikers()
        {
            List<GebruikerDTO> gebruikerDTOs = _projectDAO.GetProjectGebruikers(ProjectID);
            Gebruikers.Clear();
            foreach (var gebDTO in gebruikerDTOs)
            {
                Gebruikers.Add(new(_gebruikerDAO, gebDTO));
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

        //Bestanden
        public void GetBestanden()
        {
            List<Bestand> bestanden = new();
            List<BestandDTO> bestandDTOs = _projectDAO.GetBestanden(ProjectID);
            foreach (var bestandDTO in bestandDTOs)
            {
                Bestand bestand = new();
                bestand.BestandsLocatie = bestandDTO.BestandsLocatie;
                bestand.ID = bestandDTO.ID;
                bestanden.Add(bestand);
            }
            Bestanden = bestanden;
        }

        public void AddBestand(Bestand bestand)
        {
            BestandDTO dto = new BestandDTO()
            {
                BestandsLocatie = bestand.BestandsLocatie
            };
            _projectDAO.AddBestand(dto, ProjectID);
        }

        public void RemoveBestanden(int bestandID)
        {
            _projectDAO.RemoveBestanden(bestandID, ProjectID);
        }

        //Expertises
        public List<ExpertiseDTO> GetProjectExpertise()
        {
            List<ExpertiseDTO> expertiseDTOs = _projectDAO.GetExpertises(ProjectID);
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
