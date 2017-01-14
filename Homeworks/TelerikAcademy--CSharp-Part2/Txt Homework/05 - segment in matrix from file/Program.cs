using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _05___segment_in_matrix_from_file
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr;
            using (StreamReader reader = new StreamReader(@"..\..\05-File.txt"))
            {
                int size = int.Parse(reader.ReadLine());
                arr = new int[size, size];

                for (int y = 0; y < size; y++)
                {
                    string[] tempStrArr = reader.ReadLine().Split(' ');
                    
                    for (int x = 0; x < size; x++)
                    {
                        arr[x, y] = int.Parse(tempStrArr[x]);
                        Console.Write("{0,4}", arr[x,y]);
                    }
                    Console.WriteLine();
                }
            }

            int currentSum = 0, max = int.MinValue, xCoord = -1, yCoord = -1;
            for (int y = 0; y < arr.GetLength(0)-1; y++)
            {
                for (int x = 0; x < arr.GetLength(1) - 1; x++)
                {
                    currentSum = arr[x, y];
                    currentSum += arr[x + 1, y];
                    currentSum += arr[x, y + 1];
                    currentSum += arr[x + 1, y + 1];

                    if (currentSum > max)
                    {
                        max = currentSum;
                        yCoord = y;
                        xCoord = x;
                    }
                }
            }
            Console.WriteLine("\n{0,4}{1,4}\n{2,4}{3,4}\n",
                arr[xCoord, yCoord],
                arr[xCoord+1, yCoord],
                arr[xCoord, yCoord+1],
                arr[xCoord+1, yCoord+1]);
        }   
    }
}
