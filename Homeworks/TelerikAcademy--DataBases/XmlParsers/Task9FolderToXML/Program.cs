using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task9FolderToXML
{
    internal class Program
    {
        public static void ProcessDirectory(string targetDirectory)
        {
            try
            {
                writer.WriteRaw(GetOpeningElement("dir", targetDirectory));

                // Process the list of files found in the directory.
                string[] fileEntries = Directory.GetFiles(targetDirectory);
                foreach (string fileName in fileEntries)
                    ProcessFile(fileName);

                // Recurse into subdirectories of this directory.
                string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                foreach (string subdirectory in subdirectoryEntries)
                    ProcessDirectory(subdirectory);

                writer.WriteRaw(@"</dir>");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Exception: Can not read path " + targetDirectory + ". Skipping to next path...");
            }
        }

        // Insert logic for processing found files here.
        public static void ProcessFile(string path)
        {
            writer.WriteRaw(GetOpeningElement("file", path));
            writer.WriteRaw(@"</file>");
        }

        private static XmlWriter writer;

        private static string GetOpeningElement(string elementType, string elementName)
        {
            return @"<" + elementType + " name=" + "\"" + elementName + "\"" + @">";
        }

        private static void Main(string[] args)
        {
            using (writer = XmlWriter.Create("..\\..\\DirsAndFiles.xml"))
            {
                WriteFilesByPath("..\\..\\");
            }
        }

        private static void WriteFilesByPath(string path)
        {
            writer.WriteRaw(GetOpeningElement("MainFolder", path));
            if (File.Exists(path))
            {
                // This path is a file
                ProcessFile(path);
            }
            else if (Directory.Exists(path))
            {
                // This path is a directory
                ProcessDirectory(path);
            }
            writer.WriteRaw(@"</MainFolder>");
        }
    }
}