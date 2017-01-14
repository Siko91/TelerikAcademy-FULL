using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security;

class Program
{
    static string wordsPath = @"..\..\12-WordList.txt";
    static string filePath = @"..\..\12-File.txt";

    static void Main(string[] args)
    {
        List<string> wordsArr = new List<string>();
        List<string> linesArr = new List<string>();

        try
        {
            Console.WriteLine("Creating a file with key words...");
            using (StreamWriter wordAdder = new StreamWriter(wordsPath))
            {
                wordAdder.WriteLine("one two three");
                wordAdder.WriteLine("one four");
                wordAdder.WriteLine("five six");
                wordAdder.WriteLine("seven");
            }
            Console.WriteLine("Creating a file with text...");
            using (StreamWriter fileCreator = new StreamWriter(filePath))
            {
                fileCreator.WriteLine("One bottle two rings three flags");
                fileCreator.WriteLine("DoNotRemoveThisone fourty");
                fileCreator.WriteLine("five, or six");
                fileCreator.WriteLine("seven'th");
            }
            Console.WriteLine("Reading key words...");
            using (StreamReader wordReader = new StreamReader(wordsPath))
            {
                string line = wordReader.ReadLine();
                while (line != null)
                {
                    string[] words = line.Split(' ');
                    foreach (string word in words)
                        if (word.Length > 0)
                            wordsArr.Add(word);
                    line = wordReader.ReadLine();
                }
            }
            Console.WriteLine("Reading text files...");
            using (StreamReader fileReader = new StreamReader(filePath))
            {
                string line = fileReader.ReadLine();
                while (line != null)
                {
                    linesArr.Add(line);
                    line = fileReader.ReadLine();
                }
            }
            Console.WriteLine("Deleting words from file...\n\n\nResults:\n");
            using (StreamWriter fileRewriter = new StreamWriter(filePath))
            {
                for (int i = 0; i < linesArr.Count(); i++)
                {
                    Console.WriteLine("\n------ Line " + i + " ------");
                    Console.WriteLine("{0,15}'" + linesArr[i] + "'", "Before: ");
                    foreach (string word in wordsArr)
                    {
                        linesArr[i] = DeleteWordInLine(linesArr[i], word);
                        fileRewriter.WriteLine(linesArr[i]);
                    }
                    Console.WriteLine("{0,15}'" + linesArr[i] + "'", "After: ");
                }
            }
            Console.WriteLine();
        }
        catch (UnauthorizedAccessException)
        { Console.WriteLine("UnauthorizedAccessException"); throw; }
        catch (ArgumentNullException)
        { Console.WriteLine("ArgumentNullException"); throw; }
        catch (ArgumentException) 
        { Console.WriteLine("ArgumentException"); throw; }
        catch (PathTooLongException) 
        { Console.WriteLine("PathTooLongException"); throw; }
        catch (DirectoryNotFoundException) 
        { Console.WriteLine("DirectoryNotFoundException"); throw; }
        catch (IOException) 
        { Console.WriteLine("IOException"); throw; }
        catch (SecurityException) 
        { Console.WriteLine("SecurityException"); throw; }
        catch (IndexOutOfRangeException) 
        { Console.WriteLine("IndexOutOfRangeException"); throw; }
        catch (Exception) 
        { Console.WriteLine("Some Other Exception..."); throw; }
    }

    static string DeleteWordInLine(string line, string word)
    {
        try
        {
            for (int i = 0; i < line.Length-word.Length+1; i++)
            {
                if (line.Substring(i,word.Length).Equals(word, StringComparison.InvariantCultureIgnoreCase))
                {
                    StringBuilder temp = new StringBuilder();
                    temp.Append(line.Substring(0, i));
                    temp.Append(line.Substring(i+word.Length));

                    line = temp.ToString();
                }
            }
            return line;
        }
        catch (Exception e) // i'm lazy, so i'll leave it like that.
        {
            Console.WriteLine("Some exception has occured...");
            Console.WriteLine(e.Message);
            return line;
            throw;
        }
    }
}
