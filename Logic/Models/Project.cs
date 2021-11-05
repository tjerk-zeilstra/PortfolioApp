using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public int GebruikerID { get; set; }
        public List<Gebruiker> Persoonen { get; set; }
        public string ProjectNaam { get; set; }
        public string ProjectBeschrijving { get; set; }
        public DateTime ProjectDatum { get; set; }


    }
}
