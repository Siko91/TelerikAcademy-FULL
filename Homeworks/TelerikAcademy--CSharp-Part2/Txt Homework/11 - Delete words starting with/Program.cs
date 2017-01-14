using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _11___Delete_words_starting_with
{

    class Program
    {
        static private string nums = "_0123456789";
        static private string alphaUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static private string alphaLow = alphaUp.ToLower();

        static public string alowedChars = (nums + alphaUp + alphaLow);

        static void Main(string[] args)
        {
            string prefix = "test";
            List<string> list = new List<string>();

            using (StreamWriter create = new StreamWriter(@"..\..\11-File.txt"))
            {
                create.WriteLine("tests tested testing testІgo");
                create.WriteLine("TEsTed ttested .tested");
                create.WriteLine("test: Tests! do.testMytest");
                create.WriteLine("tests test_s _tesers Tester's");
            }
            using (StreamReader read = new StreamReader(@"..\..\11-File.txt"))
            {
                Console.WriteLine("Text:\n\n");

                string line = read.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    list.Add(line);
                    line = read.ReadLine();
                }
                Console.WriteLine("\n\n=========================================");
                Console.WriteLine();
            }
            using (StreamWriter rewrite = new StreamWriter(@"..\..\11-File.txt"))
            {
                for (int line = 0; line < list.Count(); line++)
                {
                    int start = -1, end = -1;
                    int actualEnd = -1;
                    for (int position = 0; position < list[line].Length - prefix.Length; position++)
                    {
                        if (list[line].Substring(position, prefix.Length).Equals(prefix, StringComparison.InvariantCultureIgnoreCase))
                        {
                            start = position;
                            end = position + prefix.Length;

                            bool startIsFine = CheckStart(list[line], start);
                            actualEnd = CheckEnd(list[line], end);

                            if (startIsFine && end < actualEnd)
                            {
                                list[line] = RemoveWord(list[line], start, actualEnd);
                            }
                        }
                    }
                    Console.WriteLine(list[line]);
                }
                Console.WriteLine("\n");
            }
        }
        static bool CheckStart(string str, int start)
        {
            if (start == 0) return true;
            for (int i = 0; i < alowedChars.Length; i++)
            {
                if (str.Substring(start-1,1).Equals(alowedChars.Substring(i,1)))
                {
                    return false; // it's not a prefix if it's like "AAAAAtestAAAA123"
                }
            }
            return true;
        }
        static int CheckEnd(string str, int end)
        {
            if (end == str.Length - 1) return end; // It's only prefix if there's more to it.
            int position;
            for (position = end+1; position < str.Length; position++)
            {

                bool isAlowedChar = false;
                foreach (char ch in alowedChars)
                {
                    if (str.Substring(position,1).Equals(ch.ToString()))
                    {
                        isAlowedChar = true;
                        break;
                    }
                }
                if (!isAlowedChar)
                    return position;
            }
            return str.Length;
        }
        static string RemoveWord(string str, int start, int end)
        {
            string result = str.Substring(0, start) + "<**>" + str.Substring(end);
            return result;
        }
    }
}
