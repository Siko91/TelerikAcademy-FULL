using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3Exception
{
    class SomeVERYRandomData : IComparable<SomeVERYRandomData>
    {
        public int num;
        public int num2;
        public int num3;

        public SomeVERYRandomData(int a, int b, int c)
        {
            this.num = a;
            this.num2 = b;
            this.num3 = c;
        }

        public int CompareTo(SomeVERYRandomData data)
        {
            int comparement = (this.num - data.num3 + this.num2 * data.num2 + this.num3 - data.num);

            if (comparement > 0)
            {
                return 1;
            }
            else if (comparement < 0)
            {
                return -1;
            }
            else return 0;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TestRangeException<int>(5, 1);
                Console.WriteLine("no exception hire"); // not expected
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            try
            {
                TestRangeException<DateTime>(DateTime.Now, new DateTime(1999, 12, 30));
                Console.WriteLine("no exception hire"); // not expected
            }
            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            try
            {
                TestRangeException<SomeVERYRandomData>(
                    new SomeVERYRandomData(123456, 1, 1256),
                    new SomeVERYRandomData(1, 1, 1)
                    );
                Console.WriteLine("no exception hire"); // not expected
            }
            catch (InvalidRangeException<SomeVERYRandomData> e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        static void TestRangeException<T>(T start, T end) where T : IComparable<T>
        {
            // check if range is valid
            if (start.CompareTo(end) > 0)
            {
                // throw exception if not
                throw new InvalidRangeException<T>(("Range of type <" + typeof(T).ToString() + "> is invalid becouse the start of the range is greater than it's end."), start, end);
            }
        }
    }
}
