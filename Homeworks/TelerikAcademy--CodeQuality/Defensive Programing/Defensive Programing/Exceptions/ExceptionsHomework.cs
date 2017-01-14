using System;
using System.Collections.Generic;
using System.Text;

namespace DefensivePrograming.Exceptions
{
    class ExceptionsHomework
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("StartIndex of the subsequence can not be negative");
            }
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException("Length of the subsequence can not be zero or negative");
            }
            if (startIndex + count >= arr.Length)
            {
                throw new ArgumentOutOfRangeException("The subsequence goes out of the array bounds");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }
            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (count > str.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid count!");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }
            return result.ToString();
        }

        public static bool CheckPrime(int number)
        {
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}