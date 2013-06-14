using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace wpf_Pong
{
    class PropertiesFile
    {
        #region Field region

        private static string map;
        private static string ext;

        #endregion

        #region Constructor Region

        public PropertiesFile(string mapPath, string file)
        {
            map = mapPath + "Config\\"; //Environment.CurrentDirectory + "\\config\\";
            ext = map + file; //map + "Config.Tk";
        }

        #endregion

        #region Method Region

        public static Boolean Save(Dictionary<string, string> dictionnary)
        {
            try{
                Directory.CreateDirectory(map);
            }
            catch{/*map bestaat al */}
            try
            {
                using (TextWriter tw = new StreamWriter(ext))
                {
                    foreach (KeyValuePair<string, string> s in dictionnary)
                    {
                        tw.WriteLine(s.Key +"="+ s.Value);
                    }
                    tw.Close();
                } return true;
            }
            catch
            {
                //ingebruik of geen rechten
                return false;
            }
        }

        public static Dictionary<string, string> Load()
        {
            Dictionary<string, string> ls = new Dictionary<string, string>();
            string file = ext;
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string key = line.Split('=')[0];
                        string value = line.Split('=')[1];
                        ls.Add(key , value);
                    }
                }
                return ls;
            }
            catch
            {
                return ls;
            }
        }

        

        #endregion
    }
}
