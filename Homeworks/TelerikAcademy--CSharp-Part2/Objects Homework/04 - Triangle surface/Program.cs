using System;
using System.Threading;
using System.Globalization;

// Write methods that calculate the surface of a triangle by given: Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.


namespace _04___Triangle_surface
{
    class Program
    {
        static void CalcBySideAndAltitude()
        {
            Console.WriteLine("Input a side and an altitude:");
            double side = double.Parse(Console.ReadLine());
            double altitude = double.Parse(Console.ReadLine());

            double surface = side * altitude / 2;
            Console.WriteLine(surface);
        }
        static void CalcByThreeSides()
        {
            Console.WriteLine("Input three sides:");
            double side1 = double.Parse(Console.ReadLine());
            double side2 = double.Parse(Console.ReadLine());
            double side3 = double.Parse(Console.ReadLine());

            double halfPerim = (side1 + side2 + side3) / 2;
            double surface = Math.Sqrt(halfPerim) * (halfPerim - side1) * (halfPerim - side2) * (halfPerim - side3);
            Console.WriteLine(surface);
        }
        static void CalcByTwoSidesAndAngle()
        {
            Console.WriteLine("Input two sides and an angle between them:");
            double side1 = double.Parse(Console.ReadLine());
            double side2 = double.Parse(Console.ReadLine());
            double angle = double.Parse(Console.ReadLine());

            if (angle > 180 || angle < 0)
            {
                Console.WriteLine("Wrong input...");
                return;
            }

            double surface = (side1 * side1 * Math.Sin(Math.PI * angle / 180)) / 2;
            Console.WriteLine(surface);
        }
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Choose:\n"+
                                  "Input '1' to input side and an altitude to it.\n" + 
                                  "Input '2' to input three sides.\n" + 
                                  "Input '3' to input three sides Two sides and an angle between them.\n\n");
                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice.Equals("1"))
                {
                    CalcBySideAndAltitude();
                }
                else if (choice.Equals("2"))
                {
                    CalcByThreeSides();
                }
                else if (choice.Equals("3"))
                {
                    CalcByTwoSidesAndAngle();
                }
                else
                {
                    Console.WriteLine("Unknown input. Try again...");
                }

                Console.WriteLine("\n\nPress [enter] to restart.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
