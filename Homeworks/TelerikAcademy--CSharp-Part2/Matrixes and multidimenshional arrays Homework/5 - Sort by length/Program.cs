using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
    {
        static void Main(string[] args)
        {
            
            Console.SetWindowSize(30, 35);

            string[] baseStr = { "a", "A", "1", "#" };
            Random rnd = new Random();

            while (true)
            {
                int num = rnd.Next(10, 15);
                string[] strArr = new string[num];
                int[] lengths = new int[num];

                for (int i = 0; i < num; i++)
                {
                    strArr[i] = "";
                    lengths[i] = rnd.Next(15);
                    for (int y = 0; y < lengths[i]; y++)
                    {
                        int index = rnd.Next(4);
                        strArr[i] += baseStr[index];
                    }
                }

                Print(strArr);

                ///////////SORT///////////

                for (int i = 1; i < num; i++)
                {
                    if (lengths[i-1] > lengths[i])
                    {
                        int temp = lengths[i - 1];
                        lengths[i - 1] = lengths[i];
                        lengths[i] = temp;

                        string tempStr = strArr[i - 1];
                        strArr[i - 1] = strArr[i];
                        strArr[i] = tempStr;

                        if (i>1)
                        {
                            i -= 2;
                        }
                    }
                }
                Console.WriteLine("-------------------");
                Print(strArr);

                Console.WriteLine("Press [Enter] to restart.\nUse for fast debuging.");

                Console.ReadLine();
                Console.Clear();
            }
        }
        static void Print(string[] strArr)
        {
            int counter = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                Console.WriteLine("{0,15}", strArr[i]);
                counter++;
            }
            Console.WriteLine();
        }
    }