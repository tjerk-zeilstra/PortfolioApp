using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOInterface.Interface;
using DAOInterface.DTOs;

namespace Logic.Models
{
    public class Gebruiker
    {
        private readonly IGebruikerDAO _gebruikerDAO;
        public Gebruiker(IGebruikerDAO gebruikerDAO)
        {
            _gebruikerDAO = gebruikerDAO;
        }
        public Gebruiker(IGebruikerDAO gebruikerDAO, GebruikerDTO gebruikerDTO)
        {
            _gebruikerDAO = gebruikerDAO;
            GebruikerID = gebruikerDTO.GebruikerID;
            Naam = gebruikerDTO.Naam;
            Beschrijving = gebruikerDTO.Beschrijving;
            Email = gebruikerDTO.Email;
            ProfielFoto = gebruikerDTO.ProfielFoto;
        }

        public int GebruikerID { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public string Email { get; set; }
        public string ProfielFoto { get; set; }

        public void Update(string naam, string beschrijving, string email, string profielfoto)
        {
            Naam = naam;
            Beschrijving = beschrijving;
            Email = email;
            ProfielFoto = profielfoto;
            _gebruikerDAO.EditGebruiker(new(){ 
                GebruikerID = GebruikerID,
                Naam = naam,
                Beschrijving = beschrijving,
                Email = email,
                ProfielFoto = profielfoto
            });
        }
    }
}
