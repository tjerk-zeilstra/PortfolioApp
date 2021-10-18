using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class GebruikerDTO : IGebruikerDTO
    {
        private int _gebruikerID;
        private string _naam;
        private string _beschrijving;
        private string _email;
        private string _profielfoto;

        public int GebruikerID
        {
            get { return _gebruikerID; }
            set
            {
                _gebruikerID = value;
            }
        }
        public string Naam
        {
            get { return _naam; }
            set
            {
                _naam = value;
            }
        }
        public string Beschrijving
        {
            get { return _beschrijving; }
            set
            {
                _beschrijving = value;
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }
        public string ProfielFoto
        {
            get { return _profielfoto; }
            set
            {
                _profielfoto = value;
            }
        }
    }
}
