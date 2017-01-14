using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static string GetBinary(string ch)
    {
        switch (ch)
        {
            case "0": return "0000";
            case "1": return "0001";
            case "2": return "0010";
            case "3": return "0011";
            case "4": return "0100";
            case "5": return "0101";
            case "6": return "0110";
            case "7": return "0111";
            case "8": return "1000";
            case "9": return "1001";
            case "A": return "1010";
            case "B": return "1011";
            case "C": return "1100";
            case "D": return "1101";
            case "E": return "1110";
            case "F": return "1111";

            default: return "";
        }
    }
    static void Main()
    {
        Random rnd = new Random();

        while (true)
        {
            // generating random float
            float num = (float)rnd.NextDouble();
            int isPositive = rnd.Next(2);
            if (isPositive == 1)
                num = 0 - num;
            int multiply = rnd.Next(1, 10000);
            num *= multiply;

            // conversion
            byte[] byteArray = BitConverter.GetBytes(num);
            Array.Reverse(byteArray);
            string toHex = BitConverter.ToString(byteArray);
            toHex = toHex.ToUpper();
            string toBinary = "";
            for (int i = 0; i < toHex.Length; i++)
            {
                toBinary += GetBinary(toHex.Substring(i, 1));
            }


            // formating...
            toBinary = toBinary.Substring(0, 1) + " - " + toBinary.Substring(1, 8) + " - " + toBinary.Substring(8);

            // output
            Console.WriteLine("{0,7} = {1}","Float", num);
            Console.WriteLine("{0,7} = {1}", "To hex", toHex);
            Console.WriteLine("{0,7} = {1}\n\n\n", "To bin", toBinary);
            
            // restart
            Console.WriteLine("-------------------------");
            Console.WriteLine("Press [enter] to restart.");
            Console.ReadLine();
            Console.Clear();

        }
    }
}
