using System;
using System.Collections.Generic;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Win32;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Controls;

namespace FilmDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Movie> movielist;
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            PopulateListBox();
            DataContext = this;


        }

        private void LoadData()
        {
            try
            {
                string filePath = @"movies.json";
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("The JSON file does not exist!");
                    return;
                }

                string jsonToString = File.ReadAllText(filePath);
                if (string.IsNullOrWhiteSpace(jsonToString))
                {
                    MessageBox.Show("The JSON file is empty!");
                    return;
                }

                movielist = JsonConvert.DeserializeObject<List<Movie>>(jsonToString) ?? new List<Movie>();
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Error deserializing JSON data: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }
        private void PopulateListBox()
        {
            lbMovies.Items.Clear();
            lbMovies.ItemsSource = movielist;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void MIS_Click(object sender, RoutedEventArgs e)
        {
            var movielistString = new List<string>();

            foreach (var item in movielist) { movielistString.Add(item.ToString()); }


            File.WriteAllLines(@"savedFile.txt", movielistString.ToArray());
            if (File.Exists(@"savedFile.txt")) { MessageBox.Show("The file has been saved."); }
        }
        private void MISA_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "TXT Format (*.txt) | *.txt | All files (*.*)| *.*";
            dlg.FilterIndex = 2;
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(dlg.FileName.ToString());
                foreach (var i in movielist)
                {
                    file.WriteLine(i.ToString());
                }
                file.Close();

                if (file != null) { MessageBox.Show($"The file has been saved!"); }
            }
        }
        private void MIP_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if ((pd.ShowDialog() == true))
            {
                pd.PrintVisual(Gbasic as Visual, "printing as visual");
            }
        }

        private void lbMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = lbMovies.SelectedItem.ToString().Split(';');
            tbTitle.Text = selectedItem[1];
            tbYear.Text = selectedItem[2];
            tbGenre.Text = selectedItem[3];
            tbDirector.Text = selectedItem[4];
            tbRating.Text = selectedItem[5];
        }
    }
}

