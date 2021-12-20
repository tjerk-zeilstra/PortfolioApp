using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Models;

namespace PortfolioApp.Models
{
    public class ExpertiseViewModel
    {
        public ExpertiseViewModel()
        {

        }

        public ExpertiseViewModel(Expertise expertise)
        {
            ID = expertise.ID;
            Name = expertise.Name;
            Beschrijving = expertise.Beschrijving;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Beschrijving { get; set; }
    }
}
