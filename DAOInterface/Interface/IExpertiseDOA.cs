using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOInterface.DTOs;

namespace DAOInterface.Interface
{
    public interface IExpertiseDOA
    {
        List<ExpertiseDTO> GetAllExpertises();
        List<ExpertiseDTO> GetExpertiseFromUser();
        ExpertiseDTO GetExpertise(int id);
        int AddExpertise(ExpertiseDTO expertise);
    }
}
