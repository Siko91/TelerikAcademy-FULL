using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();

        while (true)
        {
            ///////GET DATA/////////
            int size = rnd.Next(5, 15);
            int rangeMax = 50;
            
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
                arr[i] = rnd.Next(rangeMax);

            ////////WRITE DATA/////////
            Console.WriteLine("Press [enter] to restart, or write \"exit\" to quit.");

            Console.Write("{0,9}", "Inxex: ");
            for (int i = 0; i < size; i++)
                Console.Write("{0,3}", i);
            Console.WriteLine();

            Console.Write("{0,9}", "Array: ");
            for (int i = 0; i < size; i++)
                Console.Write("{0,3}", arr[i]);
            Console.WriteLine();

            /////////USE METHOD/////////

            int index = CheckNeighbours(arr);

            ///////PRINT RESULTS///////

            if (index == -1) Console.WriteLine("\nNo results found.");
            else
            {
                string pointer = "         "; // 9 x " "
                for (int i = 0; i < index + 1; i++)
                {
                    if (i == index)
                    {
                        pointer += " /\\";
                    }
                    else
                        pointer += "   ";
                }
                Console.WriteLine(pointer + "\n" + pointer + "\n");

                Console.WriteLine("Result: " + index);
            }

            //////RESTART OR QUIT//////

            string str = Console.ReadLine();
            if (str == "exit") return;

            Console.Clear();
        }
    }
    static int CheckNeighbours(int[] arr)
    {
        int size = arr.Length;

        for (int i = 1; i < size-2; i++)
        {
            if (arr[i] > arr[i + 1] && arr[i] > arr[i - 1])
            {
                return i;
            }
        }
        return -1;
    }
}
