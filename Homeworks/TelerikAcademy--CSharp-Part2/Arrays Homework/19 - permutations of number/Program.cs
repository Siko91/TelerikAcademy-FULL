using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//  Задачата не работи...

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();

        int num = r.Next(2, 11);

        List<int> nums = new List<int>();

        for (int i = 1; i <= num; i++)
        {
            nums.Add(i);
        }

        List<int> empty = new List<int>();

        Console.WriteLine("Number N = " + num + "\nNumber is generated automaticly.\n\nPermutations:\n");

        GetPermutationList(empty, nums);
        
    }
    static void GetPermutationList(List<int> curentPermutation, List<int> nums)
    {
        if (nums.Count() == 1)
        {
            int temp = nums[0];
            nums.RemoveAt(0);
            curentPermutation.Add(temp);

            Console.Write("[");
            for (int element = 0; element < curentPermutation.Count(); element++)
            {
                Console.Write(curentPermutation[element]);
                if (element < curentPermutation.Count() - 1) Console.Write(",");
            }
            Console.WriteLine("]");

            return;
        }

        for (int i = 0; i < nums.Count(); i++)
        {
            int temp = nums[i];
            nums.RemoveAt(i);
            curentPermutation.Add(temp);

            GetPermutationList(curentPermutation, nums);

            if (nums.Count() > 0) nums.Insert(i, temp);
            else nums.Add(temp);

            curentPermutation.RemoveAt(curentPermutation.Count() - 1);
        }
    }
}
