using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDatabase.Models
{
    public class Genre
    {
        public string GenreID { get; set; }
        public string GenreName { get; set; }
        public override string ToString()
        {
            return GenreID + ";" + GenreName;
        }
    }
}
