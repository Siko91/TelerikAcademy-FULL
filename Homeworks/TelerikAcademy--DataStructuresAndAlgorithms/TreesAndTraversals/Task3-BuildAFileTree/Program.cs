using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_BuildAFileTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("This might take some time...");
            ProcessFilesByPath("C:\\WINDOWS");

            //ProcessFilesByPath("..\\..\\..\\");
        }

        // Process all files in the directory passed in, recurse on any directories that are found,
        // and process the files they contain.
        public static MyDirectory ProcessDirectory(string targetDirectory)
        {
            try
            {
                // Process the list of files found in the directory.
                string[] fileEntries = Directory.GetFiles(targetDirectory);
                List<MyFile> files = new List<MyFile>();
                foreach (string fileName in fileEntries)
                    files.Add(ProcessFile(fileName));

                // Recurse into subdirectories of this directory.
                string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                List<MyDirectory> dirs = new List<MyDirectory>();
                foreach (string subdirectory in subdirectoryEntries)
                    dirs.Add(ProcessDirectory(subdirectory));

                return new MyDirectory(targetDirectory, dirs.ToArray(), files.ToArray());
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Exception: Can not read path " + targetDirectory + ". Skipping to next path...");
            }

            return new MyDirectory(targetDirectory, new MyDirectory[0], new MyFile[0]);
        }

        // Insert logic for processing found files here.
        public static MyFile ProcessFile(string path)
        {
            FileInfo file = new FileInfo(path);
            return new MyFile(file.Name, file.Length);
        }

        private static void ProcessFilesByPath(string path)
        {
            if (File.Exists(path))
            {
                // This path is a file
                MyFile file = ProcessFile(path);
                Console.WriteLine("File: " + file.Name + " has size of " + file.Size);
            }
            else if (Directory.Exists(path))
            {
                // This path is a directory
                MyDirectory dir = ProcessDirectory(path);
                Console.WriteLine("Dir: " + dir.Name + " has size of " + dir.GetSize());
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", path);
            }
        }
    }
}