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
            try
            {
                // Randomly filled List with 5-10 strList
                string[] alphabet = { "a", "b", "c", "d", "e" };

                Random rnd = new Random();
                int rows = rnd.Next(5, 8);
                int columns = rnd.Next(5, 13);

                string[,] matrix = new string[rows, columns];

                Console.WriteLine("All data is randomly generated.");
                Console.WriteLine("Array size: " + rows + "x" + columns + "\n");

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        int temp = rnd.Next(5);
                        matrix[r, c] = alphabet[temp];
                    }
                }
                PrintMatrix(matrix, rows, columns);
                FindSequences(matrix);
                Console.Write("\nPress [Enter] to restart: ");
                Console.ReadLine();
                Console.Clear();
            }
            catch (Exception)
            {
                Console.Clear();
                /*
                /////////// Use this to detect exceptions. Otherwise they will be ignored.
                string str = "";
                while (str != "ok")
                {
                    //Console.Clear();
                    Console.WriteLine("Input Password (pass = 'ok'): ");
                    str = Console.ReadLine();

                }*/
                ///////////
            }
        }
        
    }
    static void PrintMatrix(string[,] matrix, int rows, int columns)
    {
        Console.Write(" *** |");
        for (int i = 0; i < columns; i++)
        {
            Console.Write("[{0,2}]|", i);
        }
        Console.Write("\n-----");
        for (int i = 0; i < columns; i++)
        {
            Console.Write("-----");
        }
        Console.WriteLine();

        for (int r = 0; r < rows; r++)
        {
            Console.Write("[{0,2}] |", r);
            for (int c = 0; c < columns; c++)
            {
                Console.Write(" {0,3} ", matrix[r, c]);
            }
            Console.Write("\n-----");
            for (int i = 0; i < columns; i++)
            {
                Console.Write("-----");
            }
            Console.WriteLine();
        }
        return;
    }
    static void FindSequences(string[,] matrix)
    {
        /*   longestSequence
         * [0] length
         * [1] coord X (row of first element)
         * [2] coord Y (col of first element)
         * [3] type of sequence (1 - horizontal, 2 - vertical, 3 - diagonal)
         */
        int[] longestSequence = new int[4];
        int[] temp = new int[4];
        
        longestSequence = FindLongestHorizontal(matrix);
        temp = FindLongestVertical(matrix);
        if (temp[0] > longestSequence[0]) longestSequence = temp;
        temp = FindLongestDiagonal(matrix);
        if (temp[0] > longestSequence[0]) longestSequence = temp;

        Console.WriteLine("The length of the longest sequence is " + longestSequence[0] + ".");
        Console.WriteLine("The first element of the sequence is matrix[{0}, {1}].", longestSequence[1], longestSequence[2]);
        Console.Write("The type of the sequence is ");
        switch (longestSequence[3])
        {
            case 0: Console.WriteLine("---"); break;

            case 1:
                    Console.WriteLine("horizontal.\n");
                    Console.Write("\n ");
                    for (int i = 0; i < longestSequence[0]; i++)
                    {
                        Console.Write("[{0}]", matrix[longestSequence[1], longestSequence[2] + i]);
                    }
                    break;

            case 2:
                    Console.WriteLine("vertical.\n");
                    for (int i = 0; i < longestSequence[0]; i++)
			        {
                        Console.WriteLine(" [{0}]",matrix[longestSequence[1] + i,longestSequence[2]]);
                    }
                    break;

            case 3:
                    Console.WriteLine("diagonal.\n");
                    for (int i = 0; i < longestSequence[0]; i++)
                    {
                        string str = "";
                        for (int y = 0; y < i; y++)
                        {
                            str += "..";
                        }
                        Console.WriteLine("{0} [{1}]", str, matrix[longestSequence[1] + i,
                                                                    longestSequence[2] + i]);
                    }
                    break;
            default:
                break;
        }
        Console.WriteLine();
        return;
    }
    static int[] FindLongestHorizontal(string[,] matrix)
    {
        int[] result = { 0, 0, 0, 1 };
        int row = matrix.GetLength(0);
        int col = matrix.GetLength(1);

        int curentLength = 1;

        for (int r = 0; r < row; r++)
        {
            for (int c = 1; c < col; c++)
            {
                if (matrix[r,c].Equals(matrix[r,c-1]))
                {
                    curentLength++;

                    if (curentLength > result[0])
                    {
                        result[0] = curentLength;
                        result[1] = r;
                        result[2] = c - curentLength + 1;

                        curentLength = 1;
                    }
                }
                else { curentLength = 1; }

                if (c == col - 1) { curentLength = 1; }
            }
        }
        return result;
    }
    static int[] FindLongestVertical(string[,] matrix)
    {
        int[] result = { 0, 0, 0, 2 };
        int row = matrix.GetLength(0);
        int col = matrix.GetLength(1);

        int curentLength = 1;

        for (int c = 0; c < col; c++)
        {
            for (int r = 1; r < row; r++)
            {
                if (matrix[r, c].Equals(matrix[r - 1, c]))
                {
                    curentLength++;

                    if (curentLength > result[0])
                    {
                        result[0] = curentLength;
                        result[1] = r-curentLength+1;
                        result[2] = c;

                        curentLength = 1;
                    }
                }
                else { curentLength = 1; }

                if (c == col - 1) { curentLength = 1; }
            }
        }
        return result;
    }
    static int[] FindLongestDiagonal(string[,] matrix)
    {
        int[] result = { 0, 0, 0, 3 };
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        string curentElement = "";

        for (int row = 0; row < rows - 1; row++)
        {
            for (int col = 0; col < columns - 1; col++)
            {
                curentElement = matrix[row, col];
                string temp = matrix[row, col];

                int r = row, c = col;

                int curentLength = 0;
                while (curentElement.Equals(temp))
                {
                    curentLength++;

                    if (curentLength > result[0])
                    {
                        result[0] = curentLength;
                        result[1] = row;
                        result[2] = col;
                    }

                    if (r < rows - 1 && c < columns - 1)
                    {
                        r++;
                        c++;
                        temp = matrix[r, c];
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        
        return result;
    }
}

