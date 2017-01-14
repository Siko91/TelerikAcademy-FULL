using System;
using System.Linq;

namespace DefensivePrograming.Assertions
{
    public class AssertionTest
    {
        public static void RunTest()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            AssertionsHomework.SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            AssertionsHomework.SelectionSort(new int[0]); // Test sorting empty array
            AssertionsHomework.SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(AssertionsHomework.BinarySearch(arr, -1000));
            Console.WriteLine(AssertionsHomework.BinarySearch(arr, 0));
            Console.WriteLine(AssertionsHomework.BinarySearch(arr, 17));
            Console.WriteLine(AssertionsHomework.BinarySearch(arr, 10));
            Console.WriteLine(AssertionsHomework.BinarySearch(arr, 1000));
        }
    }
}
