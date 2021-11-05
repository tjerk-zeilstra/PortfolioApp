using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOInterface.Interface;
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

        public Project GetProject()
        {

        }

        public List<Project> GetProjectsFromUser(int id)
        {

        }

        public Project CreateProject()
        {

        }

        public void EditProject()
        {
            
        }
    }
}
