using System;
using System.Collections.Generic;
using DAL.DTO;

namespace DAL.Interface
{
    public interface IProjectDTO
    {
        int GebruikerID { get; set; }
        string ProjectBeschrijving { get; set; }
        DateTime ProjectDatum { get; set; }
        int ProjectID { get; set; }
        string ProjectNaam { get; set; }
    }
}