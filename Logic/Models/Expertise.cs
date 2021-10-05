using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Expertise : IExpertise
    {
        private int _id;
        private string _name;
        private string _beschrijving;

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
            }

        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
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
    }
}
