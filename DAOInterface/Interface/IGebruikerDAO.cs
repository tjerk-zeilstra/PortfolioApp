using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOInterface.DTOs;

namespace DAOInterface.Interface
{
    public interface IGebruikerDAO
    {
        IList<GebruikerDTO> GetAllGebruikers();
        GebruikerDTO GetGebruiker(int id);
        GebruikerDTO EditGebruiker(GebruikerDTO gebruiker);
        GebruikerDTO AddGebruiker(GebruikerDTO gebruiker);
        void DeleteGebruiker(GebruikerDTO gebruiker);
    }
}
