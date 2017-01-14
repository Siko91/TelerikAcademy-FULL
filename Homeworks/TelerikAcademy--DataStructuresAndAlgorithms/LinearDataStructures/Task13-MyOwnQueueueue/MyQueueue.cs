using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13_MyOwnQueueueue
{
    internal class MyQueueue<T>
    {
        public int Count
        {
            get
            {
                int result = 0;
                MyQueueItem<T> current = this.Head;
                while (current != null)
                {
                    result++;
                    current = current.NextItem;
                }
                return result;
            }
        }

        public T Dequeue()
        {
            if (this.Head != null)
            {
                T result = this.Head.Value;
                this.Head = this.Head.NextItem;
                return result;
            }
            else
            {
                Console.WriteLine(this.Count);
                throw new ArgumentOutOfRangeException("Queue is empty");
            }
        }

        public void Enqueue(T item)
        {
            MyQueueItem<T> newItem = new MyQueueItem<T>(item);
            if (this.Head == null)
            {
                this.Head = newItem;
                this.Tail = newItem;
            }
            else
            {
                this.Tail.NextItem = newItem;
                this.Tail = this.Tail.NextItem;
            }
        }

        public T Peek()
        {
            if (this.Head != null)
            {
                return this.Head.Value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Queue is empty");
            }
        }

        private MyQueueItem<T> Head { get; set; }

        private MyQueueItem<T> Tail { get; set; }
    }
}