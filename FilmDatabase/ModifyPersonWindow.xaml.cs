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

namespace FilmDatabase
{
    /// <summary>
    /// Interaction logic for ModifyPersonWindow.xaml
    /// </summary>
    public partial class ModifyPersonWindow : Window
    {
        public ModifyPersonWindow()
        {
            InitializeComponent();
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
                using (var context = new FejlesztokozpontContext())
                {
                    var person = context.people.FirstOrDefault(p => p.PersonID == txtPersonId.Text);
                    if (person != null)
                    {
                        person.FirstName = txtFirstName.Text;
                        person.LastName = txtLastName.Text;
                        person.BirthDate = dpBirthDate.SelectedDate ?? person.BirthDate;
                        context.SaveChanges();
                        MessageBox.Show("Személy módosítva.");
                        this.Close();
                    }
                    else MessageBox.Show("Személy nem található.");
                }
        }
    }
}
