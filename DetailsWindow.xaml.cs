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
        #region fields

        private bool passwordHidden = true;
        private string password;
        private string name;

        #endregion

        #region constructors

        /// <summary>
        /// Constructor to edit
        /// </summary>
        /// <param name="id"></param>
        public DetailsWindow(Password pas)
        {
            Title = "Edit password";
            InitializeComponent();
            password = pas.VisiblePassword;
            name = pas.Name;
            UpdateGUI();
        }

        /// <summary>
        /// Constructor to add new
        /// </summary>
        public DetailsWindow()
        {
            Title = "Add new password";
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get set for password
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (value.Length > 0)
                    this.password = value;
            }
        }

        /// <summary>
        /// Get set for name
        /// </summary>
        public string GetName
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length > 0)
                    this.name = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updating gui
        /// </summary>
        private void UpdateGUI()
        {
            PasswordBox.Password = password;
            TextBoxName.Text = name;
        }

        /// <summary>
        /// On button save event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password.Length > 0 || TextBox.Text.Length > 0)
            {
                if (!passwordHidden)
                    password = TextBox.Text;
                else
                    password = PasswordBox.Password;
                name = TextBoxName.Text;
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("password or name can't be empty", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// On button show click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonShow_Click(object sender, RoutedEventArgs e)
        {
            if (passwordHidden)
            {
                TextBox.Text = PasswordBox.Password;
                PasswordBox.Visibility = System.Windows.Visibility.Hidden;
                TextBox.Visibility = System.Windows.Visibility.Visible;
                ButtonShow.Content = "Hide";
                passwordHidden = false;
            }
            else
            {
                PasswordBox.Password = TextBox.Text;
                TextBox.Visibility = System.Windows.Visibility.Hidden;
                PasswordBox.Visibility = System.Windows.Visibility.Visible;
                ButtonShow.Content = "Show";
                passwordHidden = true;
            }
        }

        #endregion
    }
}
