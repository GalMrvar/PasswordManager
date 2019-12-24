using System;
using System.Collections.Generic;

namespace PasswordManager
{
    public class MainController
    {

        #region fields

        private PasswordManager passwordManager;

        #endregion

        #region constructor
        public MainController()
        {
            passwordManager = new PasswordManager();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get set for password manager
        /// </summary>
        public PasswordManager PasswordManager
        {
            get
            {
                return passwordManager;
            }
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// saving passwords to xml file
        /// </summary>
        /// <returns></returns>
        public bool SavePaswords(string filename)
        {
            return StaticHelper<Password>.XmlSerialize(filename, passwordManager.Passwords);
        }

        /// <summary>
        /// Opening new passowrds and saving them into list
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool OpenPaswords(string filename)
        {
            List<Password> list = StaticHelper<Password>.XmlDeserialize(filename);
            if (list == null)
            {
                return false;
            }
            else
            {
                foreach(Password pas in list)
                {
                    passwordManager.AddIfPossible(pas);
                }
                return true;
            }
        }

        #endregion
    }
}
