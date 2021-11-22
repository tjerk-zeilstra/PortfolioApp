using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOInterface.Interface;
using DAOInterface.DTOs;
using Logic.Models;

namespace Logic.Logic
{
    public class ProjectLogic
    {

        private readonly IProjectDAO _projectDAO;

        public ProjectLogic(IProjectDAO projectDAO)
        {
            _projectDAO = projectDAO;
        }

        public Project GetProject(int projectID)
        {
            ProjectDTO projectDTO = _projectDAO.GetProject(projectID);

            return new Project() {
                ProjectID = projectDTO.ProjectID,
                GebruikerID = projectDTO.GebruikerID,
                ProjectNaam = projectDTO.ProjectNaam,
                ProjectBeschrijving = projectDTO.ProjectBeschrijving,
                ProjectDatum = projectDTO.ProjectDatum
            };
        }

        public List<Project> GetProjectsFromUser(int userID)
        {
            List<ProjectDTO> projectDTOs = _projectDAO.GetProjectsFromUser(userID);
            List<Project> returnProjects = new();
            foreach (var projectDTO in projectDTOs)
            {
                returnProjects.Add(new Project()
                {
                    ProjectID = projectDTO.ProjectID,
                    GebruikerID = projectDTO.GebruikerID,
                    ProjectNaam = projectDTO.ProjectNaam,
                    ProjectBeschrijving = projectDTO.ProjectBeschrijving,
                    ProjectDatum = projectDTO.ProjectDatum
                });
            }
            return returnProjects;
        }

        public Project CreateProject(int userid, Project project)
        {
            int id = _projectDAO.CreateProject(new ProjectDTO
            {
                ProjectID = project.ProjectID,
                GebruikerID = project.GebruikerID,
                ProjectNaam = project.ProjectNaam,
                ProjectBeschrijving = project.ProjectBeschrijving,
                ProjectDatum = project.ProjectDatum
            });

            project.ProjectID = id;
            return project;
        }

        public Project EditProject(Project project)
        {
            _projectDAO.EditProject(new ProjectDTO
            {
                ProjectID = project.ProjectID,
                GebruikerID = project.GebruikerID,
                ProjectNaam = project.ProjectNaam,
                ProjectBeschrijving = project.ProjectBeschrijving,
                ProjectDatum = project.ProjectDatum
            });

            return project;
        }
    }
}
