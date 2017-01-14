using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*

 * We are given an array of integers and a number S. Write a program to find if there exists a subset of the elements of the array that has a sum S. Example:
	arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)
*/

class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = new List<int>();

            Random rnd = new Random();

            int length = rnd.Next(5,16);

            Console.Write("Array: ");
            for (int i = 0; i < length; i++)
            {
                myList.Add(rnd.Next(0, 15));
                Console.Write(myList[i] + " ");
            }
            int sum = rnd.Next(10, 50);
            Console.Write("\nSum: {0}\n\n", sum);

            bool combinationIsSum = WriteCombinations(myList, sum);

            if (combinationIsSum == false)
            {
                Console.WriteLine("There are no combinations.");
            }
            Console.Write("\n");
        }

        static bool WriteCombinations(List<int> myList, int sum)
        {
            bool CombinationIsSum = false;
            int length = myList.Count();

            int combinations = (int)Math.Pow(2, length) - 1;

            for (int combination = 0; combination < combinations; combination++)
            {
                long curentSum = 0;

                for (int element = 0; element < length; element++)
                {
                    if (((combination >> element) & 1) == 1)
                    {
                        curentSum += myList[element];
                    }
                }
                if (curentSum == sum)
                {
                    CombinationIsSum = true;

                    for (int element = 0; element < length; element++)
                    {
                        if (((combination >> element) & 1) == 1)
                        {
                            Console.Write(myList[element] + ", ");
                        }
                    }
                    Console.WriteLine("form " + sum + ".");
                }
            }

            return true;
        }
    }
