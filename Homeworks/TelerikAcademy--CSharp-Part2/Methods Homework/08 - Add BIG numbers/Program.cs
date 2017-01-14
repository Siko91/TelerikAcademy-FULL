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
                int size1 = rnd.Next(5, 71); // Could be larger, but it'll be tough to display it.
                int size2 = rnd.Next(5, 71);

                if (size1<size2)
                {
                    int temp = size1;
                    size1 = size2;
                    size2 = temp;
                }

                List<int> arr1 = new List<int>();
                for (int i = 0; i < size1; i++)
                    arr1.Add(rnd.Next(10));

                List<int> arr2 = new List<int>();
                for (int i = 0; i < size2; i++)
                    arr2.Add(rnd.Next(10));

                ////////DISPLAY
                Console.WriteLine("Add:");

                string str1 = "";
                for (int i = arr1.Count()-1; i >= 0; i--) str1 += arr1[i].ToString();
                Console.WriteLine("{0,71}", str1);

                Console.WriteLine("+");

                string str2 = "";
                for (int i = arr2.Count()-1; i >= 0; i--) str2 += arr2[i].ToString();
                Console.WriteLine("{0,71}", str2);

                for (int i = 0; i < 71; i++) Console.Write("-");
                Console.WriteLine();

                ////////////
                List<int> result = AddBigInts(arr1, arr2);

                ///////////

                string resultToStr = "";
                for (int i = result.Count() - 1; i >= 0; i--) resultToStr += result[i].ToString();
                Console.WriteLine("{0,71}", resultToStr);

                ///////RESTART
                Console.Write("\n\n\nPress enter to restart: ");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static List<int> AddBigInts(List<int> arr1, List<int> arr2)
        {
            List<int> result = new List<int>();

            bool ednoNaUm = false;

            while (arr1.Count() > 0 || arr2.Count() > 0 || ednoNaUm)
            {
                int temp = 0;

                if (arr1.Count() > 0) { temp += arr1[0]; arr1.RemoveAt(0); }
                if (arr2.Count() > 0) { temp += arr2[0]; arr2.RemoveAt(0); }
                if (ednoNaUm) { temp += 1; ednoNaUm = false; }

                if (temp > 9) { temp -= 10; ednoNaUm = true; }

                result.Add(temp);
            }
            return result;
        }
}