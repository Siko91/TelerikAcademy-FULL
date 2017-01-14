using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int size = 20000;

            int[] arr2 = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr2[i] = rnd.Next(100);
            }

            int[] arr1 = arr2;

            DateTime startSwoler = DateTime.Now;
            BSort(arr1, size);
            DateTime endSwoler = DateTime.Now;

            
            DateTime startFaster = DateTime.Now;
            YoYoSort(arr2, size);
            DateTime endFaster = DateTime.Now;

            Console.WriteLine("Size: " + size);

            Console.WriteLine("Bubble Sort >>> " + (endSwoler - startSwoler));

            Console.WriteLine("My Sort >>> " + (endFaster - startFaster));

            Console.WriteLine("Equal: " + (arr1.Equals(arr2)));

            Console.WriteLine();
        }
        static void swap(ref int x, ref int y)
        {
              int tmp;

              tmp = x;
              x = y;
              y = tmp;
        }

        static void BSort(int[] arr, int size)
        {

            if (size <= 1)
            {
                return;
            }
            int i,j;

            for(i = 0; i < size; i++)
                for(j = size - 1; j > i; j--)
                    if (arr[j] > arr[j-1])
                        swap(ref arr[j], ref arr[j-1]);
        }
        static void YoYoSort(int[] arr, int size)
        {

            if (size <= 1)
            {
                return;
            }
            for (int i = 1; i < size; i++)
            {
                if (arr[i-1] > arr[i])
                {
                    swap(ref arr[i], ref arr[i-1]);

                    if (i>1)
                    {
                        i -= 2;
                    }
                }
            }
        }
    }
}
