using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11_MyLinkedList
{
    public class MyLinkedList<T> : IList<T>
    {
        public MyLinkedList()
        {
        }

        public int Count
        {
            get
            {
                int result = 0;
                MyLinkedListItem<T> current = this.Head;
                while (current != null)
                {
                    result++;
                    current = current.NextItem;
                }
                return result;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public T this[int index]
        {
            get
            {
                int currentIndex = 0;
                MyLinkedListItem<T> current = this.Head;
                while (currentIndex != index)
                {
                    currentIndex++;
                    current = current.NextItem;
                }
                return current.Value;
            }

            set
            {
                int currentIndex = 0;
                MyLinkedListItem<T> current = this.Head;
                while (currentIndex != index)
                {
                    currentIndex++;
                    current = current.NextItem;
                }
                current.Value = value;
            }
        }

        public void Add(T item)
        {
            if (this.Head == null)
            {
                this.Head = this.Tail = new MyLinkedListItem<T>(item);
            }
            else
            {
                this.Tail.NextItem = new MyLinkedListItem<T>(item);
                this.Tail.NextItem.PrevItem = this.Tail;
                this.Tail = this.Tail.NextItem;
            }
        }

        public void Clear()
        {
            this.Head = null;
            this.Tail = null;
        }

        public bool Contains(T item)
        {
            int currentIndex = 0;
            MyLinkedListItem<T> current = this.Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                currentIndex++;
                current = current.NextItem;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length - arrayIndex < this.Count)
            {
                throw new ArgumentOutOfRangeException("Not enough space in the array");
            }
            int currentIndex = arrayIndex;
            foreach (T item in this)
            {
                array[currentIndex] = item;
                currentIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentIndex = 0;
            MyLinkedListItem<T> current = this.Head;
            while (current != null)
            {
                yield return current.Value;
                currentIndex++;
                current = current.NextItem;
            }
        }

        public int IndexOf(T item)
        {
            int currentIndex = 0;
            MyLinkedListItem<T> current = this.Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return currentIndex;
                }
                currentIndex++;
                current = current.NextItem;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            int currentIndex = 0;
            MyLinkedListItem<T> current = this.Head;
            while (current != null)
            {
                if (currentIndex == index)
                {
                    var newItem = new MyLinkedListItem<T>(item);

                    current.PrevItem.NextItem = newItem;
                    newItem.PrevItem = current.PrevItem;

                    current.PrevItem = newItem;
                    newItem.NextItem = current;

                    break;
                }
                currentIndex++;
                current = current.NextItem;
            }
        }

        public bool Remove(T item)
        {
            int currentIndex = 0;
            MyLinkedListItem<T> current = this.Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    current.NextItem.PrevItem = current.PrevItem;
                    current.PrevItem.NextItem = current.NextItem;
                    return true;
                }
                currentIndex++;
                current = current.NextItem;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            int currentIndex = 0;
            MyLinkedListItem<T> current = this.Head;
            while (current != null)
            {
                if (currentIndex == index)
                {
                    current.NextItem.PrevItem = current.PrevItem;
                    current.PrevItem.NextItem = current.NextItem;
                }
                currentIndex++;
                current = current.NextItem;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private MyLinkedListItem<T> Head { get; set; }

        private MyLinkedListItem<T> Tail { get; set; }
    }
}