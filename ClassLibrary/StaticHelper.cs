using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PasswordManager
{
    public static class StaticHelper<T>
    {
        /// <summary>
        /// Serializing passwords into xml file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool XmlSerialize(string filename, List<T> obj)
        {
            XmlSerializer s = new XmlSerializer(typeof(List<T>));
            TextWriter w = new StreamWriter(filename);
            try
            {
                s.Serialize(w, obj);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (w != null)
                    w.Close();
            }
        }

        /// <summary>
        /// Deserializing xml file
        /// </summary>
        /// <param name="filname"></param>
        /// <returns></returns>
        public static List<T> XmlDeserialize(string filename, List<T> obj)
        {
            XmlSerializer s = new XmlSerializer(typeof(List<T>));
            TextReader r = new StreamReader(filename);
            try
            {
                return obj = (List<T>)s.Deserialize(r);
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                if (r != null) r.Close();
            }
        }
    }
}
