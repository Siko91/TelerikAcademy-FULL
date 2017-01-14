using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recursive_Word_counting
{
    class Program
    {
        static int combinations = 0;
        static int wordLength = 0;
        static char[] curentWord;

        static void Main(string[] args)
        {
            char[] letters = Console.ReadLine().ToCharArray();
            wordLength = letters.Length;
            curentWord = new char[letters.Length];
            byte[] letterNums = new byte[26];
            foreach (char ch in letters)
            {
                letterNums[ch - 'a']++;
            }
            CountWords(letterNums, 0);

            Console.WriteLine(combinations);
        }

        //////////////////////////////////////

        static void CountWords(byte[] letterNums, int index)
        {
            if (index == wordLength)
            {
                combinations++;
                return;
            }

            if (index == 0)
            {
                for (int i = 0; i < letterNums.Length; i++)
                {
                    if (letterNums[i] > 0)
                    {
                        curentWord[index] = (char)(i + 'a');
                        letterNums[i]--;
                        CountWords(letterNums, index + 1);
                        letterNums[i]++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < letterNums.Length; i++)
                {
                    if (letterNums[i] > 0 && (char)(i + 'a') != curentWord[index - 1]) 
                    {
                        curentWord[index] = (char)(i + 'a');
                        letterNums[i]--;
                        CountWords(letterNums, index + 1);
                        letterNums[i]++;
                    }
                }
            }
        }
    }
}
