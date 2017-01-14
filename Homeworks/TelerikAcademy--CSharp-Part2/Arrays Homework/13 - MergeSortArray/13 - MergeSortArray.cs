using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MergeSortArray
    {
        static void Main(string[] args)
        {
            /* * Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia). */

            Console.Write("Input array lenghth: ");
            int num = int.Parse(Console.ReadLine());

            List<int> intList1 = new List<int>();

            for( int i=0; i<num; i++)
            {
                 Console.Write("Input int[{0}]: ", + i);
                 intList1.Add(int.Parse(Console.ReadLine()));
            }

            List<int> intList2 = new List<int>();
            for( int i=0; i<num/2; i++)
            {
                 int temp = intList1[i];
                 intList1.RemoveAt(i);
                 intList2.Add(temp);
            }

            intList1.Sort();
            intList2.Sort();

            bool firstNotEmpty = true, secondNotEmpty = true;
            List<int> sorted = new List<int>();

            while (secondNotEmpty || firstNotEmpty)
            {
                if(secondNotEmpty && firstNotEmpty)
                {
                    int int1 = intList1[0];
                    int int2 = intList2[0];

                    if(int1 > int2)
                    {
                        sorted.Add(int2);
                        intList2.RemoveAt(0);
                    }
                    else if(int1 < int2)
                    {
                        sorted.Add(int1);
                        intList1.RemoveAt(0);
                    }
                    else
                    {
                         sorted.Add(int1);
                         sorted.Add(int2);

                         intList1.RemoveAt(0);
                         intList2.RemoveAt(0);
                    }
                }
                else if(secondNotEmpty ^ firstNotEmpty)
                {
                    if(firstNotEmpty)
                    {
                        foreach(int n in intList1)
                        {
                            sorted.Add(n);
                        }
                        firstNotEmpty = false;
                    }
                    if(secondNotEmpty)
                    {
                        foreach(int n in intList2)
                        {
                           sorted.Add(n);
                        }
                        secondNotEmpty = false;
                    }
                }

                if (intList1.Count() == 0) firstNotEmpty = false;

                if (intList2.Count() == 0) secondNotEmpty = false;
            }

            for( int i=0; i<sorted.Count(); i++)
            {
                Console.WriteLine("index({0}): \"{1}\";", i, sorted[i]);
            }
        }
    }
