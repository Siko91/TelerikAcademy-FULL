using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task1PriorityQueue
{
    internal class PriorityQueue<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        public PriorityQueue()
        {
            this.queue = new BinaryHeap<T>();
        }

        public int Count
        {
            get { return this.queue.Count; }
        }

        public T Dequeue()
        {
            return this.queue.Remove();
        }

        public void Enqueue(T element)
        {
            this.queue.Add(element);
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (this.queue.Count() > 0)
            {
                yield return this.queue.Remove();
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private readonly BinaryHeap<T> queue;
    }
}