using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11SimplerThanItLooks
{
    internal class Program
    {
        private static int[] arr;

        private static void Main(string[] args)
        {
            arr = new[] { 5, 5, 5, 5, 5, 5, 5, 5, 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

            // impotant - that's how I avoid endless loop
            Array.Sort(arr);

            PrintAllPermutations(arr, 0, arr.Length);
        }

        private static void PrintAllPermutations(int[] arr, int start, int n)
        {
            Console.WriteLine(string.Join(",", arr));
            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PrintAllPermutations(arr, left + 1, n);
                    }
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                    arr[i] = arr[i + 1];
                arr[n - 1] = firstElement;
            }
        }

        private static void Swap(ref int p1, ref int p2)
        {
            int mementoP1 = p1;
            p1 = p2;
            p2 = mementoP1;
        }
    }
}