using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Input Binary: ");

            string str = Console.ReadLine();

            bool isBinary = true;
            double num = 0;

            for (int ind = 0; ind < str.Length; ind++)
            {
                int pow = str.Length - 1 - ind;

                if (str.Substring(ind,1).Equals("1"))
                {
                    num += Math.Pow(2, pow);
                }
                else if (str.Substring(ind, 1).Equals("0"))
                {
                    continue;
                }
                else
                {
                    isBinary = false;
                    break;
                }
            }

            if (!isBinary)
            {
                Console.WriteLine("Invalid Input. Try Again.");
                break;
            }
            else
            {
                Console.WriteLine("Decimal is: " + num + "\n");
            }
        }
    }
}
