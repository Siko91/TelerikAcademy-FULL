using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Random rnd = new Random();

            int num = rnd.Next(5, 31);
            int numK = rnd.Next(100);
            List<int> arr = new List<int>();

            for (int i = 0; i < num; i++)
            {
                arr.Add(rnd.Next(100));
            }

            Console.WriteLine("Array size: {0}", num);
            Console.WriteLine("Element to search for: {0}\n", numK);

            Console.Write("Array: ");
            Print(arr);
            arr.Sort();
            Console.Write("\n\nSorted: ");
            Print(arr);
            Console.WriteLine("\n");

            if (arr[0] > numK)
            {
                Console.WriteLine("Can't find a result\n");
            }
            else
            {
                int index = arr.BinarySearch(numK);
                if (index < 0)
                {
                    index = ((~index) - 1);
                }

                Console.WriteLine("Element[{0}]: {1}\n", index, arr[index]);
            }
            Console.WriteLine("Press [ENTER] to restart (for fast debuging).");
            Console.ReadLine();
            Console.Clear();
        }
    }
    static void Print(List<int> arr)
    {
        int num = arr.Count();
        int counter = 0;
        for (int i = 0; i < num; i++)
        {
            counter++;
            Console.Write("{0,3},", arr[i]);
            if (counter == 10)
            {
                Console.WriteLine();
                counter = 0;
            }
        }
        return;
    }
}
