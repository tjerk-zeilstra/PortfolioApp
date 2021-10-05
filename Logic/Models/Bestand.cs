using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Bestand : IBestand
    {
        private int _id;
        private string _locatie;

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public string Locatie
        {
            get { return _locatie; }
            set
            {
                _locatie = value;
            }
        }
    }
}
