using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Project : IProject
    {
        private int _projectID;
        private int _projectEigenaarID;
        private List<Gebruiker> _contributers;
        private string _projectNaam;
        private string _projectBeschrijving;
        private DateTime _projectDatum;

        public int ProjectID { get { return _projectID; } set { _projectID = value; } }
        public int GebruikerID { get { return _projectEigenaarID; } set { _projectEigenaarID = value; } }
        public List<Gebruiker> Contributers { get { return _contributers; } set { _contributers = value; } }
        public string ProjectNaam { get { return _projectNaam; } set { _projectNaam = value; } }
        public string ProjectBeschrijving { get { return _projectBeschrijving; } set { _projectBeschrijving = value; } }
        public DateTime ProjectDatum { get { return _projectDatum; } set { _projectDatum = value; } }


    }
}
