using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Gebruiker
    {
        public int GebruikerID { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public string Email { get; set; }
        public string ProfielFoto { get; set; }
    }
}
