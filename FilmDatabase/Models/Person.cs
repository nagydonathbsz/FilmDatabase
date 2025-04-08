using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FilmDatabase.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }

        public override string ToString()
        {
            return PersonID + ";" + FirstName + ";" + LastName + ";" + BirthDate + ";" + Nationality + ";";
        }
    }
}
