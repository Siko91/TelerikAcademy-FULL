using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08___extract_sentences_by_word
{
    class Program
    {
        static string str = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        static string word = "in";
        static string[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        static bool CheckWord(string str, int index, string word)
        {
            if (index > 0)
            {
                string ch = str.Substring(index - 1, 1);
                if (alphabet.Contains(ch.ToLower()))
                    return false;
            }
            if (index < str.Length - word.Length)
	        {
		        string ch = str.Substring(index + word.Length, 1);
                if (alphabet.Contains(ch.ToLower()))
                    return false;
	        }

            return true;
        }
        
        static List<string> GetAllSentences(string str)
        {
            List<string> sentences = (str.Split('.')).ToList();
            return sentences;
        }

        static List<string> FilterSentencesByWord(string str, string word)
        {
            List<string> results = GetAllSentences(str);

            for (int i = 0; i < results.Count(); i++)
            {
                int index = results[i].IndexOf(word, 0, StringComparison.InvariantCultureIgnoreCase);

                if (index == -1)
                {
                    results.RemoveAt(i);
                    i--;
                    continue;
                }
                else
                {
                    bool sentenceIsOk = false;
                    while (index != -1)
                    {
                        if (CheckWord(results[i], index, word))
                        {
                            sentenceIsOk = true;
                            break;
                        }
                        index = results[i].IndexOf(word, index + 1, StringComparison.InvariantCultureIgnoreCase);
                    }
                    if (!sentenceIsOk)
                    {
                        results.RemoveAt(i);
                        i--;
                    }
                }
            }

            return results;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Text:\n" + str + "\n");
            Console.WriteLine("Word:\n" + word + "\n");
            List<string> results = FilterSentencesByWord(str, word);
            Console.WriteLine("Result:");
            for (int i = 0; i < results.Count(); i++)
                Console.WriteLine(results[i]);

            Console.WriteLine();
        }
    }
}
