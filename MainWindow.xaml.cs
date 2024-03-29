﻿using Microsoft.Win32;
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
        #region fields

        private MainController mainController;

        #endregion

        #region construcotr 

        public MainWindow()
        {
            mainController = new MainController();
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void UpdateGUI()
        {
            listBox.Items.Clear();
            foreach (Password pas in mainController.PasswordManager.Passwords)
                listBox.Items.Add(pas.Name);
        }

        /// <summary>
        /// Add new button event for adding new passwords
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddNew_Click(object sender, RoutedEventArgs e)
        {
            DetailsWindow window = new DetailsWindow(); //add new constructor
            if ((bool)window.ShowDialog() == false)
            {
                UpdateGUI();
                return;
            }
            else
            {
                Password pas = new Password(window.GetName, window.Password);
                if (mainController.PasswordManager.AddIfPossible(pas))
                {
                    UpdateGUI();
                    return;
                }
                else
                {
                    MessageBox.Show("Password with that name already exists");
                }
            }
        }

        /// <summary>
        /// Delete button event, deletes password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = listBox.SelectedIndex;
            if (index < 0)
                return;
            mainController.PasswordManager.RemovePassword(index); //removig password
            UpdateGUI();
        }

        /// <summary>
        /// event for unlocking passwords 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUnlock_Click(object sender, RoutedEventArgs e)
        {
            UnlockWindow unlockWindow = new UnlockWindow();
            if ((bool)unlockWindow.ShowDialog())
            {
                mainController.PasswordManager.MasterPassword = unlockWindow.MasterPassword;
                mainController.PasswordManager.DecryptPasswords();
            }
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
                if (!mainController.OpenPaswords(fileName))
                    MessageBox.Show("something went wrong please check for correct extension or corrupted file");
            }
            UpdateGUI();
        }

        /// <summary>
        /// On save option click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            SetMasterPasswordWindow window = new SetMasterPasswordWindow();
            if ((bool)window.ShowDialog() == false)
                return;

            mainController.PasswordManager.MasterPassword = window.MasterPassword; //setting master password
            mainController.PasswordManager.EncryptPasswords(); //Encrypting passwords
            string fileName;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML Files (*.xml)|*.xml"; //only for xml
            saveFileDialog1.DefaultExt = "xml";
            saveFileDialog1.AddExtension = true;

            if ((bool)saveFileDialog1.ShowDialog())
            {
                fileName = saveFileDialog1.FileName;  //important

                if (!mainController.SavePaswords(fileName))
                    MessageBox.Show("Something went wrong");
            }
        }

        /// <summary>
        /// On double click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_DoubleClick(object sender, RoutedEventArgs e)
        {
            int index = listBox.SelectedIndex;
            if (index < 0)
                return;
            Password pas = new Password(mainController.PasswordManager.GetPassword(index));
            DetailsWindow window = new DetailsWindow(pas); //add new constructor
            if ((bool)window.ShowDialog() == false)
            {
                UpdateGUI();
                return;
            }
            else
            {
                pas = new Password(window.GetName, window.Password);
                if (mainController.PasswordManager.UpdatePassword(index, pas))
                {
                    UpdateGUI();
                    return;
                }
            }

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        #endregion
    }
}
