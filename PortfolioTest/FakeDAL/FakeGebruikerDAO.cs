using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOInterface.Interface;
using DAOInterface.DTOs;

namespace PortfolioTest.FakeDAL
{
    public class FakeGebruikerDAO : IGebruikerDAO
    {
        public GebruikerDTO AddGebruiker(GebruikerDTO gebruiker)
        {
            throw new NotImplementedException();
        }

        public void DeleteGebruiker(int id)
        {
            throw new NotImplementedException();
        }

        public void EditGebruiker(GebruikerDTO gebruiker)
        {
            throw new NotImplementedException();
        }

        public List<GebruikerDTO> GetAllGebruikers()
        {
            throw new NotImplementedException();
        }

        public GebruikerDTO GetGebruiker(int id)
        {
            throw new NotImplementedException();
        }
    }
}
