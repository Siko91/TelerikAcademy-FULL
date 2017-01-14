using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _20___Extract_Polidromes
{
    class Program
    {
        static string text = "aaaaa ok is goggog frog the main ini geeeg appa appolo";

        static void Main(string[] args)
        {
            MatchCollection words = Regex.Matches(text, @"\w+");
            foreach (Match word in words)
            {
                bool isPoli = true;
                for (int i = 0; i < word.Value.Length; i++)
                {
                    if (!(word.Value.Substring(i, 1).Equals(word.Value.Substring(word.Value.Length - 1 - i, 1))))
                    {
                        isPoli = false;
                        break;
                    }
                }
                if (isPoli)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
