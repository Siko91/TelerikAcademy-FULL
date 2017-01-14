using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*Write a program that finds in given array of integers a sequence of given sum S (if present). Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}	
*/

class BinarySearch
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

        for (int i = 0; i < length - 1; i++)
        {
            if (i > 0)
            {
                if (doubleArray[i] > doubleArray[i + 1])
                {
                    double temp = doubleArray[i + 1];
                    doubleArray[i + 1] = doubleArray[i];
                    doubleArray[i] = temp;

                    if (i > 1) { i -= 2; }
                }
            }
        }


        Console.Write("Input number to search for (like 555 or 5.55): ");
        double searchedDouble = double.Parse(Console.ReadLine());

        int startPosition = 0, endPosition = doubleArray.Length, position = endPosition / 2;

        

        while (true)
        {
            if (doubleArray[position] == searchedDouble)
            {
                break;
            }
            else if (doubleArray[position] > searchedDouble)
            {
                startPosition = position;
            }
            else
            {
                endPosition = position;
            }
            position = (startPosition + endPosition) / 2;

            if (startPosition == endPosition)
            {
                position = -1;
                break;
            }
        }

        if (position >= 0)
        {
            Console.WriteLine("Result is at position {0}.", position);
        }
        else
        {
            Console.WriteLine("No result...");
        }
    }
}
