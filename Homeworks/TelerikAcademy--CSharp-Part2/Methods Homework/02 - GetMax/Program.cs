using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write a method GetMax() with two parameters that returns the bigger of two integers. Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

namespace _02___GetMax
{
    class Program
    {
        static int GetMax(List<int> list)
        {
            int max = list[0];

            for (int i = 1; i < list.Count(); i++)
            {
                if (max < list[i])
                {
                    max = list[i];
                }
            }

            return max;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input numbers to compare,\nor an empty string to stop.\n");

            List<int> list = new List<int>();
            bool parseNext = true;

            while (parseNext)
            {
                int tempInt;
                string tempStr = Console.ReadLine();

                if (tempStr == "") break;

                else if (int.TryParse(tempStr, out tempInt))
                {
                    list.Add(tempInt);
                }
                else
	            {
                    Console.WriteLine("Incorect format. Input ignored.");
	            }
            }

            int max = GetMax(list);

            /////PRINT/////
            Console.WriteLine("Array: " + string.Join(", ", list));
            Console.WriteLine("\n" + "Max is : " + max);
        }
    }
}
