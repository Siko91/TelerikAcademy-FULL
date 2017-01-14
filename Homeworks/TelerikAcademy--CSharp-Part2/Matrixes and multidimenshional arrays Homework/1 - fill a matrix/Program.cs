using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();

        while (true)
        {
            int size = rnd.Next(3, 15);
            Console.WriteLine("Matrix size (randomly generated between 3 and 9): " + size);

            Console.WriteLine("Input 1, 2, 3, or 4 to choose a solution, or press [Enter] to restart.");
            Console.WriteLine("Solution 1 - Fill by columns (down and down again).");
            Console.WriteLine("Solution 2 - Fill by columns (down and up, like a yo-yo).");
            Console.WriteLine("Solution 3 - Fill by diagonals (South-East).");
            Console.WriteLine("Solution 4 - Fill by spyral (inwards).");
            Console.WriteLine();

            while (!Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                if (pressedKey.Key == ConsoleKey.D1 || pressedKey.Key == ConsoleKey.NumPad1)
                {
                    Console.WriteLine("1 pressed:\n");
                    FirstWay(size);
                }
                if (pressedKey.Key == ConsoleKey.D2 || pressedKey.Key == ConsoleKey.NumPad2)
                {
                    Console.WriteLine("2 pressed:\n");
                    SecondWay(size);
                }
                if (pressedKey.Key == ConsoleKey.D3 || pressedKey.Key == ConsoleKey.NumPad3)
                {
                    Console.WriteLine("3 pressed:\n");
                    ThirdWay(size);
                }
                if (pressedKey.Key == ConsoleKey.D4 || pressedKey.Key == ConsoleKey.NumPad4)
                {
                    Console.WriteLine("4 pressed:\n");
                    FourthWay(size);
                }
                if (pressedKey.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine(@"         RESTARTED...");
                    Console.WriteLine();
                    break;
                }
            }
        }
    }
    static void FirstWay(int size)
    {
        int[,] matrix = new int[size, size];
        int counter = 0;

        for (int col = 0; col < size; col++)
        {
            for (int row = 0; row < size; row++)
            {
                counter++;
                matrix[row, col] = counter;
            }
        }
        Print(matrix);
        return;
    }
    static void SecondWay(int size)
    {
        int[,] matrix = new int[size, size];
        int counter = 0;
        bool directionUP = false;

        for (int col = 0; col < size; col++)
        {
            if (directionUP)
            {
                for (int row = size-1; row >=0; row--)
                {
                    counter++;
                    matrix[row, col] = counter;
                }
                directionUP = false;
            }
            else
            {
                for (int row = 0; row < size; row++)
                {
                    counter++;
                    matrix[row, col] = counter;
                }
                directionUP = true;
            }
        }

        Print(matrix);
        return;
    }
    static void ThirdWay(int size)
    {
        int[,] matrix = new int[size, size];
        int counter = 1;
        int row = size - 1, col = 0;
        int x, y;

        while (counter <= size * size)
        {
            matrix[row, col] = counter;
            counter++;

            x = row;
            y = col;

            if (col == 0)
            {
                for (int i = 0; i < size-1-row; i++)
			    {
			        x++;
                    y++;
                    matrix[x, y] = counter;
                    counter++;
			    }
                if (row == 0) col++;
                else row--;
            }
            else if (row == 0)
            {
                for (int i = 0; i < size - 1 - col; i++)
                {
                    x++;
                    y++;
                    matrix[x, y] = counter;
                    counter++;
                }
                col++;
            }
        }
        Print(matrix);
        return;
    }
    static void FourthWay(int size)
    {
        int[,] matrix = new int[size, size];
        int counter = 0;

        // directions: 0 is down, 1 is left, 2 is up, 3 is right;
        int direction = 0;
        int x = -1, y = 0;
        string hystory = "";

        int circles = size / 2;
        if (size % 2 == 1) circles++;

        try
        {
            for (int i = 0; i < circles; i++)
            {
                hystory += " Next round ";
                while (direction == 0)
                {
                    x++;
                    counter++;
                    hystory += "v";
                    if (x > size - 1)
                    { x = size - 1; counter--; direction = 1; hystory += " break1 "; continue; }
                    else if (matrix[x, y] > 0)
                    { x--; counter--; direction = 1; hystory += " break2 "; continue; }
                    else
                    {
                        hystory += "|";
                        matrix[x, y] = counter;
                    }
                }
                while (direction == 1)
                {
                    y++;
                    counter++;
                    hystory += ">";
                    if (y > size - 1)
                    { y = size - 1; counter--; direction = 2; hystory += " break1 "; continue; }
                    else if (matrix[x, y] > 0)
                    { y--; counter--; direction = 2; hystory += " break2 "; continue; }
                    else
                    {
                        hystory += "|";
                        matrix[x, y] = counter;
                    }
                }
                while (direction == 2)
                {
                    x--;
                    counter++;
                    hystory += "^";
                    if (x < 0)
                    { x = 0; counter--; direction = 3; hystory += " break1 "; continue; }
                    else if (matrix[x, y] > 0)
                    { x++; counter--; direction = 3; hystory += " break2 "; continue; }
                    else
                    {
                        hystory += "|";
                        matrix[x, y] = counter;
                    }
                }
                while (direction == 3)
                {
                    y--;
                    counter++;
                    hystory += "<";
                    if (y < 0)
                    { y = 0; counter--; direction = 0; hystory += " break1 "; continue; }
                    else if (matrix[x, y] > 0)
                    { y++; counter--; direction = 0; hystory += " break2 "; continue; }
                    else
                    {
                        hystory += "|";
                        matrix[x, y] = counter;
                    }
                }
            }
        }
        catch (Exception)
        { Console.WriteLine(" [Error] "); Console.WriteLine("Start: " + hystory + "\n"); }
        Print(matrix);
        Console.WriteLine("\n Print hystory (for debuging): " + hystory);
        return;
    }

    ////////////////PRINT MAtRiX////////////
    static void Print(int[,] matrix)
    {
        int size = matrix.GetLength(0);

        for (int r = 0; r < size; r++)
        {
            for (int c = 0; c < size; c++)
            {
                Console.Write("{0,3} ", matrix[r, c]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        return;
    }
}
