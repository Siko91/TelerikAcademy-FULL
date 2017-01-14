using System;
using System.Text;
using System.Collections.Generic;

namespace Array_of_words_reorder_and_print
{
    class Program
    {
        static void PrintWords(List<string> words)
        {
            int counter = 0;
            bool isDone = false;
            StringBuilder result = new StringBuilder();

            while (!isDone)
            {
                isDone = true;
                foreach (string word in words)
                {
                    if (word.Length > counter)
                    {
                        result.Append(word.Substring(counter, 1));
                        isDone = false;
                    }
                }
                counter++;
            }
            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<string> words = new List<string>();
            for (int i = 0; i < num; i++)
            {
                words.Add(Console.ReadLine());
            }

            int position;
            bool moveBackwords = false;

            for (int i = 0; i < num; i++)
            {
                position = words[i].Length % (num + 1);

                if (position < i)
                    moveBackwords = true;
                else if (position == i)
                    continue;
                
                words.Insert(position, words[i]);

                if (moveBackwords)
                {
                    words.RemoveAt(i + 1);
                    moveBackwords = false;
                }
                else
                {
                    words.RemoveAt(i);
                }
            }
            PrintWords(words);
        }
    }
}
