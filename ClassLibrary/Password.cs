using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class Password
    {
        #region fields

        private string name;
        private string password;
        private string hash;

        #endregion

        #region Constructors
        public Password()
        {

        }
        #endregion


        #region properties

        /// <summary>
        /// Get set name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length > 0)
                    name = value;
            }
        }

        /// <summary>
        /// Get set password
        /// </summary>
        public string VisiblePassword
        {
            get
            {
                return password;
            }
            set
            {
                if (value.Length > 0)
                    password = value;
            }
        }

        /// <summary>
        /// Get set hash
        /// </summary>
        public string Hash
        {
            get
            {
                return hash;
            }
            set
            {
                if (value.Length > 0)
                    hash = value;
            }
        }

        #endregion 

    }
}
