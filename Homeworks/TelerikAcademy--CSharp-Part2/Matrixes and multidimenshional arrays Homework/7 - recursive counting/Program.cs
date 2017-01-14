using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static int length;

    static void Main(string[] args)
    {
        while (true)
        {
            Random rnd = new Random();

            length = rnd.Next(4, 20);
            int[,] matrix = new int[length, length];

            for (int r = 0; r < length; r++)
            {
                for (int c = 0; c < length; c++)
                {
                    matrix[r, c] = rnd.Next(1, 6);
                }
            }

            //////////////PRINT/////////////////
            for (int r = 0; r < length; r++)
            {
                for (int c = 0; c < length; c++)
                {
                    Console.Write("{0,4}", matrix[r, c]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n--------------------------\n");

            bool[,] answers = Count(matrix, length);

            for (int r = 0; r < length; r++)
            {
                for (int c = 0; c < length; c++)
                {
                    Console.Write("{0, 4}", (answers[r, c] ? "[*]" : "."));
                }
                Console.WriteLine();
            }
            Console.Write("\nPress [enter] to restart: ");
            Console.ReadLine();
            Console.Clear();
        }
    }

    static bool[,] Count(int[,] matrix, int length)
    {
        bool[,] bestAnswers = new bool[length, length];
        bool[,] answers = new bool[length, length];

        int curentcounter = 0, maxcounter = 0;

        for (int r = 0; r < length; r++)
        {
            for (int c = 0; c < length; c++)
            {
                bestAnswers[r, c] = false;
                answers[r, c] = false;
            }
        }

        for (int r = 0; r < length; r++)
        {
            for (int c = 0; c < length; c++)
            {
                CheckNextCells(matrix, r, c, matrix[r, c], answers);

                //Console.WriteLine("\nWorking on cell [" + r + ", " + c + "]");
                for (int rb = 0; rb < length; rb++)
                {
                    for (int cb = 0; cb < length; cb++)
                    {
                        if (answers[rb, cb]) curentcounter++;
                        //Console.Write("{0, 3}", (answers[rb, cb] ? "*" : ""));
                    }
                    //Console.WriteLine();
                }
                //Console.WriteLine("count: " + curentcounter);

                if (curentcounter > maxcounter)
                {
                    for (int rBool = 0; rBool < length; rBool++)
                    {
                        for (int cBool = 0; cBool < length; cBool++)
                        {
                            bestAnswers[rBool, cBool] = answers[rBool, cBool];
                        }
                    }
                    maxcounter = curentcounter;
                }

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
        return bestAnswers;
    }
    static void CheckNextCells(int[,] matrix, int r, int c, int value, bool[,] answers)
    {
        if (answers[r, c] == true) return;

        else if (matrix[r, c] != value) return;

        else
        {
            answers[r, c] = true;

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
