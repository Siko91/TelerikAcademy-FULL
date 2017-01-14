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
            //short num = (short)rnd.Next(-128, 127);

            short num = 0;
            bool inputDone = false;
            while (!inputDone)
            {
                Console.Write("Input a Short number (-32,768 to 32,767): ");
                inputDone = short.TryParse(Console.ReadLine(), out num);
            }
            Console.WriteLine();

            Console.WriteLine("Number: " + num);
            
            if (num < 0) Console.Write("   1-");
            else Console.Write("   0-");

            short mask;
            for (int i = 14; i >= 0; i--)
            {
                mask = (short)(1 << i);
                if ((mask & num) == mask)
                    Console.Write("1");
                else
                    Console.Write("0");
            }
            Console.WriteLine();

            Console.WriteLine("\n\nPress [enter] to restart.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
