using System;
using System.Linq;
using System.Diagnostics;

namespace DefensivePrograming.Assertions
{
    class AssertionsHomework
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            #region assertions
                // Asserts are not exceptions.
                // Exceptions are expected. 
                // Asserts are not expected.

                Debug.Assert(0 >= startIndex && startIndex < arr.Length,
                    "startIndex of FindMinElementIndex() is out of bounds");

                Debug.Assert(startIndex >= endIndex && endIndex < arr.Length,
                    "endIndex of FindMinElementIndex() is out of bounds");
            #endregion

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }

        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            int result = BinarySearch(arr, value, 0, arr.Length - 1);

            #region assertions
            // Asserts are not exceptions.
            // Exceptions are expected. 
            // Asserts are not expected.

            Debug.Assert(
                (0 >= result && result < arr.Length)
                || (result == -1),
                "Result of BinarySearch() is out of bounds");
            #endregion

            return result;
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }
                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}