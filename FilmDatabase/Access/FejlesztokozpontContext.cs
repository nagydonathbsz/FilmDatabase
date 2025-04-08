using FejlesztokozpontCLI.Models;
using FilmDatabase;
using FilmDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FejlesztokozpontEF.Database
{
    class FejlesztokozpontContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Person> Person { get; set; } 
        public DbSet<Genre> Genre { get; set; }
       

        public FejlesztokozpontContext() : base("name=FejlesztokozpontContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
