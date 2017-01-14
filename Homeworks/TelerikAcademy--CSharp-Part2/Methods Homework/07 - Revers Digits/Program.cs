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
            //////////////////
            Console.Write("Number: ");
            int num = rnd.Next(99999);
            Console.WriteLine(num + "\n");

            int stringMethodResult = 0;
            int intMethodResult = 0;

            DateTime stringMethodStart = DateTime.Now;
            for (int i = 0; i < 999999; i++)
                stringMethodResult = StringMethod(num);
            DateTime stringMethodEnd = DateTime.Now;

            DateTime intMethodStart = DateTime.Now;
            for (int i = 0; i < 999999; i++)
                intMethodResult = IntMethod(num);
            DateTime intMethodEnd = DateTime.Now;

            //////////////////
            Console.WriteLine("{0,15}: {1,5}", "String result", stringMethodResult);
            Console.WriteLine("{0,15}: {1,5}", "Int result", intMethodResult);

            Console.WriteLine();

            Console.WriteLine("{0,15}: {1,10}", "String Time", (stringMethodEnd - stringMethodStart));
            Console.WriteLine("{0,15}: {1,10}", "Int Time", (intMethodEnd - intMethodStart));

            Console.WriteLine("\nBoth methods are used 999'999 times.\n");
            Console.WriteLine("Press [Enter] to restart.");
            //////////////////
            string str = Console.ReadLine();
            Console.Clear();
        }
    }
    static int StringMethod(int num)
    {
        string str = num.ToString();
        string strResult = "";

        for (int i = str.Length - 1; i >= 0; i--)
        {
            strResult += str.Substring(i, 1);
        }

        int result = int.Parse(strResult);

        return result;
    }

    static int IntMethod(int num)
    {
        int result = 0;
        int current = 0;
        
        while (num != 0)
        {
            current = num % 10;
            num = num/10;

            result = result * 10;
            result += current;
        }

        return result;
    }
}
