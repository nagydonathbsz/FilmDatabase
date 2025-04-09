using System;
using System.Collections.Generic;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Win32;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Controls;
using FilmDatabase.Models;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

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
            var movies = _context.movie.ToList();
            lbMovies.ItemsSource = movies;
        }

        private void lbMovies_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lbMovies.SelectedItem is Movie selectedMovie)
            {

                tbYear.Text = selectedMovie.Year.ToString();

                tbGenre.Text = selectedMovie.Genre.GenreName;

                var szoveg = "";

                // Sz�n�szek lek�rdez�se
                var actors = _context.Movie_Actor
                    .Where(ma => ma.MovieID == selectedMovie.MovieID)
                    .Select(ma => "Sz�n�sz: " + ma.Person.FirstName + " " + ma.Person.LastName)
                    .ToList();

                szoveg += "Sz�n�szek:\n";
                szoveg += actors.Count > 0 ? string.Join("\n", actors) + "\n\n" : "Nincs adat\n\n";

                // Rendez�k lek�rdez�se
                var directors = _context.Movie_Director
                    .Where(md => md.MovieID == selectedMovie.MovieID)
                    .Select(md => "Rendez�: " + md.Person.FirstName + " " + md.Person.LastName)
                    .ToList();

                szoveg += "Rendez�k:\n";
                szoveg += directors.Count > 0 ? string.Join("\n", directors) : "Nincs adat";

                tbPeople.Text = szoveg;

                tbRating.Text = Math.Round(selectedMovie.Rating).ToString();
            } 
        }
    }
}

