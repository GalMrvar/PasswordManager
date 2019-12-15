using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Methods
        /// <summary>
        /// Add new button event for adding new passwords
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddNew_Click(object sender, RoutedEventArgs e)
        {
            DetailsWindow window = new DetailsWindow(); //add new constructor
            window.ShowDialog();
        }

        /// <summary>
        /// Delete button event, deletes password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// event for unlocking passwords 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUnlock_Click(object sender, RoutedEventArgs e)
        {
            UnlockWindow unlockWindow = new UnlockWindow();
            unlockWindow.ShowDialog();
        }

        /// <summary>
        /// To open saved files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML Files (*.xml)|*.xml"; //only for xml

            string fileName;

            if ((bool)openFileDialog1.ShowDialog())
            {
                fileName = openFileDialog1.FileName;  //important
                string errorMsg = string.Empty;
                //if (!mainFormController.EstateManager.BinaryDeserialize(fileName))
                 //   MessageBox.Show("something went wrong please check for correct extension or corrupted file");
            }
        }

        /// <summary>
        /// On save option click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            SetMasterPasswordWindow window = new SetMasterPasswordWindow();
            window.ShowDialog();

            string fileName;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML Files (*.xml)|*.xml"; //only for xml
            saveFileDialog1.DefaultExt = "xml";
            saveFileDialog1.AddExtension = true;

            if ((bool)saveFileDialog1.ShowDialog())
            {
                fileName = saveFileDialog1.FileName;  //important

                //if (!mainFormController.EstateManager.BinarySerialize(fileName))
                  //  MessageBox.Show("Something went wrong");
            }
        }

        #endregion
    }
}
