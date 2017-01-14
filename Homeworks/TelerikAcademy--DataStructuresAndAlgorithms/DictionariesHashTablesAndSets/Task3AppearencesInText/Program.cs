using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task1OccurenceCounter;

namespace Task3AppearencesInText
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<string> words = ReadFromFile("..\\..\\TextFile.txt");
            AppearenceCounter<string> appearenceCount = new AppearenceCounter<string>(words);
            var orderedAppearences = appearenceCount.Appearences.OrderBy(a => a.Value);
            foreach (var item in orderedAppearences)
            {
                Console.WriteLine(item.Key + " ==> " + item.Value + " times");
            }
        }

        private static List<string> ReadFromFile(string path)
        {
            char[] seperators = new char[] { ' ', '.', ',', '!', '?', '-', '-' };
            List<string> words = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] wordsOnLine = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in wordsOnLine)
                    {
                        words.Add(word.ToLowerInvariant());
                    }
                    line = reader.ReadLine();
                }
            }
            return words;
        }
    }
}