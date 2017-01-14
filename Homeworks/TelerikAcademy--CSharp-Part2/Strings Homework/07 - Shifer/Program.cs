using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07___Shifer
{
    class Program
    {
        static string Shifrovai(char[] str, char[] word)
        {
            StringBuilder result = new StringBuilder();
            int index = 0;
            for (int i = 0; i < str.Length; i++,index++)
            {
                if (index >= word.Length) index = 0;

                char ch = (char)(str[i]^word[index]);
                result.Append(ch);
            }
            return result.ToString();
        }

        static void Main(string[] args)
        {
            Console.Write("Inpit string: ");
            string str = Console.ReadLine();
            Console.Write("Inpit shifer: ");
            string word = Console.ReadLine();

            Console.WriteLine("\nOriginal:\n" + str + "\n");
            str = Shifrovai(str.ToCharArray(), word.ToCharArray());
            Console.WriteLine("\nEncoded:\n" + str + "\n");
            str = Shifrovai(str.ToCharArray(), word.ToCharArray());
            Console.WriteLine("\nDecoded:\n" + str + "\n");

        }
    }
}
