﻿using System;
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
            using (var context = new FejlesztokozpontContext())
            {
                var lastPerson = context.people.OrderByDescending(p => p.PersonID).FirstOrDefault();
                var newPersonID = lastPerson != null ? "P0" + (int.Parse(lastPerson.PersonID.Substring(1)) + 1).ToString() : "1";

                var person = new Person
                {
                    PersonID = newPersonID,
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
    }
}
