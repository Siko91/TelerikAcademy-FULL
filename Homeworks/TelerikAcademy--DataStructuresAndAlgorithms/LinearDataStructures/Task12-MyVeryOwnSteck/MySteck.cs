using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_MyVeryOwnSteck
{
    internal class MySteck<T>
    {
        public MySteck()
        {
            this.Values = new T[1];
            this.IndexOfLast = -1;
        }

        public int Count
        {
            get
            {
                return this.IndexOfLast + 1;
            }
        }

        public T Peek()
        {
            if (this.IndexOfLast >= 0)
            {
                T result = this.Values[this.IndexOfLast];
                return result;
            }
            else
            {
                throw new IndexOutOfRangeException("No element to peek at");
            }
        }

        public T Pop()
        {
            if (this.IndexOfLast >= 0)
            {
                T result = this.Values[this.IndexOfLast];
                this.Values = this.RemoveAt(this.Values, this.IndexOfLast);
                this.IndexOfLast--;
                return result;
            }
            else
            {
                throw new IndexOutOfRangeException("No element to pop");
            }
        }

        public void Push(T item)
        {
            if (this.Count < this.Values.Length)
            {
                this.Values = this.DoubleInSize(this.Values);
            }
            this.IndexOfLast++;
            this.Values[this.IndexOfLast] = item;
        }

        private int IndexOfLast { get; set; }

        private T[] Values { get; set; }

        private T[] DoubleInSize<T>(T[] source)
        {
            T[] dest = new T[source.Length * 2];
            Array.Copy(source, 0, dest, 0, source.Length);
            return dest;
        }

        private T[] RemoveAt<T>(T[] source, int index)
        {
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }
    }
}