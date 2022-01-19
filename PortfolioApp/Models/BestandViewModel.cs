using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApp.Models
{
    public class BestandViewModel
    {
        public ProjectViewModel Project { get; set; }
        public IFormFile Bestand { set; get; }
    }
}
