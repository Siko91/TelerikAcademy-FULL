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
            Console.Write("Input int: ");
            int num;

            if (int.TryParse(Console.ReadLine(), out num))
            {
                int mask;

                for (int i = 31; i >=0 ; i--)
                {
                    mask = 1 << i;
                    if ((num & mask) == mask)
                    {
                        Console.Write("1");
                    }
                    else
                    {
                        Console.Write("0");
                    }
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Invalid Input. Try Again...");
            }
        }
    }
}
