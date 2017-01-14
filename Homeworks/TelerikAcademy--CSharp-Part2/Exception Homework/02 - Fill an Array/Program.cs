using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static int end = 100;
    static int sizeOfArray = 10;

    static int ReadNumber(int start, int end)
    {
        Console.Write("Input int number between {0} and {1}: ", start, end);
        int num = int.Parse(Console.ReadLine());

        if (num < start || num > end)
        {
            throw new ArgumentOutOfRangeException("Input must be between " + start + " and " + end);
        }

        return num;
    }
    static void Main(string[] args)
    {
        int[] arr = new int[sizeOfArray];
        Console.WriteLine("An array with " + sizeOfArray + " elements is being created.");

        try
        {
            arr[0] = ReadNumber(0, end);
            Console.WriteLine("Element 0 is: " + arr[0]);

            for (int i = 1; i < sizeOfArray; i++)
            {
                arr[i] = ReadNumber(arr[i - 1], end);
                Console.WriteLine("Element {0} is: {1}", i, arr[i]);
            }
        }
        catch (OverflowException oe)
        {
            Console.WriteLine(oe.Message);
        }
        catch (FormatException fe)
        {
            Console.WriteLine(fe.Message);
        }
        catch (ArgumentOutOfRangeException are)
        {
            Console.WriteLine(are.Message);
        }
        finally
        {
            Console.WriteLine("Closing the program...");
        }
    }
}
