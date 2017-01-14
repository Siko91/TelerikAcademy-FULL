using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4HashTable;

namespace Task5HashedSet
{
    public class HashedSet<T> : ICollection<T>, IEnumerable<T>
    {
        public HashedSet(int size = 1000)
        {
            this.table = new HashTable<int, T>(size);
        }

        public int Count
        {
            get
            {
                return this.table.Count();
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(T item)
        {
            this.table.Add(item.GetHashCode(), item);
        }

        public void Clear()
        {
            this.table.Clear();
        }

        public bool Contains(T item)
        {
            return this.table.Contains(new KeyValuePair<int, T>(item.GetHashCode(), item));
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var result = new KeyValuePair<int, T>[array.Length];
            this.table.CopyTo(result, arrayIndex);
            array = result.Select(item => item.Value).ToArray();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.table)
            {
                yield return item.Value;
            }
        }

        public bool Remove(T item)
        {
            return this.table.Remove(new KeyValuePair<int, T>(item.GetHashCode(), item));
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private HashTable<int, T> table { get; set; }
    }
}