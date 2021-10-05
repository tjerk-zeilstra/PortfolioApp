using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;

namespace Logic
{
    public static class Factory
    {
        public static IGebruiker GetGebruiker()
        {
            IGebruiker gebruiker = new Gebruiker();
            return gebruiker;
        }

        public static IProject GetProject()
        {
            IProject project = new Project();
            return project;
        }

        public static IBestand GetBestand()
        {
            IBestand bestand = new Bestand();
            return bestand;
        }

        public static IExpertise GetExpertise()
        {
            IExpertise expertise = new Expertise();
            return expertise;
        }
    }
}
