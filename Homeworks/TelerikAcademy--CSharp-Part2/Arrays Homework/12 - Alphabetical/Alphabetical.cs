using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Alphabetical
    {
        static void Main(string[] args)
        {
            char[] chars = new char[26];
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            chars = letters.ToLower().ToCharArray();

            Console.Write("Input String: ");
            string str = Console.ReadLine().ToLower();

            foreach (char ch in str)
            {
                bool notFound = true;
                for (int y = 0; y < 26; y++)
                {
                    if (chars[y].Equals(ch))
                    {
                        Console.WriteLine("index {0}.", y);
                        notFound = false;
                        break;
                    }
                }
                if (notFound)
                {
                    Console.WriteLine("Index not found.");
                }
            }
        }
    }
