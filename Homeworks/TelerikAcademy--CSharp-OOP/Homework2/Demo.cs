using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    class Demo
    {
        static void Main()
        {
            Console.WriteLine("new Point (1,3,5) .ToString() - \"" + new Point(1, 3, 5) + "\"");

            Console.WriteLine("Creating path...");
            Path path = new Path();
            path.AddPoint(1, 3, 5);
            path.AddPoint(7, 9, 11);
            path.AddPoint(new Point(13, 15, 17));

            Console.WriteLine("Storing path...");
            Path.PathStorage.Store(path, @"..\..\StoredPath.txt");

            Console.WriteLine("Loading path...\n");
            path = Path.PathStorage.Load(@"..\..\StoredPath.txt");

            for (int i = 0; i < path.Length; i++)
            {
                Console.WriteLine("Point " + i + ": " + path[i]);
            }

            Console.WriteLine("\n------------ Generic List ------------");
            GenericList<int> list = new GenericList<int>(1);
            list.Add(1);
            list.Add(2);
            Console.WriteLine("list[0] = " + list[0]);
            Console.WriteLine("GenericList<int>.Min(list) = " + GenericList<int>.Min(list));
            Console.WriteLine("GenericList<int>.Max(list) = " + GenericList<int>.Max(list));
            Console.WriteLine("Clearing the list...");
            list.Clear();


            Console.WriteLine("\n------------ Matrixes ------------");

            Matrix<int> first = new Matrix<int>(2, 3);
            Matrix<int> second = new Matrix<int>(3, 2);


            Matrix<int> third = first * second;

            for (int i = 0; i < third.Row; i++)
            {
                for (int y = 0; y < third.Col; y++)
                {
                    Console.Write("{0,4}", third[i,y]);
                }
                Console.WriteLine();
            }

            if (third)
            {
                Console.WriteLine("Third matrix is NOT empty");
            }
            else
            {
                Console.WriteLine("Third matrix is empty");
            }

            Console.WriteLine("\n------------ Version Attribute ------------");
            Console.WriteLine(VersionAttributeDemo.TestVersionAttribute());

            Console.WriteLine();
            Console.WriteLine("done");
        }
    }
}
