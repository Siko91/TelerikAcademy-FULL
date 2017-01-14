using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static List<int> Multiply(List<int> arr, int num)
    {
        List<int> result = new List<int>();

        int current = 0, leftForNext = 0, leftFromBefore = 0;

        while (arr.Count() > 0)
        {
            leftFromBefore = leftForNext;
            leftForNext = 0;

            if (leftFromBefore > 10)
            {
                leftForNext = leftFromBefore / 10;
                leftFromBefore %= 10;
            }

            current = (arr[0] * num) + leftFromBefore;
            arr.RemoveAt(0);

            leftForNext += current / 10;
            current = current % 10;

            result.Add(current);
        }

        if (leftForNext != 0)
        {
            while (leftForNext > 0)
            {
                result.Add(leftForNext%10);
                leftForNext /= 10;
            }
        }

        return result;
    }

    static void FindAndPrintEnFacts(int num)
    {
        List<int> curentFact = new List<int>();
        curentFact.Add(1);

        for (int i = 1; i <= num; i++)
        {
            curentFact = Multiply(curentFact, i);

            string str = "";
            for (int y = curentFact.Count() - 1; y >= 0; y--)
			{
			    str += curentFact[y].ToString();
			}

            Console.WriteLine(">>>{0,4}! = {1}", i, str);
        }
    }

    static void Main(string[] args)
    {
        int num = 100;

        FindAndPrintEnFacts(num);
    }
}
