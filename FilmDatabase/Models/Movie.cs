using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDatabase
{
 
    public class Movie
    {
        public int MovieID { get; set; }
        public string GenreID { get; set; }
        public double Rating { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        
        

        public override string ToString()
        {
            return MovieID + ";" + GenreID + ";" + Rating + ";" + Year;
        }
    }
}
