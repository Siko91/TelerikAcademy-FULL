using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*Write a program that finds in given array of integers a sequence of given sum S (if present). Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}	
*/

class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
                System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");

            Console.WriteLine("Warning: Curent culture is \"en-GB\"!\n");

            Console.Write("Input Arr Length: ");
            int length = int.Parse(Console.ReadLine());

            double[] doubleArray = new double[length];

            for (int i = 0; i < length; i++)
            {
                Console.Write("Input element {0} (like 555 or 5.55): ", i);
                doubleArray[i] = double.Parse(Console.ReadLine());
            }

            int subLength = 0;
                
            while (true)
            {
                Console.Write("Input sequence length (smaller than the arr length): ");
                subLength = int.Parse(Console.ReadLine());

                if (subLength > length)
                {
                    Console.WriteLine("Error: number too big. Try Again.");
                    continue;
                }
                else if (subLength < 0)
                {
                    Console.WriteLine("Error: number too small. Try Again.");
                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.Write("Input sum to search for (like 555 or 5.55)");
            double searchedSum = double.Parse(Console.ReadLine());

            double currentSum = 0;
            bool[] positions = new bool[length - subLength + 1];

            for (int i = 0; i < length - subLength; i++)
            {
                currentSum = doubleArray[i];
                for (int y = i+1; y < subLength+i; y++)
                {
                    currentSum += doubleArray[y];
                }

                if (currentSum == searchedSum)
                {
                    positions[i] = true;
                }
                else
                {
                    positions[i] = false;
                }
            }

            for (int i = 0; i < positions.Length; i++)
            {
                if (positions[i])
                {
                    Console.Write("Elements: ");
                    for (int y = i; y < subLength+i; y++)
                    {
                        Console.Write(doubleArray[y] + ", ");
                    }
                    Console.Write("with positions: ");
                    for (int y = i; y < subLength + i; y++)
                    {
                        Console.Write(y + ", ");
                    }
                    Console.Write("form the searched sum {0}", searchedSum);
                    Console.WriteLine();
                }
            }
        }
    }
