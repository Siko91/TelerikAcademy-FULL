using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05___ToUpper
{
    class Program
    {
        static string str = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        static string upStart = "<upcase>";
        static string upEnd = "</upcase>";

        static string ToUpper(string str)
        {
            string result = "";
            bool isUpper = false;

            for (int i = 0; i < str.Length; i++)
            {
                if (i < str.Length - upStart.Length + 1)
                {
                    if (str.Substring(i, upStart.Length).Equals(upStart))
                    {
                        isUpper = true;
                        i += upStart.Length;
                    }
                }
                if (i < str.Length - upEnd.Length + 1)
                {
                    if (str.Substring(i, upEnd.Length).Equals(upEnd))
                    {
                        isUpper = false;
                        i += upEnd.Length;
                    }
                }

                if (isUpper)
                { result += str.Substring(i, 1).ToUpper(); }
                else
                { result += str.Substring(i, 1); }
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Text:\n" + str + "\n");
            string result = ToUpper(str);
            Console.WriteLine("Result:\n" + result + "\n\n");

        }
    }
}
