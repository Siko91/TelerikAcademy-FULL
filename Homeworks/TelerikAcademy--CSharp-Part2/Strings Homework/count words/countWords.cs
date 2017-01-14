using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace countWords
{
    class countWords
    {
        static char[] seperators = { ' ', '.', ',', '!', '?', ':', ';', '(', ')' };

        static void Main(string[] args)
        {
            Console.WriteLine("Input text: ");
            string[] input = Console.ReadLine().Split(seperators, StringSplitOptions.RemoveEmptyEntries);

            List<string> words = new List<string>();
            List<int> appearences = new List<int>();

            for (int y = 0; y  < input.Length; y++)
            {
                bool isListed = false;
                for (int i = 0; i < words.Count(); i++)
                {
                    if (input[y].Equals(words[i].ToString()))
                    {
                        appearences[i]++;
                        isListed = true;
                    }
                }
                if (!isListed)
                {
                    words.Add(input[y]);
                    appearences.Add(1);
                }
            }
            Console.WriteLine("---------");
            for (int i = 0; i < words.Count(); i++)
            {
                Console.WriteLine(words[i] + " - " + appearences[i]);
            }
        }
    }
}
