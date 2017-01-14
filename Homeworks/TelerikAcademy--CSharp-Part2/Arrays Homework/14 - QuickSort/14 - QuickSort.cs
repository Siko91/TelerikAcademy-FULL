using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
    {
        static void Main(string[] args)
        {

            // Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).
            int size = 0;
            List<string> strList = new List<string>();

            // Randomly filled List with 5-10 strList
            string[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            Random rnd = new Random();
            size = rnd.Next(5, 11);
            int strSize = rnd.Next(1, 8);
            Console.WriteLine("All data is randomly generated.");
            Console.WriteLine("Array size: " + size + "\n" + "Word size: " + strSize + "\n");
            for (int i = 0; i < size; i++)
            {
                int temp = rnd.Next(36);
                strList.Add(alphabet[temp]);

                for (int y = 1; y < strSize; y++)
                {
                    temp = rnd.Next(26);
                    strList[i] += alphabet[temp];
                }
            }

            /*
             // Manualy filled List with N strList
            Console.WriteLine("Input strings in the array, or press [Enter] to stop and sort the array.");
            while (true)
            {
                Console.Write("Next element number is {0}: ", size);
                string temp = Console.ReadLine();
             
                if (temp.Equals(""))
                {
                    break;
                }
             
                strList.Add(temp);
                size++;
             
            }*/

            Console.Write("Unsorted: ");
            for (int i = 0; i < size; i++)
            {
                Console.Write(strList[i] + ", ");
            }

            strList = Quicksort(strList, 0, size-1);

            Console.Write("\n\nSorted: ");
            for (int i = 0; i < size; i++)
            {
                Console.Write(strList[i] + ", ");
            }
            Console.WriteLine("\n");
        }
    public static List<string> Quicksort(List<string> strList, int left, int right)
    {
        int i = left, j = right;
        string pivot = strList[(left + right) / 2];

        while (i <= j)
        {
            while (strList[i].CompareTo(pivot) < 0)
            {
                i++;
            }

            while (strList[j].CompareTo(pivot) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                string temp = strList[i];
                strList[i] = strList[j];
                strList[j] = temp;

                i++;
                j--;
            }
        }

        if (left < j)
        {
            Quicksort(strList, left, j);
        }

        if (i < right)
        {
            Quicksort(strList, i, right);
        }

        return strList;
    }
}