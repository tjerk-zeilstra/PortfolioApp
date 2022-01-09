using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOInterface.DTOs;
using DAOInterface.Interface;

namespace DAL.DAO
{
    public class ExpertiseDAO : IExpertiseDOA
    {
        private readonly SqlConnection _connection;
        public ExpertiseDAO()
        {
            _connection = new SqlConnection("Server=DESKTOP-N7U3HV7;Database=portfolioDB_Test;Trusted_Connection=True;");
        }
        public int AddExpertise(ExpertiseDTO expertise)
        {
            throw new NotImplementedException();
        }

        public List<ExpertiseDTO> GetAllExpertises()
        {
            throw new NotImplementedException();
        }

        public ExpertiseDTO GetExpertise(int id)
        {
            throw new NotImplementedException();
        }

        public List<ExpertiseDTO> GetExpertiseFromUser()
        {
            throw new NotImplementedException();
        }
    }
}
