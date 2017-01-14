using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write methods to calculate minimum, maximum, average, sum  of integer numbers. Use variable number of arguments.and product of given set

class Program
{
    static void PrintArray<T>(IList<T> arr)
    {
        Console.WriteLine(string.Join(", ", arr) + "\n");
    }
    static void PrintMenu()
    {
        Console.WriteLine(@"    << Press [ESCAPE] to exit. >>
    << Press [BACKSPASE] to restart. >>

       Press [1] to find max.
       Press [2] to find min.
       Press [3] to find avg.
       Press [4] to find sum.");
    }
    static void FindMax<T>(IList<T> arr)
    {
        double max = double.Parse(arr[0].ToString());
        int index = 0;

        for (int i = 1; i < arr.Count(); i++)
            if (double.Parse(arr[i].ToString()) > max)
                { max = double.Parse(arr[i].ToString()); index = i; }

        Console.WriteLine("Max is {0} and it's index is " + index + "\n", max);
    }

    static void FindMin<T>(IList<T> arr)
    {
        double min = double.Parse(arr[0].ToString());
        int index = 0;

        for (int i = 1; i < arr.Count(); i++)
            if (double.Parse(arr[i].ToString()) < min)
                { min = double.Parse(arr[i].ToString()); index = i; }

        Console.WriteLine("Min is {0} and it's index is " + index + "\n", min);
    }

    static void FindAverage<T>(IList<T> arr)
    {
        double sum = double.Parse(arr[0].ToString());

        for (int i = 1; i < arr.Count(); i++)
            sum += double.Parse(arr[i].ToString()); ;

        Console.WriteLine("Average is {0}\n", (sum / arr.Count()));
    }

    static void FindSum<T>(IList<T> arr)
    {
        double sum = double.Parse(arr[0].ToString());

        for (int i = 1; i < arr.Count(); i++)
            sum += double.Parse(arr[i].ToString());

        Console.WriteLine("Sum is {0}\n", sum);
    }

    static void Main()
    {
        Random rnd = new Random();

        while (true)
        {
            Console.WriteLine("Input numbers, or an empty string to stop and get on with the program.\n");
            string str;
            List<double> arr = new List<double>();
            double temp = 0;

            while (true)
            {
                Console.Write("Input next number: ");
                str = Console.ReadLine();

                if (str.Equals(""))
                    if (arr.Count() > 1)
                        break;

                if (double.TryParse(str, out temp))
                    arr.Add(temp);
            }

            while (true)
            {
                Console.Clear();
                PrintArray(arr);
                PrintMenu();

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return;
                }
                else if (pressedKey.Key == ConsoleKey.Backspace)
                {
                    Console.Clear();
                    break;
                }
                else if (pressedKey.Key == ConsoleKey.D1 || pressedKey.Key == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    FindMax(arr);

                    Console.WriteLine("------\n\n\n        Press [ENTER] to continue.");
                    Console.ReadLine();
                    continue;
                }
                else if (pressedKey.Key == ConsoleKey.D2 || pressedKey.Key == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    FindMin(arr);

                    Console.WriteLine("------\n\n\n        Press [ENTER] to continue.");
                    Console.ReadLine();
                    continue;
                }
                else if (pressedKey.Key == ConsoleKey.D3 || pressedKey.Key == ConsoleKey.NumPad3)
                {
                    Console.Clear();
                    FindAverage(arr);

                    Console.WriteLine("------\n\n\n        Press [ENTER] to continue.");
                    Console.ReadLine();
                    continue;
                }
                else if (pressedKey.Key == ConsoleKey.D4 || pressedKey.Key == ConsoleKey.NumPad4)
                {
                    Console.Clear();
                    FindSum(arr);

                    Console.WriteLine("------\n\n\n        Press [ENTER] to continue.");
                    Console.ReadLine();
                    continue;
                }
            }
        }
    }
}
