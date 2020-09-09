using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public DateTime Datum { get; set; }

        public double Preis { get; set; }

        public string Beschreibung { get; set; }




    }
}
