using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountLetterAppearences
{
    class CountLetterAppearences
    {
        static string alphabet = "abcdefghijklmnopqrstuvwxyz";

        static void Main(string[] args)
        {
            Console.WriteLine("Input text");
            string input = Console.ReadLine();

            foreach (char letter in alphabet)
            {
                int counter = 0;
                int index = input.IndexOf(letter.ToString(), 0, StringComparison.InvariantCultureIgnoreCase);

                while (index != -1)
                {
                    counter++;
                    index = input.IndexOf(letter.ToString(), index+1, StringComparison.InvariantCultureIgnoreCase);
                }

                if (counter>0)
                {
                    Console.WriteLine(letter + " - " + counter);
                }
            }
        }
    }
}
