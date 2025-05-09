﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDatabase.Models
{
    public class Genre
    {
        [Key]
        public string GenreID { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
