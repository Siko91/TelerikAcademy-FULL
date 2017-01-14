using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

    class Program
    {
        static void Main(string[] args)
        {
            // FILL A MATRIX

            Random rnd = new Random();

            int rows = rnd.Next(4, 10);
            int columns = rnd.Next(4, 10);

            int[,] matrix = new int[rows, columns];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    matrix[r, c] = rnd.Next(100);
                }
            }

            PrintMatrix(matrix, rows, columns);
            FindMaXSQuare(matrix, rows, columns);
            
        }
        static void PrintMatrix(int[,] matrix, int rows, int columns)
        {
            Console.Write("*** |");
            for (int i = 0; i < columns; i++)
            {
                Console.Write("[{0,1}]|", i);
            }
            Console.Write("\n----");
            for (int i = 0; i < columns; i++)
            {
                Console.Write("----");
            }
            Console.WriteLine();

            for (int r = 0; r < rows; r++)
            {
                Console.Write("[{0,1}] |", r);
                for (int c = 0; c < columns; c++)
                {
                    Console.Write(" {0,2} ", matrix[r, c]);
                }
                Console.Write("\n----");
                for (int i = 0; i < columns; i++)
                {
                    Console.Write("----");
                }
                Console.WriteLine();
            }
        }
        static void FindMaXSQuare(int[,] matrix, int rows, int columns)
        {
            int[,] maxElements = new int[3, 3];
            int curentSum = 0, maxSum = 0, maxR = -1, maxC = -1;

            for (int r = 0; r < rows - 3; r++)
            {
                for (int c = 0; c < columns - 3; c++)
                {
                    curentSum = 0;

                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            curentSum += matrix[r + x, c + y];
                        }
                    }

                    if (curentSum > maxSum)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            for (int y = 0; y < 3; y++)
                            {
                                maxElements[x, y] = matrix[r + x, c + y];
                            }
                        }
                        maxSum = curentSum;
                        maxR = r;
                        maxC = c;
                    }
                }
            }
            Console.WriteLine("\nSize of submatrix = {0}.\nFirst Element of submatrix is matrix[{1},{2}]\nSum of submatrix is {3}\n", 3, maxR, maxC, maxSum);

            PrintMatrix(maxElements, 3, 3);
            return;
        }
    }
