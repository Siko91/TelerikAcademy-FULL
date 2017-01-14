using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework3
{
    public static class ExtensionsForIEnumerableT
    {
        public static double Sum<T>(this IEnumerable<T> data)
        {
            if (data == null)
            { throw new ArgumentException("argument is null"); }

            double sum = 0;
            foreach (var item in data)
            {
                sum += (dynamic)item;
            }
            return sum;
        }
        public static double Product<T>(this IEnumerable<T> data)
        {
            if (data == null)
            { throw new ArgumentException("argument is null"); }

            double prod = 1;
            foreach (var item in data)
            {
                prod *= (dynamic)item;
            }
            return prod;
        }
        public static T Max<T>(this IEnumerable<T> data) where T : IComparable
        {
            if (data == null)
            { throw new ArgumentException("argument is null"); }

            T min = (dynamic)0;
            bool isFirst = true;

            foreach (T item in data)
            {
                if (isFirst)
                {
                    isFirst = false;
                    min = item;
                }
                if (min.CompareTo(item) == -1)
                {
                    min = item;
                }
            }
            return min;
        }
        public static T Min<T>(this IEnumerable<T> data) where T : IComparable
        {
            if (data == null)
            { throw new ArgumentException("argument is null"); }

            T max = (dynamic)0;
            bool isFirst = true;

            foreach (T item in data)
            {
                if (isFirst)
                {
                    isFirst = false;
                    max = item;
                }
                if (max.CompareTo(item) == 1)
                {
                    max = item;
                }
            }
            return max;
        }
        public static double Average<T>(this IEnumerable<T> data)
        {
            if (data == null)
            { throw new ArgumentException("argument is null"); }

            double average = 0;
            foreach (var item in data)
            {
                average += (dynamic)item;
            }
            return average / data.Count();
        }
    }
}
