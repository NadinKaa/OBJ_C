using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingObjFormat
{
    class TextFileLoader
    {
        // Singleton
        private TextFileLoader() { }
        private static TextFileLoader _instance;
        public static TextFileLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TextFileLoader();
                }
                return _instance;
            }
        }

        public string LoadTextFile(string fileName)
        {
            string fileContent = null;

            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    fileContent = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("TextFileLoader.cs. LoadTextFile(). " + e.Message);
                return null;
            }
            return fileContent;
        }
    }
}
