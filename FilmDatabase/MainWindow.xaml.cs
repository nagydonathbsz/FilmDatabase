using System;
using System.Collections.Generic;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Win32;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Controls;
using FejlesztokozpontEF.Database;
using FilmDatabase.Models;
using System.Linq;

namespace FilmDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FejlesztokozpontContext _context = new FejlesztokozpontContext();

        public MainWindow()
        {
            InitializeComponent();
            LoadMovies();
        }

        private void LoadMovies()
        {
            var movies = _context.Movies.ToList();
            lbMovies.ItemsSource = movies;
        }

        private void MovieComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lbMovies.SelectedItem is Movie selectedMovie)
            {
                var szoveg = "";

                // Színészek lekérdezése
                var actors = _context.Movie_Actor
                    .Where(ma => ma.MovieID == selectedMovie.MovieID)
                    .Select(ma => "Színész: " + ma.Person.FirstName + " " + ma.Person.LastName)
                    .ToList();

                szoveg += "Színészek:\n";
                szoveg += actors.Count > 0 ? string.Join("\n", actors) + "\n\n" : "Nincs adat\n\n";

                // Rendezõk lekérdezése
                var directors = _context.Movie_Director
                    .Where(md => md.MovieID == selectedMovie.MovieID)
                    .Select(md => "Rendezõ: " + md.Person.FirstName + " " + md.Person.LastName)
                    .ToList();

                szoveg += "Rendezõk:\n";
                szoveg += directors.Count > 0 ? string.Join("\n", directors) : "Nincs adat";

                tbPeople.Text = szoveg;
            } 
        }
    }
}

