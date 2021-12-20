using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Models;

namespace PortfolioApp.Models
{
    public class GebruikerViewModel
    {
        public GebruikerViewModel(Gebruiker gebruiker)
        {
            GebruikerID = gebruiker.GebruikerID;
            Naam = gebruiker.Naam;
            Beschrijving = gebruiker.Beschrijving;
            Email = gebruiker.Email;
            ProfielFoto = gebruiker.ProfielFoto;
        }

        public int GebruikerID { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public string Email { get; set; }
        public string ProfielFoto { get; set; }
    }
}
