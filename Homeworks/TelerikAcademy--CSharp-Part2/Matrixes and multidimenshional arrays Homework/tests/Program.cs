using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static int length;
    static int maxcounter;
    static int curentcounter;

    static void Main(string[] args)
    {
        while (true)
        {
            Random rnd = new Random();

            length = rnd.Next(4, 8);
            int[,] matrix = new int[length, length];

            for (int r = 0; r < length; r++)
            {
                for (int c = 0; c < length; c++)
                {
                    matrix[r, c] = rnd.Next(1, 6);
                    Console.Write("{0,3}", matrix[r, c]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n--------------------------\n");

            bool[,] answers = Count(matrix, length);
            //////////////PRINT/////////////////

            for (int r = 0; r < length; r++)
            {
                for (int c = 0; c < length; c++)
                {
                    Console.Write("{0, 3}", (answers[r, c] ? "[]" : ".."));
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            Console.Clear();
        }
    }

    static bool[,] Count(int[,] matrix, int length)
    {
        bool[,] curentAnswers = new bool[length, length];
        bool[,] answers = new bool[length, length];

        for (int r = 0; r < length; r++)
        {
            for (int c = 0; c < length; c++)
            {
                curentAnswers[r, c] = false;
                answers[r, c] = false;
            }
        }

        for (int r = 0; r < length; r++)
        {
            for (int c = 0; c < length; c++)
            {
                //Console.WriteLine("\nWorking on cell [" + r + ", " + c + "]");
                curentcounter = 1;
                CheckNextCells(matrix, r, c, matrix[r, c], answers);

                if (curentcounter > maxcounter)
                {
                    answers = curentAnswers;
                    maxcounter = curentcounter;

                    curentcounter = 0;

                    for (int rBool = 0; rBool < length; rBool++)
                    {
                        for (int cBool = 0; cBool < length; cBool++)
                        {
                            answers[rBool, cBool] = false;
                        }
                    }
                }
            }
        }
        return answers;
    }
    static void CheckNextCells(int[,] matrix, int r, int c, int value, bool[,] answers)
    {
        if (answers[r, c] == true) return;

        else if (matrix[r, c] != value) return;
        else
        {
            answers[r, c] = true;
            curentcounter++;

            if (r < matrix.GetLength(0) - 1)
            {
                //Console.Write("v");
                CheckNextCells(matrix, r + 1, c, value, answers);
            }
            if (c < matrix.GetLength(0) - 1)
            {
                //Console.Write(">");
                CheckNextCells(matrix, r, c + 1, value, answers);
            }
            if (r > 0)
            {
                //Console.Write("^");
                CheckNextCells(matrix, r - 1, c, value, answers);
            }
            if (c > 0)
            {
                //Console.Write("<");
                CheckNextCells(matrix, r, c - 1, value, answers);
            }
        }
    }
}
