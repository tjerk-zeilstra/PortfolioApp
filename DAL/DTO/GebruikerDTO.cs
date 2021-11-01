using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;

namespace DAL.DTO
{
    public class GebruikerDTO : IGebruikerDTO
    {
        public int GebruikerID { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public string Email { get; set; }
        public string ProfielFoto { get; set; }
    }
}
