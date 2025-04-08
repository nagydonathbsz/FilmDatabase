using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmDatabase.Models;

namespace FilmDatabase
{
 
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        public double Rating { get; set; }
        [Required]
        public string Title { get; set; }
        public int GenreID { get; set; }
        public int Year { get; set; }

        [ForeignKey("GenreID")]
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Movie_Actor> Movie_Actors { get; set; }
        public virtual ICollection<Movie_Director> Movie_Directors { get; set; }

    }
}
