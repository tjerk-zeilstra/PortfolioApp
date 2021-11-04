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
        IList<ProjectDTO> GetAllProjecten();
        void EditProject(ProjectDTO Project);
        void AddProject(ProjectDTO Project);
        void DeleteProject(ProjectDTO Project);
    }
}
