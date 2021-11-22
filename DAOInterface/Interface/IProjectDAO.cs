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
        List<ProjectDTO> GetAllProjecten();
        List<ProjectDTO> GetProjectsFromUser(int userID);
        List<GebruikerDTO> GetProjectGebruikers(int projectID);
        void AddGebruiker(GebruikerDTO gebruiker);
        void RemoveGebruiker(int gebruikerID, int projectID);
        ProjectDTO GetProject(int projectID);
        void EditProject(ProjectDTO Project);
        int CreateProject(ProjectDTO Project);
        void DeleteProject(ProjectDTO Project);
    }
}
