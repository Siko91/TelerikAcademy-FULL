using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _03___read_file_exceptions
{
    class Program
    {
        static string path = @"..\..\file.txt";

        static void Main(string[] args)
        {
            try
            {
                using (StreamReader file = new StreamReader(path))
                {
                    char ch;
                    int i;

                    for (;(i = file.Read()) > -1;)
                    {
                        ch = (char)i;
                        Console.Write(ch);
                    }
                }
                Console.WriteLine("\n");
            }
            catch (ArgumentNullException)
            { Console.WriteLine("There is no path for that file"); }
            catch (ArgumentException)
            { Console.WriteLine("The directory to the file is invalid."); }
            catch (FileNotFoundException)
            { Console.WriteLine("The program could not find such a file in the specified directory."); }
            catch (DirectoryNotFoundException)
            { Console.WriteLine("The program could not find this directory."); }
            catch (IOException)
            { Console.WriteLine("There is an input/output error."); }
        }
    }
}
