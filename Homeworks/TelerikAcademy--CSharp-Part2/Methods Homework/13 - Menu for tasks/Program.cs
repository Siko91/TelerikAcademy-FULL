using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void PrintReversed(int input)
    {
        Console.Write("\nReversed: ");
        string str = input.ToString();
        for (int i = str.Length-1; i >= 0; i--)
        {
            Console.Write(str.Substring(i,1));
        }
        Console.WriteLine("\n");
    }
    static void PrintAverage(List<int> arr)
    {
        double sum = 0;
        foreach (int num in arr)
            sum += num;
        double average = sum / arr.Count();
        Console.WriteLine("Average is: " + average + "\n");
    }
    static void PrintSolvedEquation(int a, int b)
    {
        double x = (double)-b / a;
        Console.WriteLine("\nX = " + x + "\n");
    }
    static void PrintMainMenu()
    {
        Console.WriteLine("     " + "Press [Escape] to exit.");
        Console.WriteLine("     " + "Press [1] to reverse a positive int.");
        Console.WriteLine("     " + "Press [2] to find the average of a sequence.");
        Console.WriteLine("     " + "Press [3] to solve (Ax+B=0).\n");
    }

    static void Main(string[] args)
    {
        while (true)
        {
            PrintMainMenu();

            ConsoleKeyInfo pressedKey = Console.ReadKey();

            if (pressedKey.Key == ConsoleKey.Escape) return;
            else if (pressedKey.Key == ConsoleKey.D1 ||
                        pressedKey.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();

                Console.WriteLine("Input a positive number: ");

                bool inputDone = false;
                int input = 0;

                while (inputDone == false)
                {
                    string str = Console.ReadLine();
                    if (int.TryParse(str, out input))
                    {
                        if (input >= 0)
                        {
                                inputDone = true;
                        }
                    }
                }

                PrintReversed(input);
                Console.WriteLine("-----\n\n      Press [enter] to continue...");
                Console.ReadLine();
                Console.Clear();
            }
            else if (pressedKey.Key == ConsoleKey.D2 ||
                            pressedKey.Key == ConsoleKey.NumPad2)
            {
                Console.Clear();

                Console.WriteLine("Input integers, or an empty string to stop:");

                List<int> arr = new List<int>();

                while (true)
                {
                    while (true)
                    {
                        int input;
                        string str = Console.ReadLine();

                        if (str.Equals(""))
                            break;
                        else if (int.TryParse(str, out input))
                            arr.Add(input);
                    }

                if (arr.Count() > 0)
                    break;
                else
                    Console.WriteLine("Sequence must cuntain at least 1 element. Try again...");
                }

                PrintAverage(arr);
                Console.WriteLine("-----\n\n      Press [enter] to continue...");
                Console.ReadLine();
                Console.Clear();
            }

            else if (pressedKey.Key == ConsoleKey.D3 ||
                            pressedKey.Key == ConsoleKey.NumPad3)
            {
                Console.Clear();

                Console.WriteLine("Input A: ");

                bool inputDone = false;
                int inputA = 0;

                while (inputDone == false)
                {
                    string str = Console.ReadLine();
                    if (int.TryParse(str, out inputA))
                    {
                        inputDone = true;
                    }
                }
                Console.WriteLine("Input B: ");

                inputDone = false;
                int inputB = 0;

                while (inputDone == false)
                {
                    string str = Console.ReadLine();
                    if (int.TryParse(str, out inputB))
                    {
                        inputDone = true;
                    }
                }
                PrintSolvedEquation(inputA, inputB);
                Console.WriteLine("-----\n\n      Press [enter] to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
