using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOInterface.Interface;
using DAOInterface.DTOs;
using Logic.Models;

namespace Logic.Managers
{
    public class GebruikerManager
    {
        IGebruikerDAO _gebruikerDAO;

        public GebruikerManager(IGebruikerDAO gebruikerDAO)
        {
            _gebruikerDAO = gebruikerDAO;
        }

        public Gebruiker GetGebruiker(int id)
        {
            GebruikerDTO gebruikerDTO = _gebruikerDAO.GetGebruiker(id);
            Gebruiker gebruiker = new(_gebruikerDAO, gebruikerDTO);
            return gebruiker;
        }

        public Gebruiker AddGebruiker(string beschrijving, string naam, string email, string foto)
        {
            GebruikerDTO gebruikerDTO = new()
            {
                Beschrijving = beschrijving,
                Naam = naam,
                Email = email,
                ProfielFoto = foto
            };
            _gebruikerDAO.AddGebruiker(gebruikerDTO);
            return new(_gebruikerDAO, gebruikerDTO);
        }
    }
}
