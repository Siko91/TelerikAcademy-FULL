using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static string str = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
    static string[] words = { "PHP", "CLR", "Microsoft" };

    static string Censure(string str, string[] words)
    {
        for (int i = 0; i < words.Length; i++)
        {
            string replacement = new String('*', words[i].Length);
            int index = str.IndexOf(words[i], 0, StringComparison.InvariantCultureIgnoreCase);
            while (index != -1)
            {
                str = str.Substring(0, index) + replacement + str.Substring(index+words[i].Length);
                index = str.IndexOf(words[i], index + 1, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        return str;
    }

    static void Main(string[] args)
    {
        string censured = Censure(str, words);
        Console.WriteLine("Censured:\n" + censured + "\n");
        Console.WriteLine("Original:\n" + str + "\n");
    }
}
