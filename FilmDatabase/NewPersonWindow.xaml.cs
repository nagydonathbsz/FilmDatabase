using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FilmDatabase.Models;

namespace FilmDatabase
{
    /// <summary>
    /// Interaction logic for NewPersonWindow.xaml
    /// </summary>
    public partial class NewPersonWindow : Window
    {
        public NewPersonWindow()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new FejlesztokozpontContext())
                {
                    var person = new Person
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Nationality = txtNationality.Text,
                        BirthDate = dpBirthDate.SelectedDate ?? DateTime.Now
                    };
                    context.people.Add(person);
                    context.SaveChanges();
                    MessageBox.Show("Személy hozzáadva.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt: {ex.Message}");
            }
        }
    }
}
