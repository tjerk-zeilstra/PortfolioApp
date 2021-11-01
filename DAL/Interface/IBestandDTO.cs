using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IBestandDTO
    {
        int ID { get; set; }
        string Locatie { get; set; }
    }
}
