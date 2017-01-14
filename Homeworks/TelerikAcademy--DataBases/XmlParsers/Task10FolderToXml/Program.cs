using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Task10FolderToXml
{
    internal class Program
    {
        public static void ProcessDirectory(string targetDirectory, XElement parent)
        {
            try
            {
                var dir = new XElement("dir",
                    new XAttribute("Name", targetDirectory));
                parent.Add(dir);

                // Process the list of files found in the directory.
                string[] fileEntries = Directory.GetFiles(targetDirectory);
                foreach (string fileName in fileEntries)
                    ProcessFile(fileName, dir);

                // Recurse into subdirectories of this directory.
                string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                foreach (string subdirectory in subdirectoryEntries)
                    ProcessDirectory(subdirectory, dir);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Exception: Can not read path " + targetDirectory + ". Skipping to next path...");
            }
        }

        // Insert logic for processing found files here.
        public static void ProcessFile(string path, XElement parent)
        {
            parent.Add(new XElement("file",
                new XAttribute("Name", path)));
        }

        private static void Main(string[] args)
        {
            WriteFilesByPath("..\\..\\");
        }

        private static void WriteFilesByPath(string path)
        {
            XElement mainFilder = new XElement("MainFolder");
            if (File.Exists(path))
            {
                // This path is a file
                ProcessFile(path, mainFilder);
            }
            else if (Directory.Exists(path))
            {
                // This path is a directory
                ProcessDirectory(path, mainFilder);
            }
            mainFilder.Save("..\\..\\DirsAndFiles.xml");
        }
    }
}