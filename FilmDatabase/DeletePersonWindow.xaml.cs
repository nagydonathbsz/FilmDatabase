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
    /// Interaction logic for DeletePersonWindow.xaml
    /// </summary>
    public partial class DeletePersonWindow : Window
    {
        public DeletePersonWindow()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
          
                using (var context = new FejlesztokozpontContext())
                {
                    var person = context.people.FirstOrDefault(p => p.PersonID == txtPersonId.Text);
                    if (person != null)
                    {
                        context.people.Remove(person);
                        context.SaveChanges();
                        MessageBox.Show("Személy törölve.");
                        this.Close();
                    }
                    else MessageBox.Show("Személy nem található.");
                }
        }
    }
}
