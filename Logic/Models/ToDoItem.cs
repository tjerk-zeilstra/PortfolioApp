using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class ToDoItem
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EindDatum { get; set; }


    }
}
