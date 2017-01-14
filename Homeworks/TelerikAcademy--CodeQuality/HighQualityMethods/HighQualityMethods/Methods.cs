using System;

namespace HighQualityMethods
{
    class Methods
    {
        static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double halfPerimeter = (sideA + sideB + sideC) / 2;

            double area = Math.Sqrt(
                halfPerimeter *
                (halfPerimeter - sideA) *
                (halfPerimeter - sideB) *
                (halfPerimeter - sideC)
                );

            return area;
        }

        static string NumberToDigit(int number)
        {
            if (0 > number || number > 9)
            {
                throw new ArgumentOutOfRangeException("Number is out of range");
            }
            string[] digitNames = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            return digitNames[number];
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException();
            }

            int max = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }
            return max;
        }

        static void PrintAsNumber(object number, NumberPrintingFormats format)
        {
            switch (format)
            {
                case NumberPrintingFormats.Float:
                    Console.WriteLine("{0:f2}", number);
                    break;
                case NumberPrintingFormats.Percent:
                    Console.WriteLine("{0:p0}", number);
                    break;
                case NumberPrintingFormats.Aligned:
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    break;
            }
        }


        static double CalcDistance(Point2D p1, Point2D p2)
        {
            double squaredVerticalDistance = Math.Pow((p2.X - p1.X), 2);
            double squaredHorizontalDistance = Math.Pow((p2.Y - p1.Y), 2);
            double distance = Math.Sqrt(squaredVerticalDistance + squaredHorizontalDistance);
            return distance;
        }

        static bool PointsOnSameHorizontalLine(Point2D p1, Point2D p2)
        {
            return (p1.Y == p2.Y);
        }
        static bool PointsOnSameVerticalLine(Point2D p1, Point2D p2)
        {
            return (p1.X == p2.X);
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToDigit(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber(1.3, NumberPrintingFormats.Float);
            PrintAsNumber(0.75, NumberPrintingFormats.Percent);
            PrintAsNumber(2.30, NumberPrintingFormats.Aligned);

            Point2D point1 = new Point2D(0, 0);
            Point2D point2 = new Point2D(0, 5);
            Console.WriteLine(CalcDistance(point1, point2));
            Console.WriteLine("Horizontal? " + PointsOnSameHorizontalLine(point1, point2));
            Console.WriteLine("Vertical? " + PointsOnSameVerticalLine(point1, point2));

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992,3,17), "Sofia");
            Student stella = new Student("Stella", "Markova", new DateTime(1993,11,3), "Vidin", "gamer", "high");
            
            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
