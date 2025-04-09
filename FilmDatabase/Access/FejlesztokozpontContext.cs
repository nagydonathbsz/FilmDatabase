
using FilmDatabase;
using FilmDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FilmDatabase
{
    public class FejlesztokozpontContext : DbContext
    {
        public FejlesztokozpontContext() : base("name=FejlesztokozpontContext")
        {
        }

        public DbSet<Movie> movie { get; set; }
        public DbSet<Person> people { get; set; }
        public DbSet<Genre> genre { get; set; }
        public DbSet<Movie_Actor> movie_actor { get; set; }
        public DbSet<Movie_Director> movie_director { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
