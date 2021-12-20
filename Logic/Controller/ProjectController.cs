using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOInterface.Interface;
using Logic.Models;
using DAOInterface.DTOs;

namespace Logic.Controller
{
    public class ProjectController
    {
        private readonly IProjectDAO _projectDAO;
        public ProjectController(IProjectDAO projectDAO)
        {
            _projectDAO = projectDAO;
        }

        public List<Project> GetAllProjects()
        {
            List<ProjectDTO> projectDTOs = _projectDAO.GetAllProjecten();
            List<Project> projects = new();
            foreach (var item in projectDTOs)
            {
                projects.Add(new(_projectDAO, item));
            }
            return projects;
        }

        public Project GetProject(int id)
        {
            return new(_projectDAO, _projectDAO.GetProject(id));
        }
    }
}
