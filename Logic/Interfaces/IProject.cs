using System;
using System.Collections.Generic;

namespace Logic.Models
{
    public interface IProject
    {
        List<Gebruiker> Contributers { get; set; }
        int GebruikerID { get; set; }
        string ProjectBeschrijving { get; set; }
        DateTime ProjectDatum { get; set; }
        int ProjectID { get; set; }
        string ProjectNaam { get; set; }
    }
}