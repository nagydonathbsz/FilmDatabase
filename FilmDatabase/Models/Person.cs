using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FilmDatabase.Models
{
    public class Person
    {
        [Key]
        public string PersonID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Movie_Actor> Movie_Actor { get; set; }
        public virtual ICollection<Movie_Director> Movie_Director { get; set; }
    }
}
