using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDatabase
{
 
    public class Movie
    {
        //asd
        public int Ranking { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public double Rating { get; set; }

        public Movie(int ranking, string title, int year, string genre, string director, double rating)
        {
            Ranking = ranking;
            Title = title;
            Year = year;
            Genre = genre;
            Director = director;
            Rating = rating;
        }

        public override string ToString()
        {
            return Ranking + ";" + Title + ";" + Year + ";" + Genre + ";" + Director + ";" + Rating;
        }
    }
}
