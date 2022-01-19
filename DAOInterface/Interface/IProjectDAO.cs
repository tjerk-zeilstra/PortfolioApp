using DAOInterface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOInterface.Interface
{
    public interface IProjectDAO
    {   
        //Project
        List<ProjectDTO> GetAllProjecten();
        List<ProjectDTO> GetProjectsFromUser(int userID);
        ProjectDTO GetProject(int projectID);
        void EditProject(ProjectDTO Project);
        void CreateProject(ProjectDTO project);
        void DeleteProject(int id);

        //Gebruikers
        List<GebruikerDTO> GetProjectGebruikers(int projectID);
        void AddGebruiker(int gebruiker);
        void RemoveGebruiker(int gebruikerID, int projectID);

        //expertise
        List<ExpertiseDTO> GetExpertises(int projectID);
        void AddExpertise(int expertiseID);
        void RemoveExpertise(int expertiseID, int projectID);

        //bestanden
        List<BestandDTO> GetBestanden(int projectID);
        void AddBestand(BestandDTO bestand, int projectID);
        void RemoveBestanden(int bestandsID, int projectID);
    }
}
