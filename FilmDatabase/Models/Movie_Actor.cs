using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDatabase.Models
{
    public class Movie_Actor
    {
        [Key, Column(Order = 0)]
        public string MovieID { get; set; }

        [Key, Column(Order = 1)]
        public string PersonID { get; set; }

        [ForeignKey("MovieID")]
        public virtual Movie Movie { get; set; }

        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }
    }
}
