using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class PasswordManager
    {
        #region fields

        private List<Password> passwords;
        private string masterPassword;

        #endregion

        #region Constructors
        public PasswordManager()
        {
            Passwords = new List<Password>();
        }
        #endregion

        #region Properties

        /// <summary>
        /// get set list of passwords
        /// </summary>
        public List<Password> Passwords
        {
            get
            {
                return passwords;
            }
            set
            {
                passwords = value;
            }
        }

        /// <summary>
        /// Get set master password
        /// </summary>
        public string MasterPassword
        {
            get
            {
                return masterPassword;
            }
            set
            {
                if(value.Length > 0)
                    masterPassword = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Encrypting all passwords
        /// </summary>
        /// <returns></returns>
        public bool EncryptPasswords()
        {
            foreach (Password password in passwords)
            {
                password.Hash = Encrypt(password.VisiblePassword);
            }
            return true;
        }

        /// <summary>
        /// Decrypting all passwords
        /// </summary>
        /// <returns></returns>
        public bool DecryptPasswords()
        {
            foreach (Password password in passwords)
            {
                if (!string.IsNullOrEmpty(password.Hash) && string.IsNullOrEmpty(password.VisiblePassword))
                {
                    try
                    {
                        password.VisiblePassword = Decrypt(password.Hash);

                    }catch(Exception e) //In case of wrong password we just skip the exception
                    {

                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Adding new password
        /// </summary>
        /// <returns>false if password name already exists</returns>
        public bool AddIfPossible(Password pas)
        {
            foreach(Password password in passwords)
            {
                if (password.Name == pas.Name) //Password already exists
                    return false;
            }
            passwords.Add(pas);
            return true;
        }
        
        /// <summary>
        /// removing password on index
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemovePassword(int id)
        {
            passwords.RemoveAt(id);
            return true;
        }

        /// <summary>
        /// Getting password by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Password GetPassword(int id)
        {
            return passwords[id];
        }

        /// <summary>
        /// Updating password
        /// </summary>
        /// <param name="pas"></param>
        /// <returns></returns>
        public bool UpdatePassword(int index, Password pas)
        {
            passwords[index] = pas;
            return true;
        }

        /// <summary>
        /// Method used to encrypt passwords
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns></returns>
        private string Encrypt(string clearText)
        {
            string EncryptionKey = masterPassword;
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        /// <summary>
        /// Method used to decrypt passwords
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        private string Decrypt(string cipherText)
        {
            string EncryptionKey = masterPassword;
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        #endregion
    }
}

