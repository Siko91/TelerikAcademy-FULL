using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        //////////////////////INITIALIZE/////////////////////
        Random rand = new Random();
        int num = rand.Next(5, 10);

        int size = num + 1;

        while (size >= num)
        {
            size = rand.Next(2, 7);
        }

        ////////////SOME VISUAL COMFORT////////////////
        int counter = 0, countTo = num / 2;
        if (num == 7 && size < 4) countTo = 7;
        else if (num == 5 && size < 5) countTo = 5;
        else if (size < 5 && countTo < 4) countTo *= 2;

        Console.WriteLine("Numbers = 1, 2, 3 .... " + num + "\nSize of variations = " + size + "\n");

        //////////////////////START/////////////////////
        int[] curentVariation = new int[size];

        for (int i = 0; i < size; i++) // initialize for first variation;
        {
            curentVariation[i] = 1;
        }


        //////////////////////GO THTOUGH VARIATIONS/////////////////////
        bool notReady = true;
        while (notReady)
        {
            for (int value = 1; value <= num; value++)
            {
                curentVariation[size - 1] = value;  // this is the curent variation

                //////////////////////PRINT/////////////////////
                Console.Write("[");
                for (int i = 0; i < size; i++)
                {
                    Console.Write(curentVariation[i]);
                    if (i < size-1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write("] - ");


                //////////////////////FOR VISUAL COMFORT/////////////////////
                counter++;
                if (counter >= countTo)
                {
                    counter = 0;
                    Console.WriteLine();
                }

            }

            //////////////////////CHECK IF COLUMNS ARE FULL/////////////////////
            if (curentVariation[size-1] == num)
            {
                int col = size - 1;

                while (col >= 0)
                {
                    if (col == 0 && curentVariation[col] == num) { notReady = false; }
                    else if (curentVariation[col] == num) { col--; continue; }
                    else { curentVariation[col]++; break; }
                }

                //////////////////MODIFIES THE COLUMNS IF NEEDED/////////////////
                if (notReady)
                {
                    col++;
                    while (col < size)
                    {
                        curentVariation[col] = 1;
                        col++;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
