using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;

namespace DAL.DTO
{
    public class ProjectDTO : IProjectDTO
    {
        private int _projectID;
        private int _projectEigenaarID;
        private string _projectNaam;
        private string _projectBeschrijving;
        private DateTime _projectDatum;

        public int ProjectID { get { return _projectID; } set { _projectID = value; } }
        public int GebruikerID { get { return _projectEigenaarID; } set { _projectEigenaarID = value; } }
        public string ProjectNaam { get { return _projectNaam; } set { _projectNaam = value; } }
        public string ProjectBeschrijving { get { return _projectBeschrijving; } set { _projectBeschrijving = value; } }
        public DateTime ProjectDatum { get { return _projectDatum; } set { _projectDatum = value; } }
    }
}
