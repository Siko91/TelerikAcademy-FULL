using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decode
{
    class Program
    {
        static char GetChar(char char1, char char2)
        {
            int result = 65 + ((char1 - 65) ^ (char2 - 65));
            return (char)result;
        }

        static string Encrypt(string message, string cypher)
        {
            StringBuilder result = new StringBuilder();

            if (message.Length > cypher.Length)
            {
                int counter = 0;
                for (int i = 0; i < message.Length; i++)
                {
                    char char1 = message[i], char2 = cypher[counter];
                    result.Append(GetChar(char1, char2));
                    counter++;
                    if (counter >= cypher.Length)
                        counter = 0;
                }
            }
            else
            {
                int counter = 0;
                char[] charArray = message.ToCharArray();

                for (int i = 0; i < cypher.Length; i++)
                {
                    char char2 = cypher[i];
                    charArray[counter] = GetChar(charArray[counter], char2);
                    counter++;
                    if (counter >= charArray.Length)
                    {
                        counter = 0;
                    }
                }
                foreach (char ch in charArray)
                {
                    result.Append(ch);
                }
            }
            return result.ToString();
        }

        static string Encode(string str)
        {
            string element;
            int number;

            for (int start = 0; start < str.Length; start++)
            {
                if (char.IsNumber(str, start))
                {
                    for (int toEnd = 1; toEnd < str.Length - start; toEnd++)
                    {
                        if (!char.IsNumber(str, start + toEnd))
                        {
                            number = int.Parse(str.Substring(start, toEnd));
                            element = str.Substring(start + toEnd, 1);
                            StringBuilder temp = new StringBuilder();
                            temp.Append(str.Substring(0, start));
                            for (int repeat = 0; repeat < number; repeat++)
                            {
                                temp.Append(element);
                            }
                            temp.Append(str.Substring(start + toEnd + 1));

                            str = temp.ToString();
                            break;
                        }
                    }
                }
            }
            return str;
        }

        static string[] EncodeAndSeperate(string str)
        {
            string[] result = new string[2];

            int cypherLength = 0, position = str.Length - 1;
            while (char.IsDigit(str, position - 1))
            {
                position--;
            }
            cypherLength = int.Parse(str.Substring(position));

            str = Encode(str.Substring(0, position));

            result[0] = str.Substring(0, str.Length - cypherLength);
            result[1] = str.Substring(str.Length - cypherLength);

            return result;
        }

        static void Main()
        {
            string input = Console.ReadLine();
            string[] messageAndCypher = EncodeAndSeperate(input);
            messageAndCypher[0] = Encrypt(messageAndCypher[0], messageAndCypher[1]);
            Console.WriteLine(messageAndCypher[0]);
        }
    }
}
