// For Directory.GetFiles and Directory.GetDirectories For File.Exists, Directory.Exists
using System;
using System.Collections;
using System.IO;

namespace Task2_PrintFilesInFolder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // do NOT use with C\WINDOWS! It takes waaay to long! (It has too many files.)
            //PrintFilesByPath("C:\\WINDOWS");
            PrintFilesByPath("..\\..\\..\\");
        }

        // Process all files in the directory passed in, recurse on any directories that are found,
        // and process the files they contain.
        public static void ProcessDirectory(string targetDirectory)
        {
            try
            {
                Console.WriteLine("Reading directory '{0}'.", targetDirectory);

                // Process the list of files found in the directory.
                string[] fileEntries = Directory.GetFiles(targetDirectory);
                foreach (string fileName in fileEntries)
                    ProcessFile(fileName);

                // Recurse into subdirectories of this directory.
                string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                foreach (string subdirectory in subdirectoryEntries)
                    ProcessDirectory(subdirectory);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Exception: Can not read path " + targetDirectory + ". Skipping to next path...");
            }
        }

        // Insert logic for processing found files here.
        public static void ProcessFile(string path)
        {
            Console.WriteLine("-- Processed file '{0}'.", path);
        }

        private static void PrintFilesByPath(string path)
        {
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
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", path);
            }
        }
    }
}