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
    static string resultPath = @"..\..\12-Result.txt";


    static void Main(string[] args)
    {
        List<string> wordsArr = new List<string>();
        List<int> wordsCounts = new List<int>();
        List<string> linesArr = new List<string>();

        try
        {
            Console.WriteLine("Creating a file with key words...");
            using (StreamWriter wordAdder = new StreamWriter(wordsPath))
            {
                wordAdder.WriteLine("one two three");
                wordAdder.WriteLine("one four");
                wordAdder.WriteLine("five six");
                wordAdder.WriteLine("eight seven");
            }
            Console.WriteLine("Creating a file with text...");
            using (StreamWriter fileCreator = new StreamWriter(filePath))
            {
                fileCreator.WriteLine("One bottle two rings three flags");
                fileCreator.WriteLine("DoNotRemoveThisone fourty");
                fileCreator.WriteLine("five, or six");
                fileCreator.WriteLine("seven'th fives");
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
                        {
                            bool isNotListed = true;
                            for (int i = 0; i < wordsArr.Count(); i++)
                            {
                                if (word.Equals(wordsArr[i]))
                                {
                                    isNotListed = false;
                                    break;
                                }
                            }
                            if (isNotListed)
                            {
                                wordsArr.Add(word);
                                wordsCounts.Add(0);
                            }
                        }
                    line = wordReader.ReadLine();
                }
            }
            Console.WriteLine("Reading text file...");
            using (StreamReader fileReader = new StreamReader(filePath))
            {
                string line = fileReader.ReadLine();
                while (line != null)
                {
                    linesArr.Add(line);
                    line = fileReader.ReadLine();
                }
            }
            Console.WriteLine("Counting...");
            using (StreamWriter resultFile = new StreamWriter(resultPath))
            {
                for (int i = 0; i < wordsArr.Count(); i++)
                {
                    foreach (string line in linesArr)
                    {
                        wordsCounts[i] += CountWords(line, wordsArr[i]);
                    }
                }
                Console.WriteLine("Sorting...");
                for (int startPosition = 0; startPosition < wordsArr.Count(); startPosition++)
                {
                    for (int endPosition = 0; endPosition < wordsArr.Count(); endPosition++)
                    {
                        if (wordsCounts[startPosition] > wordsCounts[endPosition] || endPosition == wordsArr.Count())
                        {
                            if (startPosition < endPosition)
                            {
                                wordsArr.Insert(endPosition, wordsArr[startPosition]);
                                wordsArr.RemoveAt(startPosition);

                                wordsCounts.Insert(endPosition, wordsCounts[startPosition]);
                                wordsCounts.RemoveAt(startPosition);
                            }
                            else
                            {
                                wordsArr.Insert(endPosition, wordsArr[startPosition]);
                                wordsArr.RemoveAt(startPosition + 1);

                                wordsCounts.Insert(endPosition, wordsCounts[startPosition]);
                                wordsCounts.RemoveAt(startPosition + 1);
                            }
                        }
                    }
                }
                Console.WriteLine("Writing...\n");
                for (int i = 0; i < wordsArr.Count(); i++)
                {
                    Console.WriteLine("'" + wordsArr[i] + "' - " + wordsCounts[i]);
                    resultFile.WriteLine("'" + wordsArr[i] + "' - " + wordsCounts[i]);
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
        catch (Exception e )
        { Console.WriteLine("Some Other Exception...\n" + e.Message); throw; }
    }
    static int CountWords(string str, string word)
    {
        try
        {
            int appearences = 0;

            for (int i = 0; i < str.Length-word.Length+1; i++)
            {
                if (str.Substring(i,word.Length).Equals(word))
                {
                    appearences++;
                }
            }

            return appearences;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return 0;
            throw;
        }
    }
}
