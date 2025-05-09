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
            var topGenre = _context.movie
                .GroupBy(m => m.Genre.GenreName)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            tbGp.Text = topGenre != null ? topGenre : "N/A";

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

                // Rendezők lekérdezése
                var directors = _context.movie_director
                    .Where(md => md.MovieID == selectedMovie.MovieID)
                    .Select(md => "Rendező: " + md.Person.FirstName + " " + md.Person.LastName)
                    .ToList();

                szoveg += "Rendezők:\n";
                szoveg += directors.Count() > 0 ? string.Join("\n", directors) : "Nincs adat";

                tbPeople.Text = szoveg;

                tbRating.Text = Math.Round(selectedMovie.Rating, 2).ToString();
            }
        }
        string sb = "";
        private void MIB_G(object sender, RoutedEventArgs e)
        {

            sb = "g";
            tbSb.IsEnabled = true;
            tbSb.Text = "";
        }
        private void MIB_M(object sender, RoutedEventArgs e)
        {

            sb = "m";
            tbSb.IsEnabled = true;
            tbSb.Text = "";
        }
        private void MIB_Y(object sender, RoutedEventArgs e)
        {
            sb = "y";
            tbSb.IsEnabled = true;
            tbSb.Text = "";
        }
        private void MIB_R(object sender, RoutedEventArgs e)
        {
            sb = "r";
            tbSb.IsEnabled = true;
            tbSb.Text = "";
        }

        private void Btn_New(object sender, RoutedEventArgs e)
        {

            var window = new NewPersonWindow();
            window.ShowDialog();

        }

        private void Btn_Del(object sender, RoutedEventArgs e)
        {
            var window = new DeletePersonWindow();
            window.ShowDialog();
        }

        private void Btn_Mod(object sender, RoutedEventArgs e)
        {
            var window = new ModifyPersonWindow();
            window.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbSb_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbMovies.ItemsSource = "";
            switch (sb)
            {
                case "g":
                    {
                        var mf = tbSb.Text;

                        var search = _context.movie.Where(m => m.Genre.GenreName.ToLower().IndexOf(mf) != -1)
                            .ToList();
                        lbMovies.ItemsSource = search;
                        break;
                    }
                case "m":
                    {
                        var mf = tbSb.Text;

                        var search = _context.movie.Where(m => m.Title.ToLower().IndexOf(mf) != -1)
                            .ToList();
                        lbMovies.ItemsSource = search;
                        break;
                    }
                case "y":
                    {
                        var mf = tbSb.Text;

                        var search = _context.movie.Where(m => m.Year.ToString().IndexOf(mf) != -1).ToList();

                        lbMovies.ItemsSource = search;
                        break;
                    }

                case "r":
                    {
                        var mf = tbSb.Text;

                        var search = _context.movie.Where(m => m.Rating.ToString().IndexOf(mf) != -1)
                            .ToList();
                        lbMovies.ItemsSource = search;
                        break;
                    }
            }
        }
    }
}

