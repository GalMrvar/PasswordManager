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
    /// Interaction logic for SetMasterPasswordWindow.xaml
    /// </summary>
    public partial class SetMasterPasswordWindow : Window
    {
        #region fields

        private BrushConverter brushConverter;
        private string masterPassword;

        #endregion

        #region constructors

        public SetMasterPasswordWindow()
        {
            InitializeComponent();
            brushConverter = new BrushConverter();
        }

        #endregion

        #region Properties

        /// <summary>
        /// get method for master password
        /// </summary>
        public string MasterPassword
        {
            get
            {
                return this.masterPassword;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// On button save click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox1.Password.Equals(PasswordBox2.Password))
            {
                masterPassword = PasswordBox1.Password;
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Passwords don't match", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// On password 1 change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Password1ChangedEvent(object sender, RoutedEventArgs e)
        {
            CheckPasswordMatch();
        }

        /// <summary>
        /// On password 2 change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Password2ChangedEvent(object sender, RoutedEventArgs e)
        {
            CheckPasswordMatch();
        }

        /// <summary>
        /// checks if passwords mach and then sets values accordingly
        /// </summary>
        private void CheckPasswordMatch()
        {
            if(PasswordBox1.Password.Length == 0 && PasswordBox2.Password.Length == 0)
            {
                TextBoxMatch.Visibility = System.Windows.Visibility.Hidden;
                return;
            }
            if (PasswordBox1.Password.Equals(PasswordBox2.Password))
            {
                TextBoxMatch.Content = "Passwords match";
                TextBoxMatch.Foreground = (Brush)brushConverter.ConvertFrom("#48a921");
                TextBoxMatch.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                TextBoxMatch.Content = "Passwords don't match";
                TextBoxMatch.Foreground = new SolidColorBrush(Color.FromArgb(0xbb, 0x00, 0x00, 0x00));
                TextBoxMatch.Foreground = (Brush)brushConverter.ConvertFrom("#bb0000");
                TextBoxMatch.Visibility = System.Windows.Visibility.Visible;
            }
        }

        #endregion 
    }
}
