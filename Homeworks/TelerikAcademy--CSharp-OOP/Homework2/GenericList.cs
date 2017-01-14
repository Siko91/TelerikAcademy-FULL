using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    public class GenericList<T> where T : IComparable
    {
        private int count;
        private int capacity;
        private T[] arr;

        public GenericList()
        {
            this.capacity = 4;
            this.arr = new T[4];
        }
        public GenericList(int capacity)
        {
            this.capacity = capacity;
            this.arr = new T[capacity];
        }

        public int Count
        {
            get { return count; }
        }

        public T this [int index]
        {
            // no need to check for exceptions. They will be thrown anyway.
            get { return this.arr[index]; }
            set { this.arr[index] = value; }
        }

        public void Add(T element)
        {
            if (this.count == this.capacity)
            {
                this.capacity *= 2;
                T[] newArr = new T[capacity];
                for (int i = 0; i < this.count; i++)
                {
                    newArr[i] = this.arr[i];
                }
                this.arr = newArr;

                this.arr[count] = element;
                count++;
            }
            else
            {
                this.arr[count] = element;
                count++;
            }
        }

        public void RemoveAt(int index)
        {
            T[] newArr = new T[capacity];

            for (int i = 0; i < this.count; i++)
            {
                if (i < index)
                {
                    newArr[i] = this.arr[i];
                }
                else if (i > index)
                {
                    newArr[i-1] = this.arr[i];
                }
            }

            this.arr = newArr;
        }

        public void InsertAt(int index, T value)
        {
            GenericList<T> newArr = new GenericList<T>(this.capacity);
            for (int i = 0; i < this.count; i++)
            {
                if (i < index)
                {
                    newArr.Add(this.arr[i]);
                }
                else if (i == index)
                {
                    newArr.Add(value);
                }
                else if (i > index)
                {
                    newArr.Add(this.arr[i - 1]);
                }
            }
            this.arr = newArr.arr;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < count; i++)
            {
                if (this.arr[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Clear()
        {
            this.arr = new T[4];
        }

        static public T Min(GenericList<T> list)
        {
            if (list.Count == 0 || list == null)
	        {
                throw new ArgumentNullException("GenericList<T> list is empty or null");
	        }

            T min = list[0];
            for (int i = 1; i < list.Count; i++)
			{
                if (list[i].CompareTo(min) == -1)
                {
                    min = list[i];
                }
			}
            return min;
        }

        static public T Max(GenericList<T> list)
        {
            if (list.Count == 0 || list == null)
            {
                throw new ArgumentNullException("GenericList<T> list is empty or null");
            }

            T max = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].CompareTo(max) == 1)
                {
                    max = list[i];
                }
            }
            return max;
        }
    }
}
