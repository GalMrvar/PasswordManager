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
    public partial class UnlockWindow : Window
    {
        #region Fields
        private string masterPassword;
        private bool passwordHidden = true;
        #endregion

        #region constructors

        /// <summary>
        /// Constructor to edit
        /// </summary>
        /// <param name="id"></param>
        public UnlockWindow(int id)
        {
            Title = "Eddit password new password";
            InitializeComponent();
        }

        /// <summary>
        /// Constructor to add new
        /// </summary>
        public UnlockWindow()
        {
            Title = "Add new password";
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// get for master password
        /// </summary>
        public string MasterPassword
        {
            get
            {
                return masterPassword;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Done button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDone_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password.Length > 0)
            {
                masterPassword = PasswordBox.Password;
                this.Close();
            }
            else
            {
                MessageBox.Show("password box can't be empty", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Showing password button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonShow_Click(object sender, RoutedEventArgs e)
        {
            if (passwordHidden)
            {
                PasswordBox.Visibility = System.Windows.Visibility.Hidden;
                TextBox.Text = PasswordBox.Password;
                TextBox.Visibility = System.Windows.Visibility.Visible;
                passwordHidden = false;
            }
            else
            {
                TextBox.Visibility = System.Windows.Visibility.Hidden;
                PasswordBox.Password = TextBox.Text;
                PasswordBox.Visibility = System.Windows.Visibility.Visible;
                passwordHidden = true;
            }
        }

        #endregion
    }
}
