using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Wintellect.PowerCollections;

namespace Task3LargeTextMapping
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int rndMax = 1000;
            int rndMin = 0;
            Random rnd = new Random();
            List<string> words = new List<string>();
            for (int i = 0; i < 500000; i++)
            {
                words.Add("word" + rnd.Next(rndMin, rndMax) + "and" + rnd.Next(rndMin, rndMax));
            }
            Trie trie = new Trie(words.ToArray());

            int matchesCounter = 0;
            for (int i = 0; i < 1000000; i++)
            {
                string searchWord = "word" + rnd.Next(rndMin, rndMax) + "and" + rnd.Next(rndMin, rndMax);

                if (trie.Contains(searchWord))
                {
                    matchesCounter++;
                }
            }
            Console.WriteLine(matchesCounter + " words found from 1 000 000 searches");
        }
    }
}