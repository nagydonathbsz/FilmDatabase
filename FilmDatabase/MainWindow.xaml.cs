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
using System.Windows.Controls.Primitives;
using System.Runtime.Remoting.Contexts;

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

            tbMax.Text = movies.OrderByDescending(m => m.Rating).First().Title.ToString();
            tbGp.Text = _context.genre
                .GroupBy(mg => mg.GenreID)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            var oldestActor = _context.movie_actor
                .Select(ma => ma.Person)
                .OrderBy(p => p.BirthDate)
                .FirstOrDefault();

            tbOA.Text = oldestActor != null ? $"{oldestActor.FirstName} {oldestActor.LastName}" : "N/A";

            var youngestDirector = _context.movie_director
                .Select(md => md.Person)
                .OrderByDescending(p => p.BirthDate)
                .FirstOrDefault();

            tbYD.Text = youngestDirector != null ? $"{youngestDirector.FirstName} {youngestDirector.LastName}" : "N/A";


        }

        private void lbMovies_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lbMovies.SelectedItem is Movie selectedMovie)
            {

                tbYear.Text = selectedMovie.Year.ToString();

                tbGenre.Text = selectedMovie.Genre.GenreName;

                var szoveg = "";

                // Színészek lekérdezése
                var actors = _context.movie_actor
                    .Where(ma => ma.MovieID == selectedMovie.MovieID)
                    .Select(ma => "Színész: " + ma.Person.FirstName + " " + ma.Person.LastName)
                    .ToList();

                szoveg += "Színészek:\n";
                szoveg += actors.Count() > 0 ? string.Join("\n", actors) + "\n\n" : "Nincs adat\n\n";

                // Rendezõk lekérdezése
                var directors = _context.movie_director
                    .Where(md => md.MovieID == selectedMovie.MovieID)
                    .Select(md => "Rendezõ: " + md.Person.FirstName + " " + md.Person.LastName)
                    .ToList();

                szoveg += "Rendezõk:\n";
                szoveg += directors.Count() > 0 ? string.Join("\n", directors) : "Nincs adat";

                tbPeople.Text = szoveg;

                tbRating.Text = Math.Round(selectedMovie.Rating).ToString();
            }
        }
        private void MIB_G(object sender, RoutedEventArgs e)
        {

        }
        private void MIB_M(object sender, RoutedEventArgs e)
        {

        }
        private void MIB_MA(object sender, RoutedEventArgs e)
        {

        }
        private void MIB_MD(object sender, RoutedEventArgs e)
        {

        }
        private void MIB_P(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_New(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Del(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Mod(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

