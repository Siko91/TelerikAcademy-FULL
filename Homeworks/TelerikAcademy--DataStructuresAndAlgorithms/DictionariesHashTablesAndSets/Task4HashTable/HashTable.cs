using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4HashTable
{
    public class HashTable<T, K> : IEnumerable<KeyValuePair<T, K>>, ICollection<KeyValuePair<T, K>>
    {
        public HashTable(int size = 1000)
        {
            this.table = new LinkedList<KeyValuePair<T, K>>[size];
            this.count = 0;
        }

        public int Count
        {
            get { return this.count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public ICollection<T> Keys
        {
            get
            {
                var keys = new HashSet<T>();
                for (int i = 0; i < this.table.Length; i++)
                {
                    foreach (var item in this.table[i])
                    {
                        keys.Add(item.Key);
                    }
                }
                return keys;
            }
        }

        public ICollection<KeyValuePair<T, K>> this[int index]
        {
            get
            {
                return this.table[index];
            }
        }

        public void Add(KeyValuePair<T, K> item)
        {
            int index = item.Key.GetHashCode() % this.table.Length;
            if (table[index] == null)
            {
                table[index] = new LinkedList<KeyValuePair<T, K>>();
            }
            this.table[index].AddLast(item);
            this.count++;
        }

        public void Add(T key, K item)
        {
            this.Add(new KeyValuePair<T, K>(key, item));
        }

        public void Clear()
        {
            var newTable = new HashTable<T, K>(this.table.Length);
            this.Table = newTable.Table;
            this.count = 0;
        }

        public bool Contains(KeyValuePair<T, K> item)
        {
            int index = item.Key.GetHashCode() % this.table.Length;
            LinkedList<KeyValuePair<T, K>> list = this.table[index];
            foreach (KeyValuePair<T, K> currentItem in list)
            {
                if (currentItem.Value.Equals(item.Value) && currentItem.Key.Equals(item.Key))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Copies to an array. WARNING - the HashTable has no order, so the array index will be
        /// ignored compleatly!
        /// </summary>
        /// <param name="array"> The array. </param>
        /// <param name="arrayIndex"> Index of the array (Ignored) </param>
        public void CopyTo(KeyValuePair<T, K>[] array, int arrayIndex)
        {
            int counter = 0;
            int len = Math.Min(this.Count(), array.Length);
            foreach (var item in this)
            {
                if (counter >= len)
                {
                    break;
                }

                array[counter] = item;
                counter++;
            }
        }

        public ICollection<KeyValuePair<T, K>> FindAll(T key)
        {
            return this.table[key.GetHashCode() % this.table.Length];
        }

        public IEnumerator<KeyValuePair<T, K>> GetEnumerator()
        {
            for (int i = 0; i < this.table.Length; i++)
            {
                if (this.table[i] != null)
                {
                    foreach (var item in this.table[i])
                    {
                        yield return item;
                    }
                }
            }
        }

        public bool Remove(KeyValuePair<T, K> item)
        {
            bool hasDeletedSomething = false;
            var list = this.table[item.Key.GetHashCode() % this.table.Length];
            while (list.Contains(item))
            {
                hasDeletedSomething = true;
                list.Remove(item);
            }
            return hasDeletedSomething;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int count;

        private LinkedList<KeyValuePair<T, K>>[] table;

        private LinkedList<KeyValuePair<T, K>>[] Table
        {
            get
            {
                return this.table;
            }

            set
            {
                this.table = value;
            }
        }
    }
}