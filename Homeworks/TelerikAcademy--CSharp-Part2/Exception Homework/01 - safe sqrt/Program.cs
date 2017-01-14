using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static double GetSqrt(string str)
    {
        double num = long.Parse(str);

        if (num < 0)
            throw new ArgumentOutOfRangeException("Invalid number");

        num = Math.Sqrt(num);
        return num;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Input number to get it's square root:");
        try
        {
            string str = Console.ReadLine();
            double sqrt = GetSqrt(str);
            Console.WriteLine(sqrt);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Invalid number");
        }
        catch (ArgumentOutOfRangeException OutOfRangeException)
        {
            Console.WriteLine(OutOfRangeException.Message);
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}
