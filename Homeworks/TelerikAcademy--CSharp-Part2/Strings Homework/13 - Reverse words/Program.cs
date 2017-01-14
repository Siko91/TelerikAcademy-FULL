using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13___Reverse_words
{
    struct Sign
    {
        public string ch;
        public int pos;
    }

    class Program
    {
        static string str = "C# is not C++, not PHP and not Delphi!";
        static char[] charArr = { ' ', '!', '.', '?', ',' };

        static void Main(string[] args)
        {
            string[] words = str.Split(' ');

            List<string> result = new List<string>();
            List<Sign> signs = new List<Sign>();

            for (int i = words.Length-1; i >= 0; i--)
            {
                if (words[i].Length > 0)
                {
                    if (words[i].Substring(words[i].Length-1,1).IndexOfAny(charArr) != -1)
                    {

                        result.Add(words[i].Substring(0, words[i].Length - 2));

                        Sign sign = new Sign();
                        sign.ch = words[i].Substring(words[i].Length - 1, 1);
                        sign.pos = i+1;

                        signs.Add(sign);
                    }
                    else
                    {
                        result.Add(words[i]);
                    }
                }
            }
            for (int i = 0; i < signs.Count(); i++)
            {
                result.Insert(signs[i].pos, signs[i].ch);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
