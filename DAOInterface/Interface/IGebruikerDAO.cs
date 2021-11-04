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
        void EditGebruiker(GebruikerDTO gebruiker);
        void AddGebruiker(GebruikerDTO gebruiker);
        void DeleteGebruiker(GebruikerDTO gebruiker);
    }
}
