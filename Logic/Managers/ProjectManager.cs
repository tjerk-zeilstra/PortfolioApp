using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOInterface.Interface;
using Logic.Models;
using DAOInterface.DTOs;

namespace Logic.Managers
{
    public class ProjectManager
    {
        private readonly IProjectDAO _projectDAO;
        private readonly IGebruikerDAO _gebruikerDAO;

        public ProjectManager(IProjectDAO projectDAO, IGebruikerDAO gebruikerDAO)
        {
            _projectDAO = projectDAO;
            _gebruikerDAO = gebruikerDAO;
        }

        public List<Project> GetAllProjects()
        {
            List<ProjectDTO> projectDTOs = _projectDAO.GetAllProjecten();
            List<Project> projects = new();
            foreach (var item in projectDTOs)
            {
                projects.Add(new(_projectDAO, _gebruikerDAO, item));
            }
            return projects;
        }

        public Project GetProject(int id)
        {
            ProjectDTO projectDTO = _projectDAO.GetProject(id);
            Project project = new(_projectDAO, _gebruikerDAO) {
                ProjectID = projectDTO.ProjectID,
                GebruikerID = projectDTO.GebruikerID,
                ProjectNaam = projectDTO.ProjectNaam,
                ProjectBeschrijving = projectDTO.ProjectBeschrijving,
                ProjectDatum = projectDTO.ProjectDatum
            };
            return project;
        }

        public Project AddProject(int gebID, string naam, string beschrijving, DateTime datum)
        {
            ProjectDTO projectDTO = new()
            {
                GebruikerID = gebID,
                ProjectNaam = naam,
                ProjectBeschrijving = beschrijving,
                ProjectDatum = datum
            };
            _projectDAO.CreateProject(projectDTO);
            return new Project(_projectDAO, _gebruikerDAO) 
            { 
                ProjectID = projectDTO.ProjectID,
                GebruikerID = projectDTO.GebruikerID,
                ProjectNaam = projectDTO.ProjectNaam,
                ProjectBeschrijving = projectDTO.ProjectBeschrijving,
                ProjectDatum = projectDTO.ProjectDatum
            };
        }
        
        public void DelteProject(int id)
        {
            _projectDAO.DeleteProject(id);
        }
    }
}
