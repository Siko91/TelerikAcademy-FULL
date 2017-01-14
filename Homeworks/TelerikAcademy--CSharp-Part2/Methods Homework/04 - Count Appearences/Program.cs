using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static int CountAppearences(int[] arr, int index)
    {
        int counter = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == arr[index])
            {
                counter++;
            }
        }
        return counter;
    }

    static bool TestCountAppearences(int[] arr, int value, int appearences)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == value)
            {
                appearences--;
            }
        }
        if (appearences == 0) return true;
        else return false;
    }

    static void Main(string[] args)
    {
        Random rnd = new Random();

        while (true)
        {
            int size = rnd.Next(10, 26);
            int[] arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(5);
            }
            int index = rnd.Next(size);

            int appearences = CountAppearences(arr, index);
            bool check = TestCountAppearences(arr, arr[index], appearences);

            Console.WriteLine("Array: " + string.Join(", ", arr));
            Console.WriteLine("\nCount element[{0}] - {1}", index, arr[index]);
            Console.WriteLine("\nElement appeared {0} times", appearences);
            Console.WriteLine("Count passed check: " + check);


            Console.WriteLine("\nInput \"exit\" to exit, or press [enter] to restart");
            string str = Console.ReadLine();
            if (str == "exit") return;
            else Console.Clear();
        }
    }
}
