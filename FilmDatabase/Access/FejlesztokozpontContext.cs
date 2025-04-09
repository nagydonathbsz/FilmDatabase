
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
        public DbSet<Person> People { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie_Actor> Movie_Actor { get; set; }
        public DbSet<Movie_Director> Movie_Director { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
