using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SazaracsMagicSword.Data
{
    public static class LoadData
    {
        public static string[] LoadFile(string fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Valid filename must be provided!");

            List<string> fileData = new List<string>(50);
            string line;

            StreamReader reader = null;

            try
            {
                reader = new StreamReader(fileName, Encoding.Unicode);
                while ((line = reader.ReadLine()) != null)
                {
                    fileData.Add(line);
                }
            }

            catch (System.IO.IOException ex)
            {
                throw new Exception("Error: Could not read file from disk. Original error: " + ex.Message);
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return fileData.ToArray();
        }
    }
}
