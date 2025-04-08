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

namespace FilmDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FejlesztokozpontContext ctx = new FejlesztokozpontContext();
        public MainWindow()
        {
            InitializeComponent();
            foreach (var item in ctx.Movie)
            {
                lbMovies.Items.Add(item.Title);
            }
        }

        private void lbMovieList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var title = (string)lbMovies.SelectedItem;
            var movie = ctx.Movie
                .Include(x => x.Genre)
                .Where(x => x.Title == title).FirstOrDefault();
            MovieToFields(movie);
        }
        private void MovieToFields(Movie movie, Person person)
        {
            if (movie == null)
                return;
            tbGenre.Text = movie.GenreID;
            tbDirector.Text = person.;
            tbYear.Text = movie.Year.ToString();
            tbDirector.Text = movie.Director;
            tbCountry.Text = movie.Country.Name;
            tbLanguage.Text = movie.Language;
            tbRuntime.Text = movie.Runtime.ToString();
        }
        // Adatok megjelenítése
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void MIS_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void MISA_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void MIP_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void lbMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}

