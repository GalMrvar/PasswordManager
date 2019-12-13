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

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        /// <summary>
        /// Constructor to edit
        /// </summary>
        /// <param name="id"></param>
        public DetailsWindow(int id)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor to add new
        /// </summary>
        public DetailsWindow()
        {
            Title = "Add new password";
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonShow_Click(object sender, RoutedEventArgs e)
        {
            //https://stackoverflow.com/questions/31040510/c-sharp-wpf-unmask-password-inside-the-passwordbox
        }
    }
}
