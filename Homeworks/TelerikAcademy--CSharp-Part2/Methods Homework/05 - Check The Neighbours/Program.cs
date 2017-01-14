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
            int size = rnd.Next(6, 11);
            int rangeStart = 0, rangeEnd = 50;

            int[] arr = new int[size];

            for (int i = 0; i < size; i++)
                arr[i] = rnd.Next(rangeStart, rangeEnd);

            while (true)
            {
                int index = rnd.Next(1, size - 2);

                Console.WriteLine("press [enter] to pick another index, input \"new\" to restart with a new array, or input \"exit\" to quit the program.\n");
                Console.Write("{0,8}", "Inxex: ");
                for (int i = 0; i < size; i++)
                    Console.Write("{0,3}", i);
                Console.WriteLine();

                Console.Write("{0,8}", "Array: ");
                for (int i = 0; i < size; i++)
                    Console.Write("{0,3}", arr[i]);
                Console.WriteLine();

                string str = "        "; // 8 x " "
                for (int i = 0; i < index+1; i++)
                    {
                        if (i == index)
                        {
                            str += " /\\";
                        }
                        else
                            str += "   ";
                    }
                Console.WriteLine(str + "\n" + str);


                /////////////////

                CheckNeighbours(arr, index);

                /////////////////


                str = Console.ReadLine();

                Console.Clear();

                if (str == "exit") return;
                else if (str == "new") break;

                continue;

            }
        }
    }
    static void  CheckNeighbours(int[] arr, int i)
    {

        string left = "", right = "";

        if (arr[i] >= arr[i + 1])
        {
            right = "equal to";
            if (arr[i] > arr[i + 1])
            {
                right = "bigger than";
            }
        }
        else
        {
            right = "smaller than";
        }

        if (arr[i] >= arr[i - 1])
        {
            left = "equal to";
            if (arr[i] > arr[i - 1])
            {
                left = "bigger than";
            }
        }
        else
        {
            left = "smaller than";
        }

        Console.WriteLine("The element is " + left + " the element on it's left\nand " + right + " the element on it's right.\n");

        return;
    }
}
